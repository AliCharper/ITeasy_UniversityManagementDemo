using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Factory
{
    public class StudentFactory
    {
        /// <summary>
        /// Create an Student
        /// </summary>
        public virtual Student CreateStudent(string firstName,
            string lastName,
            string? Campus = null,
            bool isExternal = false)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.",
                    nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.",
                    nameof(lastName));
            }

            if (Campus == null && isExternal)
            {
                throw new ArgumentException($"'{nameof(Campus)}' cannot be null or empty when the employee is external.",
                    nameof(Campus));
            }

            if (isExternal)
            {

                return new ExternalStudent(firstName, lastName, Campus = null!);
            }


            return new InCampusStudent(firstName, lastName, 0, 2500, false, 1);
        }
    }
}
