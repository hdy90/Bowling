using Bowling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class CalculationsTests
    {
        [TestMethod]
        public void AllSumsAreCorrect()
        {
            PlayerResults playerResults = new PlayerResults();
            playerResults.Throws.AddRange(new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 });
            Assert.IsTrue(playerResults.Sum == 30);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9 });
            Assert.IsTrue(playerResults.Sum == 190);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 9 });
            Assert.IsTrue(playerResults.Sum == 118);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 });
            Assert.IsTrue(playerResults.Sum == 80);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.IsTrue(playerResults.Sum == 131);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 1, 9, 0, 7, 9, 0, 8, 0, 7, 3, 7, 1, 7, 0, 9, 0, 6, 4, 1, 1 });
            Assert.IsTrue(playerResults.Sum == 88);

            playerResults.Throws.Clear();
            playerResults.Throws.AddRange(new List<int> { 10, 9, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.IsTrue(playerResults.Sum == 268);
        }
    }
}
