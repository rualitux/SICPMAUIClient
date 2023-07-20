using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoMauiClient2.Models;

namespace ToDoMauiClient2.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
                "http://10.0.2.2:5160" : "https://localhost:7213";
            _url = $"{_baseAddress}/api/i";
            _jsonSerializerOptions = new JsonSerializerOptions
            { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task AddToDoAsync(Procedimiento toDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonToDo = JsonSerializer.Serialize<Procedimiento>(toDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/procedimientos", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado ToDo satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return;
        }

        public async Task AddAreaAsync(Area area)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<Area>(area, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/areas", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado area satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return;
        }



        public async Task DeleteToDoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/procedimientos/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado ToDo satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return;
        }

        public async Task<List<Procedimiento>> GetAllToDosAsync()
        {
            List<Procedimiento> todos = new List<Procedimiento>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return todos;                    
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/procedimientos");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<List<Procedimiento>>(content, _jsonSerializerOptions);
                }
                else 
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return todos;
        
        }

        public async Task<List<Area>> GetAllAreasAsync()
        {
            List<Area> lista = new List<Area>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return lista;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/areas");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<Area>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return lista;

        }

        public async Task UpdateToDoAsync(Procedimiento procedimiento)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonProc = JsonSerializer.Serialize<Procedimiento>(procedimiento, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProc, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.
                    PutAsync($"{_url}/procedimientos/{procedimiento.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"!!!Actualizado {procedimiento.NombreReferencial}");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return;
        }

        public async Task UpdateAreaAsync(Area area)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonProc = JsonSerializer.Serialize<Area>(area, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProc, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.
                    PutAsync($"{_url}/areas/{area.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"!!!Actualizado {area.Nombre}");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return;
        }

        public async Task<List<Enumerado>> GetAllEnumeradosAsync()
        {
            List<Enumerado> todos = new List<Enumerado>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return todos;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/enumerados");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<List<Enumerado>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return todos;

        }
    }
}
