using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Subject;
using Business.Validations;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _repository;
        public SubjectService(IMapper mapper, ISubjectRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(SubjectInput _subject)
        {
            var validate = Validate(_subject);
            if (!validate.Status)
            {
                return validate;
            }
            _subject.Status = true;
            var subjectMap = _mapper.Map<SubjectInput, SubjectEntity>(_subject);
            return new ReturnView() { Object = _mapper.Map<SubjectEntity, SubjectOutPut>(await _repository.Add(subjectMap)), Message = "Operation performed successfully!", Status = true };
        }
        public ReturnView Validate(SubjectInput _subject)
        {
            ReturnView retornView = new ReturnView();
            SubjectValidation validator = new SubjectValidation();
                var valid = validator.Validate(_subject);
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
        public async Task<ReturnView> Edit(SubjectInput _subject)
        {
            var validate = Validate(_subject);
            if (!validate.Status)
            {
                return validate;
            }
            var subjectMap = _mapper.Map<SubjectInput, SubjectEntity>(_subject);
            return new ReturnView() { Object = _mapper.Map<SubjectEntity, SubjectOutPut>(await _repository.Update(subjectMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            return new ReturnView() { Object = _mapper.Map<SubjectEntity, SubjectOutPut>(await _repository.Get(x=> x.Id == id)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany()
        {
            var list = _mapper.Map<IEnumerable<SubjectEntity>, IEnumerable<SubjectOutPut>>(await _repository.GetMany(x => x.Status));
            return new ReturnView() { Object = list, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
