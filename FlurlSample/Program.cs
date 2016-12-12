using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlurlSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var result = await "http://jsonplaceholder.typicode.com"
                    .AppendPathSegment("posts")
                    .SetQueryParams(new { userId = 1 })
                    .GetJsonAsync<IEnumerable<Post>>();

                Console.WriteLine($"Post count: {result.Count()}");

                var post = await "http://jsonplaceholder.typicode.com"
                    .AppendPathSegment("posts")
                    .PostJsonAsync(new { userId = 123, title = "test", body = "test" })
                    .ReceiveJson<Post>();

                Console.WriteLine($"Post ID: {post.Id}");

            }).Wait();

            Console.ReadLine();
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
