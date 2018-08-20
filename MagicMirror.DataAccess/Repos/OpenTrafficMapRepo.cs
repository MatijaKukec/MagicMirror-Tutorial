using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class OpenTrafficMapRepo : Repository<OpenTrafficMapEntity>, ITrafficRepo
    {
        private string _start;
        private string _destination;

        public async Task<Entity> GetTrafficInfoAsync(string start, string destination)
        {
            FillInputData(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            OpenTrafficMapEntity entity = await GetEntityFromJsonAsync(message);

            if (entity.Route.distance == 0)
            {
                throw new HttpRequestException("Unable to retrieve traffic information");
            }

            return entity;
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