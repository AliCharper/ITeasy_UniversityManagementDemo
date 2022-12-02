using Business;
using DataAccess.Factory;
using ITeasy_UniversityManagementDemo.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class StudentServiceTests
    {
        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedFirstObligatoryLesson()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();

            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            var obligatoryLesson = universityManagementRepositoryTestDataRepository
                .GetLesson(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Contains(obligatoryLesson, inCampusStudent.AttendedLessons);
        }
    }
}
