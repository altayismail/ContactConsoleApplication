using ContactConsoleApplication.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactConsoleApplication
{
    class Program
    {
         public static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LINQDBContext _context = new();
            List<Person> PersonDb = _context.People.ToList<Person>();

            while (true)
            {
                MenuScript();

                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreatePersonCommand createPerson = new();
                        createPerson.Handle(PersonDb);
                        break;
                    case 2:
                        DeletePersonCommand deletePerson = new();
                        deletePerson.Handle(PersonDb);
                        break;
                    case 3:
                        UpdateNumberCommand updateNumber = new();
                        updateNumber.Handle(PersonDb);
                        break;
                    case 4:
                        GetPersonsQuery query = new();
                        query.Handle(PersonDb);
                        break;
                    case 5:
                        GetPersonDetailQuery detailQuery = new();
                        detailQuery.Handle(PersonDb);
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
    }
}
