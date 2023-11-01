namespace Task_03
{
    internal class Program
    {
        private static HashSet<int> numerals = new HashSet<int>();

        private static void ConsoleAdd()
        {
            Console.Write("Введите число: ");
            int num = int.Parse(Console.ReadLine());
            if (!InHashSet(numerals, num))
            {
                numerals.Add(num);
                Console.WriteLine("Число успешно сохранено.");
            }
            else
            {
                Console.WriteLine("Число уже вводилось ранее");
            }
        }

        private static bool InHashSet(HashSet<int> nums, int num)
        {
            return nums.Contains(num) ? true : false;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleAdd();
            }
        }
    }
}