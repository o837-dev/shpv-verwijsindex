using System;

namespace Denion.WebService.Beheer.Controls
{
    public partial class TimePicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DateTime dt;

        /// <summary>
        /// Valid time required
        /// </summary>
        public bool Required = true;

        /// <summary>
        /// true if invalid datetime filled
        /// </summary>
        public bool ValidationError
        {
            get
            {
                Validate();
                return lblDate.Visible;
            }
        }

        /// <summary>
        /// true if datefield is empty
        /// </summary>
        public bool IsNullOrEmpty
        {
            get
            {
                return string.IsNullOrEmpty(txtDate.Text);
            }
        }

        public DateTime Text
        {
            set
            {
                Value = DateTime.Parse(value.ToString());
            }
        }

        /// <summary>
        /// Get date & time
        /// </summary>
        /// <returns></returns>
        public DateTime Value
        {
            set
            {
                if (value > DateTime.MinValue)
                {
                    dt = value;
                    txtDate.Text = value.ToString("dd-MM-yyyy");
                    tbHour.Text = value.ToString("HH");
                    tbMin.Text = value.ToString("mm");
                }
            }
            get
            {
                Validate();
                return dt;
            }
        }

        public bool Validate()
        {
            dt = DateTime.MinValue;
            string theTime = string.Format("{0} {1}:{2}", txtDate.Text, (string.IsNullOrEmpty(tbHour.Text) ? "0" : tbHour.Text), (string.IsNullOrEmpty(tbMin.Text) ? "0" : tbMin.Text));
            return (Required && string.IsNullOrEmpty(txtDate.Text)) || !DateTime.TryParse(theTime, out dt);
        }
    }
}