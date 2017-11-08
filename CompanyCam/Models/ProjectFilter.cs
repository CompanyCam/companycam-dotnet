namespace CompanyCam.Models
{
    public class ProjectFilter

    {
        public int? PerPage { get; set; }
        public int? Page { get; set; }
        public string Status { get; set; }
        public string Query { get; set; }
    }
}
