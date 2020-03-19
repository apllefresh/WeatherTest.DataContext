using System;

namespace WeatherTest.DataContext.Entities
{
    public class Temperature
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Degree { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}