using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class GradeEntity : BaseEntity
    {
        public decimal? FistGrade { get; set; }
        public decimal? SecondGrade { get; set; }
        public decimal? ThirdGrade { get; set; }
        public decimal? Fourthgrade { get; set; }
        public int? StudentEntityId { get; set; }
        public  StudentEntity Student  { get; set; }
        public int? SubjectEntityId { get; set; }
        public  SubjectEntity Subject { get; set; } 
    }
}
