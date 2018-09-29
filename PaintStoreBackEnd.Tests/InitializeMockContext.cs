﻿using backEnd.Controllers;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintStoreBackEnd.Tests
{
    class InitializeMockContext
    {
        public Mock<DbSet<Accounts>> mockSetAccount; 
        public Mock<DbSet<Users>> mockSetUsers;
        public Mock<DbSet<PostComments>> mockSetComments;
        public Mock<DbSet<Posts>> mockSetImages;
        public Mock<DbSet<CategoryTypes>> mockSetCategoryTypes;
        public Mock<DbSet<CategoryTools>> mockSetCategoryTools;
        public Mock<DbSet<PostLikes>> mockSetPostLikes;
        public Mock<DbSet<CommentLikes>> mockSetCommentLikes;
        public Mock<DbSet<UserFollowers>> mockSetUserFollowers;
        public Mock<PaintStoreContext> mock;
        public InitializeMockContext()
        {
            var mock = new Mock<PaintStoreContext>();
            var mockDataAccounts = new List<Accounts> {
                new Accounts { Id = 1, CreationDate = DateTime.Now, Email = "kasia@kreska.pl", PasswordHash = "!@#sdaAWEDAFSFDSAE"},
                new Accounts { Id = 2, CreationDate = DateTime.Now, Email = "zosia@kreska.pl", PasswordHash = "eWDs@daDSAdsFSFSAE" }}.AsQueryable();

            var mockDataUsers = new List<Users> {
                new Users { Id = 1, Name = "Kasia", Link = "kasialink", AvatarImgLink = "appa", BackgroundImgLink = "bappa", About = "xD", AccountId = 1, FollowedCount = 1, FollowingCount = 0, PostsCount = 3},
                new Users { Id = 2, Name = "Zosia", Link = "tosialink", AvatarImgLink = "2appa", BackgroundImgLink = "2bappa", About = "2xD", AccountId = 2, FollowedCount = 0, FollowingCount = 1, PostsCount = 1}}.AsQueryable();

            var mockDataComments = new List<PostComments> {
                new PostComments { Id = 1, CreationDate = DateTime.Parse("2008-05-01T07:34:42-5:00"), Content = "Ale Kom", PostId = 2, UserId = 2, LikeCount = 2 },
                new PostComments { Id = 2, CreationDate = DateTime.Parse("2008-05-01T07:34:42-5:00"), Content = "Ale Kom", PostId = 3, UserId = 2, LikeCount = 1  },
                new PostComments { Id = 3, CreationDate = DateTime.Parse("2008-05-01T07:34:42-5:00"), Content = "Ale Kom", PostId = 3, UserId = 2, LikeCount = 0  },
                new PostComments { Id = 4, CreationDate = DateTime.Parse("2008-05-01T07:34:42-5:00"), Content = "Ale Kom", PostId = 4, UserId = 2, LikeCount = 0  }}.AsQueryable();

            var mockDataImages = new List<Posts> {
                new Posts { Id = 1, Title = "zaden             ", CategoryTypeId = null, CategoryToolId = 1, ImgLink = "link1", CreationDate = DateTime.Parse("2008-05-01T07:34:42-5:00"), Description = "Desc1", UserId = 1, LikeCount = 2, CommentsCount = 0},
                new Posts { Id = 2, Title = "Najnowszy         ", CategoryTypeId = 2, CategoryToolId = null, ImgLink = "link2", CreationDate = DateTime.Parse("2009-05-01T07:34:42-5:00"), Description = "Desc2", UserId = 1 , LikeCount = 1, CommentsCount = 1},
                new Posts { Id = 3,  Title = "Najkomentowszy      ", CategoryTypeId = 2, CategoryToolId = 2, ImgLink = "link3", CreationDate = DateTime.Parse("2010-05-01T07:34:42-5:00"), Description = "Desc3", UserId = 2 , LikeCount = 0, CommentsCount = 2 },
                new Posts { Id = 4,  Title = "comm bez lików", CategoryTypeId = null, CategoryToolId = null, ImgLink = "link4", CreationDate = DateTime.Parse("2011-05-01T07:34:42-5:00"), Description = "Desc4", UserId = 1  , LikeCount = 1, CommentsCount = 1},
                new Posts { Id = 5, Title = "zaden2             ", CategoryTypeId = null, CategoryToolId = 1, ImgLink = "link5", CreationDate = DateTime.Parse("2008-04-01T07:34:42-5:00"), Description = "Desc5", UserId = 1, LikeCount = 0, CommentsCount = 0},
                new Posts { Id = 6, Title = "zos             ", CategoryTypeId = null, CategoryToolId = 2, ImgLink = "link6", CreationDate = DateTime.Parse("2008-03-01T07:34:42-5:00"), Description = "Desc6", UserId = 1, LikeCount = 0, CommentsCount = 0} }.AsQueryable();

            var mockDataCategoryType = new List<CategoryTypes> {
                new CategoryTypes { Id = 1, TypeName = "pose", Count = 0 },
                new CategoryTypes { Id = 2, TypeName = "animal", Count = 2},
                new CategoryTypes { Id = 3, TypeName = "poZosiase", Count = 10 },
                new CategoryTypes { Id = 4, TypeName = "deZosiase", Count = 0 } }.AsQueryable();

            var mockDataCategoryTool = new List<CategoryTools> {
                new CategoryTools { Id = 1, ToolName = "pencil", Count = 2 },
                new CategoryTools { Id = 2, ToolName = "aquarels", Count = 2} }.AsQueryable();

            var mockDataPostLikes = new List<PostLikes> {
                new PostLikes { Id = 1, UserId = 2, PostId = 1 },
                new PostLikes { Id = 2, UserId = 3, PostId = 1 },
                new PostLikes { Id = 2, UserId = 3, PostId = 4 },
                new PostLikes { Id = 3, UserId = 3, PostId = 2} }.AsQueryable();

            var mockDataCommentLikes = new List<CommentLikes> {
                new CommentLikes { Id = 1, UserId = 2, CommentId = 1 },
                new CommentLikes { Id = 2, UserId = 3, CommentId = 1 },
                new CommentLikes { Id = 3, UserId = 3, CommentId = 2} }.AsQueryable();

            var mockDataUserFollowers = new List<UserFollowers> {
                new UserFollowers { Id = 1, FollowedUserId = 1, FollowingUserId = 2} }.AsQueryable();


            mockSetAccount = InitMockDbSet(mockDataAccounts);
            mockSetUsers = InitMockDbSet(mockDataUsers);
            mockSetComments = InitMockDbSet(mockDataComments);
            mockSetImages = InitMockDbSet(mockDataImages);
            mockSetCategoryTypes = InitMockDbSet(mockDataCategoryType);
            mockSetCategoryTools = InitMockDbSet(mockDataCategoryTool);
            mockSetPostLikes = InitMockDbSet(mockDataPostLikes);
            mockSetCommentLikes = InitMockDbSet(mockDataCommentLikes);
            mockSetUserFollowers = InitMockDbSet(mockDataUserFollowers);

            mock.Setup(x => x.Accounts)
                            .Returns(mockSetAccount.Object);
            mock.Setup(x => x.Users)
                            .Returns(mockSetUsers.Object);
            mock.Setup(x => x.PostComments)
                            .Returns(mockSetComments.Object);
            mock.Setup(x => x.Posts)
                            .Returns(mockSetImages.Object);
            mock.Setup(x => x.CategoryTypes)
                            .Returns(mockSetCategoryTypes.Object);
            mock.Setup(x => x.CategoryTools)
                            .Returns(mockSetCategoryTools.Object);
            mock.Setup(x => x.PostLikes)
                            .Returns(mockSetPostLikes.Object);
            mock.Setup(x => x.CommentLikes)
                            .Returns(mockSetCommentLikes.Object);
            mock.Setup(x => x.UserFollowers)
                            .Returns(mockSetUserFollowers.Object);
            

            this.mock = mock;
        }



        /// <summary>
        /// for some tests
        /// </summary>
        /// <returns></returns>
        //public static Mock<PaintStoreContext> InitMock()
        //    {
        //    var mock = new Mock<PaintStoreContext>();
        //    var mockDataUsers = new List<Users> {
        //        new Users { Id = 1, Name = "Kasia", Link = "kasialink", AvatarImgLink = "appa", BackgroundImgLink = "bappa", About = "xD", AccountId = 1},
        //        new Users { Id = 2, Name = "Zosia", Link = "tosialink", AvatarImgLink = "2appa", BackgroundImgLink = "2bappa", About = "2xD", AccountId = 2}}.AsQueryable();

        //    var mockDataComments = new List<PostComments> {
        //        new PostComments { Id = 1, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 2, UserId = 2 },
        //        new PostComments { Id = 2, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 3, UserId = 2  },
        //        new PostComments { Id = 3, CreationDate = DateTime.Now, Content = "Ale Kom", PostId = 3, UserId = 2  } }.AsQueryable();

        //    var mockDataImages = new List<Posts> {
        //        new Posts { Id = 1, Title = "zaden", CategoryTypeId = null, CategoryToolId = 1, ImgLink = "link1", CreationDate = DateTime.Today, Description = "Desc1", UserOwnerName = "Zosia", UserId = 2 },
        //        new Posts { Id = 2, Title = "Najnowszy", CategoryTypeId = 2, CategoryToolId = null, ImgLink = "link2", CreationDate = DateTime.Now, Description = "Desc2", UserOwnerName = "Kasia", UserId = 1 },
        //        new Posts { Id = 3,  Title = "Najkomentowszy", CategoryTypeId = 2, CategoryToolId = 2, ImgLink = "link3", CreationDate = DateTime.Today, Description = "Desc3", UserOwnerName = "Zosia", UserId = 2  } }.AsQueryable();

        //    var mockDataCategoryType = new List<CategoryTypes> {
        //        new CategoryTypes { Id = 1, TypeName = "pose", Count = 0 },
        //        new CategoryTypes { Id = 2, TypeName = "animal", Count = 2} }.AsQueryable();

        //    var mockDataCategoryTool = new List<CategoryTools> {
        //        new CategoryTools { Id = 1, ToolName = "pencil", Count = 1 },
        //        new CategoryTools { Id = 2, ToolName = "aquarels", Count = 1} }.AsQueryable();

        //    var mockDataPostLikes = new List<PostLikes> {
        //        new PostLikes { Id = 1, UserId = 2, PostId = 1 },
        //        new PostLikes { Id = 2, UserId = 3, PostId = 1 },
        //        new PostLikes { Id = 3, UserId = 3, PostId = 2} }.AsQueryable();

        //    var mockDataCommentLikes = new List<CommentLikes> {
        //        new CommentLikes { Id = 1, UserId = 2, CommentId = 1 },
        //        new CommentLikes { Id = 2, UserId = 3, CommentId = 1 },
        //        new CommentLikes { Id = 3, UserId = 3, CommentId = 2} }.AsQueryable();


        //    var mockSetUsers = InitMockDbSet(mockDataUsers);
        //    var mockSetComments = InitMockDbSet(mockDataComments);
        //    var mockSetImages = InitMockDbSet(mockDataImages);
        //    var mockSetCategoryTypes = InitMockDbSet(mockDataCategoryType);
        //    var mockSetCategoryTools = InitMockDbSet(mockDataCategoryTool);
        //    var mockSetPostLikes = InitMockDbSet(mockDataPostLikes);
        //    var mockSetCommentLikes = InitMockDbSet(mockDataCommentLikes);

        //    mock.Setup(x => x.Users)
        //                    .Returns(mockSetUsers.Object);
        //    mock.Setup(x => x.PostComments)
        //                    .Returns(mockSetComments.Object);
        //    mock.Setup(x => x.Posts)
        //                    .Returns(mockSetImages.Object);
        //    mock.Setup(x => x.CategoryTypes)
        //                    .Returns(mockSetCategoryTypes.Object);
        //    mock.Setup(x => x.CategoryTools)
        //                    .Returns(mockSetCategoryTools.Object);
        //    mock.Setup(x => x.PostLikes)
        //                    .Returns(mockSetPostLikes.Object);
        //    mock.Setup(x => x.CommentLikes)
        //                    .Returns(mockSetCommentLikes.Object);

        //    return mock;
        //    }

        public static Mock<DbSet<T>> InitMockDbSet<T>(IQueryable<T> mockData) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            return mockSet;
        }
    }
}




