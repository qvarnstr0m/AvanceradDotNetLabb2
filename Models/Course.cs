using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNetLabb2.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }

        public Course()
        {
            Subjects = new List<Subject>();
        }
    }
}
