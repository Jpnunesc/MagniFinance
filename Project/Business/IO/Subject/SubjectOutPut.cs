using Business.IO.Course;
using Business.IO.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Subject
{
    public class SubjectOutPut
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Average { get; set; }
        public int IdCourse { get; set; }
        public CourseOutPut Course { get; set; }
        public List<StudentOutPut> Students { get; set; }
    }
}
