using OpdHospital.Models;
namespace OpdHospital.Interfaces;

    public interface IFileRepository
    {
        Task<long> InsertAsync(Files file);
    }
