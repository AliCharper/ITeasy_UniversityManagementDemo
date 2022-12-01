using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class StudentTests
    {
        [Fact]
        public void StudentFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            // Arrange
            var student = new InCampusStudent("Arash", "laylazi", 0, 2500, false, 1);

            // Act
            student.FirstName = "Ali";
            student.LastName = "Kolahdoozan";

            // Assert
            Assert.Equal("Ali Kolahdoozan", student.FullName, ignoreCase: true);
        }

        [Fact]
        public void StudentFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
        {
            // Arrange
            var student = new InCampusStudent("Arash", "laylazi", 0, 2500, false, 1);

            // Act
            student.FirstName = "Ali";
            student.LastName = "Kolahdoozan";

            // Assert
            Assert.StartsWith(student.FirstName, student.FullName);
        }

        [Fact]
        public void StudentFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithFirstName()
        {
            // Arrange
            var student = new InCampusStudent("Arash", "laylazi", 0, 2500, false, 1);


            // Act
            student.FirstName = "Ali";
            student.LastName = "Kolahdoozan";

            // Assert
            Assert.EndsWith(student.LastName, student.FullName);
        }

        [Fact]
        public void StudentFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            // Arrange
            var student = new InCampusStudent("Arash", "laylazi", 0, 2500, false, 1);

            // Act
            student.FirstName = "Ali";
            student.LastName = "Kolahdoozan";

            // Assert
            Assert.Contains("li ko", student.FullName, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void StudentFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            // Arrange
            var student = new InCampusStudent("Arash", "laylazi", 0, 2500, false, 1);

            // Act
            student.FirstName = "Ali";
            student.LastName = "Kolahdoozan";

            // Assert
            Assert.Matches("Ali Kolah(t|d)oozan", student.FullName);
        }
    }
}
