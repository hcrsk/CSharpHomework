namespace Task_04
{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }

        public Address(string street, string houseNumber, string flatNumber) {
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }
    }
}