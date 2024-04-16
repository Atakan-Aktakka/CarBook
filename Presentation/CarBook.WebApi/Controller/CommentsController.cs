using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
         private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            return Ok(comment);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi.");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            _commentRepository.Remove(comment);
            return Ok("Yorum Başarıyla Silindi.");
        }
        [HttpGet("GetCommentsByBlogId/{id}")]
        public IActionResult GetCommentsByBlogId(int id)
        {
            var comments = _commentRepository.GetComentsByBlogId(id);
            return Ok(comments);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id){
            var comments = _commentRepository.GetCountCommentByBlog(id);
            return Ok(comments);
        }
        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarıyla eklendi");
        }
    }
}