using System;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.DataSeeding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you sure you wish to seed HoardDb? Y/N");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                try
                {
                    Task t = SeedDatabase();
                    t.Wait();

                    Console.WriteLine("Database seed succeeded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database seed failed.");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Database seed cancelled.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static async Task SeedDatabase()
        {
            using (var seeder = new Seeder())
            {
                await seeder.SeedAsync();
            }
        }
    }
}
