using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VerdictProject3.Models
{
    public class CaseEvidence
    {
        [PrimaryKey, AutoIncrement]
        public int EvidenceID { get; set; }

        //case id
        public int CaseID { get; set; }
        //date the evidence was collected
        public DateTime DateCollected { get; set; }
        //type of evidence
        public string Type { get; set; }
        //short description of the evidence
        public string Description { get; set; }
        //suspect name and surname if there is one (optional)
        public string SuspectLinked { get; set; }
        //file path string (optional)
        public string FilePath { get; set; } 
    }
}
