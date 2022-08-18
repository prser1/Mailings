﻿namespace Mailings.Web.Services.Core;

public class AuthenticationOptions
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public List<string> Scopes { get; set; }
}