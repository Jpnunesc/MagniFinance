using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Grade
{
   public class GradeInput
    {
        public int? Id { get; set; }
        public decimal? FistGrade { get; set; }
        public decimal? SecondGrade { get; set; }
        public decimal? ThirdGrade { get; set; }
        public decimal? Fourthgrade { get; set; }
        public int StudentEntityId { get; set; }
        public int SubjectEntityId { get; set; }
    }
}
