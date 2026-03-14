using System;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services;

public class OTPService : GenericService<OtpRequest, long>
{
    public OTPService(IGenericRepository<OtpRequest, long> genericRepository) : base(genericRepository)
    {
        
    }
}
