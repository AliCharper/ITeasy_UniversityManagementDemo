using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IStudentService
    {
        Task AddInCampusStudentAsync(InCampusStudent inCampusStudent);

        Task AttendLessonAsync(InCampusStudent student, Lesson attendedLesson);

        ExternalStudent CreateExternalStudent(string firstName,
           string lastName, string company);

        InCampusStudent CreateInCampusStudent(string firstName,
            string lastName);

        Task<InCampusStudent> CreateInCampusStudentAsync(string firstName,
            string lastName);

        InCampusStudent? FetchInCampusStudent(Guid studentId);

        Task<InCampusStudent?> FetchInCampusStudentAsync(Guid studentId);

        Task<IEnumerable<InCampusStudent>> FetchInCampusStudentAsync();

        Task GiveMinimumScholarShipGivenAsync(InCampusStudent student);

        Task GiveLevelRaiseAsync(InCampusStudent student, int raise);
        void NotifyOfGraduation(Student student);
    }
}
