
namespace SoccerTournamentSimulator.Simulations.Players.Actions
{
    /// <summary>
    /// Player action of long pass.
    /// </summary>
    public class LongPassPlayerAction : IPlayerAction
    {
        private const PlayerReaction PlayerReaction = Actions.PlayerReaction.Interception;
        private const int LongPassScore = 2;
        
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <returns>Success probability of the player reaction.</returns>
        public float GetPlayerReactionSuccess(Player player)
        {
            return player.InterceptionSuccess;
        }
        
        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <param name="playerReaction">Player reaction that interacts with this action.</param>
        /// <returns>Success probability of the player reaction.</returns>
        public float GetPlayerReactionSuccess(Player player, out PlayerReaction playerReaction)
        {
            playerReaction = PlayerReaction;
            return player.InterceptionSuccess;
        }

        /// <summary>
        /// Updates advance score when this player action is performed.
        /// </summary>
        /// <param name="advanceScore">Reference to advance action.</param>
        public void UpdateAdvanceScore(ref int advanceScore)
        {
            advanceScore += LongPassScore;
        }
    }
}