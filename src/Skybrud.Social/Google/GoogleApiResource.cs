using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    public class GoogleApiResource : GoogleApiObject {
        
        // TODO: "Kind" and "ETag" should be private rather than protected

        public string Kind { get; protected set; }
        public string ETag { get; protected set; }

        protected GoogleApiResource(JsonObject obj) : base(obj) {
            Kind = obj.GetString("kind");
            ETag = obj.GetString("etag");
        }

    }

}
