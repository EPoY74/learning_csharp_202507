namespace user_profile.Models
{
    public class User
    {
        // объявляем атрибуты экземплара класса
        public string Name { get; }
        public int Age { get; }
        public string Email { get; }


        // ИНициализинуем экземпляр
        public User(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;

        }
        //Переопределяем ToString - можно сделать красивый вывод, как мы хотим
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст {Age}, E-mail: {Email}";
        }
    }
}
