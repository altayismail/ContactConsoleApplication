using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsoleApplication
{
    class DeletePersonCommand
    {
        public void Handle(List<Person> personDb)
        {
            while (true)
            {
                Console.WriteLine("Numarasını silmek istediğiniz kişinin adını ve soyadını giriniz.");
                Console.Write("İsim: ");
                string name = Console.ReadLine();
                Console.Write("Soyisim: ");
                string lastName = Console.ReadLine();

                var person = personDb.SingleOrDefault(person => person.Name.ToLower() == name.ToLower() && person.LastName.ToLower() == lastName.ToLower());
                if (person is null)
                {
                    Console.WriteLine("Silinecek ilgili kişi bulunamadı. Lütfen bir seçim yapınız.\n" +
                        "(1) Silme işlemini sonlandır\n" +
                        "(2) Yeniden Dene");
                    Console.Write("Seçim: ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                        break;
                    else if (choice == 2)
                        continue;
                }
                else if(person is not null)
                {
                    Console.Write($"{ToTitleCase(name)} {ToTitleCase(lastName)} adlı kişi rehberden siliniyor. Emin misiniz? Evet(e) veya Hayır(h): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "e")
                    {
                        personDb.Remove(person);
                        Console.WriteLine("Kişi rehberden başarılı bir şekilde silindi.");
                    }
                    else if (choice.ToLower() == "h")
                    {
                        Console.WriteLine("Silme işlemi iptal edildi. Menüye dönülüyor.");
                        break;
                    }
                    else
                        Console.WriteLine("Hatalı giriş yaptınız, menüye dönülüyor...");
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
