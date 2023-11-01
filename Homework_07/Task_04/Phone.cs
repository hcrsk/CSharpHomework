namespace Task_04
{
    public class Phone
    {
        public string MobilePhone { get; set; }
        public string FlatPhone { get; set; }

        public Phone(string mobilePhone, string flatPhone) {
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }
    }
}