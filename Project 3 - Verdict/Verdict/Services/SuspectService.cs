using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class SuspectService
    {
        private static SQLiteAsyncConnection _database;
        //connect and create
        public static async Task Init()
        {
            if (_database != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(path);
            await _database.CreateTableAsync<Suspect>();
        }

        //add new suspect
        public static async Task AddSuspect(Suspect suspect)
        {
            await Init();
            await _database.InsertAsync(suspect);
        }

        //get the suspects for specific case id
        public static async Task<List<Suspect>> GetSuspectsByCaseId(int caseId)
        {
            await Init();
            return await _database.Table<Suspect>()
                                  .Where(s => s.CaseID == caseId)
                                  .OrderBy(s => s.Name)
                                  .ToListAsync();
        }

        //update suspects 
        public static async Task UpdateSuspect(Suspect suspect)
        {
            await Init(); // Ensure DB is ready
            await _database.UpdateAsync(suspect);
        }

        //get all the suspects
        public static async Task<List<Suspect>> GetAllSuspects()
        {
            await Init();
            return await _database.Table<Suspect>().ToListAsync();
        }

        //delete suspects
        public static async Task DeleteSuspect(Suspect suspect)
        {
            await Init();
            await _database.DeleteAsync(suspect);
        }


    }
}
