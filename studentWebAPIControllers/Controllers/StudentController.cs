﻿using Microsoft.AspNetCore.Mvc;
// using studentWebAPIControllers.Services;


using System.Collections.Generic;
using System.Linq;
namespace studentWebAPIControllers.Controllers;


[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    // public StudentController()
    // {

    // }
    static List<Student> Students {get;} = new List<Student>();

    static List<Grade> Grades {get;} = new List<Grade>();
    static int nextId = 1;
    // GET all action
    [HttpGet]
    public ActionResult<List<Student>> GetAll() =>Students;
        // StudentService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        // var student = StudentService.Get(id);
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            return NotFound();

        return student;
    }

    // Get By gradeId action
    [HttpGet("GradeId/{id}")]
    public ActionResult<List<Student>> GetByGradeId(int gradeId)
    {
        // var grade = GradeService.Get(gradeId);
        var grade = Grades.FirstOrDefault(s=> s.GradeId == gradeId);
        if (grade == null)
            throw new Exception("Not Found!");

        return grade.Students.ToList();
    }

    // POST action
    [HttpPost]
    public IActionResult Add(StudentDto dto)
    {
        Student student = new Student();
        student.Id = dto.Id;
        student.Weight = dto.Weight;
        student.Height = dto.Height;
        student.Photo = dto.Photo;
        student.DateOfBirth = dto.DateOfBirth;
        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.GradeId = dto.GradeId;  


        // StudentService.Add(student);
        // return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        //student.Id = nextId++;
        //students
        //Students.Add(student);
        //return CreatedAtAction(nameof(Get),new { id = student.Id }, student );


    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest();

        // var existingStudent = StudentService.Get(id);
        // if (existingStudent is null)
        //     return NotFound();

        // StudentService.Update(student);

        // return NoContent();

        var index = Students.FindIndex(s => s.Id == id);
        if(index == -1)
            return NotFound();

        Students[index] = student;
        return NoContent();
    }


    /// <summary>
    /// Deletes a specific TodoItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>



    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if(student == null)
            return NotFound();

        // if (student is null)
        //     return NotFound();

        // StudentService.Delete(id);
        Students.Remove(student);
        return NoContent();
    }
}