//var mockSetUsers = new Mock<DbSet<Users>>();
//mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(mockDataUsers.Provider);
//mockSetUsers.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(mockDataUsers.Expression);
//mockSetUsers.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(mockDataUsers.ElementType);
//mockSetUsers.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(mockDataUsers.GetEnumerator());
//var mockSetComments = new Mock<DbSet<PostComments>>();
//mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.Provider).Returns(mockDataComments.Provider);
//mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.Expression).Returns(mockDataComments.Expression);
//mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.ElementType).Returns(mockDataComments.ElementType);
//mockSetComments.As<IQueryable<PostComments>>().Setup(m => m.GetEnumerator()).Returns(mockDataComments.GetEnumerator());
//var mockSetImages = new Mock<DbSet<Posts>>();
//mockSetImages.As<IQueryable<Posts>>().Setup(m => m.Provider).Returns(mockDataImages.Provider);
//mockSetImages.As<IQueryable<Posts>>().Setup(m => m.Expression).Returns(mockDataImages.Expression);
//mockSetImages.As<IQueryable<Posts>>().Setup(m => m.ElementType).Returns(mockDataImages.ElementType);
//mockSetImages.As<IQueryable<Posts>>().Setup(m => m.GetEnumerator()).Returns(mockDataImages.GetEnumerator());
//var mockSetCategoryTypes = new Mock<DbSet<CategoryTypes>>();
//mockSetCategoryTypes.As<IQueryable<CategoryTypes>>().Setup(m => m.Provider).Returns(mockDataCategoryType.Provider);
//mockSetCategoryTypes.As<IQueryable<CategoryTypes>>().Setup(m => m.Expression).Returns(mockDataCategoryType.Expression);
//mockSetCategoryTypes.As<IQueryable<CategoryTypes>>().Setup(m => m.ElementType).Returns(mockDataCategoryType.ElementType);
//mockSetCategoryTypes.As<IQueryable<CategoryTypes>>().Setup(m => m.GetEnumerator()).Returns(mockDataCategoryType.GetEnumerator());
//var mockSetCategoryTools = new Mock<DbSet<CategoryTools>>();
//mockSetCategoryTools.As<IQueryable<CategoryTools>>().Setup(m => m.Provider).Returns(mockDataCategoryTool.Provider);
//mockSetCategoryTools.As<IQueryable<CategoryTools>>().Setup(m => m.Expression).Returns(mockDataCategoryTool.Expression);
//mockSetCategoryTools.As<IQueryable<CategoryTools>>().Setup(m => m.ElementType).Returns(mockDataCategoryTool.ElementType);
//mockSetCategoryTools.As<IQueryable<CategoryTools>>().Setup(m => m.GetEnumerator()).Returns(mockDataCategoryTool.GetEnumerator());
