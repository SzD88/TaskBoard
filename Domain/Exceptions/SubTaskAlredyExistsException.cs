namespace Domain.ValueObjects
{
    public class SubTaskAlredyExistsException : CustomException
    {
        public object Id { get; }

        public SubTaskAlredyExistsException(object id) 
            : base($"SubTask with id: {id} alredy exists")
        {
            Id = id;    
        }
    }
}
