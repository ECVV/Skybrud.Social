﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Skybrud.Social.Http.PostData;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Class representing the POST data of a HTTP request.
    /// </summary>
    public class SocialPostData {

        #region Private fields

        private readonly Dictionary<string, ISocialPostValue> _data = new Dictionary<string, ISocialPostValue>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of POST data entries.
        /// </summary>
        public int Count {
            get { return _data.Count; }
        }

        /// <summary>
        /// Gets keys of all POST data entiries.
        /// </summary>
        public Dictionary<string, ISocialPostValue>.KeyCollection Keys {
            get { return _data.Keys; }
        }

        /// <summary>
        /// Gets values of all POST data entiries.
        /// </summary>
        public Dictionary<string, ISocialPostValue>.ValueCollection Values {
            get { return _data.Values; }
        }

        /// <summary>
        /// Gets or sets the string value of the item with the specified <code>key</code>code>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <returns>Returns the <see cref="String"/> value of the item, or <code>null</code> if not found.</returns>
        public string this[string key] {
            get {
                ISocialPostValue value;
                return _data.TryGetValue(key, out value) ? value.ToString() : null;
            }
            set { _data[key] = new SocialPostValue(key, value); }
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the POST data contains an entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>Returns <code>true</code> if the POST data contains an entry with the specified <code>key</code>,
        /// otherwise <code>false</code>.</returns>
        public bool ContainsKey(string key) {
            return _data.ContainsKey(key);
        }

        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, string value) {
            _data.Add(key, new SocialPostValue(key, value));
        }
        
        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object value) {
            _data.Add(key, new SocialPostValue(key, String.Format(CultureInfo.InvariantCulture, "{0}", value)));
        }

        /// <summary>
        /// Adds a file entry with the specified <code>key</code> and <code>path</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        public void AddFile(string key, string path) {
            _data.Add(key, new SocialPostFileValue(key, path));
        }

        /// <summary>
        /// Adds a file entry with the specified <code>key</code>, <code>path</code>, <code>contentType</code> and
        /// <code>filename</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The filename of the file.</param>
        public void AddFile(string key, string path, string contentType, string filename) {
            _data.Add(key, new SocialPostFileValue(key, path, contentType, filename));
        }

        /// <summary>
        /// Sets the value of the entry with specified <code>key</code>. If an entry with <code>key</code> already
        /// exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, string value) {
            _data[key] = new SocialPostValue(key, value);
        }

        /// <summary>
        /// Removes the entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        public void Remove(string key) {
            _data.Remove(key);
        }

        /// <summary>
        /// Gets whether the value with the specified key is an instance of <see cref="SocialPostFileValue"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns <code>true</code> if the item with the specified <code>key</code> is an instance of
        /// <see cref="SocialPostFileValue"/>, otherwise <code>false</code>.</returns>
        public bool IsFile(string key) {
            ISocialPostValue value;
            return _data.TryGetValue(key, out value) && value is SocialPostFileValue;
        }

        internal static void Write(Stream stream, string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes the multipart POST data to the specified <code>stream</code>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="boundary">The multipart boundary.</param>
        public void WriteMultipartFormData(Stream stream, string boundary) {
            int i = 0;
            foreach (ISocialPostValue value in _data.Values) {
                value.WriteToMultipartStream(stream, boundary, "\n", i++ == _data.Count - 1);
            }
        }

        /// <summary>
        /// Gets a string representation of the POST data.
        /// </summary>
        /// <returns>Returns the POST data as an URL encoded string.</returns>
        public override string ToString() {
            return String.Join("&", _data.Select(pair => SocialUtils.Strings.UrlEncode(pair.Key) + "=" + SocialUtils.Strings.UrlEncode(pair.Value.ToString())));
        }

        /// <summary>
        /// Converts the POST data into an instance of <see cref="NameValueCollection"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="NameValueCollection"/> representing the POST data.</returns>
        public virtual NameValueCollection ToNameValueCollection() {
            NameValueCollection nvc = new NameValueCollection();
            foreach (var pair in _data) {
                nvc.Add(pair.Key, String.Format(CultureInfo.InvariantCulture, "{0}", pair.Value));
            }
            return nvc;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="nvc">An instance of <see cref="NameValueCollection"/> representing the POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialPostData"/> based on the specified <code>nvc</code>.</returns>
        public static implicit operator SocialPostData(NameValueCollection nvc) {
            SocialPostData data = new SocialPostData();
            foreach (string key in nvc.Keys) {
                data.Add(key, nvc[key]);
            }
            return data;
        }

        #endregion

    }

}