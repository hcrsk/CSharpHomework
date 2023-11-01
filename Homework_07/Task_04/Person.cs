using System.Xml.Linq;

namespace Task_04
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }

        public Person(string name, Address address, Phone phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public static Person ConsoleAddPerson()
        {
            Console.Write("Введите Ф.И.О: ");
            string name = Console.ReadLine();
            Console.Write("Введите улицу: ");
            string street = Console.ReadLine();
            Console.Write("Введите номер дома: ");
            string houseNumber = Console.ReadLine();
            Console.Write("Введите номер квартиры: ");
            string flatNumber = Console.ReadLine();
            Console.Write("Введите номер мобильного телефона: ");
            string mobilePhone = Console.ReadLine();
            Console.Write("Введите номер домашнего телефона: ");
            string flatPhone = Console.ReadLine();
            return new Person(name, new Address(street, houseNumber, flatNumber), new Phone(mobilePhone, flatPhone));
        }

        public void WritePerson(string path)
        {
            using (StreamWriter addPerson = new StreamWriter("Person.xml"))
            {
                XElement xPerson = new XElement("Person",
                    new XElement("Address",
                        new XElement("Street", this.Address.Street),
                        new XElement("HouseNumber", this.Address.HouseNumber),
                        new XElement("FlatNumber", this.Address.FlatNumber)
                    ),
                    new XElement("Phones",
                        new XElement("MobilePhone", this.Phone.MobilePhone),
                        new XElement("FlatPhone", this.Phone.FlatPhone)
                    )
                );
                xPerson.Add(new XAttribute("name", this.Name));
                addPerson.Write(xPerson);
            }
        }

        public void WritePerson()
        {
            WritePerson("Person.xml");
        }

    }
}