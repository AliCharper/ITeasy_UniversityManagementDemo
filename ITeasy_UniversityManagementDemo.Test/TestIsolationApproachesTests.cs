using Business;
using DataAccess.Factory;
using DataAccess.Repository;
using Domain.DbContexts;
using Domain.Entities;
using ITeasy_UniversityManagementDemo.Test.HttpMessageHandlers;
using ITeasy_UniversityManagementDemo.Test.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class TestIsolationApproachesTests
    {

        [Fact]
        public async Task PromoteInCampusStudentAsync_IsEligible_LevelMustBeIncreased()
        {
            // Arrange
            var httpClient = new HttpClient(
                new TestablePromotionEligibilityHandler(true));
            var inCampusStudent = new InCampusStudent(
                "Ali", "Kolahdoozan", 5, 3000, false, 1);
            var promotionService = new PromotionService(httpClient,
                new UniversityManagementTestDataRepository());

            // Act
            await promotionService.PromoteInCampusStudentAsync(inCampusStudent);

            // Assert
            Assert.Equal(2, inCampusStudent.Level);
        }


        [Fact]
        public async Task AttendLessonAsync_LessonAttended_SuggestedUnitsMustCorrectlyBeRecalculated()
        {
            // Arrange
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>()
                      .UseSqlite(connection);

            var dbContext = new ApplicationDBContext(optionsBuilder.Options);
            //dbContext.Database.Migrate();

            var UniversityManagementDataRepository =
               new UniversityManagementRepository(dbContext);

            var studentService = new StudentService(
                UniversityManagementDataRepository,
                new StudentFactory());

            // get lesson from database - "Dealing with Clients 101"
            var lessonToAttend = await UniversityManagementDataRepository
                .GetLessonAsync(Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"));

            // get existing student - "Ali Kolahdoozan"
            var inCampusStudent = await UniversityManagementDataRepository
                .GetInCampusStudentAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            if (lessonToAttend == null || inCampusStudent == null)
            {
                throw new XunitException("Arranging the test failed");
            }

            // expected suggested units after attending the lesson
            var expectedSuggestedBonus = inCampusStudent.SuggestedUnits + 10;

            // Act
            await studentService.AttendLessonAsync(inCampusStudent, lessonToAttend);

            // Assert
            Assert.Equal(expectedSuggestedBonus, inCampusStudent.SuggestedUnits);
        }
    }
}
