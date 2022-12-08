using Business;
using DataAccess.Factory;
using DataAccess.Repository;
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

            studentFactoryMock.Setup(m =>
            m.CreateStudent(
                "Eynolah",
                It.IsAny<string>(),
                null,
                false))
            .Returns(new InCampusStudent("Eynolah", "Bagherzadeh", 0, 3000, false, 1));

            studentFactoryMock.Setup(m =>
             m.CreateStudent(
                 It.Is<string>(value => value.Contains("a")),
                 It.IsAny<string>(),
                 null,
                 false))
             .Returns(new InCampusStudent("Mohammad", "Jafary", 0, 3000, false, 1));

            var studentService = new StudentService(
               universityManagementTestDataRepository,
               studentFactoryMock.Object);

            decimal SuggestedUnits = 6;

            // Act 
            var student = studentService.CreateInCampusStudent("Ali", "Kolahdoozan");

            // Assert  
            Assert.Equal(SuggestedUnits, student.SuggestedUnits);
        }



        [Fact]
        public void FetchInCampusStudent_InCampusStudentFetched_SuggestedUnitsMustBeCalculated_MoqInterface()
        {
            // Arrange
            //var universityManagementTestDataRepository =
            //   new UniversityManagementTestDataRepository();  
            var universityManagementTestDataRepositoryMock =
                 new Mock<IUniversityManagementRepository>();
            universityManagementTestDataRepositoryMock
             .Setup(m => m.GetInCampusStudent(It.IsAny<Guid>()))
             .Returns(new InCampusStudent("Ali", "Kolahdoozan", 2, 2500, false, 2)
             {
                 AttendedLessons = new List<Lesson>() {
                        new Lesson("A lesson"), new Lesson("Another lesson") }
             });


            var studentFactoryMock = new Mock<StudentFactory>();
            var studentService = new StudentService(
                universityManagementTestDataRepositoryMock.Object,
                studentFactoryMock.Object);

            // Act 
            var student = studentService.FetchInCampusStudent(
                Guid.Empty);

            // Assert  
            Assert.Equal(400, student.SuggestedUnits);
        }




        [Fact]
        public async Task FetchInCampusStudent_InCampusStudentFetched_SuggestedUnitsMustBeCalculated_MoqInterface_Async()
        {
            // Arrange
            var universityManagementTestDataRepositoryMock =
              new Mock<IUniversityManagementRepository>();


            universityManagementTestDataRepositoryMock
              .Setup(m => m.GetInCampusStudentAsync(It.IsAny<Guid>()))
              .ReturnsAsync(new InCampusStudent("Ali", "Kolahdoozan", 2, 2500, false, 2)
              {
                  AttendedLessons = new List<Lesson>() {
                        new Lesson("A lesson"), new Lesson("Another lesson") }
              });


         
            var studentFactoryMock = new Mock<StudentFactory>();
            var studentService = new StudentService(
                universityManagementTestDataRepositoryMock.Object,
                studentFactoryMock.Object);

            // Act 
            var student = await studentService.FetchInCampusStudentAsync(Guid.Empty);

            // Assert  
            Assert.Equal(400, student.SuggestedUnits);
        }

    }
}
