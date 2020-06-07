using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class EstateAgentModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual ICollection<BuyerModel> BuyerClients { get; set; }
        public virtual ICollection<SellerModel> SellerClients { get; set; }
        public virtual ICollection<JobModel> Jobs { get; set; }
    }
}