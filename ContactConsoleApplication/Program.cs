using System;
using System.Collections.Generic;

namespace ContactConsoleApplication
{
    class Program
    {
         public static void Main(string[] args)
        {
            while (true)
            {
                MenuScript();

                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreatePersonCommand createPerson = new();
                        createPerson.Handle(PeopleDb);
                        break;
                    case 2:
                        DeletePersonCommand deletePerson = new();
                        deletePerson.Handle(PeopleDb);
                        break;
                    case 3:
                        UpdateNumberCommand updateNumber = new();
                        updateNumber.Handle(PeopleDb);
                        break;
                    case 4:
                        GetPersonsQuery query = new();
                        query.Handle(PeopleDb);
                        break;
                    case 5:
                        GetPersonDetailQuery detailQuery = new();
                        detailQuery.Handle(PeopleDb);
                        break;
                    default:
                        Console.WriteLine("Hatalı işlem yaptınız, tekrar deneyiniz.");
                        break;
                }
                
            }
        }

        public static void MenuScript()
        {
            Console.WriteLine("************************************\n" +
                              "(1) Rehbere Numara Kaydet\n" +
                              "(2) Rehberden Numara Sil\n" +
                              "(3) Rehberden Numara Güncelle\n" +
                              "(4) Rehberi Listele\n" +
                              "(5) Rehberden Kişi Ara\n" +
                              "*************************************");
        }

        public static List<Person> PeopleDb = new List<Person>()
        {
            new Person
            {
                Name = "Ismail",
                LastName = "Altay",
                PhoneNumber = "5071457816"
            },
            new Person
            {
                Name = "Gurkan",
                LastName = "Bollukcu",
                PhoneNumber = "5071457817"
            },
            new Person
            {
                Name = "Bora",
                LastName = "Altay",
                PhoneNumber = "5071457818"
            }
        };
    }
}
