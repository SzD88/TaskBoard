namespace Domain.ValueObjects
{
    public record Description
    {
        public string Value { get; private set; }

        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyDescriptionException();
            }

            Value = value;
        }

        public static implicit operator string(Description name)
            => name.Value;

        public static implicit operator Description(string name)
            => new(name); 
    }
}
