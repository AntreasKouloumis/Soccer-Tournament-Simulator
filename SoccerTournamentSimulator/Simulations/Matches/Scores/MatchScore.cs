using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Score resulting from a match between two teams.
    /// </summary>
    public class MatchScore
    {
        public Tuple<IdData, IdData> Pairing { get; private set; }
        
        public int HomeTeamScore { get; private set; }

        public int AwayTeamScore { get; private set; }

        public MatchOutcome HomeTeamMatchOutcome
        {
            get => DetermineMatchOutcome(HomeTeamScore, AwayTeamScore);
        }

        public MatchOutcome AwayTeamMatchOutcome
        {
            get => DetermineMatchOutcome(AwayTeamScore, HomeTeamScore);
        }

        private MatchOutcome DetermineMatchOutcome(int teamScore, int opposingTeamScore)
        {
            int scoreDifference = teamScore - opposingTeamScore;

            return scoreDifference switch
            {
                < 0 => MatchOutcome.Loss,
                0 => MatchOutcome.Draw,
                _ => MatchOutcome.Win
            };
        }

        public MatchScore(Tuple<IdData, IdData> pairing)
        {
            Pairing = pairing;
        }
        
        /// <summary>
        /// Increments team score using the id.
        /// </summary>
        /// <param name="id">Id of the team whose score to increment.</param>
        /// <returns>Incremented score. Negative value means neither team id matched.</returns>
        public int IncrementTeamScoreById(int id)
        {
            if (id == Pairing.Item1.Id)
                return IncrementHomeTeamScore();
            if (id == Pairing.Item2.Id)
                return IncrementAwayTeamScore();
            return -1;
        }

        public int IncrementHomeTeamScore() => IncrementTeamScoreByStatus(TeamStatus.Home);
        
        public int IncrementAwayTeamScore() => IncrementTeamScoreByStatus(TeamStatus.Away); 

        public int IncrementTeamScoreByStatus(TeamStatus teamStatus)
            => teamStatus == TeamStatus.Home ? ++HomeTeamScore : ++AwayTeamScore;

        /// <summary>
        /// Gets team score using team id.
        /// </summary>
        /// <param name="id">Id of team whose score to return.</param>
        /// <returns>Team score. Negative value means neither team id matched.</returns>
        public int GetTeamScoreById(int id)
        {
            if (id == Pairing.Item1.Id)
                return HomeTeamScore;
            if (id == Pairing.Item2.Id)
                return AwayTeamScore;
            return -1;
        }
        
        /// <summary>
        /// Gets opposing team score using team id.
        /// </summary>
        /// <param name="id">Id of team whose opposing team's score to return.</param>
        /// <returns>Opposing team score. Negative value means neither team id matched.</returns>
        public int GetOpposingTeamScoreById(int id)
        {
            if (id == Pairing.Item1.Id)
                return AwayTeamScore;
            if (id == Pairing.Item2.Id)
                return HomeTeamScore;
            return -1;
        }

        /// <summary>
        /// Gets team match outcome using team id.
        /// </summary>
        /// <param name="id">Id of team whose match outcome to return.</param>
        /// <returns>Team match outcome. If the id matches neither team ids,
        /// the home team match outcome is returned.</returns>
        public MatchOutcome GetTeamMatchOutcomeById(int id)
        {
            return id == Pairing.Item2.Id ? AwayTeamMatchOutcome : HomeTeamMatchOutcome;
        }
    }
}