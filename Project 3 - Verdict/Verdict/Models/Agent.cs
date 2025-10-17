using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VerdictProject3.Models
{
    public class Agent
    {
        //Automated id
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //name of agent (consists of name and surname)
        [MaxLength(100)]
        public string Name { get; set; }

        //police badge number
        [MaxLength(20)]
        public string PoliceNumber { get; set; }

        //password
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
