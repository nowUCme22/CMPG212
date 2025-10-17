using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class CaseEntryService
    {
        private static SQLiteAsyncConnection _database;
        //connect database
        public static async Task Init()
        {
            if (_database != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(path);
            await _database.CreateTableAsync<CaseEntry>();
        }

        //method to add an entry
        public static async Task AddEntry(CaseEntry entry)
        {
            await Init();
            await _database.InsertAsync(entry);
        }

        //method to get the entry for spesific case id
        public static async Task<List<CaseEntry>> GetEntriesByCaseId(int caseId)
        {
            await Init();
            return await _database.Table<CaseEntry>()
                                  .Where(e => e.CaseID == caseId)
                                  .OrderBy(e => e.Date)
                                  .ToListAsync();
        }

        //method to get all the entries
        public static async Task<List<CaseEntry>> GetAllEntries()
        {
            await Init();
            return await _database.Table<CaseEntry>().ToListAsync();
        }

        //method to delte an entry
        public static async Task DeleteEntry(CaseEntry entry)
        {
            await Init();
            await _database.DeleteAsync(entry);
        }



    }
}
