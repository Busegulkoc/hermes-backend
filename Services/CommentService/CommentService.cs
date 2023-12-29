using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.CommentService
{
    public class CommentService : ICommentService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CommentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> AddComment(AddCommentDto newComment)
        {
            var response = new ServiceResponse<List<GetCommentDto>>();

            try
            {
                var comment = _mapper.Map<Comment>(newComment);
                var traveler = _context.Travelers.FirstOrDefault(t => t.travelerId == newComment.travelerId);
                var tour = _context.Tours.FirstOrDefault(t => t.tourId == newComment.tourId);
                if (traveler == null)
                {
                    response.Message = "Traveler not found.";
                    response.Success = false;
                    return response;
                }
                if (tour == null)
                {
                    response.Message = "Tour not found.";
                    response.Success = false;
                    return response;
                }
                comment.traveler = traveler;
                comment.tour = tour;
                _context.Comments.Add(comment);

                  //tour un ve traveler ın comment listelerine de bu commenti ekliyoruz:
                if (tour.CommentList == null)
                {
                    tour.CommentList = new List<Comment>();
                }
                if (traveler.Comments == null)
                {
                    traveler.Comments = new List<Comment>();
                }
                tour.CommentList.Add(comment);
                traveler.Comments.Add(comment);

                await _context.SaveChangesAsync();

                var comments = await GetAllComments(); // Yeni veriyi ekledikten sonra tüm veriyi getir
                response.Data = comments.Data;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error adding comment: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> GetAllComments()
        {
            var response = new ServiceResponse<List<GetCommentDto>>();

            try
            {
                var comments = await _context.Comments.ToListAsync();

                response.Data = _mapper.Map<List<GetCommentDto>>(comments);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting all comments: {ex.Message}";
                response.Success = false;
                return response;
            }
        }
        public async Task<ServiceResponse<GetCommentDto>> GetCommentById(int id)
        {
            var response = new ServiceResponse<GetCommentDto>();

            try
            {
                var comment = await _context.Comments.FindAsync(id);

                if (comment == null)
                {
                    response.Message = "Comment not found";
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<GetCommentDto>(comment);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting comment: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto updatedComment)
        {
            var response = new ServiceResponse<GetCommentDto>();

            try
            {
                var comment = await _context.Comments.FindAsync(updatedComment.commentId);

                if (comment == null)
                {
                    response.Message = "Comment not found";
                    response.Success = false;
                    return response;
                }

                // Güncelleme işlemleri
                // comment.Content = updatedComment.Content;
                var traveler = _context.Travelers.FirstOrDefault(t => t.travelerId == updatedComment.travelerId);
                var tour = _context.Tours.FirstOrDefault(t => t.tourId == updatedComment.tourId);
                if (traveler != null)
                {
                    comment.traveler = traveler;
                }
                if (tour != null)
                {
                    comment.tour = tour;
                }
                comment.commentText = updatedComment.commentText;
                comment.travelerId = updatedComment.travelerId;
                comment.tourId = updatedComment.tourId;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCommentDto>(comment);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error updating comment: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id)
        {
            var response = new ServiceResponse<List<GetCommentDto>>();

            try
            {
                var comment = await _context.Comments.FindAsync(id);

                if (comment == null)
                {
                    response.Message = "Comment not found";
                    response.Success = false;
                    return response;
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();

                var data = await GetAllComments();
                response.Data = data.Data; // Tüm veriyi getir
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error deleting comment: {ex.Message}";
                response.Success = false;
                return response;
            }
        }





    }
}