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
        public void Edit(bool state)
        {
            if (state != true && state != false)
            {
                throw new Exception("Nie byl anu try ani false"); // #refactor
            }
            Value = state;
        }
        public bool GetValue()
        {
            return Value;
        }
    }
    public class EmptyCompletedNameException : Exception
    {
        public EmptyCompletedNameException()
            : base(" ")
        {

        }
    }
}
