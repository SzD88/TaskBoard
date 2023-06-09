﻿namespace Domain.ValueObjects
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
    }
}
