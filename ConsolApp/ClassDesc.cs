using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsolApp
{
    class ClassDesc
    {
        public ClassDesc()
        {
            //PaymentStartRequest req = new PaymentStartRequest();
            /*PSRightEnrollResponseData d = new PSRightEnrollResponseData();
            d.VATPSright = 312;
            d.AmountPSright = 13;
            d.AmountPSrightSpecified = true;
            d.VATPSrightSpecified = true;
            d.SellingPointId = "1234";
            string data = d.XmlSerializeToString();
            */

            Bla<PSRightEnrollRequestData>(true);
            Bla<PSRightEnrollResponseData>(true);

            Bla<RevokedByThirdPartyRequestRequestData>(true);
            Bla<RevokedByThirdPartyRequestResponseData>(true);

            Bla<PSRightRevokeRequestData>(true);
            Bla<PSRightRevokeResponseData>(true);

            Bla<ActivateEnrollRequestRequestData>(true);
            Bla<ActivateEnrollRequestResponseData>(true);

        }
        class Field
        {
            public string name { get; set; }
            public string type { get; set; }

            public string accessor { get; set; }

            public override string ToString()
            {
                return $"{accessor} {type} {name}";
            }

            public  string ToXmlString()
            {
                return string.Format("<{0}>{1}</{0}>", name, type.ToLower());
            }
        }



        
        public void Bla<T>(bool propsOnly)
        {
            List<Field> fields = new List<Field>();
            T t = (T)Activator.CreateInstance(typeof(T));
            
            
            foreach (PropertyInfo pi in t.GetType().GetProperties())
            {
                string sname = pi.Name;
                //sname = sname.Substring(1, sname.IndexOf(">") - 1);
                Type ft = pi.PropertyType;
                string fa = "public"; //(pi.IsPublic) ? "public" : ((pi.IsPrivate) ? "private" : "other");
                string tname = ft.Name;
                if (tname == "Nullable`1")
                {
                    if (ft.GenericTypeArguments != null && ft.GenericTypeArguments.Length == 1)
                    {
                        //ft.StructLayoutAttribute
                        tname = ft.GenericTypeArguments[0].Name + "?";
                    }
                }
                fields.Add(new Field
                {
                    name = sname,
                    type = tname,
                    accessor = fa
                });
            }
            if (!propsOnly)
            {
                foreach (FieldInfo fi in t.GetType().GetRuntimeFields())
                {
                    string sname = fi.Name;
                    sname = sname.Substring(1, sname.IndexOf(">") - 1);
                    Type ft = fi.FieldType;
                    string fa = (fi.IsPublic) ? "public" : ((fi.IsPrivate) ? "private" : "other");
                    string tname = ft.Name;
                    if (tname == "Nullable`1")
                    {
                        if (fi.FieldType.GenericTypeArguments != null && fi.FieldType.GenericTypeArguments.Length == 1)
                        {
                            //ft.StructLayoutAttribute
                            tname = fi.FieldType.GenericTypeArguments[0].Name + "?";
                        }
                    }
                    fields.Add(new Field
                    {
                        name = sname,
                        type = tname,
                        accessor = fa
                    });
                }
            }
            Debug.WriteLine($"<{t.GetType().Name}>");
            foreach (Field f in fields)
            {
                Debug.WriteLine("\t" + f.ToXmlString());
            }
            Debug.WriteLine($"</{t.GetType().Name}>");
        }
    }
    public static class ext
    {
        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();
            
            using (TextWriter writer = new Utf8StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

    }
    public class Utf8StringWriter : StringWriter
    {
        public Utf8StringWriter(StringBuilder sb)
            : base(sb)
        {

        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
