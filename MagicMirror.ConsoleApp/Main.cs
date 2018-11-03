using Acme.Generic.Helpers;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp.Models;
using System;
using System.Threading.Tasks;

namespace MagicMirror.ConsoleApp
{
    public class Main
    {
        // Services
        private IWeatherService _weatherService;
        private ITrafficService _trafficService;

        // Models
        private UserInformation _userInformation;
        private MainViewModel model;

        public Main(IWeatherService weatherService, ITrafficService trafficService)
        {
            _weatherService = weatherService;
            _trafficService = trafficService;
        }

        public async Task RunAsync()
        {
            try
            {
                _userInformation = GetMockInformation();
                model.Weather = await GetWeatherModelAsync(_userInformation.Town);
                model.Traffic = await GetTrafficModelAsync($"{_userInformation.Address}, {_userInformation.Town}", _userInformation.WorkAddress);

                GenerateOutput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private UserInformation GetInformation()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your street and number:");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter your zipcode:");
            string zipcode = Console.ReadLine();

            Console.WriteLine("Please enter your town and country:");
            string town = Console.ReadLine();

            Console.WriteLine("Please enter your work address:");
            string workAddress = Console.ReadLine();

            var result = new UserInformation
            {
                Name = name,
                Address = address,
                Zipcode = zipcode,
                Town = town,
                WorkAddress = workAddress
            };

            return result;
        }

        private UserInformation GetMockInformation()
        {
            var result = new UserInformation
            {
                Name = "Michiel",
                Address = "Heikant 51",
                Zipcode = "3390",
                Town = "Houwaart, Belgium",
                WorkAddress = "Kempische Steenweg, Hasselt, Belgium"
            };

            return result;
        }

        private async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            var _weatherModel = await _weatherService.GetWeatherModelAsync(city);
            return _weatherModel;
        }

        private async Task<TrafficModel> GetTrafficModelAsync(string start, string destination)
        {
            var _trafficModel = await _trafficService.GetTrafficModelAsync(start, destination);
            return _trafficModel;
        }

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {DateTimeHelper.GetTimeOfDay()} {_userInformation.Name}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {model.Weather.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {model.Weather.Temperature} degrees {model.Weather.TemperatureUom}.");
            Console.WriteLine($"The sun has risen at {model.Weather.Sunrise} and will set at approximately {model.Weather.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {model.Traffic.TravelTime}. " +
                $"If you leave now, you should arrive at approximately {model.Traffic.TimeOfArrival.ToShortTimeString()}.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }
    }
}