using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
         public static void ConfigureDepenciesService(IServiceCollection serviceCollecion)
        {
            serviceCollecion.AddTransient<IUserService, UserService>();
            serviceCollecion.AddTransient<ILoginService, LoginService>();
        }
    }
}
