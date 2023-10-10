using System.Xml.Linq;

namespace CSharpHomework
{
    internal class program
    {
        static void Main(string[] args)
        {
            string fullName = "Лавриненко Владислав Вячеславович";
            byte age = 24;
            string email = "mitelvlad99sea@gmail.com";

            string pattern = "Меня зовут {0}, мне {1} года.\nМой электронный почтовый ящик {2}";

            Console.WriteLine(pattern, fullName, age, email);

            float mathPoints = 64F; 
            float informaticsPoints = 82F; 
            float physicsPoints = 49F; 
            
            string math = "Математика", informatics = "Информатика", physics = "Физика";
            string points = "Баллы по ЕГЭ", subject = "Предмет";

            Console.WriteLine($"\n{subject, 12} {points}");
            Console.WriteLine($"{math, 12} " + mathPoints.ToString("#"));
            Console.WriteLine($"{informatics, 12} " + informaticsPoints.ToString("#"));
            Console.WriteLine($"{physics, 12} " + physicsPoints.ToString("#"));
                        
            Console.ReadKey();
        }
    }
}
