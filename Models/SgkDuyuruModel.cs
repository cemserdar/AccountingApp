namespace accountingWebSite.Models
{
    
    public class SgkDuyuruModel
    {
       

        public int Id { get; set; }
        public List<string>? Baslik { get; set; }
        public SgkDuyuruModel()
        {
            Baslik = new List<string>(); // Initialize the Baslik property in the constructor
        }
    }
}
