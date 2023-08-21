using Integrating_Related_Data.Actions;
using Integrating_Related_Data.Data;
class program
{
    ApplicationDbContext applicationDbContext = new ApplicationDbContext();
   
    public async static Task Main()
    {
        // await new SchoolService().AddStudentAsync();
        await new SchoolService().GetAllStudents();
        await new SchoolService().GetAllCourses();
        await new SchoolService().GetStudentsWithCourses();
        await new SchoolService().GetAll();
    }

}

