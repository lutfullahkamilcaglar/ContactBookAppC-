
using System;
using System.Net.Mail;

namespace MyProject.infrastructure
{
    internal class InputManagerImpl : IInputManager

    {
        public int GetInt()
        {
            int value = Convert.ToInt32(Console.ReadLine());
            return value;
        }

        public string GetString()
        {
            return Console.ReadLine()!;
        }

        public string GetStringWithDescription(string message = "")
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public DateTime DateTime(string birthDate)
        {
            Console.WriteLine(birthDate);
            return Convert.ToDateTime(Console.ReadLine());
        }

        public string GetValidEmailAddress(string message)
        {
            string email = message;
            do {
                Console.Write("Enter an email address: ");
                email = Console.ReadLine();
                MailAddress address;
                if (MailAddress.TryCreate(email, out address)) {
                    break;
                } else {
                    Console.WriteLine("Invalid email address. Please try again.");
                }
            } while (true);

            return email;
        }

        public int GetPhoneNumberWithDescription(string message)
        {
            bool parseSuccess;
            int result;
            do
            {
                Console.WriteLine(message);
                var userInput = Console.ReadLine();
                parseSuccess = int.TryParse(userInput, out result);
            } while (!parseSuccess);
            return result;
        }
        
        public int GetIntWithDescription(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}