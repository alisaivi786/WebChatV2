

namespace WebChat.Domain.Abstract;

public class BaseEntity
{
    [ExcludeParameter]
    [Key]
    public long Id { get; set; }
    public Guid? RowId { get; set; } = Guid.NewGuid();
    public DateTime? UtcDateCreated { get; set; } = DateTime.UtcNow;
    public long? CreatedBy { get; set; } = null;
    public DateTime? UtcDateModified { get; set; } = null;
    public long? ModifiedBy { get; set; } = null;
    public bool IsActive { get; set; } = true;
}
