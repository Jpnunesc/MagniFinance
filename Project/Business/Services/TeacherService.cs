using AutoMapper;
using Business.Extensions;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Subject;
using Business.IO.Teacher;
using Business.Validations;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _repository;
        private readonly ISubjectRepository _subjectRepository;
        public TeacherService(IMapper mapper, ITeacherRepository repository, ISubjectRepository subjectRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _subjectRepository = subjectRepository;
        }
        public async Task<ReturnView> Save(TeacherInput _teacher)
        {
            var validate = Validate(_teacher);
            if (!validate.Status)
            {
                return validate;
            }
            _teacher.Status = true;
            var teacherMap = _mapper.Map<TeacherInput, TeacherEntity>(_teacher);
            return new ReturnView() { Object = _mapper.Map<TeacherEntity, TeacherOutPut>(await _repository.Add(teacherMap)), Message = "Operation performed successfully!", Status = true };
        }
        public ReturnView Validate(TeacherInput _teacher)
        {
            ReturnView retornView = new ReturnView();
            TeacherValidation validator = new TeacherValidation();
                var valid = validator.Validate(_teacher);
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
        public async Task<ReturnView> Edit(TeacherInput _teacher)
        {
            var validate = Validate(_teacher);
            if (!validate.Status)
            {
                return validate;
            }
            var teacherMap = _mapper.Map<TeacherInput, TeacherEntity>(_teacher);
            return new ReturnView() { Object = _mapper.Map<TeacherEntity, TeacherOutPut>(await _repository.Update(teacherMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            return new ReturnView() { Object = _mapper.Map<TeacherEntity, TeacherOutPut>(await _repository.Get(x=> x.Id == id)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany(TeacherFilter _filter)
        {
            var listFilter = await _repository.GetFilter(_filter);
            foreach (var item in listFilter)
            {
                item.Subjects = _subjectRepository.GetMany(s => s.TeacherEntityId == item.Id).Result;
            }
            var listReturn = _mapper.Map<IEnumerable<TeacherEntity>, IEnumerable<TeacherOutPut>>(listFilter);
            return new ReturnView() { Object = listReturn, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
