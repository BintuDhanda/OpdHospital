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
        : GenericService<Appointment>, IAppointmentService
    {
        public AppointmentService(
            IGenericRepository<Appointment> genericRepository
        ) : base(genericRepository)
        {
        }

        public async Task<ApiResponse?> GetAppointmentsByUserId(long userId)
        {
            var result = await base.GetAll()
                .Where(w => w.CreatedBy == userId)
                .OrderByDescending(d => d.AppointmentId)
                .ToListAsync();

            return Response.Success(result, "appointments") as ApiResponse;
        }
    }
}
