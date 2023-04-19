using System.ComponentModel.DataAnnotations;

namespace DotNetExamplesAndNotes.WebApiDAL;

public class Blog
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<Post> Posts { get; set; }
}
