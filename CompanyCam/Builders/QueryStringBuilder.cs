using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CompanyCam.Builders
{
    public class QueryStringBuilder
    {
       
        public static string BuildUrl(string rootApiRoute, object model)
        {
            var url = rootApiRoute;
            var extra = QueryStringBuilder.GetQueryString(model);
            if (extra != null)
            {
                url += "?" + extra;
            }

            return url;
        }

        public static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null && p.Name != "projectId"
                             select p.GetCustomAttribute<Newtonsoft.Json.JsonPropertyAttribute>().PropertyName + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }

    }
}