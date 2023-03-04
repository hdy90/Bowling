using Bowling.Model;
using Bowling.Service;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class ImportTests
    {
        [TestMethod]
        public void EmptySeedReturnsNoResultsToList()
        {
            ObservableCollection<PlayerResults> bowlingList = new ObservableCollection<PlayerResults>();
            ImportService.ImportData(bowlingList, $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\seed_empty.txt");

            Assert.IsFalse( bowlingList.Any());
        }

        [TestMethod]
        public void SeedReturnsResultsToList()
        {
            ObservableCollection<PlayerResults> bowlingList = new ObservableCollection<PlayerResults>();
            ImportService.ImportData(bowlingList, $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\seed.txt");

            Assert.IsTrue(bowlingList.Count > 0);
        }

        [TestMethod]
        public void BigSeedReturnsResultsToList()
        {
            ObservableCollection<PlayerResults> bowlingList = new ObservableCollection<PlayerResults>();
            ImportService.ImportData(bowlingList, $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\seed_big.txt");

            Assert.IsTrue(bowlingList.Count > 20);
        }
    }
}