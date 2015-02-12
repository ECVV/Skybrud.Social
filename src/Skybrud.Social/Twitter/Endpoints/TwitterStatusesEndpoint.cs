using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw {
            get { return Service.Client.Statuses; }
        }

        #endregion

        #region Constructors

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessageResponse GetStatusMessage(long statusId) {
            return GetStatusMessage(statusId, null);
        }

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessageResponse GetStatusMessage(long statusId, TwitterStatusMessageOptions options) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.GetStatusMessage(statusId, options));
        }

        public TwitterTimeline GetUserTimeline(long userId, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, new TwitterTimelineOptions(count)).Body);
        }

        public TwitterTimeline GetUserTimeline(long userId, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, options).Body);
        }

        public TwitterTimeline GetUserTimeline(string screenName, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, new TwitterTimelineOptions(count)).Body);
        }

        public TwitterTimeline GetUserTimeline(string screenName, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, options).Body);
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        public TwitterTimeline GetHomeTimeline() {
            return GetHomeTimeline(null);
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetHomeTimeline(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetHomeTimeline(options).Body);
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating user and the users they follow. 
        /// </summary>
        public TwitterTimeline GetMentionsTimeline() {
            return GetMentionsTimeline(null);
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing a users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetMentionsTimeline(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetMentionsTimeline(options).Body);
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        public TwitterTimeline GetRetweetsOfMe() {
            return GetRetweetsOfMe(null);
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetRetweetsOfMe(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetRetweetsOfMe(options).Body);
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        public TwitterStatusMessageResponse PostStatusMessage(string status) {
            return PostStatusMessage(status, null);
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        public TwitterStatusMessageResponse PostStatusMessage(string status, long? replyTo) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.PostStatusMessage(status, replyTo));
        }

        #endregion

    }

}