namespace Domain.ValueObjects
{
    public record Id
    {
        public Guid Value { get; private set; }

        public Id(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new IdIsNullException();
            }
            Value = value;
        }

        public static implicit operator Guid(Id id)
        {
            return id.Value;
        }

        public static implicit operator Id(Guid id)
              => new Id(id);
        public void Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new IdIsNullException();
            }
            Value = id;
        }
        public Guid GetValue()
        {
            return Value;
        }
    }

    public class IdIsNullException : Exception
    { 
        public IdIsNullException() 
            : base ("Id cannot be null")
        {

        }
    }
   
} 