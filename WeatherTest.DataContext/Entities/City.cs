using System.Collections.Generic;

namespace WeatherTest.DataContext.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Temperature> Temperatures { get; set; }
    }
}