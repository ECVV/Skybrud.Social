﻿using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw {
            get { return Service.Client.Statuses; }
        }

        #endregion

        #region Constructor(s)

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Alias of GetStatusMessage(). Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessage GetTweet(long statusId, TwitterStatusMessageOptions options = null) {
            return GetStatusMessage(statusId, options);
        }

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessage GetStatusMessage(long statusId, TwitterStatusMessageOptions options = null) {
            return TwitterStatusMessage.ParseJson(Raw.GetStatusMessage(statusId, options));
        }

        public TwitterUserTimeline UserTimeline(long userId, int count) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(userId, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(long userId, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(userId, options));
        }

        public TwitterUserTimeline UserTimeline(string screenName, int count) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(screenName, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(string screenName, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(screenName, options));
        }

        #endregion

    }

}
