using GraphQL.Types;

namespace GraphQLNetExample.Notes
{
    public class NoteType : ObjectGraphType<Note>
    {
        public NoteType()
        {
            Name = nameof(Note);
            Description = "Note Type";
            Field(d => d.Id, nullable: false).Description("Note Id");
            Field(d => d.Message, nullable: true).Description("Note Message");
            Field(d => d.Active, nullable: true).Description("Note active");
            Field(d => d.CreatedAt, nullable: true).Description("Note createdAt");
            Field(d => d.ModifiedAt, nullable: true).Description("Note modifieddAt");
        }
    }
}