using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsfeedAPIService.DAL;
using NewsfeedAPIService.Models;
using NewsfeedAPIService.ViewModels;

namespace NewsfeedAPIService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        NewsfeedContext db;

        public PostsController(NewsfeedContext context)
        {
            db = context;
        }

        [HttpGet("digests/{digestId}")]
        public IActionResult GetPostsByDigest(int digestId)
        {
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            List<DigestSource> digestSources = db.DigestSources
                .Include(ds => ds.Source)
                .Where(ds => ds.DigestId == digestId)
                .ToList();

            List<Source> sources = new List<Source>();
            foreach (DigestSource ds in digestSources)
            {
                sources.Add(ds.Source);
            }

            List<Post> postModels = new List<Post>();
            List<PostViewModel> posts = new List<PostViewModel>();
            foreach (Source source in sources)
            {
                postModels = db.Posts
                    .Where(post => post.SourceId == source.Id)
                    .ToList();
                foreach (Post postModel in postModels)
                {
                    posts.Add(new PostViewModel(postModel, source));
                }
            }

            return Ok(posts
                .OrderByDescending(post => post.TimePosted));
        }
    }
}