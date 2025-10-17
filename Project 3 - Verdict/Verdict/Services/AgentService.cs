using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class AgentService
    {
        private static SQLiteAsyncConnection _database;

        //connect database
        public static async Task Init()
        {
            if (_database != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(path);
            await _database.CreateTableAsync<Agent>();
        }
       
        //method to get all the agents
        public static async Task<List<Agent>> GetAllAgents()
        {
            await Init();
            return await _database.Table<Agent>().ToListAsync();
        }


        //method to add a agent (singup page)
        public static async Task AddAgent(Agent agent)
        {
            await Init();
            await _database.InsertAsync(agent);
        }

        //method to update agents details
        public static async Task UpdateAgent(Agent agent)
        {
            await Init();
            await _database.UpdateAsync(agent);
        }

        //method to delete an agent
        public static async Task DeleteAgent(Agent agent)
        {
            await Init();
            await _database.DeleteAsync(agent);
        }

        //method to get an agent based on their badge number
        public static async Task<Agent> GetAgentByPoliceNumber(string policeNumber)
        {
            await Init();
            return await _database.Table<Agent>()
                .FirstOrDefaultAsync(a => a.PoliceNumber == policeNumber);
        }
    }
}
