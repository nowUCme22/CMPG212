using System;
using SQLite;

namespace VerdictProject3.Models
{
    public class Suspect
    {
        [PrimaryKey, AutoIncrement]
        public int SuspectID { get; set; }
        //case id
        public int CaseID { get; set; }
        //name of suspect
        public string Name { get; set; }
        //surname of suspect
        public string Surname { get; set; }
        //role of suspect
        // Suspect, Witness, Victim, Guilty
        public string Role { get; set; } 
        //was the suspect arrested
        public bool IsArrested { get; set; } = false;
        //formatting for the name and surname
        [Ignore]
        public string FullName => $"{Name} {Surname}";
    }
}
