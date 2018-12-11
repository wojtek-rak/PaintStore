using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Data.SqlClient;
using backEnd.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    /// <summary>
    ///  FOR TESTING!!!!!
    /// </summary>

namespace backEnd.ControllersForTesting
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AllGetController : Controller
    {
        private readonly PaintStoreContext paintStoreContext;

        public AllGetController(PaintStoreContext ctx)
        {
            paintStoreContext = ctx;
        }
        [HttpGet("{comments}")]
        public IEnumerable<String> GetAllComments()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.PostComments)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.PostId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.UserId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.CreationDate);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Content);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.LikeCount);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }
        [HttpGet("{images}/{img}")]
        public IEnumerable<String> GetAllImages()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.Posts)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.UserId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.UserOwnerName);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Title);
                    //stringBuilder.Append(", ");
                    //stringBuilder.Append(comm.CategoryTypeId);
                    //stringBuilder.Append(", ");
                    //stringBuilder.Append(comm.CategoryToolId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.ImgLink);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.CreationDate);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Description);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.LikeCount);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.ViewCount);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.CommentsCount);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.PopularActivity);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.NewestActivity);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.MixedActivity);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }
        [HttpGet("{dsaad}/{dasssq}/{likesPost}")]
        public IEnumerable<String> GetAllImagesLikes()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.PostLikes)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.UserId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.PostId);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }
        [HttpGet("{dsasdw}/{dwqdwda}/{lidakes}/{commentslikes}")]
        public IEnumerable<String> GetAllCommentsLikes()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.CommentLikes)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.UserId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.CommentId);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }

        [HttpGet("{imagdaes}/{idasmg}/{lidaskes}/{commadsents}/{users}")]
        public IEnumerable<String> GetAllUsers()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.Users)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Name);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.AccountId);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.AvatarImgLink);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.BackgroundImgLink);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Link);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.About);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.PostsCount);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.FollowedCount);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.FollowingCount);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }

        [HttpGet("{imagdaess}/{idassmg}/{lidaskess}/{commadssents}/{usedars}/{acc}")]
        public IEnumerable<String> GetAllAccount()
        {
            List<String> list = new List<String>();
            StringBuilder stringBuilder = new StringBuilder();
            using (var db = paintStoreContext)
            {
                foreach (var comm in db.Accounts)
                {
                    stringBuilder.Append("{ ");
                    stringBuilder.Append(comm.Id);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.Email);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.PasswordHash);
                    stringBuilder.Append(", ");
                    stringBuilder.Append(comm.CreationDate);
                    stringBuilder.Append(" }");
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            return list;
        }
    }
}


        //[HttpPost]
        //public Comments Post([FromBody] Comments comments)//[FromBody]string value)
        //{
        //    return comments;

        //}
        //[HttpPost("{id}")]
        //public IEnumerable<Comments> Post2([FromBody] Comments comments, string id)//[FromBody]string value)
        //{
        //    //paintStoreContext.Comments.Add(comments);
        //    //var count = paintStoreContext.SaveChanges();
        //    List<Comments> list = new List<Comments>();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    using (var db = paintStoreContext)
        //    {
        //        foreach (var blog in db.Comments)
        //        {
        //            list.Add(blog);
        //        }
        //    }
        //    return list;

        //}












        //public string Index()
        //{
        //    return "To use this API add username and name of repository like this: /< userName >/< repository > ";
        //}

        //[HttpGet("{content}")]
        //public IEnumerable<String> GetAllAndAdd(string content)
        //{
        //    using (var db = paintStoreContext)
        //    {

        //        db.Comments.Add(new Comments { Date = DateTime.Parse("2018-06-06"), Content = content, UserPath = "Zosia", ImgLink = "moj_piesek" });
        //        var count = db.SaveChanges();
        //        Console.WriteLine("{0} records saved to database", count);

        //        Console.WriteLine();
        //        Console.WriteLine("All blogs in database:");
        //        foreach (var blog in db.Comments)
        //        {
        //            Console.WriteLine(" - {0}", blog.Content);
        //        }
        //    }

        //    StringBuilder stringBuilder = new StringBuilder();
        //    List<String> list = new List<String>();
        //    //using (var connection = new SqlConnection())
        //    {
        //        var command = new SqlCommand("SELECT content FROM comments ", connection);
        //        connection.Open();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                stringBuilder.Append(reader[0]);
        //                list.Add(stringBuilder.ToString());
        //                stringBuilder.Clear();
        //            }
        //        }
        //    }
        //    return list;
        //}

        // GET: /<controller>/
//        [HttpGet("{userName}/{repositoryName}")]
//        public string Get(string userName, string repositoryName)
//        {

//            string url = "https://api.github.com/repos/" + userName + "/" + repositoryName;
//            try
//            {
//                HttpWebRequest httpprequest = WebRequest.Create(url) as HttpWebRequest;

//                httpprequest.UserAgent = "userAgent";

//                httpprequest.Method = "GET";

//                HttpWebResponse response = (HttpWebResponse)httpprequest.GetResponse();

//                String htmlString;
//                using (var reader = new StreamReader(response.GetResponseStream()))
//                {
//                    htmlString = reader.ReadToEnd();
//                    JsonTextReader rs = new JsonTextReader(new StringReader(htmlString));
//                    //return ("Token: {0}, Value: {1}" + read.TokenType + read.Value);
//                    //read.Read();
//                    JObject o2 = (JObject)JToken.ReadFrom(rs);
//                    IList<string> keys = o2.Properties().Select(p => p.Name).ToList();
//                    StringBuilder output = new StringBuilder();
//                    output.Append("{\n");
//                    JToken value = "full_name";
//                    List<string> mylist = new List<string>(new string[] { "full_name", "mirror_url" , "description", "clone_url","language", "open_issues_count" ,"watchers",
//                                       "created_at" });


//                    foreach (JProperty property in o2.Properties())
//                    {
//                        if (mylist.Any(s => property.Name.Contains(s)))
//                        {

//                            if (property.Value.Type.ToString() == "Integer")
//                            {

//                                output.Append("\"").Append(property.Name).Append("\": ").Append(property.Value).Append(",\n");
//                            }
//                            else if (property.Value.Type.ToString() == "Null")
//                            {
//                                output.Append("\"").Append(property.Name).Append("\": null,\n");
//                            }
//                            else
//                            {
//                                output.Append("\"").Append(property.Name).Append("\": \"").Append(property.Value).Append("\",\n");
//                            }

//                        }


//                    }
//                    return output.ToString().Remove(output.Length - 2) + "\n}";
//                }

//            }
//            catch (WebException ex)
//            {
//                if (ex.Status == WebExceptionStatus.ProtocolError &&
//                    ex.Response != null)
//                {
//                    var resp = (HttpWebResponse)ex.Response;
//                    if (resp.StatusCode == HttpStatusCode.NotFound)
//                    {
//                        return "Cannot found repository";
//                    }
//                    else
//                    {
//                        return resp.StatusCode.ToString();
//                    }
//                }
//                else
//                {
//                    return "Unexpected error";
//                }
//            }








//        }


//    }
//}
