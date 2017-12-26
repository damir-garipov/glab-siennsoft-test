﻿namespace Glabsiennsoft.Contracts.Common
{
    public class SqlParameter
    {
        public SqlParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public object Value { get; }
    }
}