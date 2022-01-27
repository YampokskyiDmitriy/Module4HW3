using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Module4HW3
{
    public class Starter
    {
        public void Run()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.
                UseSqlServer(connectionString)
                .Options;

            using (var db = new ApplicationDbContext(options))
            {
                var req = new Requests(db);
                req.FirstRequest().GetAwaiter().GetResult();
                req.SecondRequest().GetAwaiter().GetResult();
                req.ThirdRequest().GetAwaiter().GetResult();
                req.FourthRequest().GetAwaiter().GetResult();
                req.FifthRequest().GetAwaiter().GetResult();
                req.SixthRequest().GetAwaiter().GetResult();
            }

            System.Console.ReadLine();
        }
    }
}
