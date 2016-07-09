using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class Voter
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public System.DateTime? Birth_date { get; set; }
        public string Family_Status { get; set; }
        public string Party_Affiliation { get; set; }
        public int? Phone_Number { get; set; }
        public string Home_Address { get; set; }

        
        public virtual ICollection<Donation> Donations { get; set; }
        
        public virtual ICollection<Donor> Donors { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; }
        
        public virtual ICollection<Proposition> Propositions { get; set; }
    }
}