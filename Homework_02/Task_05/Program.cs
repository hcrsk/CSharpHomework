namespace Task_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Введите максимальное целое число диапазона: ");

            int maxNumber = int.Parse(Console.ReadLine());
            int secretNumber = random.Next(maxNumber);

            do
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                int estimatedNumber;
                if (input == "") {
                    Console.WriteLine($"Было загадано число {secretNumber}!");
                    break;
                }
                else
                {
                    estimatedNumber = Convert.ToInt32(input);
                    if (secretNumber == estimatedNumber)
                    {
                        Console.WriteLine($"Вы угадали! Загаданное число {secretNumber}");
                        break;
                    }
                    else if (secretNumber > estimatedNumber)
                        Console.WriteLine("Введенное число больше загаданного!");
                    else
                        Console.WriteLine("Введенное число меньше загаданного!");
                }
            }
            while (true);
        }
    }
}