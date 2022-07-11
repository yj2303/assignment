using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{

    public static List<IPLDesign> list = new List<IPLDesign>();
    public static void Main()
    {
        var players = new ProcessCSV();
        players.CSVData = new List<KeyValuePair<string, string>> {
        new KeyValuePair<string, string>("Name", "name"),
        new KeyValuePair<string, string>("Team", "team"),
        new KeyValuePair<string, string>("Role", "role"),
        new KeyValuePair<string, string>("Matches", "matches"),
        new KeyValuePair<string, string>("Runs", "runs"),
        new KeyValuePair<string, string>("Average", "average"),
        new KeyValuePair<string, string>("SR", "strikeRate"),
        new KeyValuePair<string, string>("Wickets", "wickets")
        };
        list = players.Import<IPLDesign>(@"IPL_Data.csv");
    }

    public class ProcessCSV
    {
        public List<KeyValuePair<string, string>> CSVData;
        public List<T> Import<T>(string data)
        {
            List<T> list = new List<T>();
            List<string> row = System.IO.File.ReadAllLines(data).ToList();
            var dataValues = row[0].Split(',').ToList().Select((v, i) => new
            {
                ColName = v,
                ColIndex = i
            });

            return list;
        }
    }
    //1
    public class IPLDesign
    {

        public string name { get; set; }
        public string team { get; set; }
        public string role { get; set; }
        public int matches { get; set; }
        public int runs { get; set; }
        public double average { get; set; }
        public double strikeRate { get; set; }
        public int wickets { get; set; }
    }
   
    public class Players
    {
        List<string> players_name = new List<string>();

       
        //3
        public List<string> BowlerWithAtLeastFortyWickets(string Team)
        {
            List<string> list = new List<string>();
            var result = (from li in Program.list
                         where li.name == Team && li.wickets >= 40
                         select li);
            foreach (var team in result)
            {
                list.Add(team.name);
            }
            return list;

        }
        //4
        public IEnumerable<string> searchPlayerWithGivenName(string playerName)
        {
            IEnumerable<string> result = (IEnumerable<string>)Program.list.Where(pl => pl.name.Contains(playerName));
            return result;
        }
       
            

        //5
        public List<string> StarPerformers()
        {
            List<string> player = new List<string>();
            var starBatsman = Program.list.OrderByDescending(x => x.runs).First();
            var  starBowler= Program.list.OrderByDescending(x => x.wickets).First();
            player.Add(starBatsman.name);
            player.Add(starBowler.name);
            
            return player;
        }

        //6
        public List<string> TopThree()
        {
            List<string> player = new List<string>();
            var batsMan = Program.list.OrderByDescending(pl => pl.runs).Take(3);
            var bowler = Program.list.OrderByDescending(pl => pl.wickets).Take(3);
            var allRounders = Program.list.OrderByDescending(pl => pl.runs).ThenBy(pl => pl.wickets).Take(3);
            foreach (var itr in batsMan)
            {
                player.Add(itr.name);
            }
            foreach (var itr in bowler)
            {
                player.Add(itr.name);
            }
            foreach (var itr in allRounders)
            {
                player.Add(itr.name);
            }

            return player;


        }

        //7
       public void twoHypotheticalTeam()
           {
            var List = Program.list.GroupBy(pl => new { team = pl.team }).Select(av => new { Average = av.Average(c => c.average), team = av.Key.team });
            var res = List.OrderByDescending(x => x.Average).Take(2);
            foreach (var player in res)
            {
                Console.WriteLine(player.team + "  " + player.Average * 11);
            }



        }
        //8
        public void NextGen()
        {   //we are finding the next gen player on the basis of good average of wickets, runs and matches that player have played 


        }
       

    }
}









