using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using JKY.Models24;
using JKY.XMLProjectCheck.Util;

namespace JKY.XMLProjectCheck
{
    public partial class fmXmlCheckMain : Form
    {
        public fmXmlCheckMain()
        {
            InitializeComponent();


            SetStyle();
        }

        private void SetStyle()
        {
            // 综合解决方案示例
            richTextBox1.Font = new Font("Consolas", 11);
        }
        private void yinei_Click(object sender, EventArgs e)
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
                    gBShow.Hide();
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

                    if (yinei.Text == "文件导入")
                    {
                        yinei.Text = "重新导入";
                        Button btn = (Button)sender;
                        int x = btn.Location.X;
                        int y = btn.Location.Y;

                        this.yinei.Location = new System.Drawing.Point(x, y + 32);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("xml文件格式异常，请排查并修改后，重新导入！"); return;
            }
        }

        private void btnClassJieXi_Click(object sender, EventArgs e)
        {
            ReflectionHelper reflectionHelper = new ReflectionHelper();
            var path13 = AppDomain.CurrentDomain.BaseDirectory + @"\dll\AutoResolveService13.dll";
            var path24 = AppDomain.CurrentDomain.BaseDirectory +  @"\dll\AutoResolveService24.dll";
            var dt13 = reflectionHelper.GetClassPropertiesFromDll(path13);
            var dt24 = reflectionHelper.GetClassPropertiesFromDll(path24);
           var p = XB.Framework.Office.NpoiLib.Excel.NpoiExpand.ExportToExcelWin(dt13,"","13特性对照表");
            XB.Framework.Office.NpoiLib.Excel.NpoiExpand.ExportToExcelWin(dt24,"", "24特性对照表");
            MessageBox.Show("导出成功!");

        }
    }
}
