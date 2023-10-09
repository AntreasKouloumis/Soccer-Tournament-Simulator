
using SoccerTournamentSimulator.Simulations.Matches;

namespace SoccerTournamentSimulator.Simulations.Players.Actions
{
    /// <summary>
    /// Player actions interface.
    /// </summary>
    public interface IPlayerAction
    {
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <returns>Success probability of the player reaction.</returns>
        float GetPlayerReactionSuccess(Player player);
        
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <param name="playerReaction">Player reaction that interacts with this action.</param>
        /// <returns>Success probability of the player reaction.</returns>
        float GetPlayerReactionSuccess(Player player, out PlayerReaction playerReaction);
        
        /// <summary>
        /// Updates advance score when this player action is performed.
        /// </summary>
        /// <param name="advanceScoreManager">Advance score manager.</param>
        void UpdateAdvanceScore(AdvanceScoreManager advanceScoreManager);
    }
}