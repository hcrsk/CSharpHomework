namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.ConsoleAddPerson();
            person.WritePerson();
        }
    }
}