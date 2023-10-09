namespace SoccerTournamentSimulator.Simulations.Teams
{
    /// <summary>
    /// Manages the teams.
    /// </summary>
    public class TeamManager
    {
        private Tuple<Team, Team> teams;
        
        public TeamManager(Tuple<Team, Team> teams) 
        {
            this.teams = teams;
        }
        
        /// <summary>
        /// Gets team by Id.
        /// </summary>
        /// <param name="id">Id of team to return.</param>
        /// <returns>Team with specified Id.</returns>
        public Team GetTeamById(int id)
        {
            if (teams.Item1.IdData.Id == id) return teams.Item1;
            return teams.Item2.IdData.Id == id ? teams.Item2 : null;
        }

        /// <summary>
        /// Gets opposing team by Id.
        /// </summary>
        /// <param name="id">Id of team whose opposing team to return.</param>
        /// <returns>Opposing team of team with specifies Id.</returns>
        public Team GetOpposingTeamById(int id)
        {
            if (teams.Item1.IdData.Id == id) return teams.Item2;
            return teams.Item2.IdData.Id == id ? teams.Item1 : null;
        }

        /// <summary>
        /// Gets team of either home or away status.
        /// </summary>
        /// <param name="teamStatus">Status of the team to return.</param>
        /// <returns>Team with specified status.</returns>
        public Team GetTeam(TeamStatus teamStatus) => teamStatus == TeamStatus.Home ? teams.Item1 : teams.Item2;
    }
}