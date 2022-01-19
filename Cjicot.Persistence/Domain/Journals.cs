using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Domain
{
    public class Journals
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string JournalType { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Keywords { get; set; }
        public int ReviewerStatus { get; set; }
        public Guid ReviewerId { get; set; }
        public DateTime? DateReviewed { get; set; }
        public int EditorStatus { get; set; }
        public Guid EditorId { get; set; }
        public DateTime? DateEdited { get; set; }
        public int IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public JournalAuthors JournalAuthors { get; set; }
        public JournalDocuments JournalDocuments { get; set; }
    }
}
