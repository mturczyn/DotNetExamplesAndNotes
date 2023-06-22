using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetExamplesAndNotes.SampleDal;

public class Post
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    [ForeignKey(nameof(Blog))]
    public Guid BlogId { get; set; }

    public Blog Blog { get; set; }
}
