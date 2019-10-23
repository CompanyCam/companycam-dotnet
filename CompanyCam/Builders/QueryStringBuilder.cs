using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

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
                             select p;

            var sb = new StringBuilder();
            var prependAmp=false;
            foreach (var prop in properties)
            {
                if (prependAmp)
                {
                    sb.Append("&");
                }
                else
                {
                    prependAmp=true;
                }

                if (prop.GetCustomAttributes(typeof(JsonPropertyAttribute),false).FirstOrDefault() is JsonPropertyAttribute jsonProps)
                {
                    sb.Append(jsonProps.PropertyName);

                }
                else
                {
                    sb.Append(prop.Name);
                }

                sb.Append($"={HttpUtility.UrlEncode(prop.GetValue(obj).ToString())}");

            }
            

            return sb.ToString();
        }

    }
}