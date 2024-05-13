using System.Text;

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
                string url = "https://petstore.swagger.io/v2/pet";

                string jsonData = "{\"id\":1, \"name\":\"Hola\"}"; 

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseData);
                    }
                    else
                    {
                        Console.WriteLine("Error al enviar la solicitud. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
