using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VerdictProject3;
using VerdictProject3.Models;

namespace VerdictProject3.Services
{
    public class DatabaseService
    {
        private static SQLiteAsyncConnection _database;

        //method to create database if not exists
        public static async Task Init()
        {

            //see if the database exists
            if (_database != null)
            {
                return;
            }

            //create database if not exists
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "verdict.db");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<Agent>();

        }

        //method to add an agent
        public static async Task AddAgent(string name, string badge, string password)
        {
            //input the new agents name, number and password
            await Init();

            var agent = new Agent
            {
                Name = name,
                PoliceNumber = badge,
                Password = password
            };

            await _database.InsertAsync(agent);
        }

        //method to login validation
        public static async Task<Agent> getAgentByInfo(string badge, string password)
        {
            await Init();

            //see if the badge(police) number and password matches the users input
            var agent = await _database.Table<Agent>()
                .Where(a => a.PoliceNumber == badge && a.Password == password)
                .FirstOrDefaultAsync();

            return agent;   
        }

        //get user by badge number for forgotten password
        public static async Task<Agent> GetAgentByBadge(string badge)
        {
            await Init();
            return await _database.Table<Agent>()
                .Where(a => a.PoliceNumber == badge)
                .FirstOrDefaultAsync();
        }

        //get all the agents
        public static async Task<List<Agent>> getAllAgents()
        {
            await Init();
            return await _database.Table<Agent>().ToListAsync();
        }
    }
}
