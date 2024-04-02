using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Azure AD credentials
        string clientId = "your-client-id";
        string tenantId = "your-tenant-id";
        string clientSecret = "your-client-secret";

        // API endpoint
        string apiUrl = "https://localhost:44325/api/values";

        // Create a confidential client application
        IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
            .Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
            .Build();

        // Define the API scope
        string[] scopes = { "api://<API-Application-ID-URI>/<Scope>" };

        // Get an access token
        AuthenticationResult result = await app.AcquireTokenForClient(scopes)
            .ExecuteAsync();

        // Use the access token to call the Web API
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API response:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
            }
        }
    }
}
