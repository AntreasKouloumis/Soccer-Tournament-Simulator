using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.CoinToss
{
    /// <summary>
    /// Coin toss manager interface.
    /// </summary>
    public interface ICoinTossManager
    {
        TeamStatus TossCoin();
    }
}