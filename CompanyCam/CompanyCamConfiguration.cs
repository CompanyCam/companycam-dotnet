using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Services;

namespace CompanyCam
{
    public static class CompanyCamConfiguration
    {
        private static string _apiKey { get; set; }
        private static string _userEmailAddress { get; set; }

        /// <summary>
        /// Sets a static CompanyCam API key
        /// </summary>
        /// <param name="apiKey"></param>
        public static void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Sets a static User Email - required by API
        /// </summary>
        /// <param name="userEmail"></param>
        public static void SetUserEmail(string userEmail)
        {
            _userEmailAddress = userEmail;
        }

        internal static string GetApiKey()
        {
            return _apiKey;
        }

        internal static string GetUserEmail()
        {
            return _userEmailAddress;
        }
    }
}
