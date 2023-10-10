namespace CSharpHomework
{
    internal class Homework1
    {
        static void Main(string[] args)
        {
            string fullName = "Vladislav Vyacheslavovich Lavrinenko";
            byte age = 24;
            string email = "mitelvlad99sea@gmail.com";
            float MathUniversalStateExamPoints = 64F;
            float InformaticsUniversalStateExamPoints = 82F;
            float PhysicsUniversalStateExamPoints = 49F;

            Console.WriteLine(string.Format("Меня зовут {0}, мне {1} года.", fullName, age));
            Console.ReadKey();
        }
    }
}