using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Entities.Traffic;
using System;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class OpenTrafficMapRepo : Repository<OpenMapEntity>
    {
        private string _start;
        private string _destination;

        public Task<TrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            throw new NotImplementedException();
        }

        private void FillInputData(string start, string destination)
        {
            _apiId = DataAccessConfig.OpenTrafficMapApiId;
            _apiUrl = DataAccessConfig.OpenTrafficMapApiUrl;
            _start = start;
            _destination = destination;

            ValidateInput();

            _url = $"{_apiUrl}?from={start}&to={destination}&key={_apiId}";
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();
            if (string.IsNullOrWhiteSpace(_start)) { throw new ArgumentNullException("A start location has to be provided"); }
            if (string.IsNullOrWhiteSpace(_destination)) { throw new ArgumentNullException("A destination has to be provided"); }
        }
    }
}