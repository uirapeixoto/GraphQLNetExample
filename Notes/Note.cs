using System.ComponentModel.DataAnnotations;

namespace GraphQLNetExample.Notes {
    public class Note {
        public Note (Guid id, string message) {
            this.Id = id;
            this.Message = message;

        }
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}