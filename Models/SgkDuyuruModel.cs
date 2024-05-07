namespace accountingWebSite.Models
{
    
    public class SgkDuyuruModel
    {
        public int Id { get; set; }
        public List<string> SgkTitle { get; set; }
        public List<string> SgkLink { get; set; }
        public List<string> SgkDate { get; set; }

        public SgkDuyuruModel()
        {
            SgkTitle = new List<string>();
            SgkLink = new List<string>();
            SgkDate = new List<string>();
        }

        public SgkDuyuruModel(int ıd, List<string> sgkTitle, List<string> sgkLink, List<string> sgkDate)
        {
            Id = ıd;
            SgkTitle = sgkTitle;
            SgkLink = sgkLink;
            SgkDate = sgkDate;
        }
    }
}
