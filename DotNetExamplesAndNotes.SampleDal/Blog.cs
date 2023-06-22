using System.ComponentModel.DataAnnotations;

namespace DotNetExamplesAndNotes.SampleDal;

public class Blog
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}
