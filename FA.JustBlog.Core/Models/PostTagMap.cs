using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class PostTagMap
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }

    }
}
