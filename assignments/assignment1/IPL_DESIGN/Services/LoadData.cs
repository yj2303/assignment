using IPL_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPL_DESIGN.Services
{
    public class LoadData
    {


        public static List<Player> GetCSVData(string file)
        {
            List<Player> list = new List<Player>();
            System.IO.StreamReader reader = new System.IO.StreamReader(file);
            var headerLine = reader.ReadLine();
            var headers = headerLine.Split(',').ToList().Select((v, i) => new { Position = i, Name = v });
            //var type = typeof(T);
            //Console.WriteLine(type + " type of T");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //Console.WriteLine(line + " line");
                var data = line.Split(',').ToList();

                Player p = new Player();
                p.name = data[0];
                p.team = data[1];
                p.role = data[2];
                p.matches = int.Parse(data[3]);
                p.runs = int.Parse(data[4]);
                p.average = double.Parse(data[5]);
                p.strike_rate = double.Parse(data[6]);
                p.wickets = int.Parse(data[7]);
                p.age = int.Parse(data[8]);

                list.Add(p);


            }

            return list;
        }

        //public static List<Team> GetData(string file_name)
        //{

        //}
    }
}
