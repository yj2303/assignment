using IPL_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Services
{
    public class Query
    {

        private Dictionary<string, Team> teams = new Dictionary<string, Team>();
        
        private List<Player> players = new List<Player>();

        public Query(Dictionary<string, Team> teams, List<Player> players)
        {

            this.teams = teams;
            this.players = players;
        }

        public List<Player> searchPlayerWithGivenName(string name)
        {
            List<Player> list = new List<Player>();
            foreach (var p in players)
            {
                if (p.name.StartsWith(name))
                {
                    list.Add(p);
                }
            }
            return list;
        }
        public List<Player> BowlerWithAtLeastFortyWicket(string name)
        {
            var list = new List<Player>();
            Team t = teams.ContainsKey(name) ? teams[name] : null;
            if (t != null)
            {
                var players = t.GetAllPlayers();
                foreach (var p in players)
                {
                    if (p.role.CompareTo("BOWLER") == 0)
                    {
                        if (p.wickets >= 40)
                        {
                            list.Add(p);
                        }
                    }
                }

            }
            return list;

        }

        public List<Player> StarPerformers(string name)
        {
            int highest_score = 0;
            int highest_wicket = 0;
            Player p_s = null;
            Player p_w = null;
            List<Player> list = new List<Player>();

            var l_players = teams.ContainsKey(name) ? teams[name].GetAllPlayers() : null;
            foreach (var p in l_players)
            {
                if (p.wickets > highest_wicket)
                {
                    highest_wicket = p.wickets;
                    p_w = p;
                }
                if (p.runs > highest_score)
                {
                    highest_score = p.runs;
                    p_s = p;
                }
            }
            list.Add(p_w);
            list.Add(p_s);
            return list;
        }

        public List<Player> GetTop3Bowlers()
        {

            var list = players.Where(p => p.role.Equals("BOWLER")).OrderByDescending(p => p.wickets).Take(3);
            var r = new List<Player>();
            foreach (var p in list)
            {
                r.Add(p);
            }
            return r;
        }

        public List<Player> GetTop3Allrounder()
        {

            var list = players.Where(p => p.role.Equals("ALL ROUNDER")).OrderByDescending(p => (p.runs/(p.matches+1))+((p.wickets/(p.matches+1))*15)).Take(3);//derive a formula (runs/matches)+((wickets/mathes)*15)
            var r = new List<Player>();
            foreach (var p in list)
            {
                r.Add(p);
            }
            return r;
        }

        public List<Player> GetTop3Batsman()
        {

            var list = players.Where(p => p.role.Equals("BATSMAN")).OrderByDescending(p => p.runs).Take(3);
            var r = new List<Player>();
            foreach (var p in list)
            {
                r.Add(p);
            }
            return r;
        }

        public void twoHypotheticalTeams()
        {
            int score;
            double max_avg1 = 0;
            double max_avg2 = 0;
            Team team1, team2;
            team1 = team2 = new Team();

            foreach (var t in teams)
            {
                double sum = 0;
                var players_ = t.Value.GetAllPlayers().Where(p => p.role.Equals("BATSMAN") ).OrderByDescending(p => p.average).Take(11);
                foreach (var p in players_)
                {
                    sum += p.average;

                }
                
                if (sum > max_avg2 && sum < max_avg1)
                {
                    max_avg2 = sum;
                    team2 = t.Value;
                }
                else
                {
                    if (sum > max_avg2 && sum > max_avg1)
                    {
                        max_avg1 = sum;
                        team1 = t.Value;
                    }
                }
            }
            Console.WriteLine($"The Team1:{team1.GetName()} will score {(int)max_avg1 } is the predicted score");
            Console.WriteLine($"The Team2:{team2.GetName()} will score {(int)max_avg2 } is the predicted score");


        }

        public void FindNextGen()
        {
            foreach (var team_ in teams)
            {
                var t = team_.Value;
                var t_name = t.GetName();
                var players_ = t.GetAllPlayers()
                    .OrderByDescending(p => ((p.average) + (p.strike_rate)+p.runs) );
                    

               
                foreach (var p in players_)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public void CreateFixtures()
        {
            Fixtures f = new Fixtures();
            f.CreateFixtures(teams);
        }
    }
}
