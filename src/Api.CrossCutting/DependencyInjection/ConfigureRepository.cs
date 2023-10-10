using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
       public static void ConfigureDepenciesServiceRepository(IServiceCollection serviceCollecion)
        {
            serviceCollecion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollecion.AddScoped<IUserRepository, UserImplementation>();
           
            serviceCollecion.AddDbContext<MyContext> (
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=genesysjp")
            );
        }
    }

 
}
