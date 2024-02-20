using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CandidateEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cosplay { get; set; }

    }
}
