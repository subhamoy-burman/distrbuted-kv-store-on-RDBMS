using System.ComponentModel.DataAnnotations;

namespace KeyValuePair.API.Model
{
    public class KeyValuePairs
    {
        [Key]
        public string Key { get; set; }
        public byte[] Value { get; set; } // Blob data type
        public bool isDeleted { get; set; }
        public DateTime TTL { get; set; } // Timestamp
    }
}
