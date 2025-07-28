namespace les_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name = string.Empty;
            while (true)
            {
                
                Console.Write("Введите Имя: ");
                name = Console.ReadLine();
                if ((name == null) || (name.Length < 1))
                {                     
                    Console.WriteLine("Вы не ввели имя.");
                    continue; // Возвращаемся к началу цикла, чтобы запросить имя снова
                }
                else
                {
                    break; // Выходим из цикла, если имя введено корректно
                }
            }
           
            while (true)
            {
                Console.Write("Введите Возраст: ");
                var ageInput = Console.ReadLine();

                if ((ageInput == null) || (ageInput.Length == 0))
                {
                    Console.WriteLine("Вы не ввели возраст.");
                    continue; // Возвращаемся к началу цикла, чтобы запросить возраст снова
                }
                if (!int.TryParse(ageInput, out int age) || (age > 140) || (age < 1))
                {
                    // Если не удалось преобразовать строку в число или число вне допустимого диапазона
                    {
                        Console.WriteLine("Ошибка: введите корректный возраст (от 1 до 140)");
                        continue; // Возвращаемся к началу цикла, чтобы запросить возраст снова
                    }
                }
                else
                {
                    if (age < 18)
                    {
                        Console.WriteLine($"{name}, вам еще рано");
                    }
                    else
                    {
                        Console.WriteLine($"{name}, добро пожаловать!");
                    }
                    break; // Выходим из цикла, если возраст введен корректно
                }
            }
            
        }

    }
 }


