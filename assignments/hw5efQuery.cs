using EFCoreScaffolding.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreScaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

            var config = configuration.Build();

            var connectionString = config.GetConnectionString("NorthwindDbConnection");

            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                .UseLazyLoadingProxies()
                                .UseSqlServer(connectionString)
                                .Options;

            var dbContext = new NorthwindContext(options);

            var customer = dbContext.Customers.Include(c => c.Orders).FirstOrDefault();


            //1
            var userId = 1;
            var employees = dbContext.Employees.Where(e => e.EmployeeId == userId).Include(e => e.Territories);
            foreach (var e in employees)
            {
                foreach (var x in e.Territories)
                {
                    Console.WriteLine(x.TerritoryDescription);
                }
            }

           //3
            var productName = dbContext.Invoices.Select(x => new
            {
                productname = x.ProductName,
                shipcountry = x.ShipCountry

            }).ToList();
            foreach (var x in productName)
            {
                Console.WriteLine(x.productname + " " + x.shipcountry);

            }
            //4
            Console.WriteLine("products"+"total quantity of product sold" + "total money earned");
            var details = dbContext.OrderDetails.Select(x => new
            {
                productid = x.ProductId,
                quantity = x.Quantity,
                moneyearned = (double)(x.UnitPrice) * (1 - (x.Discount / 100.0)) * (x.Quantity)

            }).ToList();
            foreach (var x in details)            {
                Console.WriteLine(x.productid + " " + x.quantity+ " "+x.moneyearned);

            }
            //var employees = dbContext.Employees.Where(e => e.EmployeeId == userId);
            //foreach (var e in employees)
            //{
            //    foreach (var x in e.Territories)
            //    {
            //        Console.WriteLine(x.TerritoryDescription);
            //    }
            //}
        }
    }
}