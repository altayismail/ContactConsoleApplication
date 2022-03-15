using System;
using System.Collections.Generic;

namespace ContactConsoleApplication
{
    class GetPersonsQuery
    {
        public void Handle(List<Person> peopleDb)
        {
            foreach(var person in peopleDb)
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
}
