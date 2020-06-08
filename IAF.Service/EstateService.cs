using IAF.Data;
using IAF.Model.Estate.m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Service
{
    public class EstateService
    {
        private readonly Guid _estateId;
        public EstateService(Guid estateId)
        {
            _estateId = estateId;
        }
        public bool CreateEstate(EstateCreate model)
        {
            var entity =
                new Estate()
                {
                    OwnerId = _estateId,
                    Name = model.Name,
                    // Status = model.Status,
                    Price = model.Price,
                    Address = model.Address,
                    KingdomId = model.KingdomId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Estates.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EstateListItem> GetEstates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Estates
                    .Where(e => e.OwnerId == _estateId)
                   .Select(e =>
                   new EstateListItem
                   {
                       EstateId = e.EstateId,
                       Name = e.Name,
                       Address = e.Address,
                       Price = e.Price,
                       KingdomId = e.KingdomId
                   });
                return query.ToArray();
            }
        }
        public EstateDetail GetEstateById(int estateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Estates
                    .Single(e => e.OwnerId == _estateId);
                return
                    new EstateDetail
                    {
                       // EstateId = entity.EstateId,
                        Name = entity.Name,
                        Address = entity.Address,
                        Price = entity.Price,
                        KingdomId = entity.KingdomId
                    };
            }
        }
        public bool UpdateEstate(EstateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Estates
                    .Single(e => e.EstateId == model.EstateId);
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.Price = model.Price;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEstate(int estateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Estates
                    .Single(e => e.EstateId == estateId);
                ctx.Estates.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}