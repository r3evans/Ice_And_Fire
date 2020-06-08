using IAF.Data;
using IAF.Model.Kingdom.m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Service
{
    public class KingdomService
    {
        private readonly Guid _kingdomId;
        public KingdomService(Guid kingdomId)
        {
            _kingdomId = kingdomId;
        }
        public bool CreateKingdom(KingdomCreate model)
        {
            var entity =
                new Data.Kingdom()
                {
                    OwnerId= _kingdomId,
                    Name = model.Name,
                    Description = model.Description,
                    RegionId =model.RegionId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Kingdoms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<KingdomListItem> GetKingdoms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Kingdoms
                        .Where(e => e.OwnerId == _kingdomId)
                        .Select(
                            e =>
                                new KingdomListItem
                                {
                                    KingdomId = e.KingdomId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    RegionId = e.RegionId
                                }
                        );
                return query.ToArray();
            }
        }
        public KingdomDetail GetKingdomById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kingdoms
                        .Single(e => e.KingdomId == id);
                return
                    new KingdomDetail
                    {
                       KingdomId = entity.KingdomId,
                        Name = entity.Name,
                        Description = entity.Description,
                        RegionId = entity.RegionId
                    };
            }
        }
        public bool UpdateKingdom(KingdomEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kingdoms
                        .Single(e => e.KingdomId == model.KingdomId);
                entity.Name = model.Name;
                entity.Description = model.Description;
                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteKingdom(int kingdomId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Kingdoms
                    .Single(e => e.KingdomId == kingdomId);

                ctx.Kingdoms.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
