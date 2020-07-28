using Microsoft.AspNet.Identity;
using OurFB.Models;
using OurFB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OurFB2.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }
        public IHttpActionResult Post(PostCreate PostId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(PostId))
                return InternalServerError();

            return Ok();
        }
        private PostService CreatePostService()
        {
            
            var postId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(postId);
            return postService;
        }

        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        //public IHttpActionResult Put(PostEdit post)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreatePostService();

        //    if (!service.UpdatePost(post))
        //        return InternalServerError();

        //    return Ok();
        //}

        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreatePostService();

        //    if (!service.DeletePost(id))
        //        return InternalServerError();

        //    return Ok();
        //}
    }
}
