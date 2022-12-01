using Domain.DbContexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UniversityManagementRepository : IUniversityManagementRepository
    {
        private readonly ApplicationDBContext _context;

        public UniversityManagementRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<InCampusStudent>> GetInCampusStudentAsync()
        {
            return await _context.InCampusStudents
                .Include(e => e.AttendedLessons)
                .ToListAsync();
        }

        public async Task<InCampusStudent?> GetInCampusStudentAsync(Guid studentId)
        {
            return await _context.InCampusStudents
                .Include(e => e.AttendedLessons)
                .FirstOrDefaultAsync(e => e.Id == studentId);
        }

        public InCampusStudent? GetInCampusStudent(Guid studentId)
        {
            return _context.InCampusStudents
                .Include(e => e.AttendedLessons)
                .FirstOrDefault(e => e.Id == studentId);
        }

        public async Task<Lesson?> GetLessonAsync(Guid LessonId)
        {
            return await _context.Lessons.FirstOrDefaultAsync(e => e.Id == LessonId);
        }

        public Lesson? GetLesson(Guid LessonId)
        {
            return _context.Lessons.FirstOrDefault(e => e.Id == LessonId);
        }

        public List<Lesson> GetLessons(params Guid[] LessonIds)
        {
            List<Lesson> LessonsToReturn = new();
            foreach (var lessonid in LessonIds)
            {
                var lesson = GetLesson(lessonid);
                if (lesson != null)
                {
                    LessonsToReturn.Add(lesson);
                }
            }
            return LessonsToReturn;
        }

        public async Task<List<Lesson>> GetLessonsAsync(params Guid[] LessonIds)
        {
            List<Lesson> lessonToReturn = new();
            foreach (var lessonId in LessonIds)
            {
                var lesson = await GetLessonAsync(lessonId);
                if (lesson != null)
                {
                    lessonToReturn.Add(lesson);
                }
            }
            return lessonToReturn;
        }

        public void AddInCampusStudent(InCampusStudent inCampusStudent)
        {
            _context.InCampusStudents.Add(inCampusStudent);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
