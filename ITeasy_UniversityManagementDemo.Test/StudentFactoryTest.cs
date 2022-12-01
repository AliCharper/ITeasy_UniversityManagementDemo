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

        //public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBeLargerthanOrEqualTo2500()
        //public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBeSmallerThanOrEqualTo3500()
        public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBe2500()
        {
            // Arrange
            var _studentFactory = new StudentFactory();

            // Act 
            var Student = (InCampusStudent)_studentFactory
                .CreateStudent("Reza", "Ahmadi");

            //Assert
            //Assert.Equal(6700, Student.InitialTuitionFee);

            Assert.True(Student.InitialTuitionFee >= 2500);

            //Assert.True(Student.InitialTuitionFee <= 3500);

            //Assert.True(Student.InitialTuitionFee >= 2500 && Student.InitialTuitionFee <= 3500);

            //Assert.True(Student.InitialTuitionFee >= 2500);
            //Assert.True(Student.InitialTuitionFee <= 3500);

            //// ** Warning ** Do not be an Idiot !
            //Assert.True(Student.SuggestedUnits >80);

        }
    }
}
