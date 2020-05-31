using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class SellerModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime JoinDate { get; set; }
        public bool InProcess { get; set; }
    }
}