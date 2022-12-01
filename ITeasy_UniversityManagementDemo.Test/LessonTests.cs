using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test
{
    public class LessonTests
    {
        [Fact]
        public void LessonConstructor_ConstructLesson_IsNewMustBeTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var lesson = new Lesson("C#.NET 11 - Advanced");

            // Assert
            Assert.True(lesson.IsNew);
        }
    }
}
