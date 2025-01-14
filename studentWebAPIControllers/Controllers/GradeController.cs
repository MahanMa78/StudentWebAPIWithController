using Microsoft.AspNetCore.Mvc;
// using studentWebAPIControllers.Services;


namespace studentWebAPIControllers.Controllers;


[ApiController]
[Route("[controller]")]
public class GradeController  : ControllerBase
{
    // public GradeController()
    // {

    // }
    static List<Grade> Grades {get;} = new List<Grade>() ;
    static int nextId = 1;
    // GET all action
    [HttpGet]
    public ActionResult<List<Grade>> GetAll() => Grades;
    
        // GradeService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Grade> Get(int id)
    {
        // var grade = GradeService.Get(id);
        var grade = Grades.FirstOrDefault(g => g.GradeId == id);
        if (grade == null)
            return NotFound();

        return grade;
    }

    // POST action
    [HttpPost]
    public IActionResult Add(Grade grade)
    {
        // GradeService.Add(grade);
        grade.GradeId = nextId++;
        Grades.Add(grade);
        return CreatedAtAction(nameof(Get), new { id = grade.GradeId }, grade);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Grade grade)
    {
        if (id != grade.GradeId)
            return BadRequest();

        // var existingGrade = GradeService.Get(id);
        var index = Grades.FindIndex(g => g.GradeId == id);
        if (index == -1)
            return NotFound();

        // GradeService.Update(grade);

        Grades[index]=grade;

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var grade = Grades.FirstOrDefault(g => g.GradeId==id);

        if (grade is null)
            return NotFound();

        // GradeService.Delete(id);
        Grades.Remove(grade);

        return NoContent();
}
}

