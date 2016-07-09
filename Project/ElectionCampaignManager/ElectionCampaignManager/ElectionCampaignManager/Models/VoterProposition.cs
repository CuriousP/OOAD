using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class VoterProposition
    {
        public int VoterPropositionId { get; set; }
        public int VoterId { get; set; }
        public int PropositionId { get; set; }

        public virtual Voter Voter { get; set; }
        public virtual Proposition Proposition { get; set; }
    }
}