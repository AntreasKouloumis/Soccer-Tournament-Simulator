using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Matches.Scores
{
    /// <summary>
    /// Score resulting from multiple matches in the context of tournament with a number of teams.
    /// </summary>
    public class TournamentScore
    {
        private List<List<MatchScore>> matchScores = new List<List<MatchScore>>();

        private int currentMatchIndex;
        private int currentRoundIndex;
        
        public TournamentScore(List<List<MatchScore>> matchScores)
        {
            this.matchScores = matchScores;
        }

        public TournamentScore(IReadOnlyList<List<Tuple<IdData, IdData>>> pairings)
        {
            for (int i = 0; i < pairings.Count; i++)
            {
                List<MatchScore> roundMatchScores = new List<MatchScore>();
                for (int j = 0; j < pairings[i].Count; j++)
                    roundMatchScores.Add(new MatchScore(pairings[i][j]));
                
                matchScores.Add(roundMatchScores);
            }
        }

        /// <summary>
        /// Adds the match score into the appropriate round and match slot in the list of match scores.
        /// </summary>
        /// <param name="matchScore">Match score to be added to the list of match scores.</param>
        public void AddMatchScore(MatchScore matchScore)
        {
            if (currentRoundIndex >= matchScores.Count ||
                currentMatchIndex >= matchScores[currentRoundIndex].Count) return;
            matchScores[currentRoundIndex][currentMatchIndex] = matchScore;
            currentMatchIndex++;

            if (currentMatchIndex < matchScores[currentRoundIndex].Count) return;
            currentMatchIndex = 0;
            currentRoundIndex++;
        }

        public List<List<MatchScore>> GetTournamentMatchScores() => matchScores;
        
        public List<MatchScore> GetRoundMatchScores(int roundIndex) => matchScores[roundIndex];
        
        public MatchScore GetMatchScore(int roundIndex, int matchIndex)
            => matchScores[roundIndex][matchIndex];
    }
}