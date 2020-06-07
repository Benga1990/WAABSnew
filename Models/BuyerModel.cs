using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class BuyerModel
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime JoinDate { get; set; }
        public bool InProcess { get; set; }
        [Required]
        public SellerModel Seller { get; set; }
    }
}