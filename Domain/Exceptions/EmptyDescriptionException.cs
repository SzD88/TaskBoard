namespace Domain.ValueObjects
{
    public class EmptyDescriptionException : CustomException
    {
        public EmptyDescriptionException()
            : base("Description cannot be empty")
        {

        }
    }
}
