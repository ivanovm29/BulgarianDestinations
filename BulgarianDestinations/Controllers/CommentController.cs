using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BulgarianDestinations.Core.Constants.RoleConstants;

namespace BulgarianDestinations.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IRepository repository;
        private readonly IDestinationService destinationService;

        public CommentController(
            ICommentService _commentService,
            IRepository _repository,
            IDestinationService _destinationService)
        {
            commentService = _commentService;
            repository = _repository;
            destinationService = _destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false)
            {
                return BadRequest();
            }
            var model = await commentService.Add(destinationId, GetUserId());
            return View(model);
        }

        public async Task<IActionResult> Add(CommentViewModel model, int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false)
            {
                return BadRequest();
            }

            await commentService.Add(model, destinationId, GetUserId());
            return RedirectToAction("All", new { destinationId = destinationId });
        }

        public async Task<IActionResult> All(int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false)
            {
                return BadRequest();
            }

            var model = await commentService.All(destinationId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int commentId, int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false || await commentService.Exists(commentId) == false)
            {
                return BadRequest();
            }

            await commentService.DeleteComment(commentId);
            return RedirectToAction("All", new { destinationId = destinationId });
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> AllAdmin(int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false)
            {
                return BadRequest();
            }

            var model = await commentService.All(destinationId);
            return View(model);
        }

        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> DeleteAdmin(int commentId, int destinationId)
        {
            if (await destinationService.Exists(destinationId) == false || await commentService.Exists(commentId) == false)
            {
                return BadRequest();
            }

            await commentService.DeleteComment(commentId);
            return RedirectToAction("AllAdmin", new { destinationId = destinationId });
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
