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

        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedFirstObligatoryLesson_WithPredicate()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Contains(inCampusStudent.AttendedLessons, 
                lesson => lesson.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedSecondObligatoryLesson()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());
            var obligatoryLesson = universityManagementRepositoryTestDataRepository
                .GetLesson(Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Contains(obligatoryLesson, inCampusStudent.AttendedLessons);
        }

        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedSecondObligatoryLesson_WithPredicate()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Contains(inCampusStudent.AttendedLessons, 
                lesson => lesson.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
        }

        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_AttendedLessonsMustMatchObligatoryLessons()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            var obligatoryLessons = universityManagementRepositoryTestDataRepository
               .GetLessons(
                   Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                   Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));


            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Equal(obligatoryLessons, inCampusStudent.AttendedLessons);
        }

        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_AttendedLessonsMustNotBeNew()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());


            // Act
            var inCampusStudent = studentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            //inCampusStudent.AttendedLessons[0].IsNew = true;

            // Assert            
            //foreach (var lesson in inCampusStudent.AttendedLessons)
            //{
            //    Assert.False(lesson.IsNew);
            //}

            //
            Assert.All(inCampusStudent.AttendedLessons,
                lesson => Assert.False(lesson.IsNew));
        }

        [Fact]
        public async Task CreateInCampusStudent_InCampusStudentCreated_AttendedLessonsMustMatchObligatoryLessonsAsync()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            var obligatoryLessons = await universityManagementRepositoryTestDataRepository
               .GetLessonsAsync(
                   Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                   Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));


            // Act
            var inCampusStudent = await studentService
                .CreateInCampusStudentAsync("Pejman", "Vaziri");

            // Assert
            Assert.Equal(obligatoryLessons, inCampusStudent.AttendedLessons);
        }
    }
}
