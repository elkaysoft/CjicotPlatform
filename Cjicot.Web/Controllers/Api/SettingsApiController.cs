using Cjicot.Presentation.DTO;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cjicot.Web.Controllers.Api
{
    public class SettingsApiController : BaseApiController
    {
        private readonly IAppSettingsManager _appSettingsManager;

        public SettingsApiController(IAppSettingsManager appSettingsManager)
        {
            _appSettingsManager = appSettingsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetJournalCategories()
        {
            var result = new ApiResult<List<JournalCategoryDto>>()
            {
                code = ResponseHub.RESPONSECODE01,
                message = ResponseHub.RESPONSEMESSAGE01,
            };

            try
            {
                var categories = await _appSettingsManager.GetJournalCategories();
                if(categories != null)
                {
                    result.message = ResponseHub.RESPONSECODE00;
                    result.code = ResponseHub.RESPONSECODE00;
                    result.data = categories;
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                HandleError(ex, ResponseHub.RESPONSEMESSAGE99);
            }

            return BadRequest(result);
        }
    }
}
