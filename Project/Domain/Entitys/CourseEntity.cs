using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class CourseEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<SubjectEntity> Subjects { get; set; }

    }
}
