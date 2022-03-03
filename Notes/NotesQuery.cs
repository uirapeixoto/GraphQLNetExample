using GraphQL.Types;

namespace GraphQLNetExample.Notes {
    public class NotesQuery : ObjectGraphType {
        public NotesQuery () {
            Field<ListGraphType<NoteType>> ("notes", resolve : context => new List<Note> {
                new Note (Guid.NewGuid (), "Hello World!"),
                new Note (Guid.NewGuid (), "Hello World! How are you?")
            });
        }
    }
}