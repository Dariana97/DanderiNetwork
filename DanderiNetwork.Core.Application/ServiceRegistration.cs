using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace DanderiNetwork.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services) 
        {
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IPostService, PostService>();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ICommentService, CommentServices>();








        }
    }
}
