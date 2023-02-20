namespace Domain.ValueObjects
{
    public class SubTaskDoesNotExists : CustomException
    {
        public object Id { get; }

        public SubTaskDoesNotExists(object id) 
            : base($"SubTask with id: {id} does not exists")
        {
            Id = id;    
        }
    }
}
