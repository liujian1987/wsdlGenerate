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
    public partial class DetailWindow : Form
    {
        public Form1 mainForm { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
        }

        private void detial_ok_Click(object sender, EventArgs e)
        {
            handleText();
            this.Close();
        }
        private void handleText()
        {
            String[] lines = this.richTextBox.Text.Split(new Char[]{'\n'});
            foreach (String line in lines)
            {
                if (line.Length > 0)
                {
                    String[] cells = line.Split(new Char[] { '\t' },3);
                    String name = cells[0].ToUpper().Replace(" ", "");
                    TreeNode tn;
                    if (cells.Length > 2)
                    {
                        String type = getType(cells[2]);
                        tn = new TreeNode(name + '|' + type);
                        if ("数据实体".Equals(type))
                        {
                            tn.BackColor = Color.GreenYellow;
                        }
                        mainForm.currentNode.Nodes.Add(tn);
                    }
                    else
                    {
                        tn = mainForm.currentNode.Nodes.Add(name + "|数据实体");
                        tn.BackColor = Color.GreenYellow;
                    }
                    mainForm.currentNode.ExpandAll();
                    //Console.WriteLine(cells.Length+"");        
                }
                
                
            }
        }
        private String getType(String lawType)
        {
            String type = lawType.ToUpper();
            if (type.Contains("VARCHAR"))
            {
                return "string";
            }
            if (type.Contains("NUMBER"))
            {
                return "decimal";
            }
            if (type.Contains("DATE"))
            {
                return "dateTime";
            }
            if (type.Contains("BASE64"))
            {
                return "base64Binary";
            }
            return "数据实体";
        }

        private void detial_cancel_Click(object sender, EventArgs e)
        {
            mainForm.currentNode = null;
            this.Close();
        }
         
    }
}
