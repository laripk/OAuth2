using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using OAuth2.Configuration;
using OAuth2.Infrastructure;
using OAuth2.Models;

namespace OAuth2.Client.Impl {
    /// <summary>
    /// Fitbit authentication (and usage) client.
    /// </summary>
    public class FitbitClient : OAuth2Client {

        /// <summary>
        /// Initializes a new instance of the <see cref="FitbitClient"/> class.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="configuration"></param>
        public FitbitClient(IRequestFactory factory, IClientConfiguration configuration)
            : base(factory, configuration) { }


        /// <summary>
        /// Friendly name of provider (OAuth2 service).
        /// </summary>
        public override string Name {
            get { return "Fitbit"; }
        }


        /// <summary>
        /// Defines URI of service which issues access code.
        /// </summary>
        protected override Endpoint AccessCodeServiceEndpoint {
            get {
                return new Endpoint {
                    BaseUri = "https://www.fitbit.com",
                    Resource = "/oauth2/authorize"
                };
            }
        }

        /// <summary>
        /// Defines URI of service which issues access token.
        /// </summary>
        protected override Endpoint AccessTokenServiceEndpoint {
            get {
                return new Endpoint {
                    BaseUri = "https://api.fitbit.com",
                    Resource = "/oauth2/token"
                };
            }
        }

        /// <summary>
        /// Defines URI of service which allows to obtain information about user which is currently logged in.
        /// </summary>
        protected override Endpoint UserInfoServiceEndpoint {
            get {
                return new Endpoint {
                    BaseUri = "https://api.fitbit.com",
                    Resource = "/1/user/-/profile.json"
                };
            }
        }

        /// <summary>
        /// Should return parsed <see cref="UserInfo"/> from content received from third-party service.
        /// </summary>
        /// <param name="content">The content which is received from third-party service.</param>
        protected override UserInfo ParseUserInfo(string content) {
            var cnt = JObject.Parse(content);
            var names = (cnt["fullName"].SafeGet(x => x.Value<string>()) ?? string.Empty).Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new UserInfo {
                Id = cnt["encodedId"].SafeGet(x => x.Value<string>()),
                Email = string.Empty, //not documented to come back
                ProviderName = this.Name,
                FirstName = names.Count > 0 ? names.First() : cnt["displayName"].Value<string>(),
                LastName = names.Count > 1 ? names.Last() : string.Empty,
                AvatarUri = {
                    Small = string.Empty,
                    Normal = cnt["avatar"].SafeGet(x => x.Value<string>()),
                    Large = string.Empty
                }
            };
            return result;
        }
    }
}