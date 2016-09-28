using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsdlGenerate
{
    public partial class EnterServerName : Form
    {
        public EnterServerName()
        {
            InitializeComponent();
        }

        public Form1 form1{get;set;}
        private void EnterServerName_ok_Click(object sender, EventArgs e)
        {
            if(this.serverName.Text.Equals(""))
            {
                MessageBox.Show("服务名不能为空");
                return;
            }
            form1.serverName = this.serverName.Text;
            form1.generateRootExcute();
            this.Close();
        }
    }
}
