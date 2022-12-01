using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbContexts
{
    //*************** Migration ***************
    //1- Add-Migration InitialMigration
    //2- Update-Database

    public class ApplicationDBContext : DbContext
    {
        public DbSet<InCampusStudent> InCampusStudents { get; set; } = null!;
        public DbSet<ExternalStudent> ExternalStudents { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Lesson>()
                  .HasData(obligatoryLesson1,
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
                  );

            modelBuilder.Entity<InCampusStudent>()
                .HasData(
                    new InCampusStudent("Ali", "Kolahdoozan", 6, 200000, false, 2)
                    {
                        Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                    },
                    new InCampusStudent("Arash", "Layazi", 4, 150000, true, 1)
                    {
                        Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f")
                    });

            modelBuilder
                .Entity<InCampusStudent>()
                .HasMany(p => p.AttendedLessons)
                .WithMany(p => p.StudentsThatAttended)
                .UsingEntity(j => j.ToTable("LessonInCampusStudent").HasData(new[]
                    {
                        new { AttendedLessonsId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                            StudentsThatAttendedId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                        new { AttendedLessonsId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                            StudentsThatAttendedId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                        new { AttendedLessonsId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                            StudentsThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                        new { AttendedLessonsId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                            StudentsThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                        new { AttendedLessonsId = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
                            StudentsThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") }
                    }
                ));

            modelBuilder.Entity<ExternalStudent>()
                .HasData(
                    new ExternalStudent("Mohammad", "Jafary", "IT for Idiots, Inc")
                    {
                        Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                    });
        }
    }
}
