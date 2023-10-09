namespace SoccerTournamentSimulator.Simulations.Matches.Interactions
{
    /// <summary>
    /// Simulates interactions between two players in the context of a match.
    /// <br></br> <i>In an average soccer match, both teams tally about 1,239 interactions
    /// (1,100 passes, 30 shots, 30 interceptions, 30 dribbles, 40 tackles, 9 saves).
    /// In half a match that comes out to about 620.</i>
    /// </summary>
    public class InteractionSimulator
    {
        /// <summary>Lower end of number of interactions per half a match.</summary>
        public int MinimumInteractionsCount { get ; private set; }

        /// <summary>Higher end of number of interactions per half a match.</summary>
        public int MaximumInteractionsCount { get ; private set; }

        /// <summary>Number of interactions per half a match.</summary>
        public int MatchHalfInteractionsCount { get; private set; }

        /// <summary>Number of interactions per match.</summary>
        public int MatchInteractionsCount { get; private set; }

        private Random random;

        public InteractionSimulator(Random random)
        {
            this.random = random;
            MinimumInteractionsCount = 500;
            MaximumInteractionsCount = 750;
            MatchHalfInteractionsCount = random.Next(MinimumInteractionsCount, MaximumInteractionsCount + 1);
            MatchInteractionsCount = MatchHalfInteractionsCount * 2;
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