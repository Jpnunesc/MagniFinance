using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class TeacherEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Remuneration { get; set; }
        public int IdSubject { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}
