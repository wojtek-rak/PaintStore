using backEnd.Models;
using Microsoft.Extensions.Configuration;
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
    class CommentsAddControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        public static string GetConnectionString()
        {
            var config = InitConfiguration();
            return config.GetConnectionString("PaintStoreDatabase");
        }

        //[Test]
        //public void AddCommentTests()
        //{
        //    var con = GetConnectionString();
        //    PaintStoreContext paintStoreContext = new PaintStoreContext(con);

        //    List<String> list = new List<String>();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    using (var db = paintStoreContext)
        //    {
        //        foreach (var blog in db.Comments)
        //        {
        //            stringBuilder.Append(", ");
        //            stringBuilder.Append(blog.Content);
        //            list.Add(stringBuilder.ToString());
        //            stringBuilder.Clear();
        //        }
        //    }

        //    //var foo = new Mock<IFoo>();
        //    //foo.Setup(f => f.Bar()).Returns("Hello, TDD");
        //    //var controller = new CommentsController();//foo.Object);
        //    //var result = (JsonResult)controller.GetZZ();
        //    //Assert.That(result.Data, Is.EqualTo(42));
        //}
    }
}
