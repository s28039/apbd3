using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository
    {
        /// <summary>
        /// This collection is used to simulate remote database
        /// </summary>
        public static readonly Dictionary<int, Client> Database = new Dictionary<int, Client>()
        {
            {1, new Client{ClientId = 1, Name = "Nowak", Address = "Warszawa, Chmielna 10", Email = "nowak@wp.pl", Type = "NormalClient"}},
            {2, new Client{ClientId = 2, Name = "Wiśniewski", Address = "Warszawa, Marszałkowska 22", Email = "wisniewski@gmail.pl", Type = "VeryImportantClient"}},
            {3, new Client{ClientId = 3, Name = "Wójcik", Address = "Warszawa, Puławska 15", Email = "wojcik@gmail.pl", Type = "ImportantClient"}},
            {4, new Client{ClientId = 4, Name = "Kaczmarek", Address = "Warszawa, Wilcza 8", Email = "kaczmarek@gmail.pl", Type = "ImportantClient"}},
            {5, new Client{ClientId = 5, Name = "Mazur", Address = "Warszawa, Zgoda 5", Email = "mazur@wp.pl", Type = "NormalClient"}},
            {6, new Client{ClientId = 6, Name = "Krawczyk", Address = "Warszawa, Grzybowska 6", Email = "krawczyk@wp.pl", Type = "NormalClient"}}

        };
        
        public ClientRepository()
        {
        }

        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        internal Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (Database.ContainsKey(clientId))
                return Database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }
}