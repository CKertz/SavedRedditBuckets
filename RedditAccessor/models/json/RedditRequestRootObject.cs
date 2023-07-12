using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor.models.json
{
    internal class RedditRequestRootObject
    {
        public string Kind { get; set; }
        public RedditRequestParentObject Data { get; set; }
    }
}
