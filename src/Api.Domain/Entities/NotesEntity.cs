using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class NotesEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CandidateId { get; set; }
        public decimal Note1 { get; set; }
        public decimal Note2 { get; set; }
        public decimal Note3 { get; set; }
    }
}
