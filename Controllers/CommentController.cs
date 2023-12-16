using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService){
            _commentService = commentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> Get(){
            return Ok(await _commentService.GetAllComments());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCommentDto>>> GetSingle(int id){
            return Ok(await _commentService.GetCommentById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> AddComment(AddCommentDto newComment){
            return Ok(await _commentService.AddComment(newComment));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> UpdateComment(UpdateCommentDto updatedComment){
            var response = await _commentService.UpdateComment(updatedComment);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> DeleteComment(int id){
            var response = await _commentService.DeleteComment(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}