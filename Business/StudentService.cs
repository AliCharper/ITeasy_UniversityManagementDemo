using DataAccess.Factory;
using DataAccess.Repository;
using Domain.Entities;
using Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StudentService : IStudentService
    {
        private Guid[] _obligatoryLessonIds = {
            Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
            Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e") };

        private readonly IUniversityManagementRepository _repository;
        private readonly StudentFactory _studentFactory;



        public StudentService(IUniversityManagementRepository repository,
            StudentFactory studentFactory)
        {
            _repository = repository;
            _studentFactory = studentFactory;
        }

        public async Task AddInCampusStudentAsync(InCampusStudent inCampusStudent)
        {
            _repository.AddInCampusStudent(inCampusStudent);
            await _repository.SaveChangesAsync();
        }

        public async Task AttendLessonAsync(InCampusStudent student, Lesson attendedLesson)
        {
            var alreadyAttendedLesson = student.AttendedLessons
                .Any(c => c.Id == attendedLesson.Id);

            if (alreadyAttendedLesson)
            {
                return;
            }


            student.AttendedLessons.Add(attendedLesson);


            await _repository.SaveChangesAsync();


            student.SuggestedUnits += 10;
        }

        public ExternalStudent CreateExternalStudent(string firstName, string lastName, string company)
        {
            var student = (ExternalStudent)_studentFactory.CreateStudent(
                firstName, lastName, company, true);


            return student;
        }

        public InCampusStudent CreateInCampusStudent(string firstName, string lastName)
        {
            var student = (InCampusStudent)_studentFactory
                .CreateStudent(firstName, lastName);

            var obligatoryLessons = _repository.GetLessons(_obligatoryLessonIds);

            foreach (var obligatoryLesson in obligatoryLessons)
            {
                student.AttendedLessons.Add(obligatoryLesson);
            }

            student.SuggestedUnits = CalculateStudyYears(student);
            return student;
        }


        public async Task<InCampusStudent> CreateInCampusStudentAsync(string firstName, string lastName)
        {
            var student = (InCampusStudent)_studentFactory.CreateStudent(
               firstName, lastName);


            var obligatorylessons = await _repository.GetLessonsAsync(
                _obligatoryLessonIds);


            foreach (var obligatoryLesson in obligatorylessons)
            {
                student.AttendedLessons.Add(obligatoryLesson);
            }


            student.YearsOfStudy = CalculateStudyYears(student);
            return student;
        }


        public InCampusStudent? FetchInCampusStudent(Guid studentId)
        {
            var student = _repository.GetInCampusStudent(studentId);

            if (student != null)
            {
                student.YearsOfStudy = CalculateStudyYears(student);
            }
            return student;
        }

        public async Task<InCampusStudent?> FetchInCampusStudentAsync(Guid studentId)
        {
            var student = await _repository.GetInCampusStudentAsync(studentId);

            if (student != null)
            {

                student.YearsOfStudy = CalculateStudyYears(student);
            }
            return student;
        }

        public async Task<IEnumerable<InCampusStudent>> FetchInCampusStudentAsync()
        {
            var students = await _repository.GetInCampusStudentAsync();

            foreach (var student in students)
            {

                student.YearsOfStudy = CalculateStudyYears(student);
            }

            return students;
        }

        public async Task GiveMinimumScholarShipGivenAsync(InCampusStudent student)
        {
            student.Level += 1;
            student.MinimumScholarShipGiven = true;


            await _repository.SaveChangesAsync();
        }


        public async Task GiveLevelRaiseAsync(InCampusStudent student, int raise)
        {
            if (raise > 10)
            {
                throw new StudentInvalidlevelRaiseException(
                    "Invalid Levelraise: raise shoult Not be higher than 10.", raise);
            }


            if (student.MinimumScholarShipGiven && raise == 2)
            {
                throw new StudentInvalidlevelRaiseException(
                    "Invalid Levelraise: minimum Levelraise cannot be given twice.", raise);
            }

            if (raise == 5)
            {
                await GiveMinimumScholarShipGivenAsync(student);
            }
            else
            {
                student.Level += raise;
                student.MinimumScholarShipGiven = false;
                await _repository.SaveChangesAsync();
            }
        }

        private int CalculateStudyYears(InCampusStudent stdent)
        {
            if (stdent.SuggestedUnits < 50)
            {
                return stdent.YearsOfStudy + 1;
            }
            else
            {
                return stdent.YearsOfStudy
                    * stdent.AttendedLessons.Count * 10;
            }
        }

        public void NotifyOfAbsence(Student student)
        {
            throw new NotImplementedException();
        }

    }
}
