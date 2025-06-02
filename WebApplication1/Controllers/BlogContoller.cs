using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.DataTransferObjects.BlogDto;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _blogService.GetAllBlog();
            return Ok(blogs);
        }
        [HttpPost]
        public IActionResult Add([FromBody] BlogCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Blog data is null");

            _blogService.AddBlog(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BlogUpdateDto dto)
        {
            if (dto == null || dto.BlogId != id)
                return BadRequest("Invalid blog data");

            _blogService.UpdateBlog(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.DeleteBlog(id);
            return Ok();
        }
    }
}
