using ArticleApp.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArticleApp.WebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public IActionResult HttpEntity<T>(ServiceResult<T> response)
        {
            switch (response.ErrorCode)
            {
                case 0: return Ok(response);
                case 1: return StatusCode(500, response);
                case 404: return NotFound(response);
                case 400: return BadRequest(response);
                default: throw new ApplicationException();
            }
        }
    }
}