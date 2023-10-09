namespace SoccerTournamentSimulator.Simulations.Players
{
    /// <summary>
    /// Player with the position of a Defender.
    /// </summary>
    public class Defender : Player
    {
        public Defender(
            int id, 
            string name, 
            float goalSuccess, 
            float shortPassSuccess, 
            float longPassSuccess, 
            float dribbleSuccess, 
            float interceptionSuccess, 
            float stealSuccess, 
            float saveSuccess)
            : base(
                id, 
                name, 
                goalSuccess, 
                shortPassSuccess, 
                longPassSuccess, 
                dribbleSuccess, 
                interceptionSuccess, 
                stealSuccess, 
                saveSuccess)
        { }
    }
}