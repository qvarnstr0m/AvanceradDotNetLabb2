using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNetLabb2.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }

        public Subject()
        {
            Courses = new List<Course>();
            Teachers = new List<Teacher>();
        }
    }
}
