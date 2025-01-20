namespace studentWebAPIControllers
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        public int? Height { get; set; }
        public float? Weight { get; set; }
        public int GradeId { get; set; }


    }
}
