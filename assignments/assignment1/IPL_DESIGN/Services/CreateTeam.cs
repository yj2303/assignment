using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPL_DESIGN.Models;
namespace IPL_DESIGN.Services
{
    public class TeamServices
    {
        private static Dictionary<string, Team> teams = new Dictionary<string, Team>();
        private List<Team> list_teams = new List<Team>();

       
        public static Dictionary<string, Team> GetTeams(List<Player> Players)
        {

            foreach (var p in Players)
            {
                var pteam = p.team;
                //var team=new Team(pteam);
                if (teams.ContainsKey(pteam))
                {
                    var t = teams[pteam];
                   
                    t.AddPlayer(p);

                }
                else
                {
                    var t = new Team(pteam);
                    switch(pteam)
                    {
                        case "CSK":
                            t.SetHomeGround("MA Chidambaram Stadim");
                            break;
                        case "MI":
                            t.SetHomeGround("Wankede70 Stadim");
                            break;
                        case "KKR":
                            t.SetHomeGround("Eden Gardens Stadim");
                            break;
                        case "RR":
                            t.SetHomeGround("Jaipur Stadim");
                            break;
                        case "PBKS":
                            t.SetHomeGround("Dhramshala Stadim");
                            break;
                        case "DC":
                            t.SetHomeGround("Arun Jaitley Stadim");
                            break;
                        case "SRH":
                            t.SetHomeGround("MA Chidambaram Stadim");
                            break;
                        case "RCB":
                            t.SetHomeGround("M Chinnaswamy Stadim");
                            break;


                    }
                    t.AddPlayer(p);
                    teams.Add(pteam, t);
                }


            }
            return teams;
        }
    }
}
