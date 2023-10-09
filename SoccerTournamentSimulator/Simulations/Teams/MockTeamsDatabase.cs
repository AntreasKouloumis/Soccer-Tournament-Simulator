using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.Simulations.Teams
{
    /// <summary>
    /// Mock database of teams.
    /// </summary>
    public class MockTeamsDatabase : ITeamDatabase
    {
        public List<Team> Teams { get; private set; }

        public MockTeamsDatabase()
        {
            Teams = GenerateTeamsMockData();
        }

        public List<int> GetTeamIds()
        {
            List<int> teamIds = new List<int>();
            for (int i = 0; i < Teams.Count; i++)
                teamIds.Add(Teams[i].IdData.Id);
            return teamIds;
        }
        
        public List<IdData> GetTeamIdData()
        {
            List<IdData> teamIdData = new List<IdData>();
            for (int i = 0; i < Teams.Count; i++)
                teamIdData.Add(Teams[i].IdData);
            return teamIdData;
        }
        
        public IdData GetTeamIdDataById(int id)
        {
            for (int i = 0; i < Teams.Count; i++)
                if (Teams[i].IdData.Id == id)
                    return Teams[i].IdData;
            return null;
        }

        public Team GetTeamById(int id)
        {
            for (int i = 0; i < Teams.Count; i++)
                if (Teams[i].IdData.Id == id)
                    return Teams[i];
            return null;
        }
        
        public Tuple<IdData, IdData> GetIdDataPairingByIds(Tuple<int, int> ids)
        {
            IdData homeTeam = GetTeamIdDataById(ids.Item1);
            IdData awayTeam = GetTeamIdDataById(ids.Item2);
            return new Tuple<IdData, IdData>(homeTeam, awayTeam);
        }
        
        public Tuple<Team, Team> GetTeamPairingByIdData(Tuple<IdData, IdData> ids)
        {
            Team homeTeam = GetTeamById(ids.Item1.Id);
            Team awayTeam = GetTeamById(ids.Item2.Id);
            return new Tuple<Team, Team>(homeTeam, awayTeam);
        }
        
        public Tuple<Team, Team> GetTeamPairingByIds(Tuple<int, int> ids)
        {
            Team homeTeam = GetTeamById(ids.Item1);
            Team awayTeam = GetTeamById(ids.Item2);
            return new Tuple<Team, Team>(homeTeam, awayTeam);
        }

        private List<Team> GenerateTeamsMockData()
        {
            return new List<Team>()
            {
                // Team 1 (4-4-2 formation)
                new Team(
                    1,
                    "Galacticos FC",
                    new GoalKeeper(1,
                        "Diego Alves",
                        0.9f,
                        0.6f,
                        0.4f,
                        0.3f,
                        0.5f,
                        0.2f,
                        0.9f),
                    new List<Defender>
                    {
                        new Defender(2,
                            "Sergio Ramos",
                            0.5f,
                            0.7f,
                            0.6f,
                            0.2f,
                            0.7f,
                            0.6f,
                            0.1f),
                        new Defender(3,
                            "Dani Carvajal",
                            0.6f,
                            0.7f,
                            0.5f,
                            0.3f,
                            0.6f,
                            0.7f,
                            0.1f),
                        new Defender(4,
                            "Marcelo Vieira",
                            0.5f,
                            0.8f,
                            0.5f,
                            0.2f,
                            0.7f,
                            0.5f,
                            0.1f),
                        new Defender(5,
                            "Raphael Varane",
                            0.5f,
                            0.6f,
                            0.7f,
                            0.2f,
                            0.6f,
                            0.6f,
                            0.1f)
                    },
                    new List<Midfielder>
                    {
                        new Midfielder(6,
                            "Luka Modric",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.5f,
                            0.5f,
                            0.4f,
                            0.1f),
                        new Midfielder(7,
                            "Toni Kroos",
                            0.6f,
                            0.7f,
                            0.8f,
                            0.5f,
                            0.5f,
                            0.3f,
                            0.1f),
                        new Midfielder(8,
                            "Federico Valverde",
                            0.7f,
                            0.8f,
                            0.7f,
                            0.4f,
                            0.5f,
                            0.3f,
                            0.1f),
                        new Midfielder(9,
                            "Isco Alarcon",
                            0.6f,
                            0.7f,
                            0.8f,
                            0.4f,
                            0.5f,
                            0.4f,
                            0.1f)
                    },
                    new List<Forward>
                    {
                        new Forward(10,
                            "Karim Benzema",
                            0.8f,
                            0.5f,
                            0.5f,
                            0.7f,
                            0.3f,
                            0.2f,
                            0.1f),
                        new Forward(11,
                            "Eden Hazard",
                            0.9f,
                            0.4f,
                            0.5f,
                            0.8f,
                            0.2f,
                            0.1f,
                            0.1f)
                    }
                ),

                // Team 2 (4-3-3 formation)
                new Team(
                    2,
                    "Red Devils United",
                    new GoalKeeper(12,
                        "David De Gea",
                        0.9f,
                        0.6f,
                        0.5f,
                        0.3f,
                        0.6f,
                        0.3f,
                        0.9f),
                    new List<Defender>
                    {
                        new Defender(13,
                            "Aaron Wan-Bissaka",
                            0.5f,
                            0.7f,
                            0.6f,
                            0.3f,
                            0.8f,
                            0.6f,
                            0.1f),
                        new Defender(14,
                            "Harry Maguire",
                            0.6f,
                            0.7f,
                            0.5f,
                            0.2f,
                            0.6f,
                            0.7f,
                            0.1f),
                        new Defender(15,
                            "Luke Shaw",
                            0.5f,
                            0.8f,
                            0.5f,
                            0.3f,
                            0.6f,
                            0.5f,
                            0.1f),
                        new Defender(16,
                            "Victor Lindelof",
                            0.5f,
                            0.6f,
                            0.7f,
                            0.2f,
                            0.6f,
                            0.7f,
                            0.1f)
                    },
                    new List<Midfielder>
                    {
                        new Midfielder(17,
                            "Paul Pogba",
                            0.7f,
                            0.8f,
                            0.7f,
                            0.5f,
                            0.4f,
                            0.3f,
                            0.1f),
                        new Midfielder(18,
                            "Bruno Fernandes",
                            0.7f,
                            0.8f,
                            0.6f,
                            0.6f,
                            0.5f,
                            0.3f,
                            0.1f),
                        new Midfielder(19,
                            "Scott McTominay",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.4f,
                            0.5f,
                            0.4f,
                            0.1f)
                    },
                    new List<Forward>
                    {
                        new Forward(20,
                            "Marcus Rashford",
                            0.9f,
                            0.5f,
                            0.5f,
                            0.7f,
                            0.3f,
                            0.2f,
                            0.1f),
                        new Forward(21,
                            "Anthony Martial",
                            0.8f,
                            0.6f,
                            0.5f,
                            0.7f,
                            0.3f,
                            0.2f,
                            0.1f),
                        new Forward(22,
                            "Mason Greenwood",
                            0.9f,
                            0.5f,
                            0.4f,
                            0.8f,
                            0.3f,
                            0.2f,
                            0.1f)
                    }
                ),

                // Team 3 (5-3-2 formation)
                new Team(
                    3,
                    "Blue Lions FC",
                    new GoalKeeper(23,
                        "Kepa Arrizabalaga",
                        0.8f,
                        0.6f,
                        0.4f,
                        0.2f,
                        0.6f,
                        0.2f,
                        0.9f),
                    new List<Defender>
                    {
                        new Defender(24,
                            "Cesar Azpilicueta",
                            0.6f,
                            0.7f,
                            0.6f,
                            0.2f,
                            0.8f,
                            0.6f,
                            0.1f),
                        new Defender(25,
                            "Thiago Silva",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.2f,
                            0.7f,
                            0.7f,
                            0.1f),
                        new Defender(26,
                            "Ben Chilwell",
                            0.5f,
                            0.7f,
                            0.6f,
                            0.3f,
                            0.7f,
                            0.5f,
                            0.1f),
                        new Defender(27,
                            "Reece James",
                            0.6f,
                            0.6f,
                            0.7f,
                            0.3f,
                            0.7f,
                            0.6f,
                            0.1f),
                        new Defender(28,
                            "Antonio Rudiger",
                            0.5f,
                            0.6f,
                            0.7f,
                            0.3f,
                            0.8f,
                            0.5f,
                            0.1f)
                    },
                    new List<Midfielder>
                    {
                        new Midfielder(29,
                            "N'Golo Kante",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.5f,
                            0.5f,
                            0.5f,
                            0.1f),
                        new Midfielder(30,
                            "Mason Mount",
                            0.7f,
                            0.8f,
                            0.6f,
                            0.6f,
                            0.5f,
                            0.4f,
                            0.1f),
                        new Midfielder(31,
                            "Mateo Kovacic",
                            0.6f,
                            0.8f,
                            0.8f,
                            0.4f,
                            0.5f,
                            0.4f,
                            0.1f)
                    },
                    new List<Forward>
                    {
                        new Forward(32,
                            "Timo Werner",
                            0.8f,
                            0.5f,
                            0.5f,
                            0.7f,
                            0.3f,
                            0.2f,
                            0.1f),
                        new Forward(33,
                            "Romelu Lukaku",
                            0.9f,
                            0.5f,
                            0.5f,
                            0.8f,
                            0.2f,
                            0.2f,
                            0.1f)
                    }
                ),

                // Team 4 (6-3-1 formation)
                new Team(
                    4,
                    "Skyline Rovers",
                    new GoalKeeper(34,
                        "Manuel Neuer",
                        0.9f,
                        0.7f,
                        0.5f,
                        0.3f,
                        0.7f,
                        0.3f,
                        0.9f),
                    new List<Defender>
                    {
                        new Defender(35,
                            "Joshua Kimmich",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.2f,
                            0.8f,
                            0.6f,
                            0.1f),
                        new Defender(36,
                            "David Alaba",
                            0.6f,
                            0.7f,
                            0.7f,
                            0.3f,
                            0.7f,
                            0.6f,
                            0.1f),
                        new Defender(37,
                            "Jerome Boateng",
                            0.5f,
                            0.6f,
                            0.8f,
                            0.3f,
                            0.7f,
                            0.7f,
                            0.1f),
                        new Defender(38,
                            "Niklas Sule",
                            0.5f,
                            0.6f,
                            0.8f,
                            0.2f,
                            0.7f,
                            0.5f,
                            0.1f),
                        new Defender(39,
                            "Lucas Hernandez",
                            0.5f,
                            0.6f,
                            0.7f,
                            0.3f,
                            0.7f,
                            0.6f,
                            0.1f),
                        new Defender(40,
                            "Benjamin Pavard",
                            0.5f,
                            0.6f,
                            0.7f,
                            0.3f,
                            0.7f,
                            0.5f,
                            0.1f)
                    },
                    new List<Midfielder>
                    {
                        new Midfielder(41,
                            "Leon Goretzka",
                            0.6f,
                            0.8f,
                            0.7f,
                            0.5f,
                            0.6f,
                            0.5f,
                            0.1f),
                        new Midfielder(42,
                            "Serge Gnabry",
                            0.7f,
                            0.7f,
                            0.6f,
                            0.7f,
                            0.5f,
                            0.4f,
                            0.1f),
                        new Midfielder(43,
                            "Thomas Muller",
                            0.7f,
                            0.8f,
                            0.6f,
                            0.6f,
                            0.5f,
                            0.4f,
                            0.1f)
                    },
                    new List<Forward>
                    {
                        new Forward(44,
                            "Robert Lewandowski",
                            0.9f,
                            0.5f,
                            0.5f,
                            0.8f,
                            0.3f,
                            0.2f,
                            0.1f)
                    }
                )
            };
        }
    }
}