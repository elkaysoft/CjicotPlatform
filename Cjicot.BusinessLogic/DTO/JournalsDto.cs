using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.DTO
{
    public class UploadJournalsDto
    {
        public UploadJournalsDto()
        {
            JournalId = Guid.NewGuid();
        }

        public Guid ProfileId { get; set; }
        public Guid JournalId { get; set; }
        public string JournalType { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Keywords { get; set; }
        public List<ManuscriptAuthors> manuscriptAuthors { get; set; } = new List<ManuscriptAuthors>();
        public JournalSupportingDocs documents { get; set; }
    }

    public class ManuscriptAuthors
    {
        public string Salutation { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Affliation { get; set; }
        public string Country { get; set; }
    }

    public class JournalSupportingDocs
    {
        public string CoverLetterUrl { get; set; }
        public string ManuscriptFileUrl { get; set; }
        public string SupplementaryFileUrl { get; set; }
    }

}
