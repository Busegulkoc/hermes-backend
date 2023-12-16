using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private static List<Manager> managerList = new List<Manager>{
            new Manager{ name = "Buse"},
            new Manager{managerId = 1, name = "Senay"},
            new Manager{managerId = 2, name = "Alperen"}
        };
        private readonly IMapper _mapper;
        public ManagerService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetManagerDto>>> AddManager(AddManagerDto newManager){
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            var manager = _mapper.Map<Manager>(newManager);
            manager.managerId = managerList.Max(c => c.managerId) +1; // when we use entity framework it will generate the proper id by itself.  // bu oldu mu empId ile managerList
            managerList.Add(manager);
            serviceResponse.Data = managerList.Select(c => _mapper.Map<GetManagerDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetManagerDto>>> GetAllManagers(){
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            serviceResponse.Data = managerList.Select(c => _mapper.Map<GetManagerDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetManagerDto>> GetManagerById(int id){
            var serviceResponse = new ServiceResponse<GetManagerDto>();
            var manager = managerList.FirstOrDefault(c => c.managerId == id);
            serviceResponse.Data = _mapper.Map<GetManagerDto>(manager);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetManagerDto>> UpdateManager(UpdateManagerDto updatedManager){ 
            var serviceResponse = new ServiceResponse<GetManagerDto>();

            try{
            var manager = managerList.FirstOrDefault(c => c.managerId == updatedManager.managerId);
            if(manager is null ){
                throw new Exception($"Manager with Id '{updatedManager.managerId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            manager.name = updatedManager.name;
            manager.surname = updatedManager.surname;
            manager.eMail = updatedManager.eMail;
            manager.phoneNumber = updatedManager.phoneNumber;
            manager.salary = updatedManager.salary;
            manager.cityCountryId = updatedManager.cityCountryId;

            serviceResponse.Data = _mapper.Map<GetManagerDto>(manager);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetManagerDto>>> DeleteManager(int id){
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            try{
                var manager = managerList.First(c=> c.managerId == id);
                if(manager is null){
                    throw new Exception($"Manager with Id'{id}' not found.");
                }
                managerList.Remove(manager);
                serviceResponse.Data = managerList.Select(c => _mapper.Map<GetManagerDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }


    }
}