using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class CandidateImplementation : BaseRepository<CandidateEntity>, ICandidateRepository
    {
        private readonly DbSet<CandidateEntity> _dataset;

        public CandidateImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CandidateEntity>();
        }

        public async Task<CandidateEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
