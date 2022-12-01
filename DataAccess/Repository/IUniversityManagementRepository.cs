using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUniversityManagementRepository
    {
        Task<IEnumerable<InCampusStudent>> GetInCampusStudentAsync();

        InCampusStudent? GetInCampusStudent(Guid StudentId);

        Task<InCampusStudent?> GetInCampusStudentAsync(Guid StudentId);

        Task<Lesson?> GetLessonAsync(Guid LessonID);

        Lesson? GetLesson(Guid LessonID);

        List<Lesson> GetLessons(params Guid[] LessonIDs);

        Task<List<Lesson>> GetLessonsAsync(params Guid[] LessonIds);

        void AddInCampusStudent(InCampusStudent incampusStudent);

        Task SaveChangesAsync();
    }
}
