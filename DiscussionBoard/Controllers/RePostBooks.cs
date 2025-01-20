using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscussionBoard.Data;
using DiscussionBoard.Models;

namespace DiscussionBoard.Controllers
{
    public class RePostBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RePostBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: RePostBooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int postId, string content, string author)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(author))
            {
                return BadRequest();
            }

            var reply = new Reply
            {
                PostId = postId,
                Content = content,
                Author = author,
                ReplyTime = DateTime.Now
            };

            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "PostBooks", new { id = postId });
        }
    }
}