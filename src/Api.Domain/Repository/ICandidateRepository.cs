using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICandidateRepository : IRepository<Entities.CandidateEntity>
    {
        Task<Entities.CandidateEntity> FindByLogin(string email);
    }
}
