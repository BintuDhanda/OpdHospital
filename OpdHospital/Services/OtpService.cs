using System;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services;

public class OTPService : GenericService<OtpRequest>
{
    public OTPService(IGenericRepository<OtpRequest> genericRepository) : base(genericRepository)
    {
        
    }
}
