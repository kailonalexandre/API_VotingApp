﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Candidate
{
    public class CandidateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cosplay { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
