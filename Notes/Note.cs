namespace GraphQLNetExample.Notes {
    public class Note {
        public Note (Guid id, string message) {
            this.Id = id;
            this.Message = message;

        }
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}