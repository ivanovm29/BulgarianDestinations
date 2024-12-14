using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Comment;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BulgarianDestinations.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<CommentViewModel>> All(int destinationId)
        {
            return await repository.All<Comment>()
                .OrderByDescending(d => d.Id)
                .Where(d => d.DestinationId == destinationId)
                .Select(d => new CommentViewModel()
                {
                    Id = d.Id,
                    FirstName = d.Person.User.FirstName,
                    LastName = d.Person.User.LastName,
                    Text = d.Text,
                    DestinationId = d.Destination.Id,
                    PersonId = d.Person.Id,
                })
                .ToListAsync();
        }

        public async Task<CommentViewModel> Add(int destinationId, int personId)
        {
            int id = repository.AllReadOnly<CommentPerson>().Count() + 1;
            var comment = new CommentViewModel()
            {
                Id = id,
                DestinationId = destinationId,
                PersonId = personId
                
            };
            return comment;
        }
        public async Task Add(CommentViewModel model, int destinationId, int personId)
        {
            
            var comment = new Comment()
            {
                Text = model.Text,
                PersonId = personId,

                DestinationId = destinationId
            };

            await repository.AddAsync(comment);

            await repository.SaveChangesAsync();

        }
        public async Task<int> GetUserId(string userId)
        {
            int id = 0;
            var person = repository.AllReadOnly<Person>()
                .Where(p => p.UserId == userId)
                .FirstOrDefault();
            if (person != null)
            {
                return person.Id;
            }
            return id;
        }

        public async Task DeleteComment(int commentId)
        {

                await repository.DeleteAsync<Comment>(commentId);

                await repository.SaveChangesAsync();

            
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<Comment>().Where(a => a.Id == id).AnyAsync();
        }
    }
}
