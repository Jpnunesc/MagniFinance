using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Entitys
{
    public class SubjectEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Average { get; set; }
        public int IdCourse { get; set; }
        public  CourseEntity Course { get; set; }
        public virtual ICollection<GradeEntity> Grades { get; set; }
    }
}
