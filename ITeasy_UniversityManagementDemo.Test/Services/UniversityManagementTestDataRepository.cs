using DataAccess.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITeasy_UniversityManagementDemo.Test.Services
{
    public class UniversityManagementTestDataRepository : IUniversityManagementRepository
    {
        private List<InCampusStudent> _inCampusStudents;
        private List<ExternalStudent> _externalStudents;
        private List<Lesson> _lessons;

        public UniversityManagementTestDataRepository()
        {
            // mimic expensive creation process
            Thread.Sleep(3000);

            // initialize with dummy data 
            var obligatoryLesson1 = new Lesson("University Introduction")
            {
                Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                IsNew = false
            };

            var obligatoryLesson2 = new Lesson("Respecting Your Classmates")
            {
                Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                IsNew = false
            };

            var optionalLesson1 = new Lesson("Dealing with Clients 101")
            {
                Id = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
                IsNew = false
            };

            _lessons = new()
            {
                obligatoryLesson1,
                obligatoryLesson2,
                optionalLesson1,
                new Lesson("Headache with Python - Advanced")
                {
                    Id = Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"),
                    IsNew = false
                },
                new Lesson("Management 101")
                {
                    Id = Guid.Parse("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"),
                    IsNew = false
                }
            };

            _inCampusStudents = new()
            {
                new InCampusStudent("Ali", "Kolahdoozan", 6, 200000, false, 2)
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"),
                    AttendedLessons = new List<Lesson> {
                            obligatoryLesson1, obligatoryLesson2 }
                },
                new InCampusStudent("Arash", "Layazi", 4, 150000, true, 1)
                {
                    Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"),
                    AttendedLessons = new List<Lesson> {
                            obligatoryLesson1, obligatoryLesson2, optionalLesson1 }
                }
            };

            _externalStudents = new()
            {
                new ExternalStudent("Mohammad", "Jafary", "IT for Idiots, Inc")
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                }
            };
        }

        public void AddInCampusStudent(InCampusStudent incampusStudent)
        {
            // empty on purpose
        }



        public Lesson? GetLesson(Guid lessonId)
        {
            return _lessons.FirstOrDefault(c => c.Id == lessonId);
        }

        public Task<Lesson?> GetLessonAsync(Guid lessonId)
        {
            return Task.FromResult(GetLesson(lessonId));
        }

        public List<Lesson> GetLessons(params Guid[] lessonIds)
        {
            List<Lesson> LessonsToReturn = new();
            foreach (var lessonId in lessonIds)
            {
                var lesson = GetLesson(lessonId);
                if (lesson != null)
                {
                    LessonsToReturn.Add(lesson);
                }
            }
            return LessonsToReturn;
        }

        public Task<List<Lesson>> GetLessonsAsync(params Guid[] lessonIds)
        {
            return Task.FromResult(GetLessons(lessonIds));
        }


        public InCampusStudent? GetInternalEmployee(Guid employeeId)
        {
            return _inCampusStudents.FirstOrDefault(e => e.Id == employeeId);
        }

        public Task<InCampusStudent?> GetInternalEmployeeAsync(Guid employeeId)
        {
            return Task.FromResult(GetInternalEmployee(employeeId));
        }

        public Task<IEnumerable<InCampusStudent>> GetInternalEmployeesAsync()
        {
            return Task.FromResult(_inCampusStudents.AsEnumerable());
        }

        public InCampusStudent? GetInCampusStudent(Guid StudentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InCampusStudent>> GetInCampusStudentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InCampusStudent?> GetInCampusStudentAsync(Guid StudentId)
        {
            throw new NotImplementedException();
        }



        public Task SaveChangesAsync()
        {
            // nothing to do here
            return Task.CompletedTask;
        }
    }
}
