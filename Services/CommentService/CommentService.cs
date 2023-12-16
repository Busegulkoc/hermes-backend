using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private static List<Comment> commentList = new List<Comment>{
            new Comment{ commentText = "good"},
            new Comment{commentId = 1, commentText = "bad"},
            new Comment{commentId = 2, commentText = "not bad"}
        };
        private readonly IMapper _mapper;
        public CommentService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> AddComment(AddCommentDto newComment){
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            var comment = _mapper.Map<Comment>(newComment);
            comment.commentId = commentList.Max(c => c.commentId) +1; // when we use entity framework it will generate the proper id by itself.
            commentList.Add(comment);
            serviceResponse.Data = commentList.Select(c => _mapper.Map<GetCommentDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> GetAllComments(){
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            serviceResponse.Data = commentList.Select(c => _mapper.Map<GetCommentDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetCommentDto>> GetCommentById(int id){
            var serviceResponse = new ServiceResponse<GetCommentDto>();
            var comment = commentList.FirstOrDefault(c => c.commentId == id);
            serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto updatedComment){ 
            var serviceResponse = new ServiceResponse<GetCommentDto>();

            try{
            var comment = commentList.FirstOrDefault(c => c.commentId == updatedComment.commentId);
            if(comment is null ){
                throw new Exception($"Comment with Id '{updatedComment.commentId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            comment.commentText = updatedComment.commentText;
            comment.travelerId = updatedComment.travelerId;
            comment.tourId = updatedComment.tourId;
            
            serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id){
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            try{
                var comment = commentList.First(c=> c.commentId == id);
                if(comment is null){
                    throw new Exception($"Comment with Id'{id}' not found.");
                }
                commentList.Remove(comment);
                serviceResponse.Data = commentList.Select(c => _mapper.Map<GetCommentDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }




    }
}