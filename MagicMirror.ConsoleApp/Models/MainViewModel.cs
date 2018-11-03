using MagicMirror.Business.Models;

namespace MagicMirror.ConsoleApp.Models
{
    public class MainViewModel
    {
        public WeatherModel Weather { get; set; }

        public TrafficModel Traffic { get; set; }
    }
}
