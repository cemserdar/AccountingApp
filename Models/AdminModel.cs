
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace accountingWebSite.Models
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public List<InformationModel> Information { get; set; }
        public List<CustomerModel> CustomerModels { get; set; }
        public string SgkInformation { get; set; }
        public string GibInformation { get; set; }
        public string ResmiGazete { get; set; }
        public string TurMob { get; set; }
    }


}