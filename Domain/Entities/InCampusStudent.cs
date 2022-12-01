using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InCampusStudent : Student
    {
        [Required]
        public int YearsOfStudy { get; set; }

        [NotMapped]
        public decimal SuggestedUnits { get; set; }

        [Required]
        public decimal InitialTuitionFee { get; set; }

        [Required]
        public bool MinimumScholarShipGiven { get; set; }

        public List<Lesson> AttendedLessons { get; set; } = new List<Lesson>();

        [Required]
        public int Level { get; set; }

        public InCampusStudent(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public InCampusStudent(
            string firstName,
            string lastName,
            int yearsOfStudy,
            decimal initialTuitionFee,
            bool minimumScholarshipGiven,
            int level) : base(firstName, lastName)
        {
            YearsOfStudy = yearsOfStudy;
            InitialTuitionFee = initialTuitionFee;
            MinimumScholarShipGiven = minimumScholarshipGiven;
            Level = level;
        }
    }
}
