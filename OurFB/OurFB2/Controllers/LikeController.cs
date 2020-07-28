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
    public class LikeController : ApiController
    {
        public IHttpActionResult Post(LikeCreate PostId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(PostId))
                return InternalServerError();

            return Ok();
        }
        private LikeService CreateLikeService()
        {

            var postId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(postId);
            return likeService;
        }


    }
}
