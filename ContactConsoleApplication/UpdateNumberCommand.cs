using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ContactConsoleApplication
{
    public class UpdateNumberCommand
    {
        public void Handle(List<Person> personDb)
        {
            while (true)
            {
                Console.WriteLine("Numarasını güncellemek istediğiniz kişinin adını ve soyadını giriniz.");
                Console.Write("İsim: ");
                string name = Console.ReadLine();
                Console.Write("Soyisim: ");
                string lastName = Console.ReadLine();

                var person = personDb.SingleOrDefault(person => person.Name.ToLower() == name.ToLower() && person.LastName.ToLower() == lastName.ToLower());

                if (person is null)
                {
                    Console.WriteLine("Güncellencek ilgili kişi bulunamadı. Lütfen bir seçim yapınız.\n" +
                        "(1) Güncelleme işlemini sonlandır\n" +
                        "(2) Yeniden Dene");
                    Console.Write("Seçim: ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                        break;
                    else if (choice == 2)
                        continue;
                }
                else if (person is not null)
                {
                    Console.WriteLine($"{ToTitleCase(name)} {ToTitleCase(lastName)} rehberde bulundu. Lütfen yeni telefon numarasını giriniz.");
                    Console.Write("Telefon No: ");
                    string phoneNumber = Console.ReadLine();
                    if(personDb.Any<Person>(x => x.PhoneNumber == phoneNumber))
                    {
                        Console.Write("Güncellemek istediğiniz numara zaten bulunmaktadır.\n" +
                            "(1) Güncelleme işlemini sonlandır\n" +
                            "(2) Güncelleme işlemini tekrar dene\n" +
                            "Seçim : ");
                        int choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                            break;
                        else if (choice == 2)
                            continue;
                    }
                    person.PhoneNumber = phoneNumber;
                    Console.WriteLine($"{ToTitleCase(name)} {ToTitleCase(lastName)} adlı kişinin numarası başarılı bir şekilde güncellendi.");
                    break;
                }
            }
        }

        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
