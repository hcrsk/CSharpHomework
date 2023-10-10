namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float mathPoints = 64F;
            float informaticsPoints = 83F;
            float physicsPoints = 49F;

            float sumPoints = mathPoints + informaticsPoints + physicsPoints;
            float averagePoints = (sumPoints) / 3;

            Console.WriteLine("Сумма баллов: " + sumPoints.ToString("#.##"));
            Console.ReadKey();
            Console.WriteLine("Средний балл: " + averagePoints.ToString("#.##"));

        }
    }
}