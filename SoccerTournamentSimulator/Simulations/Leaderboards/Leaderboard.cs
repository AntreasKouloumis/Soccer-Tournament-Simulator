namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Leaderboard class.
    /// </summary>
    public class Leaderboard
    {
        public List<TeamStats> TeamStats { get; private set; }

        public Leaderboard(List<TeamStats> teamStats)
        {
            TeamStats = teamStats;
        }

        public void SetLeaderboard(List<TeamStats> teamStats)
        {
            TeamStats = teamStats;
        }

        /// <summary>
        /// Sets a specific entry of team stats.
        /// </summary>
        /// <param name="newTeamStats">New team stats to replace with.</param>
        public void SetTeamStats(TeamStats newTeamStats)
        {
            for (int i = 0; i < TeamStats.Count; i++)
            {
                if (TeamStats[i].IdData.Id != newTeamStats.IdData.Id) continue;
                TeamStats[i] = newTeamStats;
                return;
            }
        }

        /// <summary>
        /// Gets a specific entry of team stats using team id.
        /// </summary>
        /// <param name="id">Id of team whose stats to return.</param>
        /// <returns>Specific entry of team stats.</returns>
        public TeamStats GetTeamStatsById(int id)
        {
            for (int i = 0; i < TeamStats.Count; i++)
                if (TeamStats[i].IdData.Id == id)
                    return TeamStats[i];
            
            return null;
        }
        
        /// <summary>
        /// Sorts the entries of the leaderboard by the team stat points.
        /// </summary>
        public void SortByPoints()
        {
            TeamStats.Sort((team1, team2) => team2.points.CompareTo(team1.points));
        }
    }
}