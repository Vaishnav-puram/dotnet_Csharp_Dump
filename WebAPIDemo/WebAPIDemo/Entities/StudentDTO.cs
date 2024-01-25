namespace WebAPIDemo.Entities
{
    public class StudentDTO
    {
        public required string Fullname { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public double Percentage { get; set; }
        public string College { get; set; }
    }
}
