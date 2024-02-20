using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Models;
using AutoMapper;
using Domain.Dtos.Candidate;
using Domain.Entities;
using Domain.Interfaces.Services.Candidate;
using Domain.Models;


namespace Service.Services
{
    public class CandidateService : ICandidateService
    {
        private IRepository<CandidateEntity> _repository;
        private readonly IMapper _mapper;

        public CandidateService(IRepository<CandidateEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CandidateDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CandidateDto>(entity) ?? new CandidateDto();
        }

        public async Task<IEnumerable<CandidateDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CandidateDto>>(listEntity);
        }

        public async Task<CandidateDtoCreateResult> Post(CandidateDtoCreate user)
        {
            var model = _mapper.Map<CandidateModel>(user);
            var entity = _mapper.Map<CandidateEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CandidateDtoCreateResult>(result);
        }

        public async Task<CandidateDtoUpdateResult> Put(CandidateDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<CandidateEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CandidateDtoUpdateResult>(result);
        }
    }
}
