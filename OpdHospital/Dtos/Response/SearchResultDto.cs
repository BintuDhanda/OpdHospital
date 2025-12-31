using System;

namespace OpdHospital.Dtos.Response;

public class SearchResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Doctor" or "Hospital"
}

