using Business.IO.Student;
using Business.IO.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Grade
{
    public class GradeOutPut
    {
        public decimal StudentGrade { get; set; }
        public int IdStudent { get; set; }
        public StudentOutPut Student { get; set; }
        public int IdSubject { get; set; }
        public SubjectOutPut Subject { get; set; }
    }
}
