using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi
{
    public class Envelope<T>
    {
        public T Result { get; }
        public string Error { get; }
        public DateTime TimeGenerated { get;}

        protected internal Envelope(T result, string error)
        {
            Result = result;
            Error = error;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public class Envelope : Envelope<string>
    {
        protected internal Envelope(string error) : base(null, error)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}
