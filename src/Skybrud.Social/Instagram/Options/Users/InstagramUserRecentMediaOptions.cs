﻿using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Users {
    
    /// <summary>
    /// http://instagram.com/developer/endpoints/users/#get_users_media_recent
    /// </summary>
    public class InstagramUserRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public DateTime? MaxTimestamp { get; set; }

        /// <summary>
        /// Only media after this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public DateTime? MinTimestamp { get; set; }

        /// <summary>
        /// Only media after this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MinId { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MaxId { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxTimestamp != null) qs.Add("max_timestamp", SocialUtils.GetUnixTimeFromDateTime(MaxTimestamp.Value));
            if (MinTimestamp != null) qs.Add("min_timestamp", SocialUtils.GetUnixTimeFromDateTime(MinTimestamp.Value));
            if (MinId != null) qs.Add("min_id", MinId);
            if (MaxId != null) qs.Add("max_id", MaxId);
            return qs;
        }

        #endregion

    }

}