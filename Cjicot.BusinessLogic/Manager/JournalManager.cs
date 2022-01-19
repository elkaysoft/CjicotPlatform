using Cjicot.Persistence.Domain;
using Cjicot.Persistence.Repository;
using Cjicot.Presentation.DTO;
using Cjicot.Presentation.Enum;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Manager
{
    public class JournalManager : IJournalManager
    {
        private readonly IRepository<Journals> _journalRepository;
        private readonly IRepository<JournalAuthors> _authorsRepository;
        private readonly IRepository<JournalDocuments > _documentsRepository;


        public JournalManager(IRepository<Journals> journalRepository, IRepository<JournalAuthors> authorsRepository, IRepository<JournalDocuments> documentsRepository)
        {
            _journalRepository = journalRepository;
            _authorsRepository = authorsRepository;
            _documentsRepository = documentsRepository;
        }

        public JournalUploadEnum UploadJournalManuscript(UploadJournalsDto request)
        {
            var result = new JournalUploadEnum();

            try
            {
                if (IsManuscriptDetailExists(request.Title))
                {
                    var journalId = request.JournalId;
                    var uploadResp = AddJournalInfo(journalId, request.ProfileId, request.JournalType, request.Title, 
                        request.Abstract, request.Keywords);

                    if(uploadResp > 0)
                    {
                        AddJournalAuthors(request.manuscriptAuthors, journalId);
                        AddJournalDocuments(request.documents, journalId);
                        result = JournalUploadEnum.UploadSuccessful;
                    }
                    else
                    {
                        result = JournalUploadEnum.UploadFailed;
                    }

                }
                else
                {
                    result = JournalUploadEnum.JournalExists;
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                result = JournalUploadEnum.UploadFailed;
            }

            return result;
        }



        #region Private Implementations

        private int AddJournalInfo(Guid journalId, Guid profileId, string journalType, string title, string abstractText, string keywords)
        {
            var journalObj = new Journals();
            journalObj.Title = title;
            journalObj.Id = journalId;
            journalObj.ProfileId = profileId;
            journalObj.JournalType = journalType; 
            journalObj.Abstract  = abstractText;
            journalObj.Keywords = keywords;
            journalObj.CreatedOn = DateTime.Now;
            journalObj.ReviewerStatus = (int)JournalStatusEnum.AwaitingReviewer;

            return _journalRepository.Insert(journalObj);
        }

        private void AddJournalAuthors(List<ManuscriptAuthors> request, Guid journalId)
        {
            foreach (var authors in request)
            {
                var journalAuthor = new JournalAuthors
                {
                    Affliation = authors.Affliation,
                    EmailAddress = authors.EmailAddress,
                    Country = authors.Country,
                    CreatedOn = DateTime.Now,
                    JournalId = journalId,
                    LastName = authors.LastName,
                    OtherName = authors.OtherName,
                    Title = authors.Salutation
                };

                _authorsRepository.Insert(journalAuthor);
            }
        }

        private bool IsManuscriptDetailExists(string title)
        {
            bool isManuscriptDetailExists = false;
            var resp = _journalRepository.GetFirstOrDefault(x => x.Title == title);
            if(resp != null)
            {
                isManuscriptDetailExists = true;
            }

            return isManuscriptDetailExists;
        }

        private void AddJournalDocuments(JournalSupportingDocs journalDoc, Guid journalId)
        {
            var docObj = new JournalDocuments
            {
                CoverLetterUrl = journalDoc.CoverLetterUrl,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                JournalId = journalId,
                ManuscriptFileUrl = journalDoc.ManuscriptFileUrl,
                SupplementaryFileUrl = journalDoc.SupplementaryFileUrl
            };
            _documentsRepository.Insert(docObj);
        }


        #endregion

    }
}
