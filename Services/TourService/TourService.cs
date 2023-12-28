using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TourService
{
    public class TourService : ITourService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TourService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetTourDto>>> AddTour(AddTourDto newTour)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            //var tour = _mapper.Map<Tour>(newTour);
            // var dbTours = await _context.Travelers.Where(c => c.travelerId == id).SelectMany(c => c.Tours).ToListAsync(); date name rating price
            var dbCityCountry = await _context.CityCountry.ToListAsync();
            var dbVehicle = await _context.TransportationVehicle.ToListAsync();
            var dbHotel = await _context.Hotels.ToListAsync();

            var matchingCityCountries = dbCityCountry.Where(cc => newTour.CityCountryList.Any(tc => tc.city.ToLower() == cc.city.ToLower() && tc.country.ToLower() == cc.country.ToLower())).ToList();   
            var matchingVehicles = dbVehicle.Where(v => newTour.TransportationVehicleList.Any(tv => tv.code.ToLower() == v.code.ToLower())).ToList();
            var matchingHotels = dbHotel.Where(h => newTour.HotelList.Any(hl => hl.name.ToLower() == h.name.ToLower())).ToList();

            if(matchingCityCountries.Count == 0)
            {
                serviceResponse.Message = "CityCountry not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if(matchingVehicles.Count == 0)
            {
                serviceResponse.Message = "Vehicle not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if(matchingHotels.Count == 0)
            {
                serviceResponse.Message = "Hotel not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            var tour = new Tour();
            tour.TransportationVehicleList = matchingVehicles;
            tour.CityCountryList = matchingCityCountries;
            tour.HotelList = matchingHotels;
            tour.name = newTour.name;
            tour.date = newTour.date;
            tour.rating = newTour.rating;
            tour.price = newTour.price;
            tour.description = newTour.description;

            for(int i = 0; i < matchingCityCountries.Count; i++){  
                if(matchingCityCountries[i].Tours == null){
                    matchingCityCountries[i].Tours = new List<Tour>();
                   matchingCityCountries[i].Tours.Add(tour); 
            }
            }
            for(int i = 0; i < matchingVehicles.Count; i++){  
                if(matchingVehicles[i].Tours == null){
                    matchingVehicles[i].Tours = new List<Tour>();
                   matchingVehicles[i].Tours.Add(tour);
                }   
            }
            for(int i = 0; i < matchingHotels.Count; i++){  
                if(matchingHotels[i].Tours == null){
                    matchingHotels[i].Tours = new List<Tour>();
                   matchingHotels[i].Tours.Add(tour); 
                }
            }
        
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Tours.Select(c => _mapper.Map<GetTourDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTourDto>>> GetAllTours()
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var dbTours = await _context.Tours.ToListAsync();
            serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTourDto>>> GetTourByCity(string city)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var dbTours = await _context.Tours.Where(c => c.CityCountryList.Any(d => d.city == city)).ToListAsync();
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTourDto>>> GetTourByPrice(int price)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var dbTours = await _context.Tours.Where(c => c.price <= price).ToListAsync();
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList(); 
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTourDto>>> GetAllToursSortedByPrice() //sort by price ascending
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var dbTours = await _context.Tours.OrderBy(c => c.price).ToListAsync();
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTourDto>>> GetAllToursSortedByRating() //sort by rating descending
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            var dbTours = await _context.Tours.OrderByDescending(c => c.rating).ToListAsync();
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTourDto>> GetTourById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTourDto>();
            var dbTour = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            serviceResponse.Data = _mapper.Map<GetTourDto>(dbTour);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTravelerDto>>> GetTravelerByTourId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            try
            {
          var dbTours = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var dbTravelers = await _context.Tours.Where(c => c.tourId == id).SelectMany(c => c.TravelerList).ToListAsync();
            serviceResponse.Data = dbTravelers.Select(c => _mapper.Map<GetTravelerDto>(c)).ToList();
            return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error finding Traveler: {ex.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCommentDto>>> GetCommentByTourId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            try
            {   
            var dbTours = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var dbComments = await _context.Tours.Where(c => c.tourId == id).SelectMany(c => c.CommentList).ToListAsync();
            serviceResponse.Data = dbComments.Select(c => _mapper.Map<GetCommentDto>(c)).ToList();
            return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error finding Comment: {ex.Message}";
                serviceResponse.Success = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCityCountryDto>>> GetCityCountryByTourId(int id){
            var serviceResponse = new ServiceResponse<List<GetCityCountryDto>>();
            try{
                 var dbTours = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var dbCityCountry = await _context.Tours.Where(c => c.tourId == id).SelectMany(c => c.CityCountryList).ToListAsync();
            serviceResponse.Data = dbCityCountry.Select(c => _mapper.Map<GetCityCountryDto>(c)).ToList();
            return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error finding Comment: {ex.Message}";
                serviceResponse.Success = false;

            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> GetTransportationVehicleByTourId(int id){
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            try{
                 var dbTours = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var dbTransportationVehicle = await _context.Tours.Where(c => c.tourId == id).SelectMany(c => c.TransportationVehicleList).ToListAsync();
            serviceResponse.Data = dbTransportationVehicle.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToList();
            return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error finding Comment: {ex.Message}";
                serviceResponse.Success = false;

            }
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<List<GetHotelDto>>> GetHotelByTourId(int id){
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            try{
                 var dbTours = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == id);
            if (dbTours is null)
            {
                serviceResponse.Message = "Tour not found.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var dbHotel = await _context.Tours.Where(c => c.tourId == id).SelectMany(c => c.HotelList).ToListAsync();
            serviceResponse.Data = dbHotel.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();
            return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error finding Comment: {ex.Message}";
                serviceResponse.Success = false;

            }
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<GetTourDto>> UpdateTour(UpdateTourDto updatedTour)
        {
            var serviceResponse = new ServiceResponse<GetTourDto>();

            try
            {
                var tour = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == updatedTour.tourId);
                if (tour is null)
                {
                    throw new Exception($"Tour with Id '{updatedTour.tourId}' not found.");
                }

                //_mapper.Map<traveler>(updatedTraveler);

                tour.name = updatedTour.name;
                tour.date = updatedTour.date;
                tour.rating = updatedTour.rating;
                tour.price = updatedTour.price;
                tour.description = updatedTour.description;

                serviceResponse.Data = _mapper.Map<GetTourDto>(tour);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTourDto>>> DeleteTour(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            try
            {
                var tour = await _context.Tours.FirstAsync(c => c.tourId == id);
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Tours.Select(c => _mapper.Map<GetTourDto>(c)).ToListAsync();
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