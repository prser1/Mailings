﻿using System.ComponentModel.DataAnnotations;

namespace Mailings.Web.API.ViewModels;

public sealed class MailingMailViewModel
{
    [Required] public string Id { get; set; }
    public string? Theme { get; set; } 
    public string? Type { get; set; }
}