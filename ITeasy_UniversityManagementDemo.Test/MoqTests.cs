using Business;
using DataAccess.Factory;
using Domain.Entities;
using ITeasy_UniversityManagementDemo.Test.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class MoqTests
    {
        [Fact]
        public void FetchInCampusStudent_InCampusStudentFetched_SuggestedUnitsMustBeCalculated()
        {
            // Arrange
            var universityManagementTestDataRepository =
              new UniversityManagementTestDataRepository();
            //var studentFactory = new StudentFactory();
            var studentFactoryMock = new Mock<StudentFactory>();
            //var studentService = new StudentService(
            //    universityManagementTestDataRepository,
            //    studentFactory);
            var studentService = new StudentService(
                universityManagementTestDataRepository,
                studentFactoryMock.Object);

            // Act 
            var student = studentService.FetchInCampusStudent(
                Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            // Assert  
            Assert.Equal(40, student.SuggestedUnits);
        }


        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_SuggestedUnitsMustBeCalculated()
        {
            // Arrange
            var universityManagementTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentFactoryMock = new Mock<StudentFactory>();
            studentFactoryMock.Setup(m =>
             m.CreateStudent(
                 "Ali",
                 It.IsAny<string>(),
                 null,
                 false))
             .Returns(new InCampusStudent("Ali", "Kolahdoozan", 5, 2500, false, 1));


            var studentService = new StudentService(
               universityManagementTestDataRepository,
               studentFactoryMock.Object);

            decimal SuggestedUnits = 6;

            // Act 
            var student = studentService.CreateInCampusStudent("Alireza", "Kolahdoozan");

            // Assert  
            Assert.Equal(SuggestedUnits, student.SuggestedUnits);
        }

    }
}
