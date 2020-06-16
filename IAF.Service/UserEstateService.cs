using IAF.Data;
using IAF.Model.UserEstate.m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Service
{
    public class UserEstateService
    {

        private readonly Guid _userEstateId;
        public UserEstateService(Guid userEstateId)
        {
            _userEstateId = userEstateId;
        }
        public bool CreateUserEstate(UserEstateCreate model)
        {
            var entity =
                new UserEstate()
                {
                    UserId = model.UserId,
                    EstateId = model.EstateId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserEstates.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserEstateListItem> GetFavoriteEstates(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .UserEstates
                    .Where(e => e.UserId == userId)
                    .Select(e =>
                  new UserEstateListItem
                  {
                      UserId = e.UserId,
                      Estate = e.Estate
                  });
                return query.ToArray();
            }
        }
        public UserEstateDetail GetUserEstateById(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserEstates
                    .Single(e => e.UserId == userId);
                return new UserEstateDetail
                {
                    UserId = entity.UserId,
                    Estate = entity.Estate
                };
            }
        }
        //public bool UpdateUserEstate(UserEstateEdit model)
        //{
        //    using (var ctx = new
        //        ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .UserEstates
        //            .Single(e => e.UserId == model.UserId);
        //        entity.UserId = model.UserId;
        //        entity.Estate = model.Estate;
        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        public bool DeleteUserEstateByEstateId(int userId, int estateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserEstates
                    .Single(e => e.UserId == userId && e.EstateId == estateId);

                ctx.UserEstates.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUserEstate(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UserEstates
                    .Single(e => e.UserId == userId);

                ctx.UserEstates.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
