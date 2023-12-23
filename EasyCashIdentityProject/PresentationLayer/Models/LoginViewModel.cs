using Microsoft.Build.Framework;
using Org.BouncyCastle.Asn1.Cmp;

namespace PresentationLayer.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; } 
}