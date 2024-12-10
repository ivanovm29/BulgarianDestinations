using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulgarianDestinations.Infrastructure.Data.Constants.DataConstants;

namespace BulgarianDestinations.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentMaxLength)]
        public string Text { get; set; } = string.Empty;

        [Required]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;

        [Required]
        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;

        public ICollection<CommentPerson> CommentsPersons { get; set; } = new List<CommentPerson>();
    }
}
