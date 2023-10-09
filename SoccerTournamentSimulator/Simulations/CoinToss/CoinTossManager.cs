using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.CoinToss
{
    /// <summary>
    /// Manages the coin toss.
    /// </summary>
    public class CoinTossManager : ICoinTossManager
    {
        private readonly Random random = new Random();
        
        /// <summary>
        /// Tosses coin to determine whether it favors the home or the away team.
        /// </summary>
        /// <returns>Whether it favors the home or the away team.</returns>
        public TeamStatus TossCoin() => (TeamStatus)random.Next(2);
    }
}