using DataAccess.Factory;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class StudentFactoryTest
    {
        [Fact]

        public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBe2500()
        {
            // Arrange
            var _studentFactory = new StudentFactory();

            // Act 
            var Student = (InCampusStudent)_studentFactory
                .CreateStudent("Reza", "Ahmadi");

            //Assert
            Assert.Equal(6700, Student.InitialTuitionFee);
        }
    }
}
