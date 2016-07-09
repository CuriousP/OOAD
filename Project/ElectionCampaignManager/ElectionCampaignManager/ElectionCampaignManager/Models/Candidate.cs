using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class Candidate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }

        
        public virtual ICollection<Proposition> Propositions { get; set; }
    }
}