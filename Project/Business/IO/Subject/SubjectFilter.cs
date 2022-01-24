using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Subject
{
    public class SubjectFilter
    {
        public int? TeacherEntityId { get; set; }
        public bool? Status { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public string Search { get; set; }
    }
}