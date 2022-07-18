using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Models
{
    public class Team
    {
        protected List<Player> _players = new List<Player>();

        protected string _name;

        protected string home_ground;

        public Team(string name)
        {
            _name = name;
        }

        public Team()
        {
            _players = new List<Player>();
            _name = "";
        }

        public void AddPlayer(Player p)
        {
            _players.Add(p);
        }

       

        public List<Player> GetAllPlayers()
        {
            return _players;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetHomeGround(string s)
        {
            home_ground = s;
        }

        public string GetHomeGround()
        {
            return home_ground;
        }
        
    }
}
