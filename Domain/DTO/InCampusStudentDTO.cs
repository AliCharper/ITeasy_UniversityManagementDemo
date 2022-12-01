using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class InCampusStudentDTO
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int YearsOfStudy { get; set; }


        public decimal SuggestedUnits { get; set; }


        public decimal InitialTuitionFee { get; set; }


        public bool MinimumScholarShipGiven { get; set; }

        public List<Lesson> AttendedLessons { get; set; } = new List<Lesson>();

        public int Level { get; set; }
    }
}
