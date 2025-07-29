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
            string? userNameNullable = String.Empty;
            string userName = String.Empty;
            int userAge = 0;
            string? userEmailNullable = String.Empty;
            string userEmail = String.Empty;
           
            // Вводим и проверяем имя
            while (true)
            {
                Console.Write("Введите свое имя: ");
                userNameNullable = Console.ReadLine();
                if (!Validators.IsValidInput(userNameNullable))
                {
                    Console.WriteLine("Имя не дожно быть пустым, пожалуйста, введите корректное имя.");
                    continue;
                }
                else
                {
                    userName = userNameNullable!;
                    break;
                }
            }
            
            // Вводим и проверяем возраст
            while(true)
            {
                Console.Write("Введите свой возраст: ");
                var inputUserAge = Console.ReadLine();
                if (!Validators.IsValidAge(inputUserAge, out userAge))
                {
                    Console.WriteLine("Введите корректный возраст, от 1 до 130 лет.");
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
                userEmailNullable = Console.ReadLine();
                if (!Validators.IsValidInput(userEmailNullable))
                    {
                    Console.WriteLine("Введите адрес вашей электнонной почты");
                    continue;
                }
                if (!Validators.IsValidEmail(userEmailNullable))
                {
                    Console.WriteLine("Адрес электронной почты должен содержать один символ @ и как, как минимум, одну точку '.' и быть более 5 символов");
                    continue;
                }
                userEmail = userEmailNullable!;
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


            // выводим данные с выравниванием в табличке
            var maxFieldLength = userName.Length;
            if (userEmail.Length > maxFieldLength)
            {
                maxFieldLength = userEmail.Length;
            }
            var columnPadding = maxFieldLength + 2;
            var paddedName = userName.PadRight(columnPadding);
            var paddedEmail = userEmail.PadRight(columnPadding);
            var age = userAge.ToString();
            var paddedAge = age.PadRight(columnPadding);

            var descNamePadded = "Имя".PadRight(columnPadding);
            var descAgePadded = "Возраст".PadRight(columnPadding);
            var descEmailPadded = "Почта".PadRight(columnPadding);
            var headerNamePadded = "Поле".PadRight(columnPadding);
            var headerValuePadded = "Значение".PadRight(columnPadding);

            for (var i = 1; i <= ((columnPadding * 2) + 5); i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            Console.WriteLine($"| {headerNamePadded}| {headerValuePadded}|");
            for (var i = 1; i <= ((columnPadding * 2) + 5); i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            Console.WriteLine($"| {descNamePadded}| {paddedName}|");
            Console.WriteLine($"| {descAgePadded}| {paddedAge}|");
            Console.WriteLine($"| {descEmailPadded}| {paddedEmail}|");
            for (var i = 1; i <= ((columnPadding * 2) + 5); i++)
            {
                Console.Write('-');
            }
        }
    }
}
