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
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine("|  Position  |         Team         |  GP  |  W   |  D   |  L   |  GF  |  GA  |  GD  | Pts  |");
            Console.WriteLine("_____________________________________________________________________________________________");

            List<TeamStats> teamStats = leaderboard.TeamStats;
            for (int i = 0; i < teamStats.Count; i++)
            {
                Console.WriteLine($"|     {i + 1}.     " +
                                  $"| {teamStats[i].IdData.Name, -20} " +
                                  $"|  {teamStats[i].gamesPlayed, -2}  " +
                                  $"|  {teamStats[i].wins, -2}  " +
                                  $"|  {teamStats[i].draws, -2}  " +
                                  $"|  {teamStats[i].losses, -2}  " +
                                  $"|  {teamStats[i].goalsFor, -2}  " +
                                  $"|  {teamStats[i].goalsAgainst, -2}  " +
                                  $"|  {teamStats[i].goalDifference, -2}  " +
                                  $"|  {teamStats[i].points, -2}  |");
            }

            Console.WriteLine("_____________________________________________________________________________________________");
        }
    }
}