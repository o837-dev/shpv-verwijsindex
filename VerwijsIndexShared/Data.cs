using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Denion.WebService.VerwijsIndex
{
    internal class Data
    {
        public static T DataRowToObject<T>(DataRow r)
        {
            T t = (T)Activator.CreateInstance(typeof(T));
            foreach (DataColumn dc in r.Table.Columns)
            {
                if (r[dc] != DBNull.Value)
                {
                    try
                    {
                        PropertyInfo prop = t.GetType().GetProperty(dc.ColumnName);
                        if (prop != null)
                            prop.SetValue(t, r[dc], null);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Failed to convert: " + dc.ColumnName + "[" + dc.DataType.ToString() + "]");
                    }
                }
            }
            return t;
        }

    }
}
