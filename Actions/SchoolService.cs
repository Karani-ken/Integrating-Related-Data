

using Integrating_Related_Data.Data;
using Integrating_Related_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrating_Related_Data.Actions
{
    public class SchoolService
    {
       ApplicationDbContext _context = new ApplicationDbContext();
             
        

        public async Task AddStudentAsync()
        {
            //add students and courses
            var student1 = new Student { name = "Leah", age=24 };
            var student2 = new Student { name = "Wesley" , age=15 };
            var student3 = new Student { name = "Easther", age = 30 };
            var student4= new Student { name = "james", age = 25 };
            var course1 = new Course { coursename = "Chemistry", courseduration = 4 };
            var course2 = new Course { coursename = "Geography", courseduration = 5 };
            var course3 = new Course { coursename = "Coding", courseduration = 3 };
            var course4 = new Course { coursename = "German", courseduration = 2 };

            //enroll students and courses
            //student1.Courses.Add(course1);
            //student2.Courses.Add(course4);
            //student2.Courses.Add(course1);
            //student3.Courses.Add(course1);
            //student3.Courses.Add(course3);
            //student4.Courses.Add(course3);



            //_context.Students.Add(student1);
            //_context.Students.Add(student2);
            //_context.Students.Add(student3);
            //_context.Students.Add(student4);
            //_context.SaveChanges();
            _context.Courses.Add(course1);
            _context.Courses.Add(course2);
            _context.Courses.Add(course3);
            _context.Courses.Add(course4);
            _context.SaveChanges();
        }
        // get all students
        //Left JOIN
        public async Task GetAllStudents()
        {
            await Console.Out.WriteLineAsync("Left Join\n\n");
            var students = _context.Students.Include(s => s.Courses).ToList();
            foreach(var student in students)
            {
                await Console.Out.WriteLineAsync($"student name: {student.name} == Age: {student.age}");
                foreach(var course in student.Courses)
                {
                    await Console.Out.WriteLineAsync($"Courses: {course.coursename} duration: {course.courseduration}");
                }
                await Console.Out.WriteLineAsync();
            }
        }
        //get all courses
        //Right Join
        public async Task GetAllCourses()
        {
            await Console.Out.WriteLineAsync("Right JOIN\n\n");
            var courses = _context.Courses.Include(c => c.Students).ToList();
            foreach(var course in courses)
            {
                await Console.Out.WriteLineAsync($"course name:{course.coursename} == duration:{course.courseduration}");
                foreach(var student in course.Students)
                {
                    await Console.Out.WriteLineAsync($"Student Taking the Course: Name:{student.name} == Age:{student.age}");
                }
                await Console.Out.WriteLineAsync();
            }
        }
        //get only students with courses 
        //Inner JOIN
        public async Task GetStudentsWithCourses()
        {
            await Console.Out.WriteLineAsync("Inner Join\n\n");
            var studentsWithCourses = _context.Students.Where(s => s.Courses.Any()).Include(s => s.Courses).ToList();

            foreach(var student in studentsWithCourses)
            {
                await Console.Out.WriteLineAsync($" name: {student.name} == age: {student.age}");
                foreach(var course in student.Courses)
                {
                    await Console.Out.WriteLineAsync($"course name: {course.coursename} == duration: {course.courseduration}");
                }
                await Console.Out.WriteLineAsync();
            }
        }
        //get all students and courses
        //Full OUTER JOIN
        public async Task GetAll()
        {
            await Console.Out.WriteLineAsync("Full OUT JOIN\n\n");
            var Allstudents = _context.Students.Include(s => s.Courses).ToList();
            var coursesWithoutStudents = _context.Courses.Where(c => c.Students.Count == 0).ToList();
            foreach( var student in Allstudents)
            {
                await Console.Out.WriteLineAsync($" name: {student.name} == age: {student.age}");
                foreach (var course in student.Courses)
                {
                    await Console.Out.WriteLineAsync($"course name: {course.coursename} == duration: {course.courseduration}");
                }
                await Console.Out.WriteLineAsync();
            }
            foreach(var course in coursesWithoutStudents)
            {
                await Console.Out.WriteLineAsync($"course name: {course.coursename} == duration {course.courseduration}");
            }

        }
    }
}
