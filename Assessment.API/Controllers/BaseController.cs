﻿using Assessment.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status500InternalServerError)]
    public class BaseController : ControllerBase
    {
        protected ActionResult GetApiResponse<T>(ApiResponse<T> obj) where T : class
        {
            if (obj.IsSuccessStatusCode && obj.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                return StatusCode(obj.StatusCode);

            if (obj.IsSuccessStatusCode)
                return StatusCode(obj.StatusCode, obj.Data);

            if (!obj.IsSuccessStatusCode && obj.HttpStatusCode == System.Net.HttpStatusCode.Conflict)
                return StatusCode(obj.StatusCode, obj.Data);

            return StatusCode(obj.StatusCode, obj.Errors);
        }
    }
}
