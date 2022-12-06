using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test.TestData
{
    public class StronglyTypedStudentServiceTestData_FromFile : TheoryData<int, bool>
    {
        public StronglyTypedStudentServiceTestData_FromFile()
        {
            var testDataLines = File.ReadAllLines("TestData/StudentServiceTestData.csv");

            foreach (var line in testDataLines)
            {
                // split the string
                var splitString = line.Split(',');
                // try parsing 
                if (int.TryParse(splitString[0], out int ScholarshipGiven)
                    && bool.TryParse(splitString[1], out bool expectedValueForMinimumScholarshipGiven))
                {
                    // add test data
                    Add(ScholarshipGiven, expectedValueForMinimumScholarshipGiven);
                }
            }
        }
    }
}
