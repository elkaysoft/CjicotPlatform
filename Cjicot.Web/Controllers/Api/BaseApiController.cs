using Cjicot.Presentation.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cjicot.Web.Controllers.Api
{
    public class BaseApiController : Controller
    {
        public IActionResult HandleError(Exception ex, string customMessage = null)
        {
            var rsp = new ApiResult();
            rsp.code = ResponseHub.RESPONSECODE99;

#if DEBUG
            rsp.message = customMessage ?? (ex?.InnerException?.Message ?? ex.Message);
#else
            rsp.ResponseMessage = customMessage ?? "Oops, an error occured while working on your request";
#endif
            //_logger.Error(ex.Message, ex);
            return BadRequest(rsp);
        }
    }
}
