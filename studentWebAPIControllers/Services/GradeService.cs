namespace studentWebAPIControllers.Services;

public static class GradeService
{
    static List<Grade> Grades { get; }
    static int nextId = 1;
    static GradeService()
    {
        Grades = new List<Grade>();
        // {
        //     new Grade { GradeId = 1, GradeName = "A" },
        //      new Grade { GradeId = 2, GradeName = "B" }


        //  };
    }

    public static List<Grade> GetAll() => Grades;

    public static Grade? Get(int id) => Grades.FirstOrDefault(g => g.GradeId == id);

    public static void Add(Grade grade)
    {
        grade.GradeId = nextId++;
        Grades.Add(grade);
    }

    public static void Delete(int id)
    {
        var grade = Get(id);
        if (grade is null)
            return;

        Grades.Remove(grade);
    }

    public static void Update(Grade grade)
    {
        var index = Grades.FindIndex(g => g.GradeId == grade.GradeId);
        if (index == -1)
            return;

        Grades[index] = grade;
    }
}

