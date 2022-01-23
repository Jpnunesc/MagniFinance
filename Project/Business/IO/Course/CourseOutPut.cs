using Business.IO.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Course
{
    public class CourseOutPut
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<SubjectOutPut> Subjects { get; set; }
    }
}
