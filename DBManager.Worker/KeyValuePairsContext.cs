using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Worker
{
    public class KeyValuePairsContext : DbContext
    {
        public KeyValuePairsContext(DbContextOptions<KeyValuePairsContext> options)
            : base(options)
        {
        }

        public DbSet<KeyValuePairs> KeyValuePairs { get; set; }
    }

    public class KeyValuePairs
    {
        [Key]
        public string Key { get; set; }
        public byte[] Value { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TTL { get; set; }
    }
}
