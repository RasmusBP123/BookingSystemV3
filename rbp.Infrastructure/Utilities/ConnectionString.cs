using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Infrastructure.Utilities
{
    public class ConnectionString
    {
        public string Value { get; }
        public ConnectionString(string value)
        {
            Value = value;
        }

    }
}
