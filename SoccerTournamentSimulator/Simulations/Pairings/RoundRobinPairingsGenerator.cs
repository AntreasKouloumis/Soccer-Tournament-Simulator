namespace SoccerTournamentSimulator.Simulations.Pairings
{
    /// <summary>
    /// Generates pairings between entity ids using the round robin algorithm.
    /// </summary>
    public class RoundRobinPairingsGenerator : IPairingsGenerator
    {
        public List<List<Tuple<int, int>>> GeneratePairings(List<int> ids)
        {
            if (ids.Count % 2 != 0)
            {
                // if odd number of ids, add a dummy.
                ids.Add(-1);
            }

            // make a copy of the list.
            List<int> rotation = new List<int>(ids);

            List<List<Tuple<int, int>>> pairings = new List<List<Tuple<int, int>>>();

            for (int i = 0; i < ids.Count - 1; i++)
            {
                List<Tuple<int, int>> roundPairs = new List<Tuple<int, int>>();
                for (int j = 0; j < ids.Count / 2; j++)
                {
                    // Skip matches involving the dummy ids.
                    if (rotation[j] == -1 || rotation[rotation.Count - j - 1] == -1)
                    {
                        continue;
                    }
                    roundPairs.Add(new Tuple<int, int>(rotation[j], rotation[rotation.Count - j - 1]));
                }
                pairings.Add(roundPairs);

                // rotate the list, keeping the first element fixed.
                int lastElement = rotation[^1];
                rotation.RemoveAt(rotation.Count - 1);
                rotation.Insert(1, lastElement);
            }

            return pairings;
        }
    }
}