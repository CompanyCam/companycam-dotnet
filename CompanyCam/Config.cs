using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Services;

namespace CompanyCam
{
    public static class Config
    {
        public static string ApiKey { get; set; }
        public static string UserEmailAddress { get; set; }

        /// <summary>
        /// Sets a static CompanyCam API key
        /// </summary>
        /// <param name="apiKey"></param>
        public static void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Sets a static User Email - required by API
        /// </summary>
        /// <param name="userEmail"></param>
        public static void SetUserEmail(string userEmail)
        {
            UserEmailAddress = userEmail;
        }
    }
}
