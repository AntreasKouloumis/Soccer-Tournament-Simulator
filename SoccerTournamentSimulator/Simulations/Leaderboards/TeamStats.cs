using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Statistics of a team participating in matches and/or tournaments.
    /// </summary>
    public class TeamStats
    {
        public IdData IdData { get; private set; }
        
        public int gamesPlayed;

        public int wins;

        public int draws;

        public int losses;

        public int goalsFor;

        public int goalsAgainst;

        public int goalDifference;

        public int points;

        public TeamStats(IdData idData)
        {
            IdData = idData;
        }

        /// <summary>
        /// Increments the appropriate counter based on the match outcome.
        /// </summary>
        /// <param name="matchOutcome">Match outcome based on which to increment.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IncrementMatchOutcome(MatchOutcome matchOutcome)
        {
            switch (matchOutcome)
            {
                case MatchOutcome.Loss:
                    losses++;
                    break;
                case MatchOutcome.Draw:
                    draws++;
                    break;
                case MatchOutcome.Win:
                    wins++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(matchOutcome), matchOutcome, null);
            }
        }
    }
}