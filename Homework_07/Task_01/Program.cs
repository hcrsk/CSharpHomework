

namespace Task_01
{
    internal class Program
    {
        public static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(101));
            }
            PrintList(list);

            list.Remove(0);
            PrintList(list);

        }
    }
}