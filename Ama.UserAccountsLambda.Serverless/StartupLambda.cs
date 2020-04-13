namespace Ama.UserAccountsLambda.Serverless
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;
    using MediatR;
    using Ama.UserAccountsLambda.Application;

    public class StartupLambda
    {
        public IServiceCollection AddLambdaServices(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            var applicationAssembly = new AssemblyApplication().GetAssembly();
            services.AddMediatR(applicationAssembly);

            return services;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                #if DEBUG
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                #endif
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
