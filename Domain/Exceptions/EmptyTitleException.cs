namespace Domain.ValueObjects
{
    public class EmptyTitleException : Exception
    {
        public EmptyTitleException()
            : base("Title cannot be empty")
        {

        }
    }
}
