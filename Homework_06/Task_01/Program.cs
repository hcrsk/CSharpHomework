namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.GetWorkerById(3);
            Console.ReadKey();
        }
    }
}