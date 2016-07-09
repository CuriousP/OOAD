using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class VoterCategory
    {
        public int VoterCategoryId { get; set; }
        public int VoterId { get; set; }
        public int CategoryId { get; set; }

        public virtual Voter Voter { get; set; }
        public virtual Category Category { get; set; }
    }
}