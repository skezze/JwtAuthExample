using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace JwtAuthExample.Models;

public class SecurityKey:ISecurityKey
{
    public  SecurityKey()
    {

        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        // Add an Accept header for JSON format.
       /* while (true)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
        }*///
           //todo :try to realtime update key
         response = client.GetAsync("https://localhost:7224/getkey").Result;
        if (response.IsSuccessStatusCode)
        {
            Key = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(Key);
        }
        else
        {
            Console.WriteLine("key api is down");
        }
      
    }
    public string Key { get; set; }
}