using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLNetExample.Notes;

namespace GraphQLNetExample.Extensions {
    public static class DependencyInjection {
        public static void RegisterServices (this IServiceCollection services) {
            services.AddGraphQLConfiguration ();
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