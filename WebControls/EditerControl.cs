using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:EditerControl runat=server></{0}:EditerControl>")]
    public class EditerControl : WebControl
    {
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (Data != null)
            {
                output.Write("<h3>" + Data.GetType().Name + "</h3>");
                output.Write(BuildObjectGrid(Data));
            }
        }

        private int cntr;


        public Object Data { get; set; }
        //{
        //    get
        //    {
        //        return ViewState["View"];
        //    }
        //    set
        //    {
        //        ViewState["View"] = value;
        //    }
        //}

        public Object Values
        {
            get
            {
                Object o = Data;

                foreach (PropertyInfo prop in o.GetType().GetProperties())
                {
                    Type type = prop.PropertyType;
                    var underlyingType = Nullable.GetUnderlyingType(type);
                    var returnType = underlyingType ?? type;
                    object val = null;
                    string sval = Page.Request[localName(prop.Name)];
                    if (!string.IsNullOrEmpty(sval))
                    {
                        if (returnType.BaseType == typeof(Enum))
                        {
                            Array items = Enum.GetValues(returnType);
                            val = Enum.Parse(returnType, sval);
                        }
                        else if (returnType == typeof(DateTime))
                        {
                            val = ToUTC(sval);
                        }
                        else
                        {
                            val = Convert.ChangeType(sval, returnType);
                        }
                        if (val != null)
                        {
                            prop.SetValue(o, val, null);
                        }
                    }
                }
                    
                return o;
            }
        }

        protected string BuildObjectGrid(Object o)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='childTable'>");

            if (o.GetType().BaseType == typeof(Array))
            {
                sb.Append("<tr>");
                sb.Append("<td>");

                Array array = (Array)o;
                foreach (var item in array)
                {
                    sb.Append(BuildObjectGrid(item));
                }

                sb.Append("</td>");
                sb.Append("</tr>");

            }
            else
            {
                // print all properties of object
                foreach (PropertyInfo prop in o.GetType().GetProperties())
                {
                    // 11-04-2012 ADJ hide all fields ending with specified to save space
                    if (!prop.ToString().EndsWith("Specified")) // header check
                    {
                        object value = prop.GetValue(o, null);
                        if (value != null)  // empty prop value => don't show
                        {
                            // only print properties with values
                            sb.Append(BuildMyObjectRow(o, prop));
                        }
                        else
                        {
                            sb.Append(BuildMyObjectRow(o, prop));
                        }
                    }
                }
            }
            
            sb.Append("</table>");

            return sb.ToString();
        }

        protected string BuildMyObjectRow(object o, PropertyInfo prop)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");

            object value = prop.GetValue(o, null);
            if ((prop.PropertyType.BaseType == typeof(Array)) && (value != null))
            {
                int id = cntr++;
                sb.Append("<td class='simhead' onclick=\"expand(this, 'cell_" + id + "');\">" + prop.Name + " [+]</td>");

                sb.Append("<td id='cell_" + id + "'  style='display: none;' >");
                sb.Append(BuildObjectGrid(value));
            }
            else if ((prop.PropertyType.BaseType == typeof(Object)) && (prop.PropertyType.Namespace.StartsWith("Denion")) && (value != null))
            {
                int id = cntr++;
                sb.Append("<td class='simhead' onclick=\"expand(this, 'cell_" + id + "');\">" + prop.Name + " [+]</td>");

                sb.Append("<td id='cell_" + id + "'  style='display: none;' >");
                sb.Append(BuildObjectGrid(value));
            }
            else
            {
                string name = prop.Name;
                sb.Append("<td class='simhead'>" + name + "</td>");

                sb.Append("<td class='simbody'>");
                if (value == null) value = "";
                sb.Append(ObjectToString(value, name));
                
            }
            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        protected string BuildMyObjectRow(string key, object value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");

            string name = key;

            sb.Append("<td class='simhead'>" + name + "</td>");

            sb.Append("<td class='simbody'>");
            if (value == null) value = "";
            
            sb.Append(ObjectToString(value, name));

            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        protected string ObjectToString(object o, string name)
        {
            string localValue = null;
            Type type = o.GetType().BaseType;
            string localname = localName(name);
            string localid = localID(name);

            if (o.GetType() == typeof(DateTime))
            {
                localValue = $"<input id='{localid}' name='{localname}' type='text' value='{ DateTimeToLocalTimeZone(o)}'/>";
            }
            else if (type == typeof(Enum))
            {
                localValue = $"<select name='{localname}' id='{localid}'>";
                Array items = Enum.GetValues(o.GetType());
                foreach (object item in items)
                {
                    localValue += "<option value='" + item + "'>" + item + "</option>";
                }

                localValue += "</select>";
            }
            else if (o.ToString().Contains(Environment.NewLine))
            {
                localValue = $"<textarea id='{localid}' name='{localname}'>{o.ToString()}</textarea>";
            }
            else
            {
                localValue = $"<input id='{localid}' name='{localname}' type='text' value='{o.ToString()}'/>";
            }
            return localValue;
        }
        private string localName(string name)
        {
            return UniqueID + IdSeparator + name;
        }

        private string localID(string Id)
        {
            return ClientID + ClientIDSeparator + Id;
        }

        public static string DateTimeToLocalTimeZone(object obj)
        {
            string rv = null;
            try
            {
                DateTime dat = DateTime.Parse(obj.ToString());
                rv = DateTimeToLocalTimeZone(dat);
            }
            catch (Exception)
            { }
            return rv;
        }

        public static string DateTimeToLocalTimeZone(DateTime dat)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentUTC = localZone.ToLocalTime(dat);

            return currentUTC.ToShortDateString() + " " + currentUTC.ToShortTimeString();
        }

        public static DateTime? ToUTC(object obj)
        {
            DateTime? rv = null;
            try
            {
                DateTime dat = DateTime.Parse(obj.ToString());
                rv = ToUTC(dat);
            }
            catch (Exception)
            { }
            return rv;
        }

        public static DateTime ToUTC(DateTime dat)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;

            return localZone.ToUniversalTime(dat);
        }
    }
}
