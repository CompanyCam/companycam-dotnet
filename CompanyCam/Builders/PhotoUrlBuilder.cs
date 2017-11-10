using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CompanyCam.Models;
using static System.String;

namespace CompanyCam.Builders
{
    public class PhotoUrlBuilder
    {
        public string BuildProjectPhotoUrl(ProjectPhotoFilter model)
        {
            var url = $"projects/{model.ProjectId}/photos";
            var extra = QueryStringBuilder.GetQueryString(model);
            if (extra != null)
            {
                url += "?" + extra;
            }

            return url;
        }
    }
}
