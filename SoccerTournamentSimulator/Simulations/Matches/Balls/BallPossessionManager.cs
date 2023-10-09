using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.Matches.Balls
{
    /// <summary>
    /// Manages the possession of the ball by teams and players.
    /// </summary>
    public class BallPossessionManager
    {
        /// <summary>Team that kicks off the match with ball possession.</summary>
        public Team InitialBallPossessionTeam { get; private set; }

        /// <summary>Team with ball possession.</summary>
        public Team BallPossessionTeam { get; private set; }

        /// <summary>Player with ball possession.</summary>
        public Player BallPossessionPlayer { get; private set; }

        /// <summary>
        /// Sets the initial and otherwise ball possession to a team.
        /// </summary>
        /// <param name="team">Team to set initial and otherwise ball possession to.</param>
        public void SetInitialBallPossessionToTeam(Team team)
            => InitialBallPossessionTeam = BallPossessionTeam = team;

        /// <summary>
        /// Sets the ball possession to a team.
        /// </summary>
        /// <param name="team">Team to set ball possession to.</param>
        public void SetBallPossessionToTeam(Team team) => BallPossessionTeam = team;

        /// <summary>
        /// Sets the ball possession to a player.
        /// </summary>
        /// <param name="player">Player to set ball possession to.</param>
        public void SetBallPossessionToPlayer(Player player) => BallPossessionPlayer = player;

        /// <summary>
        /// Sets the ball possession to a random player in the specified player position.
        /// </summary>
        /// <param name="playerPosition">Player position from which to get a random player
        /// to set ball possession to.</param>
        public void SetBallPossessionToRandomPlayerByPosition(PlayerPosition playerPosition)
            => BallPossessionPlayer = BallPossessionTeam.GetRandomPlayerByPlayerPosition(playerPosition);
    }
}