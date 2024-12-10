using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianDestinations.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(
            ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int destinationId, int personId)
        {
            var model = await commentService.Add(destinationId, personId);
            return View(model);
        }

        public async Task<IActionResult> Add(CommentViewModel model, int destinationId, int personId)
        {
            await commentService.Add(model, destinationId, personId);
            return RedirectToAction("All", new { destinationId = destinationId });
        }

        public async Task<IActionResult> All(int destinationId)
        {
            var model = await commentService.All(destinationId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int commentId, int destinationId)
        {
            await commentService.DeleteComment(commentId);
            return RedirectToAction("All", new { destinationId = destinationId });
        }
    }
}
