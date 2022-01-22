using Business.IO.Course;
using Business.IO.Grade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Student
{
    public class StudentOutPut
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Registration { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdCourse { get; set; }
        public CourseOutPut Course { get; set; }
        public IEnumerable<GradeOutPut> Grades { get; set; }
    }
}
