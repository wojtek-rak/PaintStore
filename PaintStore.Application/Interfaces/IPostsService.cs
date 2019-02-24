using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Domain.Entities;
using PaintStore.Domain.ResultsModels;

namespace PaintStore.Application.Interfaces
{
    public interface IPostsService
    {
        PostDetailsResult GetPost(int userId, int postId);
        List<PostsResults> GetFollowingPosts(int userId);
        List<PostsResults> GetAllPosts(string message);
        List<PostsResults> GetPostsByTag(string tag);
        Posts AddImage(Posts post);
        Posts EditPost(Posts post);
        int PostRemover(int postId);

    }
}
