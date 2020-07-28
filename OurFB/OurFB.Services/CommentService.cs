using OurFB.Data;
using OurFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Text = model.Content,
                    UserId = model.AuthorId,
                    PostId = model.PostId,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    PostId = e.PostId,
                                    CommentId = e.CommentId,
                                    Title = e.Title,
                                    Text = e.Text,
                                    AuthorId = e.UserId,
                                }
                        );

                return query.ToArray();
            }
        }


        //public CommentDetail GetcommentById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Comment
        //                .Single(e => e.CommentId == id && e.OwnerId == _userId);
        //        return
        //            new CommentDetail
        //            {
        //                commentId = entity.commentId,
        //                Title = entity.Title,
        //                Text = entity.Text,
        //            };
        //    }
        //}

    }
}
