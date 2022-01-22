using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class GradeEntity : BaseEntity
    {
        public decimal StudentGrade { get; set; }
        public int IdStudent { get; set; }
        public StudentEntity Student  { get; set; }
        public int IdSubject { get; set; }
        public SubjectEntity Subject { get; set; } 
    }
}
