using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] IFormFile passportPhoto)
        {
            if (passportPhoto == null || passportPhoto.Length == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            byte[] outputArray;
            using (var stream = new MemoryStream())
            {
                await passportPhoto.CopyToAsync(stream);
                outputArray = stream.ToArray();
            }

            Response.StatusCode = (int)HttpStatusCode.OK;



            return outputArray.Length.ToString();

        }
    }
}
