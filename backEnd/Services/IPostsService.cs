using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Models.ResultsModels;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.Services
{
    public interface IPostsService
    {
        PostDetailsResult GetPost(int postId);
        List<PostsResults> GetFollowingPosts(int userId);
        List<PostsResults> GetAllPosts(string message);
        List<PostsResults> GetPostsByTag(string tag);
        //IActionResult GetPostsByCategory(string message, string name);
        //IActionResult GetPostsByCategory(string message, string typeName, string toolName);
        Posts AddImage([FromBody] Posts post);
        Posts EditPost([FromBody] Posts post);
        int PostRemover(int postId);

    }
}
