using Business;
using DataAccess.Events;
using DataAccess.Factory;
using Domain.Entities;
using Infra.Exceptions;
using ITeasy_UniversityManagementDemo.Test.Fixtures;
using ITeasy_UniversityManagementDemo.Test.Services;
using ITeasy_UniversityManagementDemo.Test.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    [Collection("StudentServiceCollection")]
    public class DataDrivenStudentServiceTests //: IClassFixture<StudentServiceFixture>
    {

        private readonly StudentServiceFixture _studentServiceFixture;

        public DataDrivenStudentServiceTests(StudentServiceFixture studentServiceFixture)
        {
            _studentServiceFixture = studentServiceFixture;
        }



        [Fact]
        public async Task GiveMinimumScholarship_MinimumScholarshipGiven_InCampusStudentMinimumScholarshipGivenMustBeTrue()
        {
            //Arrange
            var inCampusStudent = new InCampusStudent(
                "Hasan", "Ahmadi", 5, 3000, false, 3);

            //Act
            await _studentServiceFixture.
                StudentService.GiveMinimumScholarShipGivenAsync(inCampusStudent);

            //Assert 
            Assert.True(inCampusStudent.MinimumScholarShipGiven);

        }

        [Fact]
        public async Task GiveJustMinimumScholarship_MoreThanMinimumScholarshipGiven_InCampusStudentMinimumScholarshipGivenMustBeFalse()
        {
            //Arrange
            var inCampusStudent = new InCampusStudent(
                "Hasan", "Ahmadi", 5, 3000, false, 3);

            //Act
            await _studentServiceFixture.
                StudentService.GiveMinimumScholarShipGivenAsync(inCampusStudent);

            //Assert 
            Assert.False(inCampusStudent.MinimumScholarShipGiven);

        }


        public static TheoryData<int, bool> StronglyTypedExampleTestDataForGiveMinimumScholarship_WithProperty
        {
            get
            {
                return new TheoryData<int, bool>()
                {
                        { 10000, true },
                        { 50000, false }
                };
            }
        }

        public static IEnumerable<object[]> StronglyTypedExampleTestDataForGiveMinimumScholarship_WithMethod(
             int testDataInstancesToProvide)
        {
            var testData = new List<object[]>
                {
                        new object[] { 100, true },
                        new object[] { 200, false }
                };

            return testData.Take(testDataInstancesToProvide);
        }


        [Theory]
        //[InlineData(10000, true)]
        //[InlineData(50000, false)]
        //[MemberData(nameof(StronglyTypedExampleTestDataForGiveMinimumScholarship_WithProperty))]
        //[MemberData(nameof(StronglyTypedExampleTestDataForGiveMinimumScholarship_WithMethod),1)]
        //[ClassData(typeof(StudentServiceTestData))]
        //[ClassData(typeof(StronglyTypedStudentServiceTestData))]
        [ClassData(typeof(StronglyTypedStudentServiceTestData_FromFile))]
        public async Task GiveMinimumScholarship_ScholarshipGiven_InCampusStudentMinimumScholarshipGivenMustMatchTheValues(
          int ScholarshipGiven, bool expectedValueForMinimumScholarshipGiven)
        {
            //Arrange
            var inCampusStudent = new InCampusStudent(
                "Hasan", "Ahmadi", 5, ScholarshipGiven, false, 3);

            //Act
            await _studentServiceFixture.
                StudentService.GiveMinimumScholarShipGivenAsync(inCampusStudent);

            //Assert 
            Assert.Equal(expectedValueForMinimumScholarshipGiven, inCampusStudent.MinimumScholarShipGiven);

        }






        [Fact]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedFirstObligatoryLesson()
        {
           
            var obligatoryLesson = _studentServiceFixture.universityManagementRepositoryTestDataRepository
                .GetLesson(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var inCampusStudent = _studentServiceFixture.StudentService
                .CreateInCampusStudent("Pejman", "Vaziri");

            // Assert
            Assert.Contains(obligatoryLesson, inCampusStudent.AttendedLessons);
        }

        [Theory]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        public void CreateInCampusStudent_InCampusStudentCreated_MustHaveAttendedFirstObligatoryLesson_WithPredicate(Guid lessonId)
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
                lesson => lesson.Id == lessonId);
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
        public async Task CreateInCampusStudent_InCampusStudentCreated_AttendedLessonsMustMatchObligatoryLessonsAsync()        {
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


        [Fact]
        public async Task GivelevelRaise_LevelRaiseAboveMaximumGiven_InCampusStudentInvalidRaiseExceptionMustBeThrown()
        {
            // Arrange           
            var universityManagementRepositoryTestDataRepository =
              new UniversityManagementTestDataRepository();
            var studentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());

            var inCampusStudent = new InCampusStudent(
                "Hasan", "Ahmadi", 5, 3000, false, 3);

            // Act & Assert
            await Assert.ThrowsAsync<StudentInvalidlevelRaiseException>(
                async () =>
                await studentService.GiveLevelRaiseAsync(inCampusStudent, 30)
                );

        }


        //[Fact]
        //public void GivelevelRaise_LevelRaiseAboveMaximumGiven_InCampusStudentInvalidRaiseExceptionMustBeThrown_Bad()
        //{
        //    // Arrange           
        //    var universityManagementRepositoryTestDataRepository =
        //      new UniversityManagementTestDataRepository();
        //    var studentService = new StudentService(
        //        universityManagementRepositoryTestDataRepository,
        //        new StudentFactory());

        //    var inCampusStudent = new InCampusStudent(
        //        "Hasan", "Ahmadi", 5, 3000, false, 3);

        //    // Act & Assert
        //     Assert.ThrowsAsync<StudentInvalidlevelRaiseException>(
        //        async () =>
        //        await studentService.GiveLevelRaiseAsync(inCampusStudent, 30)
        //        );
        //}


        [Fact]
        public void NotifyOfGraduation_StudentIsAGraduated_OnStudentIsGradatedMustBeTriggered()
        {
            // Arrange 
            var studentService = new StudentService(
                new UniversityManagementTestDataRepository(),
                new StudentFactory());

            var inCampusStudent = new InCampusStudent(
                  "Hasan", "Ahmadi", 5, 3000, false, 3);

            // Act & Assert
            Assert.Raises<StudentIsGraduatedEventArgs>(
               handler => studentService.StudentIsGraduated += handler,
               handler => studentService.StudentIsGraduated -= handler,
               () => studentService.NotifyOfGraduation(inCampusStudent));
        }

        //[Fact]
        //public void CalculateStudyYears_Test()
        //{
        //    // Arrange 
        //    var studentService = new StudentService(
        //        new UniversityManagementTestDataRepository(),
        //        new StudentFactory());

        //    var inCampusStudent = new InCampusStudent(
        //          "Hasan", "Ahmadi", 5, 3000, false, 3);

        //    int studyyears = studentService.CalculateStudyYears(inCampusStudent);

        //    // Act & Assert
        //    Assert.Equal(200, studyyears);

        //}



    }
}
