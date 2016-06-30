﻿using Skybrud.Social.Http;
using Skybrud.Social.OAuth.Objects;

namespace Skybrud.Social.OAuth.Responses {
    
    /// <summary>
    /// Class representing the response of a call to get an OAuth 1.0a refresh token.
    /// </summary>
    public class SocialOAuthRequestTokenResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the response body.
        /// </summary>
        public SocialOAuthRequestToken Body { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <code>response</code> and <code>body</code>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        /// <param name="body">The object representing the response body.</param>
        protected SocialOAuthRequestTokenResponse(SocialHttpResponse response, SocialOAuthRequestToken body) : base(response) {
            Body = body;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <code>response</code> and <code>body</code>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        /// <param name="body">The object representing the response body.</param>
        /// <returns>Returns an instance of <see cref="SocialOAuthRequestTokenResponse"/>.</returns>
        public static SocialOAuthRequestTokenResponse ParseResponse(SocialHttpResponse response, SocialOAuthRequestToken body) {
            return response == null ? null : new SocialOAuthRequestTokenResponse(response, body);
        }

        #endregion

    }

}