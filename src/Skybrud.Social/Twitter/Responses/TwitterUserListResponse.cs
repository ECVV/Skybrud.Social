using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {
    
    public class TwitterUserListResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        public TwitterUser[] Users { get; private set; }

        public long NextCursor { get; private set; }

        public long PreviousCursor { get; private set; }

        #endregion

        #region Constructor(s)

        private TwitterUserListResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        public static TwitterUserListResponse ParseJson(string contents) {

            // Deserialize the JSON
            JsonObject json = JsonConverter.ParseObject(contents);

            // Can there be multiple errors? Need. More. Data.
            if (json.HasValue("errors")) {
                JsonArray errors = json.GetArray("errors");
                throw new TwitterDeprecatedException(
                    errors.GetObject(0).GetInt32("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the JSON object
            return Parse(json);

        }

        public static TwitterUserListResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterUserListResponse {
                JsonObject = obj,
                Users = obj.GetArray("users", TwitterUser.Parse),
                NextCursor = obj.GetInt64("next_cursor"),
                PreviousCursor = obj.GetInt64("previous_cursor")
            };
        }

        #endregion
    
    }

}
