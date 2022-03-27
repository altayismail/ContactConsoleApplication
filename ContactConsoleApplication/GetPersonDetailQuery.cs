using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ContactConsoleApplication
{
    class GetPersonDetailQuery
    {
        public void Handle(List<Person> personDb)
        {
            while (true)
            {
                Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n" +
                "(1) Ad ve Soyada Göre\n" +
                "(2) Telefon Numarasına Göre");
                Console.Write("Seçim: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("İsim: ");
                    string name = Console.ReadLine();
                    Console.Write("Soyisim: ");
                    string lastName = Console.ReadLine();

                    var person = personDb.FirstOrDefault(person => person.Name.ToLower() == name.ToLower() && person.LastName.ToLower() == lastName.ToLower());
                    if (person is null)
                    {
                        Console.WriteLine($"{ToTitleCase(name)} {ToTitleCase(lastName)} adlı kişi rehberde bulunmamaktadır. Menüye dönülüyor...");
                        break;
                    }
                    else if(person is not null)
                    {
                        PrintPersonInfo(person);
                        break;
                    }

                }
                else if (choice == 2)
                {
                    Console.Write("Telefon No: ");
                    string phoneNumber = Console.ReadLine();
                    var person = personDb.FirstOrDefault(person => person.PhoneNumber == phoneNumber);
                    if(person is null)
                    {
                        Console.WriteLine($"{phoneNumber} numarasına sahip kişi rehberde bulunmamaktadır. Menüye dönülüyor...");
                        break;
                    }
                    else if(person is not null)
                    {
                        PrintPersonInfo(person);
                        break;
                    }
                }
            }
        }

        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public void PrintPersonInfo(Person person)
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
