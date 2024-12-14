using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulgarianDestinations.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IRepository repository;

        public CommentController(
            ICommentService _commentService,
            IRepository _repository)
        {
            commentService = _commentService;
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int destinationId)
        {
            var model = await commentService.Add(destinationId, GetUserId());
            return View(model);
        }

        public async Task<IActionResult> Add(CommentViewModel model, int destinationId)
        {
            await commentService.Add(model, destinationId, GetUserId());
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

        public int GetUserId()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            var person = repository.AllReadOnly<Person>()
                .Where(p => p.UserId == userId)
                .FirstOrDefault();

            return person.Id;
        }
    }
}
