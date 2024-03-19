
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Comment başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            _commentRepository.Remove(id);
            return Ok("Comment başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Comment başarıyla güncellendi"); 
        }
    }
}
