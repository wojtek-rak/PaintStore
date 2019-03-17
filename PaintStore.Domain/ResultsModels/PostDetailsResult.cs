using System;
using System.Collections.Generic;
using PaintStore.Domain.Interfaces;

namespace PaintStore.Domain.ResultsModels
{
    public class PostDetailsResult : PostsResults
    {
        public List<string> TagsList { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public bool Liked { get; set; }

        public PostDetailsResult(IPosts iPosts) : base (iPosts)
        {
        }
    }
}
