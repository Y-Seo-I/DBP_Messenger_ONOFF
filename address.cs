using System;
using System.Security.Permissions;
using System.Windows.Forms;

namespace on_off_proj
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class address : Form
    {
        public string gstrZipCode = "";
        public string gstrAddress1 = "";

        public address()
        {
            InitializeComponent();

            wb.Navigate("https://eloquent-newton-909fd7.netlify.app/");
            wb.ObjectForScripting = this; // 제일 중요
        }

        public void CallForm(object sZipCode, object sAddress1)
        {
            try
            {
                gstrZipCode = (string)sZipCode;
                gstrAddress1 = (string)sAddress1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
