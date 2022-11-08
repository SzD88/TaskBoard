namespace Domain.ValueObjects
{
    public class EmptyDescriptionException : Exception
    {
        public EmptyDescriptionException()
            : base("Description cannot be empty")
        {

        }
    }
}
