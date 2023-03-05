using System;
using System.Collections.ObjectModel;
using System.Linq;
using Bowling.Model;

namespace Bowling.Service
{
    public static class ImportService
    {
        /// <summary>
        /// Try to import data from file, needs empty list and path to file
        /// </summary>
        /// <param name="playerResults"></param>
        /// <param name="filePath"></param>
        public static bool ImportData(ObservableCollection<PlayerResults> playerResults, string filePath)
        {
            playerResults.Clear();
            if (!CanContinue(filePath))
                return false;

            try
            {
                Start(filePath, playerResults);
                return true;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private static void Start(string filePath, ObservableCollection<PlayerResults> playerResults)
        {
            string[] data = System.IO.File.ReadAllLines(filePath);
            bool newPlayer = true;
            if (data.Length == 0)
                return;

            var tmpPlayer = new PlayerResults();
            foreach (string line in data)
            {
                if (newPlayer)
                {
                    playerResults.Add(new PlayerResults());
                    tmpPlayer = playerResults.Last();
                    tmpPlayer.PlayerName = line;

                    newPlayer = !newPlayer;
                } else
                {
                    var results = line.Split(", ").Select(int.Parse).ToList();
                    tmpPlayer.Throws.AddRange(results);

                    newPlayer = !newPlayer;
                }
            }
        }

        private static bool CanContinue(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            if (!System.IO.File.Exists(filePath))
                return false;

            return true;
        }
    }
}
