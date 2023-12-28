using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.ManagerService
{
    public class ManagerService : IManagerService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ManagerService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetManagerDto>>> AddManager(AddManagerDto newManager)
        {
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            var manager = _mapper.Map<Manager>(newManager);
            _context.Manager.Add(manager);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Manager.Select(c => _mapper.Map<GetManagerDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetManagerDto>>> GetAllManagers()
        {
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            var dbManagers = await _context.Manager.ToListAsync();
            serviceResponse.Data = dbManagers.Select(c => _mapper.Map<GetManagerDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetManagerDto>> GetManagerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetManagerDto>();
            var dbManager = await _context.Manager.FirstOrDefaultAsync(c => c.managerId == id);
            serviceResponse.Data = _mapper.Map<GetManagerDto>(dbManager);
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetManagerDto>> GetManagerByEmailAndPassword(string email, string password)
        {
            var serviceResponse = new ServiceResponse<GetManagerDto>();
            try{
                var dbManager = await _context.Manager.FirstOrDefaultAsync(c => c.eMail == email && c.password == password);
                if(dbManager is null){
                    serviceResponse.Message = "Manager not found.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                serviceResponse.Data = _mapper.Map<GetManagerDto>(dbManager);
                return serviceResponse;
            }
            catch(Exception ex){
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }    
        public async Task<ServiceResponse<GetManagerDto>> UpdateManager(UpdateManagerDto updatedManager)
        {
            var serviceResponse = new ServiceResponse<GetManagerDto>();

            try
            {
                var manager = await _context.Manager.FirstOrDefaultAsync(c => c.managerId == updatedManager.managerId);
                if (manager is null)
                {
                    throw new Exception($"Manager with Id '{updatedManager.managerId}' not found.");
                }

                //_mapper.Map<traveler>(updatedTraveler);

                manager.name = updatedManager.name;
                manager.surname = updatedManager.surname;
                manager.eMail = updatedManager.eMail;
                manager.password = updatedManager.password;
                manager.phoneNumber = updatedManager.phoneNumber;
                manager.salary = updatedManager.salary;
                manager.cityCountryId = updatedManager.cityCountryId;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetManagerDto>(manager);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetManagerDto>>> DeleteManager(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetManagerDto>>();
            try
            {
                Manager manager = await _context.Manager.FirstAsync(c => c.managerId == id);
                _context.Manager.Remove(manager);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Manager.Select(c => _mapper.Map<GetManagerDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


    }
}