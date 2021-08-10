using Hoard.Core.Entities.Games;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.Infrastructure.DataSeeding
{
    internal class Seeder : IDisposable
    {
        private readonly DataSeedingContext context;

        internal Seeder()
        {
            context = new DataSeedingContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        internal async Task SeedAsync()
        {
            if (await context.Database.CanConnectAsync())
            {
                Console.WriteLine("Connected to database...");

                //await SeedHoardersAsync();
                //await SeedPlatformDevelopersAsync();
                await SeedTestAsync();


                Console.WriteLine("Savings changes...");
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Database connection failed.");
            }
        }

        private async Task SeedTestAsync()
        {
            var hoarders = new List<Hoarder>
            {
                new Hoarder { ID = 98, Name = "TestPerson1" },
                new Hoarder { ID = 99, Name = "TestPerson2" }
            };

            Console.WriteLine("Adding TestHoarders...");
            await context.AddAsync(hoarders);
        }

        private async Task SeedHoardersAsync()
        {
            var hoarders = new List<Hoarder> 
            { 
                new Hoarder { ID = 1, Name = "Meintje" },
                new Hoarder { ID = 2, Name = "Bram" }
            };

            Console.WriteLine("Adding Hoarders...");
            await context.AddAsync(hoarders);
        }

        private async Task SeedPlatformDevelopersAsync()
        {
            var platformDevelopers = new List<PlatformDeveloper> 
            { 
               new PlatformDeveloper { ID = 1, Name = "Nintendo", OrdinalNumber = 1 },
               new PlatformDeveloper { ID = 2, Name = "Sony", OrdinalNumber = 2 },
               new PlatformDeveloper { ID = 3, Name = "Microsoft", OrdinalNumber = 3 },
               new PlatformDeveloper { ID = 4, Name = "Sega", OrdinalNumber = 4 },
               new PlatformDeveloper { ID = 5, Name = "Valve", OrdinalNumber = 5 },
               new PlatformDeveloper { ID = 6, Name = "Epic Games", OrdinalNumber = 6 }
            };

            Console.WriteLine("Adding PlatformDevelopers...");
            await context.AddAsync(platformDevelopers);
        }

        private async Task SeedExampleAsync()
        {
            var example = new List<String>
            {
                
            };

            Console.WriteLine("Adding example");
            await context.AddAsync(example);
        }
    }
}
