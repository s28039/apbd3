using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Nowak", 200},
                {"Wiśniewski", 20000},
                {"Wójcik", 10000},
                {"Kaczmarek", 3000},
                {"Mazur", 1000}

            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        internal int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
                return _database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }
    }
}