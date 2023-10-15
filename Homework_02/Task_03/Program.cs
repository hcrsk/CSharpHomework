namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());
            bool isSimple = true;
            int i = 1; 

            if (number < 1)
                isSimple = false;
            else if (number == 1)
                isSimple = true;
            else
                while (isSimple) {
                    ++i;
                    if (number % i == 0) {
                        isSimple = false;
                        break;
                    }
                    else if (i + 1 == number)
                        break;
                }
            if (isSimple) Console.WriteLine($"Число {number} простое.");
            else Console.WriteLine($"Число {number} не простое.");
        }
    }
}