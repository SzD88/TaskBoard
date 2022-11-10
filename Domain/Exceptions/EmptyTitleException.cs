namespace Domain.ValueObjects
{
    public class EmptyTitleException : CustomException
    {
        public EmptyTitleException()
            : base("Title cannot be empty")
        {

        }
    }
}
