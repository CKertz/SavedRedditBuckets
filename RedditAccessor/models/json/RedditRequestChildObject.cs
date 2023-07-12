using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor.models.json
{
    public class RedditRequestChildObject
    {
        public string Kind { get; set; }
        public RedditSavedItem Data { get; set; }
    }
}
