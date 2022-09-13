﻿namespace Domain.ValueObjects
{

    public record ProjectNumber
    {
        public string Value { get; private set; }

        public ProjectNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyProjectNumberException();
            }

            Value = value;
        }

        public static implicit operator string(ProjectNumber name)
            => name.Value;

        public static implicit operator ProjectNumber(string name)
            => new(name);
        public void Edit(string projNumber)
        {
            if (string.IsNullOrWhiteSpace(projNumber))
            {
                throw new EmptyProjectNumberException();
            }
            Value = projNumber;
        }
        public string GetValue()
        {
            return Value;
        }
    }
    public class EmptyProjectNumberException : Exception
    {
        public EmptyProjectNumberException()
            : base("Project Number cannot be empty")
        {

        }
    }
}