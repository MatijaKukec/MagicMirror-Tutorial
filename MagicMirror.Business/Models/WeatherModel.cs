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
            ConvertTemperature(Temperature, TemperatureUom.Celsius);
            ConvertDates();
        }

        private void ConvertDates()
        {
            int.TryParse(Sunset, out int sunset);
            int.TryParse(Sunrise, out int sunrise);
            Sunset = DateTimeHelper.ConvertFromUnixTimeStamp(sunset).ToShortTimeString();
            Sunrise = DateTimeHelper.ConvertFromUnixTimeStamp(sunrise).ToShortTimeString();
        }

        private void ConvertTemperature(double degreesToConvert, TemperatureUom targetTemperatureUom)
        {
            double convertedDegrees = 0;
            switch (targetTemperatureUom)
            {
                case TemperatureUom.Celsius:
                    if (TemperatureUom == TemperatureUom.Kelvin) { convertedDegrees = TemperatureHelper.KelvinToCelsius(degreesToConvert); }
                    else if (TemperatureUom == TemperatureUom.Fahrenheit) { convertedDegrees = TemperatureHelper.KelvinToFahrenheit(degreesToConvert); }
                    else if (TemperatureUom == TemperatureUom.Celsius) { convertedDegrees = degreesToConvert; }
                    break;

                case TemperatureUom.Fahrenheit:
                    if (TemperatureUom == TemperatureUom.Kelvin) { convertedDegrees = TemperatureHelper.KelvinToFahrenheit(degreesToConvert); }
                    else if (TemperatureUom == TemperatureUom.Fahrenheit) { convertedDegrees = degreesToConvert; }
                    else if (TemperatureUom == TemperatureUom.Celsius) { convertedDegrees = TemperatureHelper.CelsiusToFahrenheit(degreesToConvert); }
                    break;

                case TemperatureUom.Kelvin:
                    if (TemperatureUom == TemperatureUom.Kelvin) { convertedDegrees = degreesToConvert; }
                    else if (TemperatureUom == TemperatureUom.Fahrenheit) { convertedDegrees = TemperatureHelper.FahrenheitToKelvin(degreesToConvert); }
                    else if (TemperatureUom == TemperatureUom.Celsius) { convertedDegrees = TemperatureHelper.CelsiusToKelvin(degreesToConvert); }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(TemperatureUom), TemperatureUom, null);
            }

            TemperatureUom = targetTemperatureUom;
            Temperature = convertedDegrees;
        }
    }
}