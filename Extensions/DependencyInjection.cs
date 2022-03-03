using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLNetExample.Data;
using GraphQLNetExample.Notes;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetExample.Extensions {
    public static class DependencyInjection {
        public static void RegisterServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddGraphQLConfiguration ();
            services.AddDbContextService(configuration);
        }

        public static void AddDbContextService (this IServiceCollection services, IConfiguration configuration){
            // Add services to the container.
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        public static void AddGraphQLConfiguration (this IServiceCollection services) {
            // Add services to the container.
            // add notes schema
            services.AddSingleton<ISchema, NotesSchema> (services =>
                new NotesSchema (new SelfActivatingServiceProvider (services))
            );

            // register graphQL
            services.AddGraphQL (options => {
                options.EnableMetrics = true;
            }).AddSystemTextJson ();
        }
    }
}