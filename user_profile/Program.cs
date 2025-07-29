//Текущее задание — Анкета с валидацией
//📋 Техническое задание (ТЗ):
//Пользователь вводит с клавиатуры:
//Имя — не пустое.
//Возраст — число от 1 до 140.
//Email — должен содержать ровно один символ @.

//⚙️ Программа должна:
//📌 Проверять каждый ввод отдельно и повторно запрашивать, если данные некорректны.
//📌 После успешного ввода всех данных — создать анкету пользователя.
//📌 Вывести результат в виде JSON или таблицей (на выбор).

//🧠 Цель:
//Научиться писать валидацию пользовательского ввода.
//Привить привычку проверять данные, прежде чем их использовать.
//Подготовиться к следующему шагу — ООП и сериализация.
using System.Text.Json;


namespace user_profile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? userName = String.Empty;
            int userAge = 0;
            string? userEmail = String.Empty;
           
            // Вводим и проверяем имя
            while (true)
            {
                Console.Write("Введите свое имя: ");
                userName = Console.ReadLine();
                if ((userName is null) || (userName.Length <  1))
                {
                    Console.WriteLine("Имя не дожно быть пустым, пожалуйста, введите корректное имя.");
                    continue;
                }
                else
                {
                    break;
                }
            }
            
            // Вводим и проверяем возраст
            while(true)
            {
                Console.Write("Введите свой возраст: ");
                var inputUserAge = Console.ReadLine();
                if ((inputUserAge is null) 
                    || (inputUserAge.Length == 0)
                    )
                {
                    Console.WriteLine("Вы ничего не ввели, пожалуйста, введите возраст");
                    continue;
                }
                if (!int.TryParse(inputUserAge, out userAge)
                    || (userAge > 140)
                    || (userAge < 1)
                    )
                {
                    Console.WriteLine("Введите корректный возраст, от 1 до 140 лет.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            // Вводим и "проверяем" адрес элекстронной почты
            while (true)
            {
                Console.Write("Введите свою электронную почту: ");
                userEmail = Console.ReadLine();
                if ( (userEmail is null)
                    || (userEmail.Length < 1))
                    {
                    Console.WriteLine("Введите адрес вашей электнонной почты");
                    continue;
                }
                if (!userEmail.Any(c => c == '@'))
                {
                    Console.WriteLine("Адрес электронной почты должен содержать символ @.");
                    continue;
                }
                if ((userEmail.Count(c => c == '@') > 1))
                {
                    Console.WriteLine("Адрес электронной почты должен содержать только 1 символ @.");
                    continue;
                }
                if (!userEmail.Any(c => c == '.'))
                {
                    Console.WriteLine("Адреc электронной почты должен иметь '.' ");
                    continue;
                }
                break;
            }

            // Выводим полученные данные на экран
            // Создаю анонимный объект 
            var userData = new
            {
                Name = userName,
                Age = userAge,
                Email = userEmail
            };


            // Сериализуем анонимный объект
            var outputData = JsonSerializer.Serialize(userData);

            Console.WriteLine(outputData);
        }
    }
}
