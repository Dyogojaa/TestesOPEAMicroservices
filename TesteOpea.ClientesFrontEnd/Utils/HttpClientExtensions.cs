using System;
using System.Net.Http.Headers;
using System.Text.Json;
namespace TesteOpea.ClientesFrontEnd.Utils
{
    public static class HttpClientExtensions
    {
        private static readonly MediaTypeHeaderValue contentType 
                        = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode) throw 
                    new ApplicationException(
                        $"Algo de Errado aconteceu ao Ler a Resposta da API:" +
                        $"{response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static  Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpCliente, string Url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString);  

            content.Headers.ContentType = contentType;
            
            return httpCliente.PostAsync(Url, content);

        }


        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpCliente, string Url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);

            var content = new StringContent(dataAsString);

            content.Headers.ContentType = contentType;

            return httpCliente.PutAsync(Url, content);

        }
    }
}
