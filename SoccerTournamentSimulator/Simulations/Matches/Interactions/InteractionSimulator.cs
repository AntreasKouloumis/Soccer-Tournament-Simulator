namespace SoccerTournamentSimulator.Simulations.Matches.Interactions
{
    /// <summary>
    /// Simulates interactions between two players in the context of a match.
    /// </summary>
    public class InteractionSimulator
    {
        private Random random;

        public InteractionSimulator(Random random)
        {
            this.random = random;
        }

        /// <summary>
        /// Simulates an interaction based on the probability of success of an action and a reaction.
        /// </summary>
        /// <param name="actionSuccess">Probability of success of an action.</param>
        /// <param name="reactionSuccess">Probability of success of a reaction.</param>
        /// <returns>Whether the action was successful or not during the interaction.</returns>
        public bool SimulateInteraction(double actionSuccess, double reactionSuccess)
            => SimulateInteraction(actionSuccess, reactionSuccess, out _);

        /// <summary>
        /// Simulates an interaction based on the probability of success of an action and a reaction.
        /// </summary>
        /// <param name="actionSuccess">Probability of success of an action.</param>
        /// <param name="reactionSuccess">Probability of success of a reaction.</param>
        /// <param name="interactionOutcome">Specific outcome of interaction.</param>
        /// <returns>Whether the action was successful or not during the interaction.</returns>
        public bool SimulateInteraction(double actionSuccess, double reactionSuccess,
            out InteractionOutcome interactionOutcome)
        {
            double reactionFailure = 1 - reactionSuccess;
            double actionUnimpededSuccess = actionSuccess * reactionFailure;

            double randomNumber = random.NextDouble();

            if (randomNumber <= reactionSuccess)
            {
                interactionOutcome = InteractionOutcome.ReactionSuccess;
                return false;
            }

            if (randomNumber <= reactionSuccess + actionUnimpededSuccess)
            {
                interactionOutcome = InteractionOutcome.ActionUnimpededSuccess;
                return true;
            }

            interactionOutcome = InteractionOutcome.ActionFailure;
            return false;
        }
    }
}