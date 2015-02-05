using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterAccountEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterAccountRawEndpoint Raw {
            get { return Service.Client.Account; }
        }

        internal TwitterAccountEndpoint(TwitterService service) {
            Service = service;
        }

        /// <summary>
        /// Verify and get information about the user (requires an access token).
        /// </summary>
        public TwitterUser VerifyCredentials() {

            // Make a call to the API
            SocialHttpResponse response = Raw.VerifyCredentials();

            // Check for errors
            if (response.StatusCode != HttpStatusCode.OK) {
                throw TwitterDeprecatedException.Parse(response.Body);
            }

            // Parse the response
            return TwitterUser.ParseJson(response.Body);

        }
    
    }

}