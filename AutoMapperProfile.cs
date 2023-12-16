using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            CreateMap<traveler,GetTravelerDto>();
            CreateMap<AddTravelerDto,traveler>();
            //CreateMap<UpdateTravelerDto,traveler>();

            CreateMap<Tour,GetTourDto>();
            CreateMap<AddTourDto,Tour>();

            CreateMap<Comment,GetCommentDto>();
            CreateMap<AddCommentDto,Comment>();

            CreateMap<CityCountry,GetCityCountryDto>();
            CreateMap<AddCityCountryDto,CityCountry>();

            CreateMap<TransportationVehicle,GetTransportationVehicleDto>();
            CreateMap<AddTransportationVehicleDto,TransportationVehicle>();

            CreateMap<Hotel,GetHotelDto>();
            CreateMap<AddHotelDto,Hotel>();

            CreateMap<Manager,GetManagerDto>();
            CreateMap<AddManagerDto,Manager>();

            CreateMap<TransportationWorkers,GetTransportationWorkersDto>();
            CreateMap<AddTransportationWorkersDto,TransportationWorkers>();

            CreateMap<Admin,GetAdminDto>();
            CreateMap<AddAdminDto,Admin>();
            CreateMap<Admin, AddAdminDto>();
        }
    }
}