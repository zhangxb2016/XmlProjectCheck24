using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JKY.Models24;
using System.Xml;

namespace JKY.XMLProjectCheck
{
    public partial class fmXmlCheckMainPlus : Form
    {
        public fmXmlCheckMainPlus()
        {
            InitializeComponent();

            SetStyle();
        }

        private void SetStyle()
        {
            // 综合解决方案示例
            richTextBox1.Font = new Font("Consolas", 11);
        }

        private void btnFileImport_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "成果文件(*.xml)|*.xml";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;
                    XmlDocument xml = new XmlDocument();
                    string projectName = "";
                    string UploadMsg = "";
                    StringBuilder cg = new StringBuilder();
                    using (var stream = new StreamReader(file, System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        while (!stream.EndOfStream)
                        {
                            cg.Append(stream.ReadLine());
                        }
                    }
                    xml.LoadXml(cg.ToString());
                    List<string> list = new List<string>();
                    var rpt = new CheckReport();
                    var res = new CheckMain24().SaveXmlToDB(xml, ""
                                       , "", "", "", "", "", "", "", "", out projectName, out UploadMsg, out list, out rpt);
                    richTextBox1.Text = String.Empty;
                    pView.Hide();
                    richTextBox1.Text += fileDialog.SafeFileName + ":" + "\r\n";

                    if (res.IsSuccess == 0)
                    {
                        richTextBox1.Text += "解析成功";
                    }
                    else
                    {
                        if (list.Count != 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(rpt.Header);
                            var num = 1;
                            foreach (var item in rpt.ModelItems)
                            {
                                sb.AppendLine(num + ". " + item.Caption);
                                var detailNum = 1;
                                foreach (var detail in item.FieldTip)
                                {
                                    if (!detail.Equals("请联系计价软件公司！"))
                                        sb.AppendLine($"    ({detailNum}) " + detail);
                                    detailNum++;
                                }
                                num++;
                            }
                            sb.AppendLine(rpt.Footer);
                            richTextBox1.Text = sb.ToString();
                            //list = list.Distinct().ToList();
                            //for (int i = 0; i < list.Count; i++)
                            //{
                            //    //richTextBox1.Text += (i + 1).ToString() + "." + list[i].ToString() + "\r\n";
                            //    richTextBox1.Text += list[i].ToString() + "\r\n";
                            //}
                        }
                        else
                        {
                            richTextBox1.Text += "解析成功";
                        }
                    }

                    if (btnFileImport.Text == "文件导入")
                    {
                        btnFileImport.Text = "重新导入";
                        Button btn = (Button)sender;
                        int x = btn.Location.X;
                        int y = btn.Location.Y;

                        this.btnFileImport.Location = new System.Drawing.Point(x, y + 32);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("xml文件格式异常，请排查并修改后，重新导入！"); return;
            }
        }
    }
}
