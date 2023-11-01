using System.Numerics;

namespace Task_02
{
    internal class Program
    {
        private static Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

        private static void FillPhoneBook()
        {
            string phone = "not empty";

            while (true)
            {
                Console.Write("Введите номер телефона: ");
                phone = Console.ReadLine();
                if (phone != "")
                {
                    Console.Write("Введите Ф.И.О.: ");
                    string fullname = Console.ReadLine();
                    PhoneBook.Add(phone, fullname);
                }
                else
                {
                    break;
                }
            }
        }

        private static void FindByNumber()
        {
            Console.Write("Найти владельца по введенному номеру телефона: ");
            string phone = Console.ReadLine();
            string owner;
            if (PhoneBook.TryGetValue(phone, out owner))
            {
                Console.WriteLine($"{owner} - владелец {phone}");
            }
            else
            {
                Console.WriteLine("Владелец не найден!");
            }
        }

        static void Main(string[] args)
        {
            FillPhoneBook();
            FindByNumber();
        }
    }
}