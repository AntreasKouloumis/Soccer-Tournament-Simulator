using SoccerTournamentSimulator.Simulations.Matches.Scores;

namespace SoccerTournamentSimulator.Simulations.Tournaments
{
    /// <summary>
    /// Prints the tournament bracket formulated in a readable table in the console.
    /// </summary>
    public class TournamentBracketPrinter : ITournamentBracketPrinter
    {
        public void PrintTournamentBracket(TournamentScore tournamentScore)
        {
            List<List<MatchScore>> matchScores = tournamentScore.GetTournamentMatchScores();

            for (int i = 0; i < matchScores.Count; i++)
            {
                Console.WriteLine("_______________________________________________________________");
                Console.WriteLine($"|                           Round {i + 1, -2}                          |");
                Console.WriteLine("_______________________________________________________________");
                Console.WriteLine($"|          Home          |   Score   |          Away          |");
                Console.WriteLine("_______________________________________________________________");
                for (int j = 0; j < matchScores[i].Count; j++)
                {
                    Console.WriteLine($"|  {matchScores[i][j].Pairing.Item1.Name, 20}  " +
                                      $"|  {matchScores[i][j].HomeTeamScore, 2} " +
                                      $"- {matchScores[i][j].AwayTeamScore, -2}  " +
                                      $"|  {matchScores[i][j].Pairing.Item1.Name, -20}  |");
                }
                Console.WriteLine("_______________________________________________________________");
                Console.WriteLine();
            }
            
            
        }
    }
}