using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class Donor
    {
        public int? ID { get; set; }
        public int Donor_Tin { get; set; }
        public string Large_Donor { get; set; }    
        
        public virtual ICollection<Voter> Voters { get; set; }
    }
}