using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Domain
{
    public class JournalDocuments
    {
        [Key]
        public Int64 Id { get; set; }
        public Guid JournalId { get; set; }
        public string CoverLetterUrl { get; set; }
        public string ManuscriptFileUrl { get; set; }
        public string SupplementaryFileUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public Journals Journals { get; set; }

    }
}
