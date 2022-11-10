namespace Domain.ValueObjects
{
    public class EmptyDContentException : CustomException
    {
        public EmptyDContentException()
            : base("Content cannot be empty")
        {

        }
    }
}
