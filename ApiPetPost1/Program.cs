using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiPetPost
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await PostData();
        }

        static async Task PostData()
        {
            try
            {
                // URL a la que se enviará la solicitud POST
                string url = "https://petstore.swagger.io/v2/pet"; // URL de ejemplo, asegúrate de usar la URL correcta de tu API

                // Datos que se enviarán en el cuerpo de la solicitud
                string jsonData = "{\"id\":1, \"name\":\"Hola\"}"; // Datos de ejemplo, reemplaza con los datos reales que desees enviar

                // Crear una instancia de HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Configurar el encabezado de contenido para JSON
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Crear el contenido de la solicitud
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseData);
                    }
                    else
                    {
                        // Si la solicitud no fue exitosa, mostrar el código de estado
                        Console.WriteLine("Error al enviar la solicitud. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                // Capturar y mostrar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
