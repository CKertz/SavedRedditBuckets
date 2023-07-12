using Microsoft.AspNetCore.Mvc;
using RedditAccessor.models.json;
using RedditAccessor.models;
using RedditAccessor;

namespace SavedRedditBuckets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post(LoginPayload payload)
        {
            // TODO: how to handle a session? for temporary sloppy implementing, could just hold payload in some sort of static var?
            Console.WriteLine(payload.Username);

        }
    }
}
