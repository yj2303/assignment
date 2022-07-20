using Assignment_2.Models;
//using BenchmarkDotNet.Exporters.Csv;
using System;
using System.Collections.Generic;
using System.Globalization;
//using System.Globalization;
using System.Linq;
using System.Text;
//using System.Object;
//using System.Threading.Tasks;

namespace Assignment_2.OperationEntities
{
    public class Class1
    {
        public void m()
        {
            List<Coin> coins = new List<Coin>();
            List<Trader> traders = new List<Trader>();
            //ch
            var reader = new StreamReader(@"C:\Users\Admin\Source\Repos\KDU-Dotnet-Backend\Assignment-2\Files\coins.csv");
            var csv = new CsvHelper.CsvReader(reader,CultureInfo.InvariantCulture);
            coins = csv.GetRecords<Coin>().ToList();

            var reader1 = new StreamReader(@"C:\Users\Admin\source\repos\KDU-Dotnet-Backend\Assignment-2\Files\traders.csv");
            var csv1 = new CsvHelper.CsvReader(reader1, CultureInfo.InvariantCulture);
            traders = csv1.GetRecords<Trader>()
                                .ToList();
        }

    }
}
