using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Manages the score of a tournament comprising out of a number of teams.
    /// </summary>
    public class TournamentScoreManager
    {
        public TournamentScore TournamentScore { get; private set; }

        public TournamentScoreManager()
        {
        }

        public TournamentScoreManager(List<List<Tuple<IdData, IdData>>> pairings)
        {
            InitializeTournamentScore(pairings);
        }

        public void InitializeTournamentScore(List<List<Tuple<IdData, IdData>>> pairings)
        {
            TournamentScore = new TournamentScore(pairings);
        }

        public void AddMatchScore(MatchScore matchScore)
        {
            TournamentScore.AddMatchScore(matchScore);
        }
    }
}