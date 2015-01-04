using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    public class InstagramUsersRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about a user by the specified ID.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        public SocialHttpResponse GetUser(string identifier) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/");
        }
        
        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetRecentMedia(string identifier, InstagramMediaSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/media/recent/", options);
        }

        // TODO: Implement /users/self/media/liked

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        public SocialHttpResponse Search(string query, int count = 0) {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Add("q", query);

            // Optional
            if (count > 0) qs.Add("count", count);

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/search", qs);

        }

        #endregion

    }

}
