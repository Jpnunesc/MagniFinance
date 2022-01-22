using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Course;
using Business.Validations;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _repository;
        public CourseService(IMapper mapper, ICourseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(CourseInput _course)
        {
            var validate = Validate(_course);
            if (!validate.Status)
            {
                return validate;
            }
            _course.Status = true;
            var courseMap = _mapper.Map<CourseInput, CourseEntity>(_course);
            return new ReturnView() { Object = _mapper.Map<CourseEntity, CourseOutPut>(await _repository.Add(courseMap)), Message = "Operation performed successfully!", Status = true };
        }
        public ReturnView Validate(CourseInput _course)
        {
            ReturnView retornView = new ReturnView();
            CourseValidation validator = new CourseValidation();
                var valid = validator.Validate(_course);
                if (!valid.IsValid)
                {
                retornView.Status = false;
                    foreach (var item in valid.Errors)
                    {
                    retornView.Message = string.IsNullOrEmpty(retornView.Message) ? item.ErrorMessage : retornView.Message + ", " + item.ErrorMessage;
                    }
                    return retornView;
                }
            retornView.Status = true;
            return retornView;
        }
        public async Task<ReturnView> Edit(CourseInput _course)
        {
            var validate = Validate(_course);
            if (!validate.Status)
            {
                return validate;
            }
            var courseMap = _mapper.Map<CourseInput, CourseEntity>(_course);
            return new ReturnView() { Object = _mapper.Map<CourseEntity, CourseOutPut>(await _repository.Update(courseMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            return new ReturnView() { Object = _mapper.Map<CourseEntity, CourseOutPut>(await _repository.Get(x=> x.Id == id)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany(CourseFilter _filter)
        {
            var list = _mapper.Map<IEnumerable<CourseEntity>, IEnumerable<CourseOutPut>>(await _repository.GetFilter(_filter));
            return new ReturnView() { Object = list, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
