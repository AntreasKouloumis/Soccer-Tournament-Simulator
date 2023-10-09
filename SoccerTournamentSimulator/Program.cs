using SoccerTournamentSimulator.Simulations;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator;

class Program
{
    private static SimulationManager simulationManager;
        
    static void Main(string[] args)
    {
        simulationManager = new SimulationManager(new MockTeamDatabase());

        simulationManager.StartSimulation();
    }
}