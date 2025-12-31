using Microsoft.EntityFrameworkCore;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Services
{
    public interface IPatientService
    {
        Task<ApiResponse?> GetPatientBookByUserId(long userId);
    }
    public class PatientService : GenericService<Patient>, IPatientService
    {
        private readonly IGenericRepository<Patient> _repository;
        public PatientService(IGenericRepository<Patient> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse?> GetPatientBookByUserId(long userId)
        {
            var query = base.GetAll();

            query = query.Where(w=>w.UserId == userId);

            var result = await query.ToListAsync();
            var total = await query.CountAsync();

            return Response.Success(result, "patients book", total) as ApiResponse;
        }
    }

    
}
