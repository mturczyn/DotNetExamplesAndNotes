using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetExamplesAndNotes.WebApiDAL;

public class Post
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(4000)]
    public string Content { get; set; }

    public Guid BlogId { get; set; }

    [ForeignKey(nameof(BlogId))]
    public Blog Blog { get; set; }
}
