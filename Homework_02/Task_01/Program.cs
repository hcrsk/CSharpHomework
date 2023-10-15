namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0) Console.WriteLine($"Число {number} чётное");
            else Console.WriteLine($"Число {number} не чётное");
        }
    }
}