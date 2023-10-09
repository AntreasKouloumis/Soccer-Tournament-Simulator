namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Match score event arguments.
    /// </summary>
    public class MatchScoreEventArgs : EventArgs
    {
        public MatchScore MatchScore { get; }

        public MatchScoreEventArgs(MatchScore matchScore)
        {
            MatchScore = matchScore;
        }
    }
}