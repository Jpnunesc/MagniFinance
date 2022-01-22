﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class StudentEntity : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Registration { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdCourse { get; set; }
        public CourseEntity Course { get; set; }
        public IEnumerable<GradeEntity> Grades { get; set; }

    }
}
