using Newtonsoft.Json;
using Spidedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Spidedex.Services
{
    public class DataAccessService : IDataAccessService
    {
        public readonly string _baseUri;
        private readonly HttpClient _httpClient;
        List<SpiderFactSheet> spiderFactSheets = new List<SpiderFactSheet>();
        public DataAccessService()
        {
            _baseUri = GetBaseAdress();
            _httpClient = new() { BaseAddress = new Uri(_baseUri) };
        }

        private string GetBaseAdress()
        {
            //return DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5157" : "https://localhost:7160";
            return "https://spidedexapi20230604130659.azurewebsites.net";
        }

        public async Task<bool> AddUpdateSpiderAsync(Spider spider)
        {
            try
            {
                // Spider doesn't exist so we want to create a new one.
                if (spider.Id == 0)
                {
                    var response = await _httpClient.PostAsync("/spiders", new StringContent(JsonConvert.SerializeObject(spider), Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return await Task.FromResult(true);
                    }
                }
                // Spider exists so we want to update it.
                else
                {
                    var response = await _httpClient.PutAsync($"/spiders/{spider.Id}", new StringContent(JsonConvert.SerializeObject(spider), Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return await Task.FromResult(true);
                    }
                }
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteSpiderAsync(int spiderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/spiders/{spiderId}");

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Spider> GetSpiderAsync(int spiderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/spiders/{spiderId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return await Task.FromResult(JsonConvert.DeserializeObject<Spider>(content));
                }
                else
                {
                    return await Task.FromResult<Spider>(null);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult<Spider>(null);
            }
        }

        public async Task<IEnumerable<Spider>> GetSpidersAsync(string userDetails)
        {
            try
            {
                var spiderList = new List<Spider>();
                if (userDetails != null)
                {
                    var response = await _httpClient.GetAsync($"/spiders/foruser/{userDetails}");

                    if (response.IsSuccessStatusCode)
                    {
                        spiderList = await response.Content.ReadFromJsonAsync<List<Spider>>();
                    }
                    return await Task.FromResult(spiderList);
                }
                else
                {
                    return await Task.FromResult(spiderList);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult<IEnumerable<Spider>>(null);
            }
        }

        public async Task<List<SpiderFactSheet>> GetSpiderFactSheetsAsync()
        {
            try
            {
                // Load the fact sheets locally from json file.
                using var jsonStream = await FileSystem.OpenAppPackageFileAsync("SpiderFactSheets.json");
                using var reader = new StreamReader(jsonStream);
                // read the json file and deserialize it into a list of spider fact sheets.
                var json = await reader.ReadToEndAsync();
                spiderFactSheets = JsonConvert.DeserializeObject<List<SpiderFactSheet>>(json);

                return await Task.FromResult(spiderFactSheets);
            }
            catch (Exception)
            {
                return await Task.FromResult<List<SpiderFactSheet>>(null);
            }
        }
    }
}