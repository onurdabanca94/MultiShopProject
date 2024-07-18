﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Comment.Context;
using MultiShopProject.Comment.Entities;

namespace MultiShopProject.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Comment has been created!");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Comment has been updated!");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Find(id);
            _context.UserComments.Remove(value);
            return Ok("Comment has been removed!");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }
        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductId == id);
            return Ok(value);
        }
    }
}
