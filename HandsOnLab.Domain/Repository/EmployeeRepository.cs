using HandsOnLab.Domain.IRepository;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOnLab.Domain.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private const int EXPONENT = 2;
        private const int RETRY_COUNT = 3;
        private const int SECONDS_FOR_RETRY = 2;

        public async Task<IList<Employee>> GetEmployeeAsync()
        {
            string path = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            using (var restClient = new HttpClient())
            {
                return await GetRetryPolicy().ExecuteAsync(async () =>
                {
                    var response = await restClient.GetAsync(path).ConfigureAwait(false);
                    return await ProcessResponseAsync<List<Employee>>(response).ConfigureAwait(false);
                }).ConfigureAwait(false);
            }
        }

        private AsyncRetryPolicy GetRetryPolicy()
        {
            return Policy.Handle<Exception>().
                WaitAndRetryAsync(RETRY_COUNT, retryCount => TimeSpan.FromSeconds(Math.Pow(EXPONENT, SECONDS_FOR_RETRY)));
        }
        private static async Task<T> ProcessResponseAsync<T>(HttpResponseMessage response) where T : class, new()
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"ha ocurrido un error al tratar de realizar la petición {response.RequestMessage.Method} a {response.RequestMessage.RequestUri} " +
                    $"StatusCode: {response.StatusCode.GetHashCode()}, {result}");
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
