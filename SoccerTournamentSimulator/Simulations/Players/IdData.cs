namespace SoccerTournamentSimulator.Simulations.Players
{
    /// <summary>
    /// Identification data.
    /// </summary>
    public class IdData
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public IdData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}