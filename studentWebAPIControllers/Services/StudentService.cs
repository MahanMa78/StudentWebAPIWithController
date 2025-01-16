//using System.Xml.Linq;
////using studentWebAPIControllers.Models;
//namespace studentWebAPIControllers.Services;

//public static class StudentService
//{
//    static List<Student> Students { get; }
//    static int nextId = 1;
//    static StudentService()
//    {
//        Students= new List<Student>();
//        // {
//        //     new Student
//        //     {
//        //         Id = 1,
//        //         FirstName = "Mahan",
//        //         LastName = "Mazaheri",
//        //         Grade = new Grade
//        //         {
//        //             GradeId = 1,
//        //             GradeName = "A"
//        //         },
//        //         //IsComplete = true
//        //     },
//        //     new Student
//        //     {
//        //         Id = 2,
//        //         FirstName = "Ali",
//        //         LastName = "Alavi",
//        //         Grade = new Grade
//        //         {
//        //             GradeId = 2,
//        //             GradeName = "B"
//        //         },
//        //         //IsComplete = true
//        //     }
//        //  };
//    }

//    public static List<Student> GetAll() => Students;

//    //public static List<Student> GetByGradeId(int gradeId)
//    //{
//    //    var grade = GradeService.Get(gradeId);
//    //    if (grade == null)
//    //        throw new Exception("Not Found!");

//    //    return grade.Students.ToList();
//    //}

//    public static Student? Get(int id) => Students.FirstOrDefault(s => s.Id == id);

//    public static void Add(Student student)
//    {
//        student.Id = nextId++;
//        Students.Add(student);
//    }

//    public static void Delete(int id)
//    {
//        var student = Get(id);
//        if (student is null)
//            return;

//        Students.Remove(student);
//    }

//    public static void Update(Student student)
//    {
//        var index = Students.FindIndex(s => s.Id == student.Id);
//        if (index == -1)
//            return;

//        Students[index] = student;
//    }
//}
