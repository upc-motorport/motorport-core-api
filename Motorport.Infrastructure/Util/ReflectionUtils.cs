using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Motorport.Infrastructure.Util
{
    public static class ReflectionUtils
    {
        public static void CopyPropertiesTo(this object fromObject, object toObject, bool includeId = true, string idPropertyName = "Id")
        {
            PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
            foreach (PropertyInfo propTo in toObjectProperties)
            {
                if (!includeId && propTo.Name == idPropertyName)
                {
                    continue;
                }
                PropertyInfo propFrom = fromObject.GetType().GetProperty(propTo.Name);
                if (propFrom != null && propFrom.CanWrite)
                    propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
            }
        }
    }
}
