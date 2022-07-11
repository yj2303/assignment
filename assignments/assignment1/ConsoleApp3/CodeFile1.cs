using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleAppConditionalLinq
{
    public static class LINQExtensions
    {
        public static IQueryable<T> If<T>(
            this IQueryable<T> query,
            bool should,
            params Func<IQueryable<T>, IQueryable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }

        public static IEnumerable<T> If<T>(
            this IEnumerable<T> query,
            bool should,
            params Func<IEnumerable<T>, IEnumerable<T>>[] transforms)
        {
            return should
                ? transforms.Aggregate(query,
                    (current, transform) => transform.Invoke(current))
                : query;
        }
    }

    class DataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool SexIsFemale { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int SocialSecurityNr { get; set; }
    }

    class Program
    {
        // data to be searched
        static List<string> theData;

        // search for this&that Y/N
        static bool searchForFirstName = false;
        static bool searchForLastName = false;
        static bool searchForOnlyFemale = true;
        static bool searchForYearOfBirthGreaterThan = true;
        static bool searchForSocialSecurityGreaterThan = true;

        // search"terms"
        static string searchTermFirstName = "Fox";
        static string searchTermLastName = "Mulder";
        static int searchTermYearOfBirth = 1980;
        static int searchTermSocialSecNr = 420000;

        static void Main(string[] args)
        {
            PopulateAndFilterData();
            DisplayData(theData);

            Console.WriteLine("");
            Console.WriteLine("now search with searchForOnlyFemale set to FALSE:");
            Console.WriteLine("");

            // now don't only search exclusive for women
            searchForOnlyFemale = false;
            PopulateAndFilterData();
            DisplayData(theData);

            Console.WriteLine("");
            Console.WriteLine("now search for LastName='Smith'");
            Console.WriteLine("");

            // now only search for lastname like('Smith') and soc.sec.nr > 300000
            searchForFirstName = false;
            searchForLastName = true;
            searchForOnlyFemale = false;
            searchForYearOfBirthGreaterThan = false;
            searchForSocialSecurityGreaterThan = true;

            searchTermLastName = "Smith";
            searchTermSocialSecNr = 300000;

            PopulateAndFilterData();
            DisplayData(theData);

            Console.ReadKey();
        }

        static void PopulateAndFilterData()
        {
            theData = PopulateData();
            theData = theData.If(searchForFirstName,
                            q => q.Where(_ => _.FirstName == searchTermFirstName))
                      .If(searchForLastName,
                            q => q.Where(_ => _.LastName == searchTermLastName))
                      .If(searchForOnlyFemale,
                            q => q.Where(_ => _.SexIsFemale))
                      .If(searchForYearOfBirthGreaterThan,
                            q => q.Where(_ => _.DayOfBirth.Year > searchTermYearOfBirth))
                      .If(searchForSocialSecurityGreaterThan,
                            q => q.Where(_ => _.SocialSecurityNr > searchTermSocialSecNr))
                      .ToList();
        }

        static List<string> PopulateData()
        {
            List<string> res = new List<string>();
            res = (List<string>)File.ReadLines(@"IPL_2021_data.csv");



            return res;
        }

        static void DisplayData(List<DataModel> data)
        {
            foreach (var d in data)
            {
                Console.Write($"{d.FirstName} {d.LastName}");
                Console.Write($" born in {d.DayOfBirth.Year}");
                Console.Write($" with SocSecNr {d.SocialSecurityNr}");
                Console.WriteLine($" (is female: {d.SexIsFemale})");
            }
        }
    }
}