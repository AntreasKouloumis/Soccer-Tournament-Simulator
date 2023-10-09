
using SoccerTournamentSimulator.Simulations.Matches;

namespace SoccerTournamentSimulator.Simulations.Players.Actions
{
    /// <summary>
    /// Player action of dribble.
    /// </summary>
    public class DribblePlayerAction : IPlayerAction
    {
        private const PlayerReaction PlayerReaction = Actions.PlayerReaction.Tackle;
        private const int DribbleScore = 1;

        /// <summary>
        /// Gets the success probability of the player reaction that interacts with this player action.
        /// </summary>
        /// <param name="player">Player whose success probability to return.</param>
        /// <returns>Success probability of the player reaction.</returns>
        public float GetPlayerReactionSuccess(Player player)
        {
            return player.TackleSuccess;
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
            return player.TackleSuccess;
        }

        /// <summary>
        /// Updates advance score when this player action is performed.
        /// </summary>
        /// <param name="advanceScoreManager">Advance score manager.</param>
        public void UpdateAdvanceScore(AdvanceScoreManager advanceScoreManager)
        {
            advanceScoreManager.IncrementAdvanceScore(DribbleScore);
        }
    }
}