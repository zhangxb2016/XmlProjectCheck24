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
    public partial class fmXmlCheckMainPro : Form
    {
        public fmXmlCheckMainPro()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SuspendLayout();  // 暂停布局
            richTextBox1.Font = new Font("Consolas", 11);        // 执行窗体初始化代码
            this.ResumeLayout(false);  // 恢复布局

            this.tableLayoutPanel1.SuspendLayout();
            // 加载或初始化控件
            this.tableLayoutPanel1.ResumeLayout();
            this.tableLayoutPanel1.Refresh();
        }

        private void fmXmlCheckMainPro_Load(object sender, EventArgs e)
        {
          
            //this.DoubleBuffered = true; // 在窗体构造函数或Load事件中添加
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            //  ControlStyles.DoubleBuffer |
            //  ControlStyles.UserPaint, true);
            //this.UpdateStyles();
        

            //this.SuspendLayout();
            //// 初始化控件或加载数据
            //this.ResumeLayout(false);
            //this.PerformLayout();
            //this.AutoScaleMode = AutoScaleMode.Dpi;

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
