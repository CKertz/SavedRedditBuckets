using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor.models.json
{
    public class RedditSavedItem
    {
        public string Subreddit { get; set; }
        public string PermaLink { get; set; }
        public long Created_utc { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Link_Title { get; set; }

    }
}
