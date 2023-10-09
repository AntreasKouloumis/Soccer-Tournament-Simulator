using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Pairings;

namespace SoccerTournamentSimulator.UnitTests.Pairings
{
    [TestClass]
    public class RoundRobinPairingsGeneratorTests
    {
        [TestMethod]
        public void GeneratePairings_EvenNumberOfIds_ReturnsValidPairings()
        {
            // Arrange.
            RoundRobinPairingsGenerator generator = new RoundRobinPairingsGenerator();
            List<int> ids = new List<int> { 1, 2, 3, 4 };

            // Act.
            List<List<Tuple<int, int>>> pairings = generator.GeneratePairings(ids);

            // Assert.
            Assert.IsNotNull(pairings);
            
            // Each round has one less pairing.
            Assert.AreEqual(ids.Count - 1, pairings.Count);
            foreach (List<Tuple<int, int>> roundPairs in pairings)
            {
                // Each round has half the number of pairings.
                Assert.AreEqual(ids.Count / 2, roundPairs.Count);
                foreach (Tuple<int, int> pair in roundPairs)
                {
                    Assert.IsTrue(ids.Contains(pair.Item1));
                    Assert.IsTrue(ids.Contains(pair.Item2));
                    
                    // Ensure each pairing is different.
                    Assert.AreNotEqual(pair.Item1, pair.Item2);
                }
            }
        }

        [TestMethod]
        public void GeneratePairings_OddNumberOfIds_ReturnsValidPairings()
        {
            // Arrange
            RoundRobinPairingsGenerator generator = new RoundRobinPairingsGenerator();
            List<int> ids = new List<int> { 1, 2, 3 };

            // Act
            List<List<Tuple<int, int>>> pairings = generator.GeneratePairings(ids);

            // Assert
            Assert.IsNotNull(pairings);
            
            // Each round has one less pairing.
            Assert.AreEqual(ids.Count - 1, pairings.Count);
            foreach (List<Tuple<int, int>> roundPairs in pairings)
            {
                // Each round has half the number of pairings minus the dummy.
                Assert.AreEqual(ids.Count / 2 - 1, roundPairs.Count);
                foreach (Tuple<int, int> pair in roundPairs)
                {
                    Assert.IsTrue(ids.Contains(pair.Item1));
                    Assert.IsTrue(ids.Contains(pair.Item2));
                    
                    // Ensure each pairing is different.
                    Assert.AreNotEqual(pair.Item1, pair.Item2);
                }
            }
        }
    }
}