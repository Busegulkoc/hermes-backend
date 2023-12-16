using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private static List<Admin> adminList = new List<Admin>{
            new Admin{ name = "Buse"},
            new Admin{adminId = 1, name = "Senay"},
            new Admin{adminId = 2, name = "Alperen"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AdminService( IMapper mapper, DataContext context){
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetAdminDto>>> AddAdmin(AddAdminDto newAdmin){
            var serviceResponse = new ServiceResponse<List<GetAdminDto>>();
            var admin = _mapper.Map<Admin>(newAdmin);
            // admin.adminId = adminList.Max(c => c.adminId) +1; // when we use entity framework it will generate the proper id by itself.  // bu oldu mu empId ile managerList
            adminList.Add(admin);
            serviceResponse.Data = adminList.Select(c => _mapper.Map<GetAdminDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAdminDto>>> GetAllAdmins(){
            var serviceResponse = new ServiceResponse<List<GetAdminDto>>();
            var dbAdmin = await _context.Admin.ToListAsync();
            serviceResponse.Data = adminList.Select(c => _mapper.Map<GetAdminDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetAdminDto>> GetAdminById(int id){
            var serviceResponse = new ServiceResponse<GetAdminDto>();
            var admin = adminList.FirstOrDefault(c => c.adminId == id);
            serviceResponse.Data = _mapper.Map<GetAdminDto>(admin);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAdminDto>> UpdateAdmin(UpdateAdminDto updatedAdmin){ 
            var serviceResponse = new ServiceResponse<GetAdminDto>();

            try{
            var admin = adminList.FirstOrDefault(c => c.adminId == updatedAdmin.adminId);
            if(admin is null ){
                throw new Exception($"Admin with Id '{updatedAdmin.adminId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            admin.name = updatedAdmin.name;
            admin.surname = updatedAdmin.surname;
            admin.eMail = updatedAdmin.eMail;
            admin.phoneNumber = updatedAdmin.phoneNumber;
            admin.salary = updatedAdmin.salary;

            serviceResponse.Data = _mapper.Map<GetAdminDto>(admin);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetAdminDto>>> DeleteAdmin(int id){
            var serviceResponse = new ServiceResponse<List<GetAdminDto>>();
            try{
                var admin = adminList.First(c=> c.adminId == id);
                if(admin is null){
                    throw new Exception($"Admin with Id'{id}' not found.");
                }
                adminList.Remove(admin);
                serviceResponse.Data = adminList.Select(c => _mapper.Map<GetAdminDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}