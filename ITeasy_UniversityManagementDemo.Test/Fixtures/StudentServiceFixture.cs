using Business;
using DataAccess.Factory;
using DataAccess.Repository;
using ITeasy_UniversityManagementDemo.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test.Fixtures
{
    public class StudentServiceFixture : IDisposable
    {
        public IUniversityManagementRepository universityManagementRepositoryTestDataRepository
        { get; }
        public StudentService StudentService
        { get; }

        public StudentServiceFixture()
        {
            universityManagementRepositoryTestDataRepository =
                new UniversityManagementTestDataRepository();

            StudentService = new StudentService(
                universityManagementRepositoryTestDataRepository,
                new StudentFactory());
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}
