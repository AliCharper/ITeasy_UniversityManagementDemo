using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExternalStudent : Student
    {
        public string UniverSity { get; set; }

        public ExternalStudent(
            string firstName,
            string lastName,
            string univerSity)
            : base(firstName, lastName)
        {
            UniverSity = univerSity;
        }
    }
}
