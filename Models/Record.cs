namespace Recordboxed
{
    public class Record {
        public int RecordId { get; set; } 
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public string? Meta { get; set; }
    }
}