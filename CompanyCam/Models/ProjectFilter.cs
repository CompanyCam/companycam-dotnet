using CompanyCam.Objects;

namespace CompanyCam.Models
{
    public class ProjectFilter

    {
        public int? per_page { get; set; }
        public int? page { get; set; }
        public Status status { get; set; }
        public string query { get; set; }
    }
}
