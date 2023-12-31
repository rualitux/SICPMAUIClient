﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                 ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
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

        public async Task<BienPatrimonial> AddBienAsync(BienPatrimonial bienPatrimonial)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<BienPatrimonial>(bienPatrimonial, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/bienes", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado bien satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                //leo la respuesta 201
                var respuestaPost = await response.Content.ReadAsStringAsync();
                //convierto a BienPatrimonial con todas las IDs puestas por el API
                var bienPosteado = JsonSerializer.Deserialize<BienPatrimonial>(respuestaPost, _jsonSerializerOptions);
                return bienPosteado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return null;
        }

        public async Task<Inventario> AddInventarioAsync(Inventario inventario)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<Inventario>(inventario, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/inventarios", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado inventario satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                //leo la respuesta 201
                var respuestaPost = await response.Content.ReadAsStringAsync();
                //convierto a BienPatrimonial con todas las IDs puestas por el API
                var inventarioPosteado = JsonSerializer.Deserialize<Inventario>(respuestaPost, _jsonSerializerOptions);
                return inventarioPosteado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return null;
        }

          public async Task<Ajuste> AddAjusteAsync(Ajuste ajuste)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<Ajuste>(ajuste, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/ajustes", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado ajuste satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                //leo la respuesta 201
                var respuestaPost = await response.Content.ReadAsStringAsync();
                //convierto a Ajuste con todas las IDs puestas por el API
                var ajustePosteado = JsonSerializer.Deserialize<Ajuste>(respuestaPost, _jsonSerializerOptions);
                return ajustePosteado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return null;
        }

        public async Task<AjusteDetalle> AddAjusteDetalleAsync(AjusteDetalle ajusteDetalle)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<AjusteDetalle>(ajusteDetalle, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/ajustes/detalles", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado ajuste satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                //leo la respuesta 201
                var respuestaPost = await response.Content.ReadAsStringAsync();
                //convierto a Ajuste con todas las IDs puestas por el API
                var ajusteDetallePosteado = JsonSerializer.Deserialize<AjusteDetalle>(respuestaPost, _jsonSerializerOptions);
                return ajusteDetallePosteado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return null;
        }

        public async Task<BienProcedimientoAltaRetorno> AddBienProcedimientoAlta(BienProcedimientoAlta bienProcedimientoAlta)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<BienProcedimientoAlta>(bienProcedimientoAlta, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/bienes/alta", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado altas satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                var respuestaPost = await response.Content.ReadAsStringAsync();
                //convierto a BienPatrimonial con todas las IDs puestas por el API
                var bienPosteado = JsonSerializer.Deserialize<BienProcedimientoAltaRetorno>(respuestaPost, _jsonSerializerOptions);
                return bienPosteado;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }
            return null;
        }

        public async Task AddAjusteBaja(AjusteBajaVM ajusteBajaVM) {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonContent = JsonSerializer.Serialize<AjusteBajaVM>(ajusteBajaVM, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/inventarios/baja", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("!!! Creado altas satisfactoriamente");
                }
                else
                {
                    Debug.WriteLine("!!! Sin respuesta Http 2xx");

                }
                return;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message} ");
            }

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
        public async Task<List<BienPatrimonial>> GetAllBienesAsync()
        {
            List<BienPatrimonial> lista = new List<BienPatrimonial>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return lista;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/bienes");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<BienPatrimonial>>(content, _jsonSerializerOptions);
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

        public async Task<List<Inventario>> GetAllInventariosAsync()
        {
            List<Inventario> lista = new List<Inventario>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return lista;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/inventarios");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<Inventario>>(content, _jsonSerializerOptions);
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

        public async Task<List<AjustoExtendidoDto>> GetAllAjustesAsync()
        {
            List<AjustoExtendidoDto> lista = new List<AjustoExtendidoDto>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return lista;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/ajustes/extendido");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<AjustoExtendidoDto>>(content, _jsonSerializerOptions);
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




        public async Task<AjusteBajaVM> GetInventarioAsync(int inventarioId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return null;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.
                          GetAsync($"{_url}/inventarios/{inventarioId}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var item = JsonSerializer.Deserialize<Inventario>(content, _jsonSerializerOptions);
                    var ajusteBajaVM = new AjusteBajaVM();
                    ajusteBajaVM.InventarioId = item.Id;
                    ajusteBajaVM.Cantidad = item.Cantidad;
                    ajusteBajaVM.AnexoTipoId = item.AnexoTipoId;
                    ajusteBajaVM.AreaId = item.AreaId;
                    ajusteBajaVM.BienPatrimonialId = item.BienPatrimonialId;
                    ajusteBajaVM.EstadoCondicionId = item.EstadoCondicionId;
                    return ajusteBajaVM;
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
            return null;
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

        public async Task UpdateBienAsync(BienPatrimonial bienPatrimonial)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonProc = JsonSerializer.Serialize<BienPatrimonial>(bienPatrimonial, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProc, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.
                    PutAsync($"{_url}/bienes/{bienPatrimonial.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"!!!Actualizado {bienPatrimonial.Denominacion}");
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

        public async Task UpdateInventarioAsync(Inventario inventario)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("!!! Sin internet");
                return;
            }
            try
            {
                string jsonProc = JsonSerializer.Serialize<Inventario>(inventario, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProc, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.
                    PutAsync($"{_url}/inventarios/{inventario.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"!!!Actualizado {inventario.BienPatrimonialId} en {inventario.AreaId}");
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
