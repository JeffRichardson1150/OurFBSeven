using OurFB.Data;
using OurFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Email = model.Email,
                 
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .User
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.UserId,
                                    Name = e.Name,
                                    Email = e.Email
                                }
                        ); 

                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserId == id && e.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        Name = entity.Name,
                        Email = entity.Email,
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Email = model.Email;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserId == UserId && e.OwnerId == _userId);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
