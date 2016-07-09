using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class Proposition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        
        public virtual ICollection<Voter> Voters { get; set; }
    }
}