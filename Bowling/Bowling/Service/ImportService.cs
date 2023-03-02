using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Bowling.Model;

namespace Bowling.Service
{
    public static class ImportService
    {

        public static void ImportData(List<PlayerResults> bowlingList, string filePath)
        {
            if (!CanContinue(filePath))
                return;

            Start(filePath, bowlingList);
        }

        private static void Start(string filePath, List<PlayerResults> bowlingList)
        {
            string[] data = System.IO.File.ReadAllLines(filePath);
            bool newLine = true;
            if (data.Length == 0)
                return;

            var tmpPlayer = new PlayerResults();
            foreach (string line in data)
            {
                if (newLine)
                {
                    bowlingList.Add(new PlayerResults());
                    tmpPlayer = bowlingList.Last();
                    tmpPlayer.PlayerName = line;

                    newLine = !newLine;
                } else
                {
                    var results = line.Split(", ").Select(int.Parse).ToList();
                    tmpPlayer.ResultsInRounds.AddRange(results);
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
