using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TransportationVehicleService
{
    public interface ITransportationVehicleService
    {
        Task<ServiceResponse<List<GetTransportationVehicleDto>>> GetAllTransportationVehicles();
        Task<ServiceResponse<GetTransportationVehicleDto>> GetTransportationVehicleById(int id);
        Task<ServiceResponse<List<GetTransportationVehicleDto>>> AddTransportationVehicle( AddTransportationVehicleDto newTransportationVehicle);
        Task<ServiceResponse<GetTransportationVehicleDto>> UpdateTransportationVehicle(UpdateTransportationVehicleDto updatedTransportationVehicle);
        Task<ServiceResponse<List<GetTransportationVehicleDto>>> DeleteTransportationVehicle(int id);
    }
}