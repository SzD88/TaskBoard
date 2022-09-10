namespace Domain.ValueObjects
{

    public record Title
    {
        public string Value { get; private set; }

        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyTitleException();
            }

            Value = value;
        }

        public static implicit operator string(Title name)
            => name.Value;

        public static implicit operator Title(string name)
            => new(name);
        public void Edit(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new EmptyTitleException();
            }
            Value = title;
        }
    }
    public class EmptyTitleException : Exception
    {
        public EmptyTitleException()
            : base("Title cannot be empty")
        {

        }
    }
}
