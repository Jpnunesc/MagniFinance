
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Services;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC.Config
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection Registered { get; private set; }
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<ITeacherService, TeacherService>(); 
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IGradeRepository, GradeRepository>();

        }
    }
}


