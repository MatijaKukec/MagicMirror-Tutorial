using Acme.Generic.Helpers;
using MagicMirror.Business.Enums;
using System;

namespace MagicMirror.Business.Models
{
    public class WeatherModel : Model
    {
        public string Location { get; set; }

        public string Icon { get; set; }

        public double Temperature { get; set; }

        public string WeatherType { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public TemperatureUom TemperatureUom { get; set; }

        public override void ConvertValues()
        {
            ConvertTemperature(Temperature, TemperatureUom.Kelvin);
            ConvertDates();
        }

        private void ConvertDates()
        {
            int.TryParse(Sunset, out int sunset);
            int.TryParse(Sunrise, out int sunrise);
            Sunset = UnixTimeHelper.ConvertFromUnixTimeStamp(sunset).ToShortTimeString();
            Sunrise = UnixTimeHelper.ConvertFromUnixTimeStamp(sunrise).ToShortTimeString();
        }

        private void ConvertTemperature(double degrees, TemperatureUom baseUom)
        {
            double convertedDegrees;

            switch (TemperatureUom)
            {
                case TemperatureUom.Celsius:
                    if (baseUom == TemperatureUom.Kelvin)
                    {
                        convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    }
                    else if (baseUom == TemperatureUom.Celsius)
                    {
                        convertedDegrees = degrees;
                    }
                    else
                    {
                        convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    }
                    break;
                case TemperatureUom.Fahrenheit:
                    convertedDegrees = TemperatureHelper.KelvinToFahrenheit(degrees);
                    break;

                case TemperatureUom.Kelvin:
                    convertedDegrees = degrees;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(TemperatureUom), TemperatureUom, null);
            }

            Temperature = convertedDegrees;
        }
    }
}