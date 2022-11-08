namespace Domain.ValueObjects
{
    public class IdIsNullException : Exception
    {
        public IdIsNullException()
            : base("Id cannot be null")
        {

        }
    }

}