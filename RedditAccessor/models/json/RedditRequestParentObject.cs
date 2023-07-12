using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor.models.json
{
    internal class RedditRequestParentObject
    {
        public List<RedditRequestChildObject> Children { get; set; }
        public string After { get; set; }
    }
}
