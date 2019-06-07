using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models
{
    public class Response
    {
        public class FeedCollection
        {
            public int Id { get; set; }
            public string FeedUrl { get; set; }
            public string Name { get; set; }
        }

        public class SimpleResponse
        {
            public bool IsSuccess { get; set; }
            public string error { get; set; }
        }
    }
}
