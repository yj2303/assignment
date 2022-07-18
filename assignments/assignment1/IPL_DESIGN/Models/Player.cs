using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Models
{
    public class Player
    {
        public string name { set; get; }
        public string role { set; get; }
        public string team { set; get; }
        public int matches { set; get; }
        public int runs { set; get; }
        public int wickets { set; get; }
        public double strike_rate { set; get; }
        public double average { set; get; }

        public int age { set; get; }
        public override string ToString()
        {
            return $"Name:{name}, Role:{role}, Team:{team}, Matches:{matches}, Runs:{runs}, Wickets:{wickets}, Strike Rate:{strike_rate}, Average:{average}, Age:{age}";
        }


    }
}
