using System;
using System.Collections.Specialized;

namespace Skybrud.Social {

    /// <summary>
    /// Varois extension methods used throughout the Skybrud.Social implementation.
    /// </summary>
    public static class SocialExtensions {
        
        /// <summary>
        /// Appends the specified <paramref name="query"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The URI builder.</param>
        /// <param name="query">The query string.</param>
        public static void AppendQueryString(this UriBuilder builder, NameValueCollection query) {
            if (query == null || query.Count == 0) return;
            NameValueCollection nvc = SocialUtils.Misc.ParseQueryString(builder.Query);
            nvc.Add(query);
            builder.Query = SocialUtils.Misc.NameValueCollectionToQueryString(nvc);
        }

        /// <summary>
        /// Merges <paramref name="builder"/> with the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="builder">The URI builder.</param>
        /// <param name="query">The query string.</param>
        /// <returns>Returns the builder.</returns>
        public static UriBuilder MergeQueryString(this UriBuilder builder, NameValueCollection query) {
            if (query == null || query.Count == 0) return builder;
            builder.Query = SocialUtils.Misc.NameValueCollectionToQueryString(SocialUtils.Misc.ParseQueryString(builder.Query).Set(query));
            return builder;
        }
        
        /// <summary>
        /// Merges the values of <paramref name="query"/> into <paramref name="subject"/>.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="query">The query with the new values.</param>
        /// <returns>Returns the subject.</returns>
        public static NameValueCollection Set(this NameValueCollection subject, NameValueCollection query) {
            if (query == null || query.Count == 0) return subject;
            foreach (string key in query.AllKeys) {
                subject.Set(key, query[key]);
            }
            return subject;
        }
    
    }

}