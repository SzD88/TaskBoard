namespace Domain.ValueObjects
{
    public class EmptyProjectNumberException : Exception
    {
        public EmptyProjectNumberException()
            : base("Project Number cannot be empty")
        {

        }
    }
}
