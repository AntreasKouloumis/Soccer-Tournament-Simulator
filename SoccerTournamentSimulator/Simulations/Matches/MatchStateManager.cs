namespace SoccerTournamentSimulator.Simulations.Matches
{
    /// <summary>
    /// Manages the state of the match.
    /// </summary>
    public class MatchStateManager
    {
        public MatchState CurrentMatchState { get; private set; } = MatchState.Kickoff;
        
        public void MoveToNextState() => CurrentMatchState++;

        public bool IsFirstHalf() => CurrentMatchState == MatchState.FirstHalf;
        
        public bool IsFinalWhistle() => CurrentMatchState == MatchState.FinalWhistle;
    }
}