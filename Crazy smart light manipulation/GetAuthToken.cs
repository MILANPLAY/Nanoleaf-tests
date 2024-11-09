using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace NanoleafSpace
{
    public partial class Nanoleaf
    {

        private async Task GetAuthToken()
        {
            Console.WriteLine("Hold the power button until the lights on the controler flash. Then pres ENTER");
            Console.ReadLine();
            if (!string.IsNullOrEmpty(IpAddress))
            {
                string url = $"http://{IpAddress}:{Port}/api/v1/new";

                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, url);

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        JObject JsonRespose = JObject.Parse(responseContent);
                        Console.WriteLine("Authentication token received:");
                        Console.WriteLine(JsonRespose["auth_token"]);
                        AuthToken = (string)JsonRespose["auth_token"];
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        public  async Task DeleteUserAsync()
        {
            if (!string.IsNullOrEmpty(IpAddress))
            {
                string url = $"http://{IpAddress}:{Port}/api/v1/{AuthToken}";

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    var message = response.StatusCode switch
                    {
                        System.Net.HttpStatusCode.NoContent => "User deleted successfully.",
                        System.Net.HttpStatusCode.Unauthorized => "Error: Unauthorized (401).",
                        System.Net.HttpStatusCode.InternalServerError => "Error: Internal Server Error (500).",
                        _ => $"Unexpected response: {response.StatusCode}"
                    };

                    Console.WriteLine(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

        }

    }
}
