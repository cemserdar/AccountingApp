using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accountingWebSite.Models
{
    public class InformationModel
    {
        public int InformationId { get; set; }
        public List<string> Title { get; set; }
        public int Role { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }

}