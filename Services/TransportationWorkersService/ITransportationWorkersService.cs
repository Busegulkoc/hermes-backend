using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TransportationWorkersService
{
    public interface ITransportationWorkersService
    {
        Task<ServiceResponse<List<GetTransportationWorkersDto>>> GetAllTransportationWorkerss();
        Task<ServiceResponse<GetTransportationWorkersDto>> GetTransportationWorkersById(int id);
        Task<ServiceResponse<List<GetTransportationWorkersDto>>> AddTransportationWorkers( AddTransportationWorkersDto newTransportationWorkers);
        Task<ServiceResponse<GetTransportationWorkersDto>> UpdateTransportationWorkers(UpdateTransportationWorkersDto updatedTransportationWorkers);
        Task<ServiceResponse<List<GetTransportationWorkersDto>>> DeleteTransportationWorkers(int id);
    
    }
}