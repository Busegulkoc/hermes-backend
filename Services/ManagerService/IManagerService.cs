using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.ManagerService
{
    public interface IManagerService
    {
        Task<ServiceResponse<List<GetManagerDto>>> GetAllManagers();
        Task<ServiceResponse<GetManagerDto>> GetManagerById(int id);
        Task<ServiceResponse<GetManagerDto>> GetManagerByEmailAndPassword(string email, string password);
        Task<ServiceResponse<List<GetManagerDto>>> AddManager( AddManagerDto newManager);
        Task<ServiceResponse<GetManagerDto>> UpdateManager(UpdateManagerDto updatedManager);
        Task<ServiceResponse<List<GetManagerDto>>> DeleteManager(int id);
    
    }
}