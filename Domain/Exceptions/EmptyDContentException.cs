namespace Domain.ValueObjects
{
    public class EmptyDContentException : Exception
    {
        public EmptyDContentException()
            : base("Content cannot be empty")
        {

        }
    }
}
