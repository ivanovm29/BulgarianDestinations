using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulgarianDestinations.Infrastructure.Data.Constants.DataConstants;

namespace BulgarianDestinations.Core.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Text { get; set; } = string.Empty;
        public int DestinationId {  get; set; }
        public int PersonId { get; set; }

    }
}
