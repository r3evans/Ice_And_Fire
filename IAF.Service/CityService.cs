using IAF.Data;
using IAF.Model.City.m;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Service
{
    public class CityService
    {
        private readonly Guid _cityId;
        public CityService(Guid cityId)
        {
            _cityId = cityId;
        }
        public bool CreateCity(CityCreate model)
        {
            var entity =
                new Data.City()
                {
                    OwnerId = _cityId,
                    Name = model.Name,
                    Description = model.Description,
                    RegionId = model.RegionId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CityListItem> GetCities()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Cities
                        .Where(e => e.OwnerId == _cityId)
                        .Select(
                            e =>
                                new CityListItem
                                {
                                    CityId = e.CityId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    RegionName = e.Region.Name
                                }
                        );
                return query.ToArray();
            }
        }
        public CityDetail GetCityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var avgPrice =
                     ctx
                     .Estates
                     .GroupBy(k => k.CityId)
                     .Select(g => new {
                         City = g.Key,
                         Average = g.Average(k => k.Price)
                     })
                     .First(e => e.City == id);

                var entity =
                    ctx
                        .Cities.Include("Region")
                        .Single(e => e.CityId == id);
                return
                    new CityDetail
                    {
                        CityId = entity.CityId,
                        Name = entity.Name,
                        Description = entity.Description,
                        RegionName = entity.Region?.Name,
                        AverageEstatePrice = avgPrice.Average
                    };
            }
        }
        public bool UpdateCity(CityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cities
                        .Single(e => e.CityId == model.CityId);
                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCity(int cityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cities
                    .Single(e => e.CityId == cityId);

                ctx.Cities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
