using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SuperAwesome.Api.Data;

namespace SuperAwesome.Api.Business
{
    public static class DataSeeder
    {
        public static void VerifyInitialDbSeed(this IServiceScope scope)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
            var hostingEnv = scope.ServiceProvider.GetRequiredService<IHostingEnvironment>();

            VerifyUsers(dbContext, hostingEnv);
        }

        private static void VerifyUsers(ApiDbContext context, IHostingEnvironment roleManager)
        {
            var numberOfPorjects = context.Set<Domain.Project>().Count();

            if (numberOfPorjects == 0)
            {

            }
        }
    }
}