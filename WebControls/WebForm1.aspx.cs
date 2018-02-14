using Denion.WebService.VerwijsIndex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EditerControl1.Data = new MyClass();
        }

        public class MyClass
        {
            public Nullable<int> MyProperty { get; set; }
            public MyEnum myEnum1 { get; set; }
            public Nullable<MyEnum> myEnum2 { get; set; }
            public string stringeling { get; set; }

            public MyClass()
            {
                MyProperty = 1;

                myEnum1 = MyEnum.vier;
                myEnum2 = MyEnum.twee;
                stringeling = "drie!";
            }
        }
        public  enum MyEnum
        {
            een = 1, 
            twee = 2,
            vier = 4
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Object o = EditerControl1.Values;
            Debug.WriteLine(o);
        }
    }
}