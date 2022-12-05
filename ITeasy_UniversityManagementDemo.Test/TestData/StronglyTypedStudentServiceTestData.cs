using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test.TestData
{
    public class StronglyTypedStudentServiceTestData : TheoryData<int, bool>
    {
        public StronglyTypedStudentServiceTestData()
        {
            Add(100, true);
            Add(200, false);
        }
    }
}
