using Api.Domain.Dtos.User;
using Domain.Dtos.Candidate;
using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Candidate
{
    public interface ICandidateService
    {
        Task<CandidateDto> Get(Guid id);
        Task<IEnumerable<CandidateDto>> GetAll();
        Task<CandidateDtoCreateResult> Post(CandidateDtoCreate candidate);
        Task<CandidateDtoUpdateResult> Put(CandidateDtoUpdate candidate);
        Task<bool> Delete(Guid id);
    }
}
