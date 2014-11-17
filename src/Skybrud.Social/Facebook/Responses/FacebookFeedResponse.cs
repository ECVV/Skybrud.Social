using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookFeedResponse : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Array of feed entries.
        /// </summary>
        public FacebookFeedEntry[] Data { get; private set; }

        /// <summary>
        /// Gets relevant information for paging purposes. This may be <var>NULL</var> in some cases.
        /// </summary>
        public FacebookPaging Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookFeedResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>FacebookFeedResponse</var> from the
        /// JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookFeedResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>FacebookFeedResponse</var> from the
        /// specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookFeedResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>FacebookFeedResponse</var> from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookFeedResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);
            return new FacebookFeedResponse(obj) {
                Data = obj.GetArray("data", FacebookFeedEntry.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion

    }

}
