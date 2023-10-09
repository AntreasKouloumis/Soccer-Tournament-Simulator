using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.Matches
{
    /// <summary>
    /// Manages the advance score, which describes the degree to which a team at any given time,
    /// has made an advance with ball possession in pursuit of scoring a goal against the opposing team.
    /// </summary>
    public class AdvanceScoreManager
    {
        /// <summary>
        /// Describes the degree to which a team at any given time,
        /// has made an advance with ball possession in pursuit of scoring
        /// a goal against the opposing team.
        /// </summary>
        private int advanceScore;

        /// <summary>Advance score at the time of the kickoff, which is the middle of the field.</summary>
        private const int KickoffAdvanceScore = 4;

        private const int MaximumAdvanceScore = 9;

        private Dictionary<int, PlayerPosition> advanceBrackets = new Dictionary<int, PlayerPosition>
        {
            { 0, PlayerPosition.GoalKeeper },
            { 1, PlayerPosition.Defender },
            { 2, PlayerPosition.Defender },
            { 3, PlayerPosition.Defender },
            { 4, PlayerPosition.Midfielder },
            { 5, PlayerPosition.Midfielder },
            { 6, PlayerPosition.Midfielder },
            { 7, PlayerPosition.Forward },
            { 8, PlayerPosition.Forward },
            { 9, PlayerPosition.Forward },
        };

        public int IncrementAdvanceScore() => IncrementAdvanceScore(1);

        public int IncrementAdvanceScore(int amount)
        {
            int newAdvanceAmount = advanceScore + amount;
            if (newAdvanceAmount > MaximumAdvanceScore)
                return advanceScore = 9;
            return advanceScore += amount;
        }

        /// <summary>
        /// Sets the advance score appropriately for the kickoff.
        /// </summary>
        public int SetAdvanceScoreToKickoff() => advanceScore = KickoffAdvanceScore;

        public int InvertAdvanceScore()
        {
            int invertedAdvanceScore = MaximumAdvanceScore - advanceScore;
            if (invertedAdvanceScore < 0)
                return advanceScore = 0;
            return advanceScore = invertedAdvanceScore;
        }

        public int ResetAdvanceScore() => advanceScore = 0;

        public int GetAdvanceScore() => advanceScore;
        
        public int GetKickoffAdvanceScore() => KickoffAdvanceScore;
        
        public int GetMaximumAdvanceScore() => MaximumAdvanceScore;

        /// <summary>
        /// Gets player position in the context of a team according to the advance score.
        /// </summary>
        /// <returns>Player position in the context of a team.</returns>
        public PlayerPosition GetPlayerPositionAccordingToAdvanceScore() => advanceBrackets[advanceScore];

        /// <summary>
        /// Gets player position in the context of a team according to the advance score
        /// from the perspective of the opposing team.
        /// </summary>
        /// <returns>Player position in the context of a team.</returns>
        public PlayerPosition GetPlayerPositionAccordingToInverseAdvanceScore()
        {
            int invertedAdvanceScore = MaximumAdvanceScore - advanceScore;
            if (invertedAdvanceScore < 0)
                invertedAdvanceScore = 0;
            return advanceBrackets[invertedAdvanceScore];
        }

        /// <summary>
        /// Gets the fraction of the advance score in relation to the maximum advance score.
        /// </summary>
        /// <returns>Fraction of the advance score in relation to the maximum advance score.</returns>
        public float GetAdvanceMultiplier() => (float)advanceScore / (float)MaximumAdvanceScore;
    }
}