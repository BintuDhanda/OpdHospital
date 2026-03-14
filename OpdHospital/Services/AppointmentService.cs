using Microsoft.EntityFrameworkCore;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Services
{
    public interface IAppointmentService
    {
        Task<ApiResponse?> GetAppointmentsByUserId(long userId);
    }


    public class AppointmentService
        : GenericService<Appointment, long>, IAppointmentService
    {
        public AppointmentService(
            IGenericRepository<Appointment, long> genericRepository
        ) : base(genericRepository)
        {
        }

        public async Task<ApiResponse?> GetAppointmentsByUserId(long userId)
        {
            var result = await base.GetAll()
                .Where(w => w.CreatedBy == userId)
                .OrderByDescending(d => d.Id)
                .ToListAsync();

            return Response.Success(result, "appointments") as ApiResponse;
        }
    }
}
