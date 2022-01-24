using Business.IO.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Teacher
{
   public class TeacherOutPut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Remuneration { get; set; }
        public int IdSubject { get; set; }
        public List<SubjectOutPut> Subjects { get; set; }
    }
}
