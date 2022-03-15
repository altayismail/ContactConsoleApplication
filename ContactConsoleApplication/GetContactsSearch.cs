using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsoleApplication.Entities
{
    public class GetContactsSearch
    {
        public void Handle(List<Person> peopleDb)
        {
            while (true)
            {
                Console.Write("Search: ");
                string search = Console.ReadLine();

                foreach (var person in peopleDb)
                {
                    if ((person.Name.ToLower() + person.LastName.ToLower()).Contains(search.ToLower()))
                        PrintPersonDetail(person);
                }

                break;
            }
        }

        public void PrintPersonDetail(Person person)
        {
            Console.WriteLine("__________________________________");
            Console.WriteLine($"Ad        : {person.Name}");
            Console.WriteLine($"Soyad     : {person.LastName}");
            Console.WriteLine($"Telefon No: {person.PhoneNumber}");
            Console.WriteLine($"Şirket    : {person.Company}");
            Console.WriteLine($"Email     : {person.Email}");
            Console.WriteLine("__________________________________");
        }
    }
}
