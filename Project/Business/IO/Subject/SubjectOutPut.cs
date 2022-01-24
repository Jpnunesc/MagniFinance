using Business.IO.Course;
using Business.IO.Grade;
using Business.IO.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Subject
{
    public class SubjectOutPut
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Average { get; set; }
        public int IdCourse { get; set; }
        public int TeacherEntityId { get; set; }
        public TeacherOutPut Teacher { get; set; }
        public CourseOutPut Course { get; set; }
        public List<GradeOutPut> Grades { get; set; }
        public string NameCourse { get { return Course != null ? Course.Name : ""; } }
        public string NameTeacher { get { return Teacher != null ? Teacher.Name : ""; } }
    }
}
