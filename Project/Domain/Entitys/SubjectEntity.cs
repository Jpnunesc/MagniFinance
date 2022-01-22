using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class SubjectEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Average { get; set; }
        public int IdCourse { get; set; }
        public CourseEntity Course { get; set; }
        public List<StudentEntity> Students { get; set; }
    }
}
