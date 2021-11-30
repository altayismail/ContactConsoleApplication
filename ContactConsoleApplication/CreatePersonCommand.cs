using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsoleApplication
{
    public class CreatePersonCommand
    {
        public void Handle(List<Person> personDb)
        {
            Console.Write("İsim: ");
            string name = Console.ReadLine();
            Console.Write("Soyisim: ");
            string lastName = Console.ReadLine();

            Console.Write("Telefon No (10 Haneli): ");
            string phoneNumber = Console.ReadLine();
            if (phoneNumber.Length != 10)
            {
                Console.WriteLine("Girdiğiniz numara 10 haneli değil. Bu yüzden telefon numarası boş bırakılacak.");
                phoneNumber = null;
            }

            var person = personDb.SingleOrDefault(person => person.PhoneNumber == phoneNumber);
            bool control = true;
            if (person is not null)
            {
                Console.WriteLine("Rehberde bu numaraya sahip biri veya birileri bulunmaktadır. Bu yüzden numara kaydedilemedi.");
                control = false;
            }

            if (control)
            {
                Person newPerson = new Person()
                {
                    Name = ToTitleCase(name),
                    LastName = ToTitleCase(lastName),
                    PhoneNumber = phoneNumber
                };

                personDb.Add(newPerson);
                Console.WriteLine("Kişi başarılı bir şekilde kaydedildi.");
            }
            
        }
        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
