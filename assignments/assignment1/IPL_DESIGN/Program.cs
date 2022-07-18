using IPL_DESIGN.Models;
using IPL_DESIGN.Services;
namespace IPL_DESIGN
{

    public class Program
    {
        static void Main(string[] args)
        {

            var data = LoadData.GetCSVData(@"C:\Users\Admin\Source\Repos\assignments\Assignment_IPL\IPL_2021_data.csv");


            var teams = TeamServices.GetTeams(data);
            foreach (KeyValuePair<string, Team> t in teams)
            {

                var players = t.Value.GetAllPlayers();

            }

            Query q = new Query(teams, data);



            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Get Match Fixtures List");
            Console.WriteLine("2) Bowlers of any with more than 40 wickets ");
            Console.WriteLine("3) Search a player ");
            Console.WriteLine("4) Highest Wicket Taker ");
            Console.WriteLine("5) Highest Run Scorer ");
            Console.WriteLine("6) Get top 3 Bowlers Batsmen Allrounders of the season ");
            Console.WriteLine("7) Fantasy Team Match with 11 batsmen score prediction");
            

            switch (Console.ReadLine())
            {

                case "1":
                    q.CreateFixtures();
                    break;
                case "2":
                    {
                        string input = Console.ReadLine();
                        var bowlers = q.BowlerWithAtLeastFortyWicket(input);
                        foreach (var bowler in bowlers)
                        {
                            Console.WriteLine(bowler);
                        }
                    }
                    break;
                case "3":
                    {
                        string input = Console.ReadLine();
                        var players_list = q.searchPlayerWithGivenName(input);
                        foreach (var p in players_list)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;
                case "4":
                    {

                        string input = Console.ReadLine();
                        var players_list = q.StarPerformers(input);
                        Console.WriteLine("Highest wicket taker");
                        Console.WriteLine(players_list[0]);
                        Console.WriteLine("Highest Run SCorer");
                        Console.WriteLine(players_list[1]);
                    }
                    break;
                case "5":
                    {
                        var players_list = q.GetTop3Batsman();
                        foreach (Player p in players_list)
                        {
                            Console.WriteLine(p);
                        }

                        Console.WriteLine(new String('=', 40) + " Top 3 bowlers " + new String('*', 40));
                        players_list = q.GetTop3Bowlers();
                        foreach (Player p in players_list)
                        {
                            Console.WriteLine(p);
                        }

                        Console.WriteLine(new String('=', 40) + " Top 3 allrounders " + new String('*', 40));
                        players_list = q.GetTop3Allrounder();
                        foreach (Player p in players_list)
                        {
                            Console.WriteLine(p);
                        }

                    }
                    break;
                case "6":
                    {
                        q.twoHypotheticalTeams();
                    }
                    break;
                case "7":
                    {
                          q.FindNextGen();
                    }
                    break;
                default:
                    string str = "Invalid Operation";
                    Console.WriteLine(str);
                    break;

            }
        }
    }
}