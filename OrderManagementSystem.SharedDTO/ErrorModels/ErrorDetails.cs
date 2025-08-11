﻿using System.Text.Json;

namespace Shared.ErrorModels;

public class Response
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public List<string>? Errors { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}
