﻿namespace Mailings.Authentication.Core.ResponseFactory;

/// <summary>
///     Response types of success results
/// </summary>
public enum SuccessResponseType
{
    Unknown,
    Ok,
    MissingResult,
    Changed,
    Created
}