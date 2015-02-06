using System;
using Skybrud.Social.Twitter.Endpoints;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter {

    public class TwitterService {

        public TwitterOAuthClient Client { get; private set; }

        public TwitterAccountEndpoint Account { get; private set; }
        public TwitterFollowersEndpoint Followers { get; private set; }
        public TwitterFriendsEndpoint Friends { get; private set; }
        public TwitterGeoEndpoint Geo { get; private set; }
        public TwitterSearchEndpoint Search { get; private set; }
        public TwitterStatusesEndpoint Statuses { get; private set; }
        public TwitterUsersEndpoint Users { get; private set; }

        private TwitterService() {
            // make constructor private
        }

        public static TwitterService CreateFromOAuthClient(TwitterOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            TwitterService service = new TwitterService {
                Client = client
            };

            // Set the endpoints etc.
            service.Account = new TwitterAccountEndpoint(service);
            service.Followers = new TwitterFollowersEndpoint(service);
            service.Friends = new TwitterFriendsEndpoint(service);
            service.Geo = new TwitterGeoEndpoint(service);
            service.Search = new TwitterSearchEndpoint(service);
            service.Statuses = new TwitterStatusesEndpoint(service);
            service.Users = new TwitterUsersEndpoint(service);

            // Return the service
            return service;

        }

    }

}
