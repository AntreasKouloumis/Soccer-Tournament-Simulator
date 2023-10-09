using SoccerTournamentSimulator.Simulations.Matches.Scores;

namespace SoccerTournamentSimulator.Simulations.Tournaments
{
    /// <summary>
    /// Tournament bracket printer interface.
    /// </summary>
    public interface ITournamentBracketPrinter
    {
        /// <summary>
        /// Prints a tournament bracket in the console.
        /// </summary>
        /// <param name="tournamentScore">Tournament score with which to print the tournament bracket.</param>
        void PrintTournamentBracket(TournamentScore tournamentScore);
    }
}