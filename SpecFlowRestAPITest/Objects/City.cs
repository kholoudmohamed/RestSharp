using System;
using Newtonsoft.Json;

namespace SpecFlowRestAPITest.Objects
{
    [Serializable]
    public class City
    {
        [JsonProperty(PropertyName = "\\n    \\\"City\\\"")]
        public string CityName { get; set; }

        [JsonProperty(PropertyName = "Temperature")]
        public string CityTemperature { get; set; }

        [JsonProperty(PropertyName = "Humidity")]
        public string CityHumidity { get; set; }

        [JsonProperty(PropertyName = "WeatherDescription")]
        public string CityWeatherDescription { get; set; }

        [JsonProperty(PropertyName = "WindSpeed")]
        public string CityWindSpeed { get; set; }

        [JsonProperty(PropertyName = "WindDirectionDegree")]
        public string CityWindDirectionDegree { get; set; }
    }
}
