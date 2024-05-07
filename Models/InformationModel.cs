using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accountingWebSite.Models
{
    public class InformationModel
    {
        public int InformationId { get; set; }
        //public List<string> Title { get; set; }
        //public List<string> Link { get; set; }
        //public int Role { get; set; }
        //public List<DateTime> Date { get; set; }
        //public string Image { get; set; }
        public SgkDuyuruModel SgkDuyuruModel { get; set; }
        public GibDuyuruModel gibDuyuruModel { get; set; }
    }

}