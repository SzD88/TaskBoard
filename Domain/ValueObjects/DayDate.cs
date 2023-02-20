namespace Domain.ValueObjects
{

    public record DayDate
    {
        public DateTime Value { get; private set; }

        public DayDate(DateTime value)
        {
            //if (value is not null) //# refactor
            //{
            //    throw new EmptyProjectNumberException();
            //}

            Value = value;
        }

        public static implicit operator DateTime(DayDate name)
            => name.Value;

        public static implicit operator DayDate(DateTime name)
            => new(name); 
    }
}
