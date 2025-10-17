//using CloudKit;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class CaseService
    {
        private static SQLiteAsyncConnection _database;
        //connect
        public static async Task Init()
        {
            if (_database != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(path);
            await _database.CreateTableAsync<Case>();
        }

        //add a new case
        public static async Task AddCase(Case newCase)
        {
            await Init();
            await _database.InsertAsync(newCase);
        }

        //update an case
        public static async Task UpdateCase(Case UpdatedCase)
        {
            await Init();
            await _database.UpdateAsync(UpdatedCase);
        }

        //get all the cases
        public static async Task<List<Case>> GetAllCases()
        {
            await Init();
            return await _database.Table<Case>().ToListAsync();
        }

        //delete a case
        public static async Task DeleteCase(Case caseToDelete)
        {
            await Init();
            await _database.DeleteAsync(caseToDelete);
        }

        //delete a case with all of the related entries and data
        public static async Task DeleteCaseAndRelatedData(int caseId)
        {
            await Init();

            // delete case entries
            var entries = await CaseEntryService.GetEntriesByCaseId(caseId);
            foreach (var entry in entries)
            {
                await CaseEntryService.DeleteEntry(entry);
            }

            // delete case evidence
            var evidenceList = await EvidenceService.GetEvidenceByCaseId(caseId);
            foreach (var evidence in evidenceList)
            {
                await EvidenceService.DeleteEvidence(evidence);
            }

            // delete case suspects
            var suspects = await SuspectService.GetSuspectsByCaseId(caseId);
            foreach (var suspect in suspects)
            {
                await SuspectService.DeleteSuspect(suspect);
            }

            // delete the case itself
            var caseToDelete = await _database.Table<Case>().FirstOrDefaultAsync(c => c.ID == caseId);
            if (caseToDelete != null)
            {
                await _database.DeleteAsync(caseToDelete);
            }
        }

        //update the badge number for a case
        public static async Task UpdateBadgeNumberForCases(string oldBadge, string newBadge)
        {
            await Init();
            var cases = await _database.Table<Case>()
                                       .Where(c => c.AgentBadge == oldBadge)
                                       .ToListAsync();

            foreach (var c in cases)
            {
                c.AgentBadge = newBadge;
                await _database.UpdateAsync(c);
            }
        }

        //get specific case according to badge number
        public static async Task<List<Case>> GetCasesByAgentBadge(string policeNumber)
        {
            await Init();
            return await _database.Table<Case>()
                                  .Where(c => c.AgentBadge == policeNumber)
                                  .ToListAsync();
        }




    }
}
