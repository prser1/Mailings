﻿namespace Mailings.Resources.Domain.Models;

public class EmailAddressTo
{
    public Guid Id { get; set; }
    public MailingGroup Group { get; set; }
    public EmailAddress Address { get; set; }
}