using System.ComponentModel.DataAnnotations;

namespace Recordboxed
{
    public class Record {
        // todo Guid vs Id?
        // [Key]
        // public required Guid RecordId { get; set; } 
        [Key]
        public int Id { get; set; } 
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string Meta { get; set; }
    }
}