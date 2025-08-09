using System.Net.Mail;

namespace les2_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Введите электронную почту: ");
                string? inputEmail = Console.ReadLine();
                if ((inputEmail is not null) && (inputEmail.Length > 5))
                {
                    string emailAddr = string.Empty;
                    string email = inputEmail.Trim();
                    try
                    {
                        
                        emailAddr = new MailAddress(email).Address; // Проверка корректности email
                    }
                    catch
                    {
                        Console.WriteLine("Почта ввредена не в корректном формате. ");
                        continue; // Возвращаемся к началу цикла, чтобы запросить email снова
                    }

                    if (emailAddr.Length > 5)
                    {
                        Console.WriteLine($"Электронная почта {emailAddr} была введена корректно.");
                        break; // Выходим из цикла, если email введен корректно
                    }
                }
                else
                {
                    Console.WriteLine("Вы не ввели электронную почту.");
                    continue; // Возвращаемся к началу цикла, чтобы запросить email снова
                }
            }

        }
    }
}
