using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Related_Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string coursename { get; set; }

        public int courseduration { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
