namespace JwtAuthExample.Models;

public class AuthOptionsModel
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
}