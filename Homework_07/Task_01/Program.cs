namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.GetRandomList(100);
            list.PrintList();
            Console.Write("\n\n");
            Console.ReadKey();
            list.RemoveAll(n => (n > 25 && n < 50));
            list.PrintList();
            Console.ReadKey();
        }
    }
}