using System;
using System.Collections.Generic;
using backEnd.Interfaces;

namespace backEnd.Models.ResultsModels
{
    public class PostDetailsResult : PostsResults, IPosts
    {
        //public string CategoryTypeName { get; set; }
        //public string CategoryToolName { get; set; }
        public List<string> TagsList { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public bool Liked { get; set; }

        public PostDetailsResult(IPosts iPosts) : base (iPosts)
        {
        }
    }
}
