using OurFB.Data;
using OurFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    Likes = model.Likes,
                    PostId = model.PostId,
                    UserId = model.UserId,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Like.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

//        public IEnumerable<LikeListItem> GetLikes()
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var query =
//                    ctx
//                        .Like
////                        .Where(e => e.UserId == _userId)
//                        .Select(
//                            e =>
//                                new LikeListItem
//                                {
//                                    PostId = e.PostId,
//                                    LikeId = e.LikeId,
//                                    Title = e.Title,
//                                    Text = e.Text,
//                                    AuthorId = e.UserId,
//                                }
//                        );

//                return query.ToArray();
//            }
//        }


        //public LikeDetail GetlikeById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Like
        //                .Single(e => e.LikeId == id && e.OwnerId == _userId);
        //        return
        //            new LikeDetail
        //            {
        //                likeId = entity.likeId,
        //                Title = entity.Title,
        //                Text = entity.Text,
        //            };
        //    }
        //}

    }
}
