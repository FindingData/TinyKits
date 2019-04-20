using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public abstract class DbBindProvider : IDbBind
    {
        public abstract List<KeyValuePair<string, CSharpDataType>> MappingTypes { get; }

        public virtual string GetPropertyTypeName(string dbTypeName)
        {
            dbTypeName = dbTypeName.ToLower();
            var propertyTypes = MappingTypes.Where(it => it.Key.Equals(dbTypeName, StringComparison.CurrentCultureIgnoreCase));
            if (dbTypeName == "int32")
            {
                return "int";
            }
            else if (dbTypeName == "int64")
            {
                return "long";
            }
            else if (dbTypeName == "int16")
            {
                return "short";
            }
            else if (propertyTypes == null)
            {
                return "other";
            }
            else if (dbTypeName.IsContainsIn("xml", "string", "String"))
            {
                return "string";
            }
            else if (dbTypeName.IsContainsIn("boolean", "bool"))
            {
                return "bool";
            }
            else if (propertyTypes == null || propertyTypes.Count() == 0)
            {
                throw new NotSupportedException($"{ dbTypeName } Type NotSupported, DbBindProvider.GetPropertyTypeName error");
                //Check.ThrowNotSupportedException(string.Format(" \"{0}\" Type NotSupported, DbBindProvider.GetPropertyTypeName error.", dbTypeName));                
            }
            else if (propertyTypes.First().Value == CSharpDataType.byteArray)
            {
                return "byte[]";
            }
            else
            {
                return propertyTypes.First().Value.ToString();
            }
        }
    }
}
