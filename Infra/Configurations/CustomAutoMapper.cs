using AutoMapper;
using Infra.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configurations
{
    public static class CustomAutoMapper
    {
        public static void AddCustomConfiguredAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StudentMappingProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
