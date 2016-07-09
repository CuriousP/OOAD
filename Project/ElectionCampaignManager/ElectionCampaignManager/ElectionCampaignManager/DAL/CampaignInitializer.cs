using System;
using System.Collections.Generic;
using ElectionCampaignManager.Models;

namespace ElectionCampaignManager.DAL
{
    public class CampaignInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CampaignContext>
    {
        protected override void Seed(CampaignContext context)
        {
            var categories = new List<Category>
            {
                new Category { ID=123, Description="Male/ Female" },
                new Category { ID=124, Description="Ethnicity"},
                new Category { ID=125, Description="Poor/ Middle/ Rich " }
            };

            categories.ForEach(c => context.Categorys.Add(c));
            context.SaveChanges();

            var propositions = new List<Proposition>
             {
                 new Proposition { ID=123, Description ="Love all, trust a few, do wrong to none."},
                 new Proposition { ID=124, Description="Better three hours too soon than a minute too late. " },
                 new Proposition { ID=125, Description="We know what we are, but know not what we may be." }
             }; 

             propositions.ForEach(p => context.Propositions.Add(p));
             context.SaveChanges();

            var candidates = new List<Candidate>
            {
                new Candidate {ID=123, Name="John Smith", Party="Democratic"},
                new Candidate {ID=124, Name="James", Party="Republican"},
                new Candidate {ID=125, Name="Neena", Party="Democratic"},
            };

            candidates.ForEach(c => context.Candidates.Add(c));
            context.SaveChanges();

            var candidatePropositions = new List<CandidateProposition>
            {
                new CandidateProposition {CandidateId=123, PropositionId=123 },
                new CandidateProposition {CandidateId=123, PropositionId=124 },
                new CandidateProposition {CandidateId=124, PropositionId=124 },
                new CandidateProposition {CandidateId=124, PropositionId=125 },
                new CandidateProposition {CandidateId=125, PropositionId=123 },
                new CandidateProposition {CandidateId=125, PropositionId=125 }
            };

            candidatePropositions.ForEach(cp => context.CandidatePropositions.Add(cp));
            context.SaveChanges();

            var voters = new List<Voter>
            {
                new Voter {First_Name="Carson", Last_Name="Alexander", Birth_date=DateTime.Parse("1960-11-21"), Family_Status="Married", Home_Address="123 St, California", Party_Affiliation="Democratic", Phone_Number=1234555},
                new Voter {First_Name="Will", Last_Name="Smith", Birth_date=DateTime.Parse("1970-10-21"), Family_Status="Single", Home_Address="153 St, California", Party_Affiliation="Republican", Phone_Number=1235544},
                new Voter {First_Name="Matt", Last_Name="Damon", Birth_date=DateTime.Parse("1972-10-21"), Family_Status="Single", Home_Address="1554 St, California", Party_Affiliation="Democratic", Phone_Number=4235522},
            };

            voters.ForEach(v => context.Voters.Add(v));
            context.SaveChanges();
        }
    }
}