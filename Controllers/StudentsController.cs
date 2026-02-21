using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // In-memory list
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Rahul", Age = 20, Course = "CSE" },
            new Student { Id = 2, Name = "Anjali", Age = 21, Course = "ECE" }
        };

        // GET: api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            newStudent.Id = students.Max(s => s.Id) + 1;
            students.Add(newStudent);

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Course = updatedStudent.Course;

            return Ok(student);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);

            return Ok("Student deleted successfully");
        }
    }
}