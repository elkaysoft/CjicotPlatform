using Cjicot.Presentation.DTO;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cjicot.Web.Controllers.Api
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public IActionResult AuthorRegisteration(RegistrationDto payload)
        {
            var result = new ApiResult
            {
                code = ResponseHub.RESPONSECODE01,
                message = ResponseHub.RESPONSEMESSAGE01,
            };

            try
            {
                var validator = new RegistrationValidator();
                var validationResult = validator.Validate(payload);

                if (validationResult.IsValid)
                {
                    if (_accountManager.IsUserExists(payload.Username))
                    {
                        result.code = ResponseHub.RESPONSECODE02;
                        result.message = "Username exists, pls try again later";
                        return BadRequest(result);
                    }
                    else
                    {
                        var uploadResp = _accountManager.RegisterAuthor(payload);
                        if(uploadResp > 0)
                        {
                            result.code = ResponseHub.RESPONSECODE00;
                            result.message = ResponseHub.RESPONSEMESSAGE00;
                            return Ok(result);
                        }
                        else
                        {
                            result.code = ResponseHub.RESPONSECODE01;
                            result.message = ResponseHub.RESPONSEMESSAGE01;
                            return BadRequest(result);
                        }
                    }
                }
                else
                {
                    result.code = ResponseHub.RESPONSECODE01;
                    result.message = helper.ResolveFluentValidationErrorToStr(validationResult.Errors);
                    return BadRequest(result);
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
