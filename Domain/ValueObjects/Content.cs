namespace Domain.ValueObjects
{

    public record Content
        {
            public string Value { get; private set; } 
            public Content(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyDContentException();
                } 
                Value = value;
            }

            public static implicit operator string(Content content)
                => content.Value;

            public static implicit operator Content(string content)
                => new(content);
        public void Edit(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new EmptyDContentException();
            }
            Value = content;
        }
    }
    public class EmptyDContentException : Exception
    {
        public EmptyDContentException()
            : base("Content cannot be empty")
        {

        }
    }
}
