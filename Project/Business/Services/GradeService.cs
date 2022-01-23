using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Course;
using Business.IO.Grade;
using Business.Validations;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GradeService : IGradeService
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _repository;
        public GradeService(IMapper mapper, IGradeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(GradeInput _grade)
        {
            var validate = Validate(_grade);
            if (!validate.Status)
            {
                return validate;
            }
            var gradeMap = _mapper.Map<GradeInput, GradeEntity>(_grade);
            return new ReturnView() { Object = _mapper.Map<GradeEntity, GradeOutPut>(await _repository.Add(gradeMap)), Message = "Operation performed successfully!", Status = true };
        }
        public ReturnView Validate(GradeInput _grade)
        {
            ReturnView retornView = new ReturnView();
            GradeValidation validator = new GradeValidation();
                var valid = validator.Validate(_grade);
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
        public async Task<ReturnView> Edit(GradeInput _grade)
        {
            var validate = Validate(_grade);
            if (!validate.Status)
            {
                return validate;
            }
            var gradeMap = _mapper.Map<GradeInput, GradeEntity>(_grade);
            return new ReturnView() { Object = _mapper.Map<GradeEntity, GradeOutPut>(await _repository.Update(gradeMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            return new ReturnView() { Object = _mapper.Map<GradeEntity, GradeOutPut>(await _repository.Get(x=> x.Id == id)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany(GradeFilter _filter)
        {
            var list = _mapper.Map<IEnumerable<GradeEntity>, IEnumerable<GradeOutPut>>(await _repository.GetFilter(_filter));
            return new ReturnView() { Object = list, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
