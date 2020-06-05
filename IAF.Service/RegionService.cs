using IAF.Data;
using IAF.Model.Region.m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Service
{
   public class RegionService
    {
        private readonly Guid _regionId;

        public RegionService(Guid regionId)
        {
            _regionId = regionId;
        }
        public bool CreateRegion(RegionCreate model)
        {
            var entity =
                new Region()
                {
                    RegionId = _regionId,
                    Name = model.Name,
                    Description = model.Description,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Regions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RegionListItem> GetRegions()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Regions
                    .Where(e => e.RegionId == _regionId)
                    .Select(
                        e =>
                        new RegionListItem
                        {
                            RegionId = e.RegionId,
                            Name = e.Name,
                            Description = e.Description,
                        }
                    );
                return query.ToArray();
            }
        }
        public RegionDetail GetRegionById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionId == id);
                return
                    new RegionDetail
                    {
                        RegionId = entity.RegionId,
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }
        public bool UpdateRegion(RegionEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionId == model.RegionId);

                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRegion(Guid regionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Regions
                    .Single(e => e.RegionId == regionId);

                ctx.Regions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
