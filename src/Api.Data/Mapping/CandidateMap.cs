using Api.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class CandidateMap : IEntityTypeConfiguration<CandidateEntity>
    {

        public void Configure(EntityTypeBuilder<CandidateEntity> builder)
        {
            builder.ToTable("Candidate");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(p => p.Cosplay).IsRequired().HasMaxLength(100);
        }
    }
}
