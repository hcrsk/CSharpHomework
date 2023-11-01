namespace Task_02
{
    public static class ExtendDictionary
    {
        public static void Add(this Dictionary<int, string> PhoneBook)
        {
            Console.WriteLine("Введите ");
            Console.WriteLine();
            PhoneBook.Add(number, Fullname);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> PhoneBook = new Dictionary<int, string>(); 
        }
    }
}