using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace wsdlGenerate
{
    public partial class Form1 : Form
    {
        public TreeNode currentNode { get; set; }
        public String serverName { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.treeView.BackColor = Color.LemonChiffon;
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                contextMenuStrip.Items[2].Visible = false;
                contextMenuStrip.Items[3].Visible = false;
                contextMenuStrip.Items[4].Visible = false;
                contextMenuStrip.Items[5].Visible = false;
                TreeView treeView = sender as TreeView;
                TreeNode treeNode = treeView.GetNodeAt(e.X, e.Y);
                if (null != treeNode)
                {
                    currentNode = treeNode;
                    contextMenuStrip.Items[0].Enabled = true;
                    if (treeNode.Text.EndsWith("Request") || treeNode.Text.EndsWith("Response"))
                    {
                        contextMenuStrip.Items[1].Enabled = false;
                    }
                    else
                    {
                        contextMenuStrip.Items[1].Enabled = true;
                    }
                }
                else
                {
                    contextMenuStrip.Items[0].Enabled = false;
                    contextMenuStrip.Items[1].Enabled = false;
                }

                if (treeNode.Text.Equals(serverName + "Request"))
                {
                    contextMenuStrip.Items[2].Visible = true;
                    contextMenuStrip.Items[3].Visible = false;
                }
                if (treeNode.Text.Equals(serverName + "Response"))
                {
                    contextMenuStrip.Items[2].Visible = false;
                    contextMenuStrip.Items[3].Visible = true;
                    contextMenuStrip.Items[4].Visible = true;
                    contextMenuStrip.Items[5].Visible = true;
                }
                this.contextMenuStrip.Show(MousePosition);
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {

            ToolStripItem item = sender as ToolStripItem;
            if (item.Name.Equals("insert"))
            {
                DetailWindow detailWindow = new DetailWindow();
                detailWindow.mainForm = this;
                detailWindow.ShowDialog();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            currentNode.Parent.Nodes.Remove(currentNode);
            currentNode = null;
        }



        private void generateWsdl(String path)
        {
            xsdXml = new XmlDocument();
            xsdXml.AppendChild(xsdXml.CreateXmlDeclaration("1.0", "utf-8", ""));
            schema = xsdXml.CreateElement("schema");
            schema.SetAttribute("attributeFormDefault", "unqualified");
            schema.SetAttribute("elementFormDefault", "qualified");
            schema.SetAttribute("targetNamespace", "http://mss.cmcc.com/" + serverName);
            schema.SetAttribute("xmlns:po", "http://mss.cmcc.com/" + serverName);
            schema.SetAttribute("xmlns:msg", "http://mss.cmcc.com/MsgHeader");
            schema.SetAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
            XmlElement import = xsdXml.CreateElement("import");
            import.SetAttribute("namespace", "http://mss.cmcc.com/MsgHeader");
            import.SetAttribute("schemaLocation", "MsgHeader.xsd");
            schema.AppendChild(import);

            generate2(this.treeView.Nodes, schema);

            xsdXml.AppendChild(schema);
            xsdXml.Save(@path);
        }










        private XmlDocument xsdXml;
        XmlElement schema;
        private Char[] splitChar = new Char[] { '|' };
        //public void generate(TreeNodeCollection nodes, XmlElement element)
        //{
        //    foreach (TreeNode node in nodes)
        //    {
        //        XmlElement subElement = xsdXml.CreateElement("element");
        //        String[] noteTexts = node.Text.Split(splitChar);
        //        if (node.GetNodeCount(false) > 0)
        //        {
        //            XmlElement sequenceItem = xsdXml.CreateElement("sequence");
        //            XmlElement complexTypeItem = xsdXml.CreateElement("complexType");

        //            if (node.Text.Equals(serverName + "Request") || node.Text.Equals(serverName + "Response"))
        //            {
        //                subElement.SetAttribute("name", noteTexts[0]);
        //                subElement.SetAttribute("type", "po:" + noteTexts[0]);
        //                schema.AppendChild(subElement);

        //                if (node.Text.Equals(serverName + "Request"))
        //                {
        //                    XmlElement msg = xsdXml.CreateElement("element");
        //                    msg.SetAttribute("name", "MsgHeader");
        //                    msg.SetAttribute("type", "msg:MsgHeader");
        //                    sequenceItem.AppendChild(msg);
        //                }

        //                complexTypeItem.SetAttribute("name", noteTexts[0]);
        //                complexTypeItem.AppendChild(sequenceItem);
        //                schema.AppendChild(complexTypeItem);
        //                generate(node.Nodes, sequenceItem);
        //            }
        //            else
        //            {
        //                complexTypeItem.SetAttribute("name", noteTexts[0] + "_ITEM");
        //                complexTypeItem.AppendChild(sequenceItem);
        //                schema.AppendChild(complexTypeItem);
        //                subElement.SetAttribute("name", noteTexts[0]);
        //                subElement.SetAttribute("type", "po:" + noteTexts[0] + "_LIST");


        //                XmlElement sequenceList = xsdXml.CreateElement("sequence");
        //                XmlElement item = xsdXml.CreateElement("element");
        //                item.SetAttribute("name", noteTexts[0] + "_ITEM");
        //                item.SetAttribute("type", "po:" + noteTexts[0] + "_ITEM");
        //                item.SetAttribute("minOccurs", "0");
        //                item.SetAttribute("maxOccurs", "unbounded");

        //                sequenceList.AppendChild(item);

        //                XmlElement complexTypeList = xsdXml.CreateElement("complexType");
        //                complexTypeList.SetAttribute("name", noteTexts[0] + "_LIST");

        //                complexTypeList.AppendChild(sequenceList);
        //                schema.AppendChild(complexTypeList);
        //                generate(node.Nodes, sequenceItem);
        //            }
        //        }
        //        else
        //        {

        //            subElement.SetAttribute("name", noteTexts[0]);
        //            subElement.SetAttribute("type", noteTexts[1]);
        //            subElement.SetAttribute("nillable", "true");
        //        }
        //        element.AppendChild(subElement);
        //    }

        //}
        public void generate2(TreeNodeCollection nodes, XmlElement element)
        {
            foreach (TreeNode node in nodes)
            {
                String[] noteTexts = node.Text.Split(splitChar);
                if (node.GetNodeCount(false) > 0)
                {
                    if (Regex.IsMatch(noteTexts[0], @"^" + serverName + "(Request|Response)$")) requestOrResponse_handle(node, noteTexts, element);
                    else if (Regex.IsMatch(noteTexts[0], @"^(" + serverName + "|)(Error|Response|Input|Output)Collection$")) standardCollection_handle(node, noteTexts, element);
                    else collection_handle(node, noteTexts, element);
                }
                else
                {
                    XmlElement subElement = xsdXml.CreateElement("element");
                    subElement.SetAttribute("name", noteTexts[0]);
                    subElement.SetAttribute("type", noteTexts[1]);
                    subElement.SetAttribute("nillable", "true");
                    if ("base64Binary".Equals(noteTexts[1]))
                    {
                        subElement.SetAttribute("minOccurs", "0");
                        subElement.SetAttribute("expectedContentTypes", "http://www.w3.org/2005/05/xmlmime", "application/octet-stream");
                    }
                    element.AppendChild(subElement);
                }
            }
        }
        public void requestOrResponse_handle(TreeNode node, String[] noteTexts, XmlElement element)
        {


            ///构建子集Item
            XmlElement subSequence = xsdXml.CreateElement("sequence");
            if (node.Text.EndsWith("Request"))
            {
                XmlElement msg = xsdXml.CreateElement("element");
                msg.SetAttribute("name", "MsgHeader");
                msg.SetAttribute("type", "msg:MsgHeader");
                subSequence.AppendChild(msg);
            }
            XmlElement complexType = xsdXml.CreateElement("complexType");
            complexType.SetAttribute("name", noteTexts[0]);
            complexType.AppendChild(subSequence);
            schema.AppendChild(complexType);


            //创建元素
            XmlElement subElement = xsdXml.CreateElement("element");
            subElement.SetAttribute("name", noteTexts[0]);
            subElement.SetAttribute("type", "po:" + noteTexts[0]);
            element.AppendChild(subElement);

            generate2(node.Nodes, subSequence);
        }
        public void standardCollection_handle(TreeNode node, String[] noteTexts, XmlElement element)
        {
            //构建子集Item
            String itemName = noteTexts[0].Replace("Collection", "Item");
            XmlElement subSequence = xsdXml.CreateElement("sequence");
            XmlElement subComplexType = xsdXml.CreateElement("complexType");
            subComplexType.SetAttribute("name", itemName);
            subComplexType.AppendChild(subSequence);
            schema.AppendChild(subComplexType);


            //构建子集Collection
            XmlElement item = xsdXml.CreateElement("element");
            item.SetAttribute("name", itemName);
            item.SetAttribute("type", "po:" + itemName);
            item.SetAttribute("minOccurs", "0");
            item.SetAttribute("maxOccurs", "unbounded");
            XmlElement sequence = xsdXml.CreateElement("sequence");
            sequence.AppendChild(item);
            XmlElement complexType = xsdXml.CreateElement("complexType");
            complexType.SetAttribute("name", noteTexts[0]);
            complexType.AppendChild(sequence);
            schema.AppendChild(complexType);


            //创建元素
            XmlElement subElement = xsdXml.CreateElement("element");
            subElement.SetAttribute("name", noteTexts[0]);
            subElement.SetAttribute("type", "po:" + noteTexts[0]);
            element.AppendChild(subElement);

            generate2(node.Nodes, subSequence);
        }

        public void collection_handle(TreeNode node, String[] noteTexts, XmlElement element)
        {
            String itemName = noteTexts[0] + "_ITEM";
            String collectionName = noteTexts[0] + "_LIST";
            //构建子集Item
            XmlElement subSequence = xsdXml.CreateElement("sequence");
            XmlElement subComplexType = xsdXml.CreateElement("complexType");
            subComplexType.SetAttribute("name", itemName);
            subComplexType.AppendChild(subSequence);
            schema.AppendChild(subComplexType);


            //构建子集Collection
            XmlElement item = xsdXml.CreateElement("element");
            item.SetAttribute("name", itemName);
            item.SetAttribute("type", "po:" + itemName);
            item.SetAttribute("minOccurs", "0");
            item.SetAttribute("maxOccurs", "unbounded");
            XmlElement sequence = xsdXml.CreateElement("sequence");
            sequence.AppendChild(item);
            XmlElement complexType = xsdXml.CreateElement("complexType");
            complexType.SetAttribute("name", collectionName);
            complexType.AppendChild(sequence);
            schema.AppendChild(complexType);


            //创建元素
            XmlElement subElement = xsdXml.CreateElement("element");
            subElement.SetAttribute("name", collectionName);
            subElement.SetAttribute("type", "po:" + collectionName);
            element.AppendChild(subElement);

            generate2(node.Nodes, subSequence);
        }


        private void export_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String dirPath = this.folderBrowserDialog.SelectedPath + "\\" + serverName;
                Directory.CreateDirectory(dirPath);

                String businessService = Encoding.UTF8.GetString(Properties.Resources.BusinessService);
                businessService = businessService.Replace("${serverName}", serverName);
                File.WriteAllText(dirPath + "\\" + serverName + ".biz", businessService);


                String proxyService = Encoding.UTF8.GetString(Properties.Resources.ProxyService);
                proxyService = proxyService.Replace("${serverName}", serverName);
                File.WriteAllText(dirPath + "\\" + serverName + ".proxy", proxyService);

                String msgHeader = Properties.Resources.MsgHeader;
                File.WriteAllText(dirPath + "\\" + "MsgHeader.xsd", msgHeader);

                String wsdl = Encoding.UTF8.GetString(Properties.Resources.Server);
                wsdl = wsdl.Replace("${serverName}", serverName);
                File.WriteAllText(dirPath + "\\" + serverName + ".wsdl", wsdl);
                generateWsdl(dirPath + "\\" + serverName + ".xsd");
                MessageBox.Show("ok");
            }

        }

        private void generateRoot_Click(object sender, EventArgs e)
        {
            EnterServerName enterName = new EnterServerName();
            enterName.form1 = this;
            enterName.ShowDialog();
        }
        public void generateRootExcute()
        {
            this.treeView.Nodes.Clear();
            this.treeView.Nodes.Add(serverName + "Request");
            this.treeView.Nodes.Add(serverName + "Response");            
        }

        private void addInputCollection_Click(object sender, EventArgs e)
        {
            TreeNode tn = currentNode.Nodes.Add(serverName + "InputCollection|数据实体");
            tn.BackColor = Color.GreenYellow;
            currentNode.ExpandAll();
        }

        private void addOutputCollection_Click(object sender, EventArgs e)
        {
            
            TreeNode tn = currentNode.Nodes.Add(serverName + "OutputCollection|数据实体");
            tn.BackColor = Color.GreenYellow;
            currentNode.ExpandAll();
        }

        private void addQuiryStandardAttribute_Click(object sender, EventArgs e)
        {
            currentNode.Nodes.Add("ErrorFlag|string");
            currentNode.Nodes.Add("ErrorMessage|string");
            currentNode.Nodes.Add("TOTAL_RECORD|decimal");
            currentNode.Nodes.Add("TOTAL_PAGE|decimal");
            currentNode.Nodes.Add("PAGE_SIZE|decimal");
            currentNode.Nodes.Add("CURRENT_PAGE|decimal");
            currentNode.Nodes.Add("INSTANCE_ID|decimal");
            currentNode.ExpandAll();
        }

        private void addImportStandardAttribute_Click(object sender, EventArgs e)
        {
            currentNode.Nodes.Add("ErrorFlag|string");
            currentNode.Nodes.Add("ErrorMessage|string");
            TreeNode tn = currentNode.Nodes.Add("ErrorCollection|数据实体");
            tn.BackColor = Color.GreenYellow;
            tn.Nodes.Add("ENTITY_NAME|string");
            tn.Nodes.Add("PRI_KEY|string");
            tn.Nodes.Add("ERROR_MESSAGE|string");
            tn.Nodes.Add("RECORD_NUMBER|string");
            tn.Nodes.Add("RETAIN_1|string");
            tn.Nodes.Add("RETAIN_2|string");
            tn.Nodes.Add("RETAIN_3|string");
            tn.Nodes.Add("RETAIN_4|string");
            tn.Nodes.Add("RETAIN_5|string");

            tn = currentNode.Nodes.Add("ResponseCollection|数据实体");
            tn.BackColor = Color.GreenYellow;
            tn.Nodes.Add("REQUEST_ID|string");
            tn.Nodes.Add("PRI_KEY|string");
            tn.Nodes.Add("RECORD_NUMBER|string");
            tn.Nodes.Add("RETAIN_1|string");
            tn.Nodes.Add("RETAIN_2|string");
            tn.Nodes.Add("RETAIN_3|string");
            tn.Nodes.Add("RETAIN_4|string");
            tn.Nodes.Add("RETAIN_5|string");
            currentNode.Nodes.Add("INSTANCE_ID|decimal");
            currentNode.ExpandAll();
        }
    }
}
