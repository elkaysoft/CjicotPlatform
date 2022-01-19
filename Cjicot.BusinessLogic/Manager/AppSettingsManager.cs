using Cjicot.Persistence.Domain;
using Cjicot.Persistence.Repository;
using Cjicot.Presentation.DTO;
using Cjicot.Presentation.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Manager
{
    public class AppSettingsManager : IAppSettingsManager
    {
        private readonly IRepository<JournalCategory> _journalRepository;

        public AppSettingsManager(IRepository<JournalCategory> journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<List<JournalCategoryDto>> GetJournalCategories()
        {
            var result = new List<JournalCategoryDto>();

            try
            {
                var journals = await _journalRepository.GetAllAsync(x => x.IsDeleted == false);
                journals.ForEach(p =>
                {
                    result.Add(new JournalCategoryDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    });
                });
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            return result;
        }
    }
}
