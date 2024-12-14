using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> All(int destinationId);

        Task Add(CommentViewModel model, int destinationId, int personId);
        Task<CommentViewModel> Add(int destinationId, int personId);

        Task DeleteComment(int commentId);
        Task<int> GetUserId(string userId);

        Task<bool> Exists(int id);
    }
}
