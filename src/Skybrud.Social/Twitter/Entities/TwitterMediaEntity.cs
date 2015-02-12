using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterMediaEntity : TwitterBaseEntity {

        #region Properties

        public long Id { get; private set; }
        
        public string IdStr { get; private set; }
        
        public string MediaUrl { get; private set; }
        
        public string MediaUrlHttps { get; private set; }
        
        public string Url { get; private set; }
        
        public string DisplayUrl { get; private set; }
        
        public string ExpandedUrl { get; private set; }
        
        public string Type { get; private set; }

        #endregion

        #region Constructors

        private TwitterMediaEntity() { }

        #endregion

        #region Static methods

        public static TwitterMediaEntity Parse(JsonObject entity) {
            return new TwitterMediaEntity {
                Id = entity.GetInt64("id"),
                IdStr = entity.GetString("id_str"),
                StartIndex = entity.GetArray("indices").GetInt32(0),
                EndIndex = entity.GetArray("indices").GetInt32(1),
                MediaUrl = entity.GetString("media_url"),
                MediaUrlHttps = entity.GetString("media_url_https"),
                Url = entity.GetString("url"),
                DisplayUrl = entity.GetString("display_url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                Type = entity.GetString("type")
            };
        }

        #endregion

    }

}