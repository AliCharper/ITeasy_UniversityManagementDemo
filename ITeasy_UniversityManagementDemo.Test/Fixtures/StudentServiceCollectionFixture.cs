using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test.Fixtures
{
    [CollectionDefinition("StudentServiceCollection")]
    public class StudentServiceCollectionFixture
        : ICollectionFixture<StudentServiceFixture>
    {
    }
}
