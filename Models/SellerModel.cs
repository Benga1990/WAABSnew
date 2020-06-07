using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class SellerModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime JoinDate { get; set; }
        public bool InProcess { get; set; }
        public BuyerModel Buyer { get; set; }
    }
}