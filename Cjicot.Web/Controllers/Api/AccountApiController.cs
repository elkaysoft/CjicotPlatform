using Cjicot.Presentation.DTO;
using Cjicot.Presentation.IManager;
using Cjicot.Presentation.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cjicot.Web.Controllers.Api
{
    public class AccountApiController : BaseApiController
    {
        private readonly IAccountManager _accountManager;

        public AccountApiController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginDto request)
        {
            var result = new ApiResult
            {
                code = ResponseHub.RESPONSECODE01,
                message = ResponseHub.RESPONSEMESSAGE01,
            };

            try
            {
                var validator = new LoginValidator();
                var validationResult = validator.Validate(request);

                if (validationResult.IsValid)
                {
                    var resp = _accountManager.AppLogin(request);
                    if(resp.Username != null)
                    {
                        if (resp.IsActive)
                        {
                            if (!resp.IsLocked)
                            {
                                result.code = ResponseHub.RESPONSECODE00;
                                result.message = ResponseHub.RESPONSEMESSAGE00;
                                return Ok(result);
                            }
                            else
                            {
                                result.code = ResponseHub.RESPONSECODE02;
                                result.message = "Your account has been locked, kindly reset your password";
                                return BadRequest(result);
                            }
                        }
                        else
                        {
                            result.code = ResponseHub.RESPONSECODE02;
                            result.message = "Your account has been disabled, kindly contact the administrator";
                            return BadRequest();
                        }
                    }
                    else
                    {
                        result.code = ResponseHub.RESPONSECODE02;
                        result.message = "Invalid Username/Password";
                        return BadRequest(result);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                HandleError(ex, ResponseHub.RESPONSEMESSAGE99);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AuthorRegistration(RegistrationDto payload)
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
