namespace accountingWebSite.Models
{
    public class GibDuyuruModel
    {
        public int GibId { get; set; }
        public List<string> GibTitle { get; set; }
        public List<string> GibLink { get; set; }
        public List<string> GibDate { get; set; }

        public GibDuyuruModel()
        {
            GibTitle = new List<string>(); 
            GibLink = new List<string>(); 
            GibDate = new List<string>(); 
        }
    }
}
