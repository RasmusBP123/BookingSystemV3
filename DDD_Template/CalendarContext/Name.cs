using CSharpFunctionalExtensions;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.CalendarContext
{
    public class Name : ValueObject
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }

        public static Result<Name> Create(string value)
        {
            if(string.IsNullOrWhiteSpace(value)) return Result.Failure<Name>("Name is empty");
            if(value.Length > 200) return Result.Failure<Name>("Name is too long");

            return Result.Success(new Name(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }
    }
}
