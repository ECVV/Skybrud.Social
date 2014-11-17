using System;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookLink : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }
        public string Message { get; private set; }
        public string Name { get; private set; }
        public string Link { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        private FacebookLink(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLink LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        public static FacebookLink ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        public static FacebookLink Parse(JsonObject obj) {

            // Return NULL if NULL
            if (obj == null) return null;

            // Some error checking
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);

            // Initialize the link object
            return new FacebookLink(obj) {
                Id = obj.GetString("id"),
                Message = obj.GetString("message"),
                Name = obj.GetString("name"),
                Link = obj.GetString("link"),
                Caption = obj.GetString("caption"),
                Description = obj.GetString("description"),
                CreatedTime = DateTime.Parse(obj.GetString("created_time")),
                UpdatedTime = DateTime.Parse(obj.GetString("updated_time"))
            };

        }

        #endregion

    }

}
