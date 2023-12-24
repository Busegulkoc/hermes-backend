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
            var tour = _mapper.Map<Tour>(newTour);
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