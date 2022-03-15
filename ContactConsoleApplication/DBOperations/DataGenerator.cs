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
                    PhoneNumber = "5071457816",
                    Email = "ismailaltay@mail.com",
                    Company = "IYTE"
                },
                new Person()
                {
                    Name = "Gurkan",
                    LastName = "Bollukcu",
                    PhoneNumber = "5071457817",
                    Email = "gurkanbollukcu@mail.com",
                    Company = null
                },
                new Person()
                {
                    Name = "Bora",
                    LastName = "Altay",
                    PhoneNumber = "5071457818",
                    Email = "boraaltay@mail.com",
                    Company = "OAL"
                }
                );
                context.SaveChanges();
            };
        }
    }
}
