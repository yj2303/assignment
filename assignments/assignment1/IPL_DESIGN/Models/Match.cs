using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Models
{
    public class Match
    {
        public int _match_no { get; set; }
        public Team team1 { get; set; }
        public Team team2 { get; set; }
        public string location { get; set; }

        public string ToString()
        {
            return $"Match No: {_match_no}, Team1: {team1.GetName()}, Team2: {team2.GetName()}, Location: {location}";
        }

    }
}
