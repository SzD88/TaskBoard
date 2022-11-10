namespace Domain.ValueObjects
{
    public class IdIsNullException : CustomException
    {
        public IdIsNullException()
            : base("Id cannot be null")
        {

        }
    }

}