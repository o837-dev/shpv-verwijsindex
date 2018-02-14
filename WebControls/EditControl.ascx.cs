using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    public partial class EditControl : System.Web.UI.UserControl
    {

        /// <summary>
        /// Additional values to be shown before obj, 
        ///  NOTE add values before calling obj property
        /// </summary>
        public Dictionary<string, object> PrefixValues { get; set; }

        /// <summary>
        /// Additional values to be shown after obj, 
        ///  NOTE add values before calling obj property
        /// </summary>
        public Dictionary<string, object> SuffixValues { get; set; }


        private int cntr;

        public bool HideXml { get; set; }

        public bool Expanded { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            PrefixValues = new Dictionary<string, object>();
            SuffixValues = new Dictionary<string, object>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public Object obj
        {
            get
            {
                return Session["View"];
            }
            set
            {
                Session["View"] = value;
                BuildPage(value);
            }
        }

        protected void BuildPage(Object o)
        {
            if (o != null)
            { 
                placeholder.InnerHtml = BuildObjectGrid(o);
            }
            else
            {
                placeholder.InnerHtml = "&nbsp;";
            }
        }

        protected string BuildObjectGrid(Object o)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='childTable'>");

            // add aditional values only on main object
            if (o == obj)
            {
                // show aditional values in front of the main object
                foreach (var pair in PrefixValues)
                {
                    sb.Append(BuildMyObjectRow(pair.Key, pair.Value));
                }
            }

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
                        }
                    }
                }
            }

            // add aditional values only on main object
            if (o == obj)
            {
                // show aditional values in after the main object
                foreach (var pair in SuffixValues)
                {
                    sb.Append(BuildMyObjectRow(pair.Key, pair.Value));
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
            else if ((prop.PropertyType.BaseType == typeof(Object)) && (prop.PropertyType.Namespace.StartsWith("RDW")) && (value != null))
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
                sb.Append(ObjectToString(value));
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
            sb.Append(ObjectToString(value));

            sb.Append("</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        protected string ObjectToString(object o)
        {
            string localValue = null;
            if (o.GetType() == typeof(DateTime))
            {
                localValue = DateTimeToLocalTimeZone(o);
            }
            else
            {
                localValue = o.ToString();
            }
            return localValue;
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
    }
}