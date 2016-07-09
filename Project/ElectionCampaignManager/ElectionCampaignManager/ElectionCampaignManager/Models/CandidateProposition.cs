using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class CandidateProposition
    {
        public int CandidatePropositionId { get; set; }
        public int CandidateId { get; set;}
        public int PropositionId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Proposition Proposition { get; set; }
    }
}