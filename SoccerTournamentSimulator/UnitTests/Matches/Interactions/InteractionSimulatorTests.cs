using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches.Interactions;

namespace SoccerTournamentSimulator.UnitTests.Matches.Interactions
{
    // Custom controlled random class
    public class ControlledRandom : Random
    {
        private readonly double nextDoubleValue;

        public ControlledRandom(double nextDoubleValue)
        {
            this.nextDoubleValue = nextDoubleValue;
        }

        public override double NextDouble()
        {
            return nextDoubleValue;
        }
    }
    
    [TestClass]
    public class InteractionSimulatorTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeMatchInteractionsCountWithinRange()
        {
            // Arrange: Controlled random value.
            InteractionSimulator simulator = 
                new InteractionSimulator(new ControlledRandom(600));

            // Act
            
            // Assert
            Assert.IsTrue(simulator.MatchHalfInteractionsCount >= simulator.MinimumInteractionsCount);
            Assert.IsTrue(simulator.MatchHalfInteractionsCount <= simulator.MaximumInteractionsCount);
        }

        [TestMethod]
        public void SimulateInteraction_ShouldReturnFalseForReactionSuccess()
        {
            // Arrange: Controlled random value.
            ControlledRandom controlledRandom = new ControlledRandom(0.6);
            InteractionSimulator simulator = new InteractionSimulator(controlledRandom);
            const double actionSuccess = 0.5; // 50% success
            const double reactionSuccess = 0.7; // 70% success

            // Act
            bool result = simulator.SimulateInteraction(actionSuccess, reactionSuccess);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SimulateInteraction_ShouldReturnTrueForActionUnimpededSuccess()
        {
            // Arrange: Controlled random value.
            ControlledRandom controlledRandom = new ControlledRandom(0.4); 
            InteractionSimulator simulator = new InteractionSimulator(controlledRandom);
            const double actionSuccess = 0.7; // 70% success
            const double reactionSuccess = 0.3; // 30% success

            // Act
            bool result = simulator.SimulateInteraction(actionSuccess, reactionSuccess);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SimulateInteraction_ShouldSetInteractionOutcomeForActionFailure()
        {
            // Arrange: Controlled random value.
            ControlledRandom controlledRandom = new ControlledRandom(0.7);
            InteractionSimulator simulator = new InteractionSimulator(controlledRandom);
            const double actionSuccess = 0.2; // 20% success
            const double reactionSuccess = 0.6; // 60% success

            // Act
            bool result = simulator.SimulateInteraction(actionSuccess, reactionSuccess, 
                out InteractionOutcome outcome);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(InteractionOutcome.ActionFailure, outcome);
        }
    }
}

