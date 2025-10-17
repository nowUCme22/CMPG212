using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class EvidenceService
    {
        private static SQLiteAsyncConnection _database;
        //connect and create new if not exists
        public static async Task Init()
        {
            if (_database != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(path);
            await _database.CreateTableAsync<CaseEvidence>();
        }

        //add new evidence
        public static async Task AddEvidence(CaseEvidence evidence)
        {
            await Init();
            await _database.InsertAsync(evidence);
        }

        //get all evidence for spesific case id
        public static async Task<List<CaseEvidence>> GetEvidenceByCaseId(int caseId)
        {
            await Init();
            return await _database.Table<CaseEvidence>()
                                  .Where(e => e.CaseID == caseId)
                                  .OrderBy(e => e.DateCollected)
                                  .ToListAsync();
        }

        //delete evidence
        public static async Task DeleteEvidence(CaseEvidence evidence)
        {
            await Init();
            await _database.DeleteAsync(evidence);
        }



    }
}
