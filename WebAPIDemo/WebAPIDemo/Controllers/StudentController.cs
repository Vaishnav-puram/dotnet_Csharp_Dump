using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Entities;
using WebAPIDemo.Repo;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await studentDbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> GetById(int Id)
        {
            var student = await studentDbContext.Students.FindAsync(Id);
            if(student is null)
            {
                return NotFound("Student Not Found !");
            }
            return Ok(student);
        }

        [HttpPost("/addStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student s)
        {
            studentDbContext.Students.Add(s);
            studentDbContext.SaveChanges();
            return Ok(s);
        }
        [HttpPut("/updateStudent/{Id}")]
        public async Task<ActionResult<string>> UpdateStudent(int Id,StudentDTO s)
        {
            var student = await studentDbContext.Students.FindAsync(Id);
            if(student is null)
            {
                return NotFound("Student record not found !");
            }
            student.Fullname = s.Fullname;
            student.DOB = s.DOB;
            student.Age = s.Age;
            student.College = s.College;
            studentDbContext.Students.Update(student);
            studentDbContext.SaveChanges();
            return Ok("Student record updated");
        }

        [HttpDelete("/delStudent/{Id}")]
        public async Task<ActionResult<String>> deleteStudent(int Id)
        {
            var s = await studentDbContext.Students.FindAsync(Id);
            if(s is null)
            {
                return NotFound("Unable to find the record !");
            }
            studentDbContext.Students.Remove(s);
            studentDbContext.SaveChanges();
            return Ok("Student deleted");
        }
    }
}
