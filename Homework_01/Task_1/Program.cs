using System.Xml.Linq;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Лавриненко Владислав Вячеславович";
            byte age = 24;
            string email = "mitelvlad99sea@gmail.com";
            string pattern = "Меня зовут {0}, мне {1} года.\nМой электронный почтовый ящик {2}\n";
            float mathPoints = 64F;
            float informaticsPoints = 83F;
            float physicsPoints = 49F;

            Console.WriteLine(pattern, fullName, age, email);

            
            float sumPoints = mathPoints + informaticsPoints + physicsPoints;
            float averagePoints = (sumPoints) / 3;
            pattern = "{0,12} {1,13}";
            Console.ReadKey();
            Console.WriteLine(pattern, "Предмет", "Баллы по ЕГЭ");
            Console.WriteLine(pattern, "Математика", mathPoints.ToString("#"));
            Console.WriteLine(pattern, "Информатика", informaticsPoints.ToString("#"));
            Console.WriteLine(pattern, "Физика", physicsPoints.ToString("#"));

            Console.ReadKey();
            Console.WriteLine("\nСумма баллов: " + sumPoints.ToString("#"));
            Console.WriteLine("Средний балл: " + averagePoints.ToString("#.##"));
            Console.ReadKey();
        }
    }
}
