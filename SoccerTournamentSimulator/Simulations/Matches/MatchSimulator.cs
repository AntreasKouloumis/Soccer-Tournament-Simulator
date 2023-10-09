using SoccerTournamentSimulator.Simulations.CoinToss;
using SoccerTournamentSimulator.Simulations.Matches.Balls;
using SoccerTournamentSimulator.Simulations.Matches.Interactions;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Players.Actions;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.Matches
{
    /// <summary>
    /// Simulates matches between two teams.
    /// </summary>
    public class MatchSimulator
    {
        private MatchScoreManager matchScoreManager;
        private BallPossessionManager ballPossessionManager;
        private InteractionSimulator interactionSimulator;
        private ICoinTossManager coinTossManager;
        private TeamManager teamManager;
        private MatchStateManager matchStateManager;
        private AdvanceScoreManager advanceScoreManager;
        
        public event EventHandler<MatchScoreEventArgs>? OnMatchEnded;

        public MatchSimulator(
            MatchScoreManager matchScoreManager,
            BallPossessionManager ballPossessionManager,
            InteractionSimulator interactionSimulator,
            ICoinTossManager coinTossManager,
            TeamManager teamManager,
            MatchStateManager matchStateManager,
            AdvanceScoreManager advanceScoreManager)
        {
            this.matchScoreManager = matchScoreManager;
            this.ballPossessionManager = ballPossessionManager;
            this.interactionSimulator = interactionSimulator;
            this.coinTossManager = coinTossManager;
            this.teamManager = teamManager;
            this.matchStateManager = matchStateManager;
            this.advanceScoreManager = advanceScoreManager;
        }

        /// <summary>
        /// Simulates a match.
        /// </summary>
        public void SimulateMatch()
        {
            KickoffMatchSegment();
        }

        /// <summary>
        /// Kicks off each segment of the match.
        /// </summary>
        private void KickoffMatchSegment()
        {
            matchStateManager.MoveToNextState();
            if (matchStateManager.IsFinalWhistle())
            {
                MatchEnded();
                return;
            }

            advanceScoreManager.SetAdvanceScoreToKickoff();
            UpdateInitialBallPossessionOfMatchSegment();
            SetBallPossessionToPlayerAccordingToAdvanceScore();
            SimulateMatchSegment();
        }

        private void MatchEnded()
        {
            OnMatchEnded?.Invoke(this, new MatchScoreEventArgs(matchScoreManager.MatchScore));
        }

        /// <summary>
        /// Updates the initial ball possession at the start of each segment of the match.
        /// </summary>
        private void UpdateInitialBallPossessionOfMatchSegment()
        {
            if (matchStateManager.IsFirstHalf())
            {
                Team initialTeam = teamManager.GetTeam(coinTossManager.TossCoin());
                ballPossessionManager.SetInitialBallPossessionToTeam(initialTeam);
                return;
            }

            int initialTeamId = ballPossessionManager.InitialBallPossessionTeam.IdData.Id;
            Team initialOpposingTeam = teamManager.GetOpposingTeamById(initialTeamId);
            ballPossessionManager.SetBallPossessionToTeam(initialOpposingTeam);
        }

        private Team GetOpposingTeam()
            => teamManager.GetOpposingTeamById(ballPossessionManager.BallPossessionTeam.IdData.Id);

        private void SetBallPossessionToOpposingTeam()
        {
            ballPossessionManager.SetBallPossessionToTeam(GetOpposingTeam());
        }

        private void SetBallPossessionToPlayerAccordingToAdvanceScore()
        {
            PlayerPosition playerPosition = advanceScoreManager.GetPlayerPositionAccordingToAdvanceScore();
            ballPossessionManager.SetBallPossessionToRandomPlayerByPosition(playerPosition);
        }

        /// <summary>
        /// Simulates each segment of the match.
        /// </summary>
        private void SimulateMatchSegment()
        {
            for (int i = interactionSimulator.MatchHalfInteractionsCount; i >= 0; i--)
            {
                // Get actor and reactor.
                Player playerActor = ballPossessionManager.BallPossessionPlayer;
                PlayerPosition playerPosition = advanceScoreManager.GetPlayerPositionAccordingToInverseAdvanceScore();
                Player playerReactor = GetOpposingTeam().GetRandomPlayerByPlayerPosition(playerPosition);

                // Get action and reaction success.
                float actionSuccess = playerActor.GetPlayerActionSuccess(
                    advanceScoreManager.GetAdvanceMultiplier(), out IPlayerAction playerAction);
                float reactionSuccess = playerAction.GetPlayerReactionSuccess(playerReactor);

                // Interaction outcome.
                if (interactionSimulator.SimulateInteraction(actionSuccess, reactionSuccess))
                    OnActionSuccess(playerAction);
                else
                    OnActionFailure(playerReactor);
            }

            KickoffMatchSegment();
        }

        /// <summary>
        /// Handles the action success contingency.
        /// </summary>
        /// <param name="playerAction">Player action that resulted in success.</param>
        private void OnActionSuccess(IPlayerAction playerAction)
        {
            advanceScoreManager.UpdateAdvanceScore(playerAction);
            switch (playerAction)
            {
                case ShortPassPlayerAction or LongPassPlayerAction:
                    SetBallPossessionToPlayerAccordingToAdvanceScore();
                    break;
                case ShootPlayerAction:
                    matchScoreManager.IncrementTeamScoreById(
                        ballPossessionManager.BallPossessionTeam.IdData.Id);
                    break;
            }
        }

        /// <summary>
        /// Handles the action failure contingency.
        /// </summary>
        /// <param name="playerReactor">Player reactor that was involved in the action failure.</param>
        private void OnActionFailure(Player playerReactor)
        {
            advanceScoreManager.ResetAdvanceScore();
            SetBallPossessionToOpposingTeam();
            ballPossessionManager.SetBallPossessionToPlayer(playerReactor);
        }
    }
}