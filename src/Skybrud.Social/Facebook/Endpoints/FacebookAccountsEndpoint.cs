using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookAccountsEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookAccountsRawEndpoint Raw {
            get { return Service.Client.Accounts; }
        }

        #endregion

        #region Constructors

        internal FacebookAccountsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <code>/me/accounts</code>
        /// method. This call requires a user access token.
        /// </summary>
        public FacebookResponse<FacebookAccountsCollection> GetAccounts() {
            return FacebookHelpers.ParseResponse(Raw.GetAccounts(), FacebookAccountsCollection.Parse);
        }

        #endregion

    }

}
