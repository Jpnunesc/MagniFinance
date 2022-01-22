using AutoMapper;
using Business.IO.Course;
using Business.IO.Student;
using Business.IO.Subject;
using Business.IO.Teacher;
using Business.IO.Users;
using Domain.Entity;
using Domain.Entitys;
using System.Collections.Generic;

namespace Business.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAuthView, UserEntity>(MemberList.None);
            CreateMap<UserEntity, UserAuthView>(MemberList.None);

            CreateMap<TeacherInput, TeacherEntity>(MemberList.None);
            CreateMap<TeacherEntity, TeacherOutPut>(MemberList.None);

            CreateMap<CourseEntity, CourseOutPut>(MemberList.None);
            CreateMap<CourseInput, CourseEntity>(MemberList.None);

            CreateMap<StudentEntity, StudentOutPut>(MemberList.None);
            CreateMap<StudentInput, StudentEntity>(MemberList.None);

            CreateMap<SubjectEntity, SubjectOutPut>(MemberList.None);
            CreateMap<SubjectInput, SubjectEntity>(MemberList.None);


        }
    }

}