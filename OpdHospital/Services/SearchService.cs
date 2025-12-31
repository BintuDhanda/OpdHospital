using System;
using Microsoft.EntityFrameworkCore;
using OpdHospital.Dtos.Response;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Services;

public interface ISearchService
{
    Task<ApiResponse?> Search(string query);
}

public class SearchService : ISearchService
{
    private readonly IGenericService<Doctor> _doctorGenericService;
    private readonly IGenericService<Hospital> _hospitalrGenericService;

    public SearchService(IGenericService<Doctor> doctorGenericService, IGenericService<Hospital> hospitalrGenericService)
    {
        _doctorGenericService = doctorGenericService;
        _hospitalrGenericService = hospitalrGenericService;
    }

    public async Task<ApiResponse?> Search(string query)
    {
        query = query.Trim();

        var doctorsQuery = _doctorGenericService.GetAll()
            .Where(d => d.FullName.Contains(query))
            .Select(d => new SearchResultDto
            {
                Id = d.DoctorId,
                Name = d.FullName,
                Type = "Doctor"
            });

        var hospitalsQuery = _hospitalrGenericService.GetAll()
            .Where(h => h.HospitalName.Contains(query))
            .Select(h => new SearchResultDto
            {
                Id = h.HospitalId,
                Name = h.HospitalName,
                Type = "Hospital"
            });

        var result = await doctorsQuery
            .Union(hospitalsQuery)
            .OrderBy(x => x.Name)
            .ToListAsync();

        return Utilities.Response.Success(result, "Search results") as ApiResponse;
    }

}
