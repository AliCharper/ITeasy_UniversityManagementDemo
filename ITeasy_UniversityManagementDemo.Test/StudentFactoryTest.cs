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
            Assert.Equal(2500, Student.InitialTuitionFee);

            //Assert.True(Student.InitialTuitionFee >= 2500);
            //Assert.True(Student.InitialTuitionFee <= 3500);
            //Assert.True(Student.InitialTuitionFee >= 2500 && Student.InitialTuitionFee <= 3500);
            //Assert.True(Student.InitialTuitionFee >= 2500);
            //Assert.True(Student.InitialTuitionFee <= 3500);

            //// ** Warning ** Do not be an Idiot !
            //Assert.True(Student.SuggestedUnits >80);

        }

        [Fact]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500()
        {

            // Arrange
            var _studentFactory = new StudentFactory();

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            //Assert.True(student.InitialTuitionFee >= 3000 && student.InitialTuitionFee <= 3500);
            Assert.True(student.InitialTuitionFee >= 3000 && student.InitialTuitionFee <= 3500,
                "InitialTuitionFee in not in the Range");

        }

        [Fact]

        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500_Alternative()
        {

            // Arrange
            var _studentFactory = new StudentFactory();


            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            Assert.True(student.InitialTuitionFee >= 2500);
            Assert.True(student.InitialTuitionFee <= 3500);
        }

        [Fact]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500_AlternativeWithInRange()
        {

            // Arrange
            var _studentFactory = new StudentFactory();


            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            Assert.InRange(student.InitialTuitionFee, 2500, 3500);
        }


        [Fact]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBe2500_PrecisionExample()
        {
            // Arrange
            var _studentFactory = new StudentFactory();

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Ali", "Hamidi");

            student.InitialTuitionFee = 2500.123m;

            // Assert
           //Assert.Equal(2500, student.InitialTuitionFee);
           Assert.Equal(2500, student.InitialTuitionFee, 0);
        }

    }




}

