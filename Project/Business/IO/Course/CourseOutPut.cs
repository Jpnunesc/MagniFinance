using Business.IO.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Course
{
    public class CourseOutPut
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<SubjectOutPut> Subjects { get; set; }
    }
}
