using System.Collections.Generic;

namespace CompanyCam.Models
{
    public class PhotoFilter
    {
        public int? per_page { get; set; }
        public int? page { get; set; }
        public string Status { get; set; }
        public int? start_date { get; set; }
        public int? end_date { get; set; }
        public List<string> user_ids { get; set; }
        public List<string> group_ids { get; set; }
        public List<string> project_ids { get; set; }
        public List<string> tag_ids { get; set; }
    }
}
