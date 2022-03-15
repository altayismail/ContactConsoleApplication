using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

            Console.Write("Email: ");
            string email = Console.ReadLine();
            if (!email.Contains("@mail.com"))
                throw new InvalidOperationException("Geçersiz email.");

            Console.Write("Şirket: ");
            string sirket = Console.ReadLine();

            Console.Write("Telefon No (10 Haneli): ");
            string phoneNumber = Console.ReadLine();
            if (phoneNumber.Length != 10)
                throw new InvalidOperationException("Telefon numarası 10 haneli olmalıdır '5071457817'.");
            if(phoneNumber.Any(char.IsLetter))
                throw new InvalidOperationException("Telefon numarası harf içermemelidir.");

            Person person = personDb.SingleOrDefault(person => person.PhoneNumber == phoneNumber);

            if (person is not null)
            {
                throw new InvalidOperationException("Rehberde bu numaraya sahip biri veya birileri bulunmaktadır. Bu yüzden numara kaydedilemedi.");
            }

            Person newPerson = new Person()
            {
                Name = ToTitleCase(name),
                LastName = ToTitleCase(lastName),
                PhoneNumber = phoneNumber,
                Email = email,
                Company = sirket

            };

            personDb.Add(newPerson);
            Console.WriteLine("Kişi başarılı bir şekilde kaydedildi.");

        }
        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
