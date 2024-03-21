using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace MiniORM
{
	// TODO: Create your DbContext class here.

    public abstract class DbContext
    {
        private readonly DatabaseConnection _connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;


        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(DateTime),
            typeof(decimal),
            typeof(bool)

        };
    }
}