using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class JobModel
    {
        public int ID { get; set;}
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public int BankID { get; set; }
        public int EstateAgentID { get; set; }
        public int SolicitorID { get; set; }
    }
}