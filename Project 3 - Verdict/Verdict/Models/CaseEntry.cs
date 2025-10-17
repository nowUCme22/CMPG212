using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VerdictProject3.Models
{
    public class CaseEntry
    {
        [PrimaryKey, AutoIncrement]
        public int EntryID { get; set; }
        //case id
        public int CaseID { get; set; }
        //date of entry
        public DateTime Date { get; set; }
        //type of entry
        // Interview, Evidence, ens.
        public string EntryType { get; set; } 
        //short summary of entry
        public string Summary { get; set; }
        //important details of entry
        public string Details { get; set; }
    }
}
