namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity;
            int minValue = int.MaxValue;

            Console.Write("Введите длину последовательности: ");
            quantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantity; i++)
            {
                Console.Write($"Введите {i + 1} число: ");
                int value = int.Parse(Console.ReadLine());
                if (value < minValue) minValue = value;
            }
            Console.WriteLine($"Наименьшее число из последовательности {minValue}."); ;
        }
    }
}