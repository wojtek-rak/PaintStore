using backEnd.Controllers;
using backEnd.Controllers.CommentsControllers;
using backEnd.Controllers.LikeControllers.Comment;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintStoreBackEnd.Tests
{

    [TestFixture]
    class ImageRemoveControllerTest
    {
        [Test]
        public void ImageRemoveTest()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new ImageRemoveController(mock.Object);
            var editedCom = controller.PostRemove(new Posts { Id = 4 });
            mock.Verify(m => m.SaveChanges(), Times.Once());
            init.mockSetImages.Verify(m => m.Remove(It.IsAny<Posts>()), Times.Once());
            init.mockSetPostLikes.Verify(m => m.Remove(It.IsAny<PostLikes>()), Times.Once());
            init.mockSetComments.Verify(m => m.Remove(It.IsAny<PostComments>()), Times.Once());
            init.mockSetCommentLikes.Verify(m => m.Remove(It.IsAny<CommentLikes>()), Times.Never());
        }
    }
}

