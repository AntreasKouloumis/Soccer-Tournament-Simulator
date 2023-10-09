namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Prints the leaderboard formulated in a readable table in the console.
    /// </summary>
    public class LeaderboardPrinter : ILeaderboardPrinter
    {
        /// <summary>
        /// Prints a leaderboard in the console.
        /// </summary>
        /// <param name="leaderboard">Leaderboard to print.</param>
        public void PrintLeaderboard(Leaderboard leaderboard)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| Team              |  GP  |  W   |  D   |  L   |  GF  |  GA  |  GD  | Pts  |");
            Console.WriteLine("------------------------------------------------------------");

            List<TeamStats> teamStats = leaderboard.TeamStats;
            for (int i = 0; i < teamStats.Count; i++)
            {
                Console.WriteLine($"| {teamStats[i].IdData.Name} |  {teamStats[i].gamesPlayed}   " +
                                  $"|  {teamStats[i].wins}   |  {teamStats[i].draws}   " +
                                  $"|  {teamStats[i].losses}   |  {teamStats[i].goalsFor}   " +
                                  $"|  {teamStats[i].goalsAgainst}   |  {teamStats[i].goalDifference}   " +
                                  $"|  {teamStats[i].points}   |");
            }

            Console.WriteLine("------------------------------------------------------------");
        }
    }
}