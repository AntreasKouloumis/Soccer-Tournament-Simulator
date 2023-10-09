using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Manages the Leaderboard.
    /// </summary>
    public class LeaderboardManager
    {
        public Leaderboard Leaderboard { get; private set; }

        public LeaderboardManager()
        {
        }

        public LeaderboardManager(List<IdData> teamIdData)
        {
            InitializeLeaderboard(teamIdData);
        }

        public void InitializeLeaderboard(List<IdData> teamIdData)
        {
            List<TeamStats> teamStats = new List<TeamStats>();

            for (int i = 0; i < teamIdData.Count; i++)
                teamStats.Add(new TeamStats(teamIdData[i]));

            Leaderboard = new Leaderboard(teamStats);
        }

        /// <summary>
        /// Updates the leaderboard using the score of the tournament.
        /// </summary>
        /// <param name="tournamentScore">Tournament score comprising out of the score of each match,
        /// of each round of the tournament.</param>
        /// <returns>Updated leaderboard.</returns>
        public Leaderboard UpdateLeaderboard(TournamentScore tournamentScore)
        {
            List<List<MatchScore>> matchScores = tournamentScore.GetTournamentMatchScores();
            
            for (int i = 0; i < matchScores.Count; i++)
            {
                for (int j = 0; j < matchScores[i].Count; j++)
                {
                    int homeTeamId = matchScores[i][j].Pairing.Item1.Id;
                    int awayTeamId = matchScores[i][j].Pairing.Item2.Id;
                    
                    TeamStats homeTeamStats = Leaderboard.GetTeamStatsById(homeTeamId);
                    TeamStats awayTeamStats = Leaderboard.GetTeamStatsById(awayTeamId);
                    
                    UpdateTeamStats(homeTeamStats, matchScores[i][j]);
                    UpdateTeamStats(awayTeamStats, matchScores[i][j]);
                }
            }

            Leaderboard.SortByPoints();
            
            return Leaderboard;
        }

        /// <summary>
        /// Updates the team stats based on match score.
        /// </summary>
        /// <param name="teamStats">Team stats to update.</param>
        /// <param name="matchScore">Match score with which to update team stats.</param>
        private void UpdateTeamStats(TeamStats teamStats, MatchScore matchScore)
        {
            int teamId = teamStats.IdData.Id;
            int teamScore = matchScore.GetTeamScoreById(teamId);
            int opposingTeamScore = matchScore.GetOpposingTeamScoreById(teamId);
            MatchOutcome matchOutcome = matchScore.GetTeamMatchOutcomeById(teamId);
            
            teamStats.gamesPlayed++;
            teamStats.goalsFor += teamScore;
            teamStats.goalsAgainst += opposingTeamScore;
            teamStats.goalDifference += teamScore - opposingTeamScore;
            teamStats.points += (int)matchOutcome;
            teamStats.IncrementMatchOutcome(matchOutcome);
        }
    }
}