using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.HotelService
{
    public class HotelService : IHotelService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public HotelService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetHotelDto>>> AddHotel(AddHotelDto newHotel)
        {
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            var hotel = _mapper.Map<Hotel>(newHotel);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Hotels.Select(c => _mapper.Map<GetHotelDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetHotelDto>>> GetAllHotels()
        {
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            var dbHotels = await _context.Hotels.ToListAsync();
            serviceResponse.Data = dbHotels.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetHotelDto>> GetHotelById(int id)
        {
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            var dbHotel = await _context.Hotels.FirstOrDefaultAsync(c => c.hotelId == id);
            serviceResponse.Data = _mapper.Map<GetHotelDto>(dbHotel);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHotelDto>> UpdateHotel(UpdateHotelDto updatedHotel)
        {
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            try
            {
                Hotel hotel = await _context.Hotels.FirstOrDefaultAsync(c => c.hotelId == updatedHotel.hotelId);
                hotel.name = updatedHotel.name;
                hotel.cityCountryId = updatedHotel.cityCountryId;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetHotelDto>(hotel);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetHotelDto>>> DeleteHotel(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            try
            {
                Hotel hotel = await _context.Hotels.FirstAsync(c => c.hotelId == id);
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Hotels.Select(c => _mapper.Map<GetHotelDto>(c)).ToListAsync();
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