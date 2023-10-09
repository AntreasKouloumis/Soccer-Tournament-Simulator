
namespace SoccerTournamentSimulator.Simulations.Players.Actions
{
    /// <summary>
    /// Player action of shoot.
    /// </summary>
    public class ShootPlayerAction : IPlayerAction
    {
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <returns>Success probability of the player reaction.</returns>
        public float GetPlayerReactionSuccess(Player player)
        {
            bool isStealSuccessHigher = player.TackleSuccess > player.SaveSuccess;
            return isStealSuccessHigher ? player.TackleSuccess : player.SaveSuccess;
        }
        
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <param name="playerReaction">Player reaction that interacts with this action.</param>
        /// <returns>Success probability of the player reaction.</returns>
        public float GetPlayerReactionSuccess(Player player, out PlayerReaction playerReaction)
        {
            bool isStealSuccessHigher = player.TackleSuccess > player.SaveSuccess;
            playerReaction = isStealSuccessHigher ? PlayerReaction.Tackle : PlayerReaction.Save;
            return isStealSuccessHigher ? player.TackleSuccess : player.SaveSuccess;
        }
        
        /// <summary>
        /// Updates advance score when this player action is performed.
        /// </summary>
        /// <param name="advanceScore">Reference to advance action.</param>
        public void UpdateAdvanceScore(ref int advanceScore)
        {
            advanceScore = 0;
        }
    }
}