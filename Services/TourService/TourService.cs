using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TourService
{
    public class TourService : ITourService
    {
         private static List<Tour> tourList = new List<Tour>{
            new Tour{ name = "America"},
            new Tour{tourId = 1, name = "Italy"},
            new Tour{tourId = 2, name = "Germany"}
        };
        private readonly IMapper _mapper;
        public TourService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTourDto>>> AddTour(AddTourDto newTour){
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var tour = _mapper.Map<Tour>(newTour);
            tour.tourId = tourList.Max(c => c.tourId) +1; // when we use entity framework it will generate the proper id by itself.
            tourList.Add(tour);
            serviceResponse.Data = tourList.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTourDto>>> GetAllTours(){
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            serviceResponse.Data = tourList.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetTourDto>> GetTourById(int id){
            var serviceResponse = new ServiceResponse<GetTourDto>();
            var tour = tourList.FirstOrDefault(c => c.tourId == id);
            serviceResponse.Data = _mapper.Map<GetTourDto>(tour);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTourDto>> UpdateTour(UpdateTourDto updatedTour){ 
            var serviceResponse = new ServiceResponse<GetTourDto>();

            try{
            var tour = tourList.FirstOrDefault(c => c.tourId == updatedTour.tourId);
            if(tour is null ){
                throw new Exception($"Tour with Id '{updatedTour.tourId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            tour.name = updatedTour.name;
            tour.date = updatedTour.date;
            tour.rating = updatedTour.rating;
            tour.price = updatedTour.price;

            serviceResponse.Data = _mapper.Map<GetTourDto>(tour);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetTourDto>>> DeleteTour(int id){
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            try{
                var tour = tourList.First(c=> c.tourId == id);
                if(tour is null){
                    throw new Exception($"Tour with Id'{id}' not found.");
                }
                tourList.Remove(tour);
                serviceResponse.Data = tourList.Select(c => _mapper.Map<GetTourDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}