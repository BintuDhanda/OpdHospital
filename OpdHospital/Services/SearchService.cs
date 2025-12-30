using System;

namespace OpdHospital.Services;

public interface ISearchService
{
    Task<List<string>> Search(string query);
}

public class SearchService : ISearchService
{
    public async Task<List<string>> Search(string query)
    {
        // Simulate a search operation with a delay
        await Task.Delay(500);

        // Return dummy search results
        return new List<string>
        {
            $"Result 1 for '{query}'",
            $"Result 2 for '{query}'",
            $"Result 3 for '{query}'"
        };
    }
}
