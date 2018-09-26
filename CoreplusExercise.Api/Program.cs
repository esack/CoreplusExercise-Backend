using System;
using Autofac;
using CoreplusExercise.Accessor.Practitioner;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreplusExercise.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = ApiAutofacContainer.Container.BeginLifetimeScope())
            {
                try
                {
                    var context = scope.Resolve<PractitionerContext>();

                    PractitionerContextInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = scope.Resolve<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
