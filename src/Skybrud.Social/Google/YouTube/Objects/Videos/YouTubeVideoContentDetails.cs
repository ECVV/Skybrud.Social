﻿using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {
    
    public class YouTubeVideoContentDetails : GoogleApiObject {

        #region Properties
        
        public string Duration { get; private set; }
        public string Dimension { get; private set; }
        public string Definition { get; private set; }
        public string Caption { get; private set; }
        public bool IsLicensedContent { get; private set; }

        #endregion
        
        #region Constructors

        private YouTubeVideoContentDetails() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubeVideoContentDetails</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubeVideoContentDetails LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoContentDetails</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubeVideoContentDetails ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoContentDetails</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubeVideoContentDetails Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;
            
            // Initialize and return the object
            return new YouTubeVideoContentDetails {
                JsonObject = obj,
                Duration = obj.GetString("duration"),
                Dimension = obj.GetString("dimension"),
                Definition = obj.GetString("definition"),
                Caption = obj.GetString("caption"),
                IsLicensedContent = obj.GetBoolean("licensedContent")
            };

        }

        #endregion

    }

}