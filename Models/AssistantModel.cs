using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAABSnew.Models
{
    public class AssistantModel
    {
        public int Id { get; set; }
        public bool Confrimed { get; set; }
        public string StageDetails { get; set; }
        public bool OtherUserConfirmed { get; set; }
    }
}