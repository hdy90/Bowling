using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Bowling.Model;

namespace Bowling.Service
{
    public static class ImportService
    {
        /// <summary>
        /// Try to import data from file, needs empty list and path to file
        /// </summary>
        /// <param name="bowlingList"></param>
        /// <param name="filePath"></param>
        public static void ImportData(List<PlayerResults> bowlingList, string filePath)
        {
            if (!CanContinue(filePath))
                return;

            try
            {
                Start(filePath, bowlingList);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private static void Start(string filePath, List<PlayerResults> bowlingList)
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
                    bowlingList.Add(new PlayerResults());
                    tmpPlayer = bowlingList.Last();
                    tmpPlayer.PlayerName = line;

                    newPlayer = !newPlayer;
                } else
                {
                    var results = line.Split(", ").Select(int.Parse).ToList();
                    tmpPlayer.ResultsInRounds.AddRange(results);

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
