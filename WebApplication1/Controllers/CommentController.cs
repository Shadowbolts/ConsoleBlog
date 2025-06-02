using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.DataTransferObjects.CommentDtos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) 
        {
            _commentService = commentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var comments = _commentService.GetAllComments();
            return Ok(comments);
        }
        [HttpPost]
        public IActionResult Add([FromBody] CommentCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Blog data is null");

            _commentService.AddComment(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CommentUpdateDto dto)
        {
            if (dto == null || dto.CommentId != id)
                return BadRequest("Invalid blog data");

            _commentService.UpdateComment(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.DeleteComment(id);
            return Ok();
        }
    }
}
