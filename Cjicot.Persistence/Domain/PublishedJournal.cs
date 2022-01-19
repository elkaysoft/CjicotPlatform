using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Domain
{
    public class PublishedJournal
    {
        [Key]
        public Int64 Id { get; set; }
        public Guid JournalId { get; set; }
        public Guid AuthorId { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public DateTime DatePublished { get; set; }
        
    }
}
