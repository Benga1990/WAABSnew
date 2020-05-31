using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class EstateAgentModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual ICollection<BuyerModel> BuyerClients { get; set; }
        public virtual ICollection<SellerModel> SellerClients { get; set; }
        public virtual ICollection<JobModel> Jobs { get; set; }
    }
}