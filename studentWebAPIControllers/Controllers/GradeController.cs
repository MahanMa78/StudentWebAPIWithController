using Microsoft.AspNetCore.Mvc;
using studentWebAPIControllers.Services;


namespace studentWebAPIControllers.Controllers;


[ApiController]
[Route("[controller]")]
public class GradeController  : ControllerBase
{
    public GradeController()
    {

    }
    // GET all action
    [HttpGet]
    public ActionResult<List<Grade>> GetAll() =>
        GradeService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<ICollection<Student>> Get(int id)
    {
        var grade = GradeService.Get(id);
        if (grade == null)
            return NotFound();

        return grade.Students;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Grade grade)
    {
        GradeService.Add(grade);
        return CreatedAtAction(nameof(Get), new { id = grade.GradeId }, grade);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Grade grade)
    {
        if (id != grade.GradeId)
            return BadRequest();

        var existingGrade = GradeService.Get(id);
        if (existingGrade is null)
            return NotFound();

        GradeService.Update(grade);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var grade = GradeService.Get(id);

        if (grade is null)
            return NotFound();

        GradeService.Delete(id);

        return NoContent();
}
}

