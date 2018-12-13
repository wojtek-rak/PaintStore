using System.Collections.Generic;
using System.Linq;
using backEnd.Models;
using backEnd.Services;
using Moq;
using NUnit.Framework;

namespace PaintStoreBackEnd.Tests
{
    [TestFixture]
    public class TagsServiceTests
    {
        [Test]
        public void AddTags_NoTagInDb_AddTag()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new TagsService(mock.Object);
            controller.GetOrAddTag("Yellow");
            init.mockSetTags.Verify(m => m.Add(It.IsAny<Tags>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddTags_TagInDb_AddTag()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var controller = new TagsService(mock.Object);
            var tagBanan = controller.GetOrAddTag("banan");
            mock.Verify(m => m.SaveChanges(), Times.Never());
            init.mockSetTags.Verify(m => m.Add(It.IsAny<Tags>()), Times.Never());
            var expected = 1;
            Assert.AreEqual(1, tagBanan.Count);
        }

        [Test]
        public void AddPostTags_ListOfTags_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var tagsService = new TagsService(mock.Object);
            tagsService.AddPostTags(new List<string>() {"banan"}, 2);

            mock.Verify(m => m.SaveChanges(), Times.Once);
            init.mockSetPostTags.Verify(m => m.Remove(It.IsAny<PostTags>()), Times.Exactly(3));
            init.mockSetPostTags.Verify(m => m.Add(It.IsAny<PostTags>()), Times.Once);
        }

        [Test]
        public void AddPostTags_CountingTest_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var tagName = "banan";
            var tagName2 = "krajobraz";
            var expectedTagsCountInt = mock.Object.Tags.First(x => x.TagName == tagName).Count;
            var expectedTagsCountInt2 = mock.Object.Tags.First(x => x.TagName == tagName2).Count;
            var tagsService = new TagsService(mock.Object);
            tagsService.AddPostTags(new List<string>() {tagName}, 2);

            mock.Verify(m => m.SaveChanges(), Times.Once);
            init.mockSetPostTags.Verify(m => m.Remove(It.IsAny<PostTags>()), Times.Exactly(3));
            init.mockSetPostTags.Verify(m => m.Add(It.IsAny<PostTags>()), Times.Once);
            Assert.AreEqual(expectedTagsCountInt, mock.Object.Tags.First(x => x.TagName == tagName).Count);
            Assert.AreEqual(expectedTagsCountInt2 - 1, mock.Object.Tags.First(x => x.TagName == tagName2).Count);

        }
        [Test]
        public void GetPostTags_ValidPostId_Test()
        {
            var init = new InitializeMockContext();
            var mock = init.mock;

            var postId = 1;
            var tagsService = new TagsService(mock.Object);
            var result = tagsService.GetTags(postId).Count;
            var expected = 2;

            Assert.AreEqual(expected, result);

        }
       
    }
}