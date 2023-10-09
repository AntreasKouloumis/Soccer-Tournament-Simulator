using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Teams
{
    /// <summary>
    /// Team database interface.
    /// </summary>
    public interface ITeamDatabase
    {
        public List<int> GetTeamIds();
        
        public List<IdData> GetTeamIdData();
        
        public IdData GetTeamIdDataById(int id);

        public Team GetTeamById(int id);
        
        public Tuple<IdData, IdData> GetIdDataPairingByIds(Tuple<int, int> ids);
        
        Tuple<Team, Team> GetTeamPairingByIdData(Tuple<IdData, IdData> ids);

        Tuple<Team, Team> GetTeamPairingByIds(Tuple<int, int> ids);
    }
}