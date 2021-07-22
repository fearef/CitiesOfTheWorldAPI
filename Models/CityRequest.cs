using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CitiesOfTheWorldAPI.Models
{
    public class CityRequest
    {
        public string CityName { get; set; }
        public int Year { get; set; } = -1;

        public static JsonSerializerOptions JsonSerializerOptions { get; private set; } = new JsonSerializerOptions() { PropertyNamingPolicy=JsonNamingPolicy.CamelCase };
    }
}
