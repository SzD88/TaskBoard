namespace Domain.Entities
{
    public class AuditibleEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
