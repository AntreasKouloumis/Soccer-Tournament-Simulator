namespace SoccerTournamentSimulator.Simulations.Pairings
{
    /// <summary>
    /// Generates pairings between entity ids.
    /// </summary>
    public interface IPairingsGenerator
    {
        List<List<Tuple<int, int>>> GeneratePairings(List<int> ids);
    }
}