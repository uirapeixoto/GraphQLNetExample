using GraphQL.Types;

namespace GraphQLNetExample.Notes
{
    public class NotesSchema : Schema
    {
        public NotesSchema(IServiceProvider servicesProvider) : base(servicesProvider)
        {
            Query = servicesProvider.GetRequiredService<NotesQuery>();
        }
    }
}