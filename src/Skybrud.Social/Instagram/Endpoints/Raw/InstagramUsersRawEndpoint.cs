using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Users;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        public SocialHttpResponse GetUser(string identifier) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/");
        }

        /// <summary>
        /// Gets the most recent media published by the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetRecentMedia(string identifier) {
            return GetRecentMedia(identifier, new InstagramUserRecentMediaOptions());
        }

        /// <summary>
        /// Gets the most recent media published by the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetRecentMedia(string identifier, int count) {
            return GetRecentMedia(identifier, new InstagramUserRecentMediaOptions {
                Count = count
            });
        }

        /// <summary>
        /// Gets the most recent media published by the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetRecentMedia(string identifier, InstagramUserRecentMediaOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/media/recent/", options);
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetLikedMedia() {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/self/media/liked");
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetLikedMedia(int count) {
            return GetLikedMedia(new InstagramUserLikedMediaOptions {
                Count = count
            });
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetLikedMedia(InstagramUserLikedMediaOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/self/media/liked", options);
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public SocialHttpResponse Search(string query) {
            return Search(new InstagramUserSearchOptions {
                Query = query
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public SocialHttpResponse Search(string query, int count) {
            return Search(new InstagramUserSearchOptions {
                Query = query,
                Count = count
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse Search(InstagramUserSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/search", options);
        }

        #endregion

    }

}