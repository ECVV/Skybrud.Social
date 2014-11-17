using System;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPhoto : SocialJsonObject {

        public long Id { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Picture { get; private set; }
        public string Source { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public FacebookImage[] Images { get; private set; }

        /// <summary>
        /// Gets the place the photo was taken. It is possible to upload photos to Facebook without
        /// specifying a place, and in such cases the property will be <code>NULL</code>.
        /// </summary>
        public FacebookPlace Place { get; private set; }

        #region Constructors

        private FacebookPhoto(JsonObject obj) : base(obj) { }

        #endregion

        public FacebookImage GetImageGreaterThanOrEqualTo(int width, int height) {
            return Images.Reverse().FirstOrDefault(x => x.Width >= width && x.Height != height);
        }

        public static FacebookPhoto Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPhoto(obj) {
                Id = obj.GetInt64("id"),
                Width = obj.GetInt32("width"),
                Height = obj.GetInt32("height"),
                Picture = obj.GetString("picture"),
                Source = obj.GetString("source"),
                Place = obj.GetObject("place", FacebookPlace.Parse),
                Created = obj.GetDateTime("created_time"),
                Updated = obj.GetDateTime("updated_time"),
                Images = obj.GetArray("images", FacebookImage.Parse)
            };
        }
    
    }

}
