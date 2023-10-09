using SoccerTournamentSimulator.Simulations.Players.Actions;

namespace SoccerTournamentSimulator.Simulations.Players
{
    /// <summary>
    /// Player abstract class.
    /// </summary>
    public abstract class Player
    {
        public IdData IdData { get; protected set; }

        public float GoalSuccess { get; protected set; }

        public float ShortPassSuccess { get; protected set; }

        public float LongPassSuccess { get; protected set; }

        public float DribbleSuccess { get; protected set; }

        public float InterceptionSuccess { get; protected set; }

        public float TackleSuccess { get; protected set; }

        public float SaveSuccess { get; protected set; }

        private float[] successValues;

        private IPlayerAction[] playerActions;

        private readonly Random random = new Random();

        protected Player(
            int id,
            string name,
            float goalSuccess,
            float shortPassSuccess,
            float longPassSuccess,
            float dribbleSuccess,
            float interceptionSuccess,
            float tackleSuccess,
            float saveSuccess)
        {
            IdData = new IdData(id, name);
            GoalSuccess = goalSuccess;
            ShortPassSuccess = shortPassSuccess;
            LongPassSuccess = longPassSuccess;
            DribbleSuccess = dribbleSuccess;
            InterceptionSuccess = interceptionSuccess;
            TackleSuccess = tackleSuccess;
            SaveSuccess = saveSuccess;

            successValues = new float[]
            {
                ShortPassSuccess,
                LongPassSuccess,
                DribbleSuccess,
                GoalSuccess
            };
            playerActions = new IPlayerAction[]
            {
                new ShortPassPlayerAction(),
                new LongPassPlayerAction(),
                new DribblePlayerAction(),
                new ShootPlayerAction()
            };
        }

        /// <summary>
        /// Gets player action success choosing from the two actions with the highest probability of success.
        /// </summary>
        /// <param name="advanceMultiplier">Multiplier based on the current advance score.</param>
        /// <param name="playerAction">Player action whose success was returned.</param>
        /// <returns>Player action success</returns>
        public float GetPlayerActionSuccess(float advanceMultiplier, out IPlayerAction playerAction)
        {
            successValues[^1] = GoalSuccess * advanceMultiplier;
            float highestSuccess = float.MinValue;
            float secondHighestSuccess = float.MinValue;
            int highestIndex = -1;
            int secondHighestIndex = -1;

            for (int i = 0; i < successValues.Length; i++)
            {
                if (successValues[i] > highestSuccess)
                {
                    // Move the current largest to second largest
                    secondHighestSuccess = highestSuccess;
                    secondHighestIndex = highestIndex;

                    // Update the largest value and index
                    highestSuccess = successValues[i];
                    highestIndex = i;
                }
                else if (successValues[i] > secondHighestSuccess)
                {
                    secondHighestSuccess = successValues[i];
                    secondHighestIndex = i;
                }
            }

            bool splitSecondDecision = random.Next(2) == 1;
            float chosenSuccess = splitSecondDecision ? highestSuccess : secondHighestSuccess;
            int chosenIndex = splitSecondDecision ? highestIndex : secondHighestIndex;

            playerAction = playerActions[chosenIndex];
            return chosenSuccess;
        }
    }
}