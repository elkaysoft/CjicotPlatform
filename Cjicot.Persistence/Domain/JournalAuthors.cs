using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Domain
{
    public class JournalAuthors
    {
        [Key]
        public Int64 Id { get; set; }
        public Guid JournalId { get; set; }
        public string Title { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Affliation { get; set; }
        public string Country { get; set; }
        public DateTime CreatedOn { get; set; }
        public Journals Journals { get; set; }


    }
}
