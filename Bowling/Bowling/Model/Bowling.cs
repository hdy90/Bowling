using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class PlayerResults
    {
        public string PlayerName { get; set; }
        public IEnumerable<int> ResultsInRounds { get; set; }
        public int Sum { get; set; }
        public PlayerResults()
        {
            ResultsInRounds = new List<int>();
        }

    }        
}
