using System.Globalization;

namespace Task_01
{
    internal struct Worker
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }

        public Worker(int id, DateTime CreateTime, string fullname, int age, int height, DateTime birthDate, string birthPlace)
        {
            this.Id = id;
            this.CreateTime = CreateTime;
            this.Fullname = fullname;
            this.Age = age;
            this.Height = height;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
        }
        public Worker(int id) :
            this(id, DateTime.Now, String.Empty, 0, 0, new DateTime(1900, 1, 1, 0, 0, 0), String.Empty)
        {
        }

        public Worker(string[] data) :
            this(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToDateTime(data[5]), data[6])
        {
        }
    }
}
