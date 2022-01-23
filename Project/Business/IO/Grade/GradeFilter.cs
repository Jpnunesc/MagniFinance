using Business.IO.Student;
using Business.IO.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Grade
{
    public class GradeFilter
    {
        public int? IdSubject { get; set; }
        public int? IdStudent { get; set; }
    }
}
