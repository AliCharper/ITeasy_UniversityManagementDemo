using Business;
using DataAccess.Factory;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class CrossCutting
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<StudentFactory>();
            services.AddScoped<IUniversityManagementRepository, UniversityManagementRepository>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
