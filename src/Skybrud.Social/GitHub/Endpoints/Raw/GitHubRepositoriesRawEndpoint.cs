using System;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    public class GitHubRepositoriesRawEndpoint {

        #region Properties

        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public string GetContents(string owner, string repository, string path) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(
                Client.GenerateAbsoluteUrl(String.Format("/repos/{0}/{1}/contents/{2}", owner, repository, path))
            );
        }

        public SocialHttpResponse GetRepositories() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/repos");
        }

        public SocialHttpResponse GetRespositories(string username) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/users/" + username + "/repos");
        }

        #endregion

    }

}
