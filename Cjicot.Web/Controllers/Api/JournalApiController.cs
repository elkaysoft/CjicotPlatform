using Cjicot.Presentation.DTO;
using Cjicot.Presentation.Enum;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cjicot.Web.Controllers.Api
{
    public class JournalApiController : BaseApiController
    {
        private readonly IJournalManager _journalManager;
        private readonly IAccountManager _accountManager;

        public JournalApiController(IJournalManager journalManager, IAccountManager accountManager)
        {
            _journalManager = journalManager;
            _accountManager = accountManager;
        }

        [HttpPost]
        public IActionResult UploadManuscript([FromBody]UploadJournalsDto request)
        {
            var result = new ApiResult()
            {
                code = ResponseHub.RESPONSECODE01,
                message = ResponseHub.RESPONSEMESSAGE01
            };

            try
            {
                var validator = new JournalUploadValidator();
                var validationResult = validator.Validate(request);

                if (validationResult.IsValid)
                {
                    if (_accountManager.IsProfileIdValid(request.ProfileId))
                    {
                        var journalCreation = _journalManager.UploadJournalManuscript(request);
                        if(journalCreation == JournalUploadEnum.UploadSuccessful)
                        {
                            result.code = ResponseHub.RESPONSECODE00;
                            result.message = ResponseHub.RESPONSEMESSAGE00;
                            return Ok(result);
                        }
                        else
                        {
                            result.code=ResponseHub.RESPONSECODE02;
                            result.message = "Sorry, your manuscript upload failed, please try again later";
                        }

                    }
                    else
                    {
                        result.code = ResponseHub.RESPONSECODE02;
                        result.message = "Your profile cannot be accessed at the moment, kindly logout and login";
                        return BadRequest(result);
                    }
                }

            }
            catch(Exception ex)
            {
                HandleError(ex, "Sorry we unable to process, please try again later!");
            }


            return BadRequest(result);
        }
    }
}
