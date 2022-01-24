using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Subject
{
   public class SubjectInput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public decimal? Average { get; set; }
        public int? IdCourse { get; set; }
        public int? TeacherEntityId { get; set; }

    }
}
