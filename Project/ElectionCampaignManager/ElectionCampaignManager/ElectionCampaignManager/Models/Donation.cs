using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public System.DateTime Donation_Date { get; set; }
        public int VoterId { get; set; }
        public int Amount { get; set; }

        public virtual Voter Voter { get; set; }
    }
}