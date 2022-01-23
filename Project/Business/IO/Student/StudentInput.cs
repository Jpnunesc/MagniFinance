using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Student
{
   public class StudentInput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdCourse { get; set; }
    }
}
