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
            try
            {
                if (!email.Contains("@mail.com"))
                    throw new EmailException("Geçersiz Email!");
            }
            catch(EmailException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
                

            Console.Write("Şirket: ");
            string sirket = Console.ReadLine();

            Console.Write("Telefon No (10 Haneli): ");
            string phoneNumber = Console.ReadLine();
            try
            {
                if (phoneNumber.Length != 10)
                    throw new InvalidOperationException("Telefon numarası 10 haneli olmalıdır '5071457817'.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
            }

            try
            {
                if (phoneNumber.Any(char.IsLetter))
                    throw new InvalidOperationException("Telefon numarası harf içermemelidir.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            Person person = personDb.SingleOrDefault(person => person.PhoneNumber == phoneNumber);

            try
            {
                if (person is not null)
                {
                    throw new InvalidOperationException("Rehberde bu numaraya sahip biri veya birileri bulunmaktadır. Bu yüzden numara kaydedilemedi.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
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

    public class EmailException : Exception
    {
        public EmailException() { }
        public EmailException(string message) : base(message)
        {
            
        }
    }
}
