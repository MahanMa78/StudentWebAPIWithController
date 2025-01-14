
public class Grade
{
    //public Grade()
    //{
        //Students = new List<Student>();
    //}

    public int GradeId { get; set; }
    public string? GradeName { get; set; }
    public ICollection<Student>? Students { get; set; }

    //public IList<Student>? Students { get; set; }
    //public int StudentId { get; set; }
    //public Student? Student { get; set; }
}
