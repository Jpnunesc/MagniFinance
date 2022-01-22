using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Student;
using Business.Validations;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repository;
        public StudentService(IMapper mapper, IStudentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(StudentInput _student)
        {
            var validate = Validate(_student);
            if (!validate.Status)
            {
                return validate;
            }
            _student.Status = true;
            var studentMap = _mapper.Map<StudentInput, StudentEntity>(_student);
            return new ReturnView() { Object = _mapper.Map<StudentEntity, StudentOutPut>(await _repository.Add(studentMap)), Message = "Operation performed successfully!", Status = true };
        }
        public ReturnView Validate(StudentInput _teacher)
        {
            ReturnView retornView = new ReturnView();
            StudentValidation validator = new StudentValidation();
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
        public async Task<ReturnView> Edit(StudentInput _teacher)
        {
            var validate = Validate(_teacher);
            if (!validate.Status)
            {
                return validate;
            }
            var studentMap = _mapper.Map<StudentInput, StudentEntity>(_teacher);
            return new ReturnView() { Object = _mapper.Map<StudentEntity, StudentOutPut>(await _repository.Update(studentMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            return new ReturnView() { Object = _mapper.Map<StudentEntity, StudentOutPut>(await _repository.Get(x=> x.Id == id)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany(StudentFilter _filter)
        {
            var list = _mapper.Map<IEnumerable<StudentEntity>, IEnumerable<StudentOutPut>>(await _repository.GetFilter(_filter));
            return new ReturnView() { Object = list, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
