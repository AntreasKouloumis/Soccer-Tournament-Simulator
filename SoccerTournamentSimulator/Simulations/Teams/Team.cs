using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Teams
{
    /// <summary>
    /// Team class.
    /// </summary>
    public class Team
    {
        public IdData IdData { get; private set; }

        public GoalKeeper GoalKeeper { get; private set; }

        public List<Defender> Defenders { get; private set; }

        public List<Midfielder> Midfielders { get; private set; }

        public List<Forward> Forwards { get; private set; }

        private readonly Random random = new Random();

        public Team(
            int id,
            string name,
            GoalKeeper goalKeeper,
            List<Defender> defenders,
            List<Midfielder> midfielders,
            List<Forward> forwards)
        {
            IdData = new IdData(id, name);
            GoalKeeper = goalKeeper;
            Defenders = defenders;
            Midfielders = midfielders;
            Forwards = forwards;
        }

        /// <summary>
        /// Gets player from the team by Id.
        /// </summary>
        /// <param name="id">Id of player to get from the team.</param>
        /// <returns>Player from the team with specified Id.</returns>
        public Player GetPlayerById(int id)
        {
            if (GoalKeeper.IdData.Id == id) return GoalKeeper;
            for (int i = 0; i < Defenders.Count; i++)
                if (Defenders[i].IdData.Id == id)
                    return Defenders[i];
            for (int i = 0; i < Midfielders.Count; i++)
                if (Midfielders[i].IdData.Id == id)
                    return Midfielders[i];
            for (int i = 0; i < Forwards.Count; i++)
                if (Forwards[i].IdData.Id == id)
                    return Forwards[i];
            return null;
        }

        /// <summary>
        /// Gets random player from the team by player position.
        /// </summary>
        /// <param name="playerPosition">Player position with which to get a random player.</param>
        /// <returns>Random player from the team with specified player position.</returns>
        /// <exception cref="ArgumentException">Unsupported player position.</exception>
        public Player GetRandomPlayerByPlayerPosition(PlayerPosition playerPosition)
        {
            return playerPosition switch
            {
                PlayerPosition.GoalKeeper => GoalKeeper,
                PlayerPosition.Defender => Defenders[random.Next(Defenders.Count)],
                PlayerPosition.Midfielder => Midfielders[random.Next(Midfielders.Count)],
                PlayerPosition.Forward => Forwards[random.Next(Forwards.Count)],
                _ => throw new ArgumentOutOfRangeException(nameof(playerPosition), 
                    playerPosition, null)
            };
        }
    }
}