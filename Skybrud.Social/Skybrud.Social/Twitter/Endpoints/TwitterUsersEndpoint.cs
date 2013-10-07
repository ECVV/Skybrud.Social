﻿using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterUsersEndpoint {

        protected TwitterService Service;

        internal TwitterUsersEndpoint(TwitterService service) {
            Service = service;
        }

        public TwitterUser Show(long userId) {
            return TwitterUser.ParseJson(Service.Client.Users.GetUser(userId, false));
        }

        public TwitterUser Show(long userId, bool includeEntities) {
            return TwitterUser.ParseJson(Service.Client.Users.GetUser(userId, includeEntities));
        }

        public TwitterUser Show(string screenName) {
            return TwitterUser.ParseJson(Service.Client.Users.GetUser(screenName, false));
        }

        public TwitterUser Show(string screenName, bool includeEntities) {
            return TwitterUser.ParseJson(Service.Client.Users.GetUser(screenName, includeEntities));
        }

    }

}
