namespace Domain.ValueObjects
{

    public record Completed
    {
        public bool Value { get; private set; }

        public Completed(bool value)
        { 
            Value = value;
        }

        public static implicit operator bool(Completed completed)
            => completed.Value;

        public static implicit operator Completed(bool completed)
            => new(completed); 
    } 
}
