using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    [DefaultProperty("Value")]
    [ToolboxData("<{0}:DateTimePicker runat=server></{0}:DateTimePicker>")]
    public class DateTimePicker : WebControl
    {
        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public DateTime Value
        {
            get
            {
                EnsureChildControls();
                if (string.IsNullOrEmpty(txtDate.Text))
                    return DateTime.MinValue;
                else
                    return DateTime.Parse(txtDate.Text + " " + ((tbHour.Text == "") ? "00" : tbHour.Text) + ":" + ((tbMin.Text == "") ? "00" : tbMin.Text));
            }
            set
            {
                EnsureChildControls();
                txtDate.Text = value.ToString("dd-MM-yyyy");
                tbHour.Text = value.ToString("HH");
                tbMin.Text = value.ToString("mm");
            }
        }

        [Bindable(false)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public DateTime Text
        {
            set
            {
                Value = DateTime.Parse(value.ToString());
            }
        }

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //}

        private TextBox txtDate;// = new TextBox();
        private AjaxControlToolkit.CalendarExtender calDate;// = new AjaxControlToolkit.CalendarExtender();
        private TextBox tbHour;// = new TextBox();
        private TextBox tbMin;// = new TextBox();
        private Label lblDate;// = new Label();

        protected override void CreateChildControls()
        {
            txtDate = new TextBox();
            calDate = new AjaxControlToolkit.CalendarExtender();
            tbHour = new TextBox();
            tbMin = new TextBox();
            lblDate = new Label();

            //<asp:TextBox runat="server" ID="txtDate" Width="90px" autocomplete="off" AutoPostBack="false" /> 
            txtDate.ID = this.ID + "_txtDate";
            txtDate.AutoCompleteType = AutoCompleteType.None;
            txtDate.AutoPostBack = false;
            txtDate.Width = 90;

            //<ajaxtoolkit:calendarextender ID="calDate" runat="server" TargetControlID="txtDate" Format="dd-MM-yyyy" />
            calDate.ID = this.ID + "_calDate";
            calDate.TargetControlID = txtDate.ID;
            calDate.Format = "dd-MM-yyyy";

            //<asp:TextBox ID="tbHour" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
            tbHour.ID = this.ID + "_tbHour";
            tbHour.MaxLength = 2;
            tbHour.Width = 20;

            //<asp:TextBox ID="tbMin" runat="server" MaxLength="2" Width="20px"></asp:TextBox>
            tbMin.ID = this.ID + "_tbMin";
            tbMin.MaxLength = 2;
            tbMin.Width = 20;

            //<asp:Label ID="lblDate" runat="server" class="error" Text="*" Visible="false"/>   
            lblDate.ID = this.ID + "_lblDate";
            lblDate.CssClass = "error";
            lblDate.Text = "*";
            lblDate.Visible = false;

            this.Controls.Add(txtDate);
            this.Controls.Add(calDate);
            this.Controls.Add(tbHour);
            this.Controls.Add(tbMin);
            this.Controls.Add(lblDate);

            base.CreateChildControls();
        }

        //protected override void RenderContents(HtmlTextWriter output)
        //{
        ////    output.Write(Text);
        //}
    }
}
