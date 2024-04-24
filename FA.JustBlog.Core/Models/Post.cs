using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string? Title { get; set; }
        [StringLength(255)]
        public string? ShortDescription { get; set; }
        [StringLength(255)]
        public string? PostContent { get; set; }
        [StringLength(255)]
        public string? UrlSlug { get; set; } 
        public bool? Published { get; set; } 
        public DateTime PostedOn { get; set; } 
        public DateTime? Modified { get; set; }
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }

    }
}
