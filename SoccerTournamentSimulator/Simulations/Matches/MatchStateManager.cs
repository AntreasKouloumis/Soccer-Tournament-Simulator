namespace SoccerTournamentSimulator.Simulations.Matches
{
    /// <summary>
    /// Manages the state of the match.
    /// </summary>
    public class MatchStateManager
    {
        public MatchState MatchState { get; private set; } = MatchState.Kickoff;
        
        public MatchState MoveToNextState() => ++MatchState;

        public bool IsFirstHalf() => MatchState == MatchState.FirstHalf;
        
        public bool IsFinalWhistle() => MatchState == MatchState.FinalWhistle;
    }
}