using GraphQL.Types;
using GraphQLNetExample.Data;

namespace GraphQLNetExample.Notes {
    public class NotesQuery : ObjectGraphType {
        public NotesQuery () {
            Field<ListGraphType<NoteType>> ("notes", resolve:
                context => new List<Note> {
                    new Note { Id = 1, Message = "Hello World!" },
                    new Note { Id = 2, Message = "Hello World! How are you?" }
                });
            Field<ListGraphType<NoteType>> ("notesFromEF", resolve : context => {
                var notesContext = context.RequestServices.GetRequiredService<DataContext> ();
                return notesContext.Notes.ToList ();
            });
        }
    }
}