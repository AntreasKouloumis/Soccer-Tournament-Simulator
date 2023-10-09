using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Manages the score of a match between two teams.
    /// </summary>
    public class MatchScoreManager
    {
        public MatchScore MatchScore { get; private set; }

        public MatchScoreManager()
        {
        }

        public MatchScoreManager(Tuple<IdData, IdData> pairing)
        {
            SetPairing(pairing);
        }

        public void SetPairing(Tuple<IdData, IdData> pairing)
        {
            MatchScore = new MatchScore(pairing);
        }

        /// <summary>
        /// Increments team score using the id.
        /// </summary>
        /// <param name="id">Id of the team whose score to increment.</param>
        /// <returns>Incremented score. Negative value means neither team id matched.</returns>
        public int IncrementTeamScoreById(int id)
        {
            return MatchScore.IncrementTeamScoreById(id);
        }
    }
}