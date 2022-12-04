using DataAccess.Factory;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class StudentFactoryTest : IDisposable
    {
        private StudentFactory _studentFactory;
        public StudentFactoryTest()
        {
            _studentFactory = new StudentFactory();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        [Trait("Category", "StudentFactory_CreateStudent_InitialTuitionFee")]
        //public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBeLargerthanOrEqualTo2500()
        //public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBeSmallerThanOrEqualTo3500()
        public void CreateStudent_ConstructInCampusStudent_InitialTuitionFeeMustBe2500()
        {

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
        [Trait("Category", "StudentFactory_CreateStudent_InitialTuitionFee")]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500()
        {

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            //Assert.True(student.InitialTuitionFee >= 3000 && student.InitialTuitionFee <= 3500);
            Assert.True(student.InitialTuitionFee >= 3000 && student.InitialTuitionFee <= 3500,
                "InitialTuitionFee in not in the Range");

        }

        [Fact]
        [Trait("Category", "StudentFactory_CreateStudent_InitialTuitionFee")]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500_Alternative()
        {

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            Assert.True(student.InitialTuitionFee >= 2500);
            Assert.True(student.InitialTuitionFee <= 3500);
        }

        [Fact]
        [Trait("Category", "StudentFactory_CreateStudent_InitialTuitionFee")]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBeBetween2500And3500_AlternativeWithInRange()
        {

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Kamran", "Kamali");

            // Assert
            Assert.InRange(student.InitialTuitionFee, 2500, 3500);
        }


        [Fact]
        [Trait("Category", "StudentFactory_CreateStudent_InitialTuitionFee")]
        public void CreateStudent_ConstructInternalStudent_InitialTuitionFeeMustBe2500_PrecisionExample()
        {

            // Act
            var student = (InCampusStudent)_studentFactory
                .CreateStudent("Ali", "Hamidi");

            student.InitialTuitionFee = 2500.123m;

            // Assert
           //Assert.Equal(2500, student.InitialTuitionFee);
           Assert.Equal(2500, student.InitialTuitionFee, 0);
        }

        [Fact]
        [Trait("Category", "StudentFactory_CreateStudent_ReturnType")]
        public void CreateStudent_IsExternalIsTrue_ReturnTypeMustBeExternalStudent()
        {
            

            // Act
            var student = _studentFactory
                .CreateStudent("Eynolah", "Bagherzadeh", "Najaf Abad", true);

            // Assert
            Assert.IsType<ExternalStudent>(student);
            //Assert.IsAssignableFrom<Student>(student);

        }

       
    }




}

