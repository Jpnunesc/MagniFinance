using Business.IO.Course;
using Business.IO.Grade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Student
{
    public class StudentOutPut
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string Registration { get { return Id.Value.ToString().PadLeft(9, '0'); } }
        public DateTime BirthDate { get; set; }
        public int IdCourse { get; set; }
        public CourseOutPut Course { get; set; }
        public List<GradeOutPut> Grades { get; set; }
        public string NameCourse { get { return Course != null ? Course.Name : ""; } }
    }
}
