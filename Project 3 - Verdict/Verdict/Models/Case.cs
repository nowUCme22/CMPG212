using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VerdictProject3.Models
{
    public class Case
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //case id to identify case
        public string CaseIdentifier { get; set; }
        //policae badge number 
        public string AgentBadge { get; set; }
        //case description
        public string Description { get; set; }
        //date case is created
        public DateTime DateCreated { get; set; }
        //see if case is closed or still open
        public bool IsClosed { get; set; } = false;
        //date case id closed
        public DateTime? DateClosed { get; set; }
    }
}
