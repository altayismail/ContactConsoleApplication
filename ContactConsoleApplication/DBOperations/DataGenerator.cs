using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsoleApplication.DBOperations
{
    class DataGenerator
    {
        public static void Initialize()
        {
            using(var context = new LINQDBContext())
            {
                if (context.People.Any())
                    return;

                context.People.AddRange
                (
                new Person()
                {
                    Name = "Ismail",
                    LastName = "Altay",
                    PhoneNumber = "5071457816"
                },
                new Person()
                {
                    Name = "Gurkan",
                    LastName = "Bollukcu",
                    PhoneNumber = "5071457817"
                },
                new Person()
                {
                    Name = "Bora",
                    LastName = "Altay",
                    PhoneNumber = "5071457818"
                }
                );
                context.SaveChanges();
            };
        }
    }
}
