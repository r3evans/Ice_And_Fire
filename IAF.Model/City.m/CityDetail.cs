using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAF.Model.City.m
{
    public class CityDetail
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public decimal AverageEstatePrice { get; set; }

        [JsonProperty("AverageEstatePrice")]
        public string AverageEstatePriceString { get => AverageEstatePrice.ToString("C"); }
        public string RegionName { get; set; }
        public int CityId { get; set; }
    }
}
