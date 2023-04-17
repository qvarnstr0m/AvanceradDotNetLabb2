using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNetLabb2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
    }
}
