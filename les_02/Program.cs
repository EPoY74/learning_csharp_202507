namespace les_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите Имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите Возраст: ");
            var ageInput = Console.ReadLine();
            var age = int.Parse(ageInput);
            if (age < 18)
            {
                Console.WriteLine($"{name}, вам еще рано");
            }
            else
            {
                Console.WriteLine($"{name}, добро пожаловать!");
            }
        }
    }
}
