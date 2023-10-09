namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Tournament score event arguments.
    /// </summary>
    public class TournamentScoreEventArgs : EventArgs
    {
        public TournamentScore TournamentScore { get; }

        public TournamentScoreEventArgs(TournamentScore tournamentScore)
        {
            TournamentScore = tournamentScore;
        }
    }
}