using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlapp.Models
{
    // This class represents the struture of our data
    public class Course
    {
        public int courseID { get; set; }

        public string courseName { get; set; }
        public decimal rating { get; set; }

        public string examImage { get; set; }
    }
}
