using Microsoft.AspNetCore.Mvc;
using RedditAccessor;
using RedditAccessor.models;
using RedditAccessor.models.json;

namespace SavedRedditBuckets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedditSavedPostController : ControllerBase
    {
        private readonly ILogger<RedditSavedPostController> _logger;

        public RedditSavedPostController(ILogger<RedditSavedPostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<RedditRequestChildObject> Get()
        {
            RedditWebRequest request = new RedditWebRequest();
            request.Password = "";
            RedditRequestHandler handler = new RedditRequestHandler();
            request.AccessToken = RedditRequestHandler.GetRedditAccessToken(request);
            var result = RedditRequestHandler.GetSavedPosts(request);
            return result;

        }
    }
}