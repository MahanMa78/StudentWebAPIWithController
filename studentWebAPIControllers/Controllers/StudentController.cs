using Microsoft.AspNetCore.Mvc;
using studentWebAPIControllers.Services;
namespace studentWebAPIControllers.Controllers;


[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    public StudentController()
    {

    }
    // GET all action
    [HttpGet]
    public ActionResult<List<Student>> GetAll() =>
        StudentService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = StudentService.Get(id);
        if (student == null)
            return NotFound();

        return student;
    }

    // Get By gradeId action
    [HttpGet("{id}")]
    public ActionResult<List<Student>> GetByGradeId(int gradeId)
    {
        var grade = GradeService.Get(gradeId);
        if (grade == null)
            throw new Exception("Not Found!");

        return grade.Students.ToList();
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Student student)
    {
        StudentService.Add(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest();

        var existingStudent = StudentService.Get(id);
        if (existingStudent is null)
            return NotFound();

        StudentService.Update(student);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = StudentService.Get(id);

        if (student is null)
            return NotFound();

        StudentService.Delete(id);

        return NoContent();
    }
}
