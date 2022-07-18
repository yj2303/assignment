using IPL_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Services
{
    public class Fixtures
    {
        private List<Match> list_matches = new List<Match>();

        private List<Team> list_teams = new List<Team>();

        
        public void CreateFixtures(Dictionary<string,Team> teams)
        {
            foreach (KeyValuePair<string, Team> t in teams)
            {
                list_teams.Add(t.Value);
            }

                //list_teams = teams;
            int n=list_teams.Count;
            //Console.WriteLine("count of teams " + n);
            int count = 1;
            for(int i=0;i<n-1;i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var match_ = new Match();
                    match_._match_no = count;
                    match_.team1 = list_teams[j];
                    match_.team2 = list_teams[((n-1) - j)];
                    match_.location = list_teams[j].GetHomeGround();
                    
                    list_matches.Add(match_);

                    count++;
                }
                //foreach(var t in list_teams)
                //{
                //    Console.Write( t.GetName()+" ");
                //}
                //Console.WriteLine();
                list_teams.Insert(1, list_teams[(n-1)]);
                list_teams.RemoveAt(n);

            }
            //Console.WriteLine("outside loop");
            n = list_matches.Count();
            //Console.WriteLine(n+" mathes up tilll");
            for (int i=0;i<n;i++)
            {
                var match_=list_matches[i];
                var match_2 = new Match();
                match_2._match_no = count;
                match_2.team1 = match_.team2;
                match_2.team2 = match_.team1;
                match_2.location = match_2.team1.GetHomeGround();
                list_matches.Add((Match)match_2);
                count++;
            }
            

            foreach(var match in list_matches)
            {
                Console.WriteLine(match.ToString());
            }

             

        }
    }
}
