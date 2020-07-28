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
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }
        public IHttpActionResult Comment(CommentCreate CommentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(CommentId))
                return InternalServerError();

            return Ok();
        }
        private CommentService CreateCommentService()
        {

            var commentId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(commentId);
            return commentService;
        }

        //public IHttpActionResult Get(int id)
        //{
        //    CommentService commentService = CreateCommentService();
        //    var comment = commentService.GetCommentById(id);
        //    return Ok(comment);
        //}
    }
}
