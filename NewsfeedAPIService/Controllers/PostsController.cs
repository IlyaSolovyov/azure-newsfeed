using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsfeedAPIService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        [HttpGet("digests/{digestId}")]
        public IActionResult GetPostsByDigest(int digestId)
        {
            return Ok("Succesfully asked for posts by id#" + digestId);
        }
    }
}