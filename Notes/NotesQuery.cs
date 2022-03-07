using GraphQL;
using GraphQL.Types;
using GraphQLNetExample.Data;

namespace GraphQLNetExample.Notes {
    public class NotesQuery : ObjectGraphType {
        public NotesQuery () {
            Field<ListGraphType<NoteType>> ("notes_mock", resolve:
                context => new List<Note> {
                    new Note { Id = 1, Message = "Hello World!" },
                    new Note { Id = 2, Message = "Hello World! How are you?" }
                });
            Field<ListGraphType<NoteType>> ("notes", resolve : context => {
                var notesContext = context.RequestServices.GetRequiredService<DataContext> ();
                return notesContext.Notes.ToList ();
            });
            
            Field<NoteType> ("note_by_id",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id" }
            ) ,
            resolve : context => {
                var id = context.GetArgument<int> ("id");
                var notesContext = context.RequestServices.GetRequiredService<DataContext> ();
                var rs = notesContext.Notes.FirstOrDefault(x => x.Id == id);
                return rs;
            } );

             Field<ListGraphType<NoteType>> ("note_contains_on_message",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "word" }
            ) ,
            resolve : context => {
                var word = context.GetArgument<string> ("word");
                var notesContext = context.RequestServices.GetRequiredService<DataContext> ();
                var rs = notesContext.Notes.Where(x => x.Message.Contains(word)).ToList();
                return rs;
            } );
        }
    }
}