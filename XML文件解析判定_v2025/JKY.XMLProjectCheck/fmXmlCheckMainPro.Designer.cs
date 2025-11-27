using System.Drawing;

namespace JKY.XMLProjectCheck
{
    partial class fmXmlCheckMainPro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpicMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pView = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelview2 = new System.Windows.Forms.Label();
            this.labelview1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFileImport = new System.Windows.Forms.Button();
            this.tlpicMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpicMain
            // 
            this.tlpicMain.BackColor = System.Drawing.Color.White;
            this.tlpicMain.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.bj1;
            this.tlpicMain.ColumnCount = 6;
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpicMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpicMain.Controls.Add(this.panel1, 1, 0);
            this.tlpicMain.Controls.Add(this.groupBox1, 0, 2);
            this.tlpicMain.Controls.Add(this.panel4, 0, 3);
            this.tlpicMain.Controls.Add(this.panel5, 0, 1);
            this.tlpicMain.Controls.Add(this.tableLayoutPanel1, 4, 2);
            this.tlpicMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpicMain.Location = new System.Drawing.Point(0, 0);
            this.tlpicMain.Name = "tlpicMain";
            this.tlpicMain.RowCount = 4;
            this.tlpicMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpicMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpicMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpicMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpicMain.Size = new System.Drawing.Size(1372, 1094);
            this.tlpicMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.Frame_2036097084_2x;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tlpicMain.SetColumnSpan(this.panel1, 2);
            this.panel1.Location = new System.Drawing.Point(63, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 74);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.tlpicMain.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Location = new System.Drawing.Point(3, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1166, 888);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检验结果";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pView);
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1160, 784);
            this.panel3.TabIndex = 1;
            // 
            // pView
            // 
            this.pView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pView.Location = new System.Drawing.Point(0, 0);
            this.pView.Name = "pView";
            this.pView.Size = new System.Drawing.Size(1160, 784);
            this.pView.TabIndex = 43;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1160, 784);
            this.richTextBox1.TabIndex = 42;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 70);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.btnred;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(57, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 70);
            this.button2.TabIndex = 1;
            this.button2.Text = "错误提示";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.tlpicMain.SetColumnSpan(this.panel4, 6);
            this.panel4.Controls.Add(this.labelview2);
            this.panel4.Controls.Add(this.labelview1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 1037);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1366, 54);
            this.panel4.TabIndex = 46;
            // 
            // labelview2
            // 
            this.labelview2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelview2.BackColor = System.Drawing.Color.Transparent;
            this.labelview2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelview2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelview2.Location = new System.Drawing.Point(42, 18);
            this.labelview2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelview2.Name = "labelview2";
            this.labelview2.Size = new System.Drawing.Size(349, 21);
            this.labelview2.TabIndex = 45;
            this.labelview2.Text = "北京建科研软件技术有限公司";
            // 
            // labelview1
            // 
            this.labelview1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelview1.BackColor = System.Drawing.Color.Transparent;
            this.labelview1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelview1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelview1.Location = new System.Drawing.Point(1000, 18);
            this.labelview1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelview1.Name = "labelview1";
            this.labelview1.Size = new System.Drawing.Size(339, 21);
            this.labelview1.TabIndex = 45;
            this.labelview1.Text = "欢迎使用XML文件校验系统 v2.0";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.cap;
            this.tlpicMain.SetColumnSpan(this.panel5, 6);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1366, 54);
            this.panel5.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.btn2;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(62, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "XML校验";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(269, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(662, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "本工具能快速校验您的XML文件是否满足建设工程造价数据交换标准！";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnFileImport, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1195, 143);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(154, 888);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // btnFileImport
            // 
            this.btnFileImport.BackColor = System.Drawing.Color.White;
            this.btnFileImport.BackgroundImage = global::JKY.XMLProjectCheck.Properties.Resources.btnbule;
            this.btnFileImport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFileImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileImport.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFileImport.ForeColor = System.Drawing.Color.White;
            this.btnFileImport.Location = new System.Drawing.Point(3, 103);
            this.btnFileImport.Name = "btnFileImport";
            this.btnFileImport.Size = new System.Drawing.Size(148, 61);
            this.btnFileImport.TabIndex = 1;
            this.btnFileImport.Text = "文件导入";
            this.btnFileImport.UseVisualStyleBackColor = false;
            this.btnFileImport.Click += new System.EventHandler(this.btnFileImport_Click);
            // 
            // fmXmlCheckMainPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 1094);
            this.Controls.Add(this.tlpicMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmXmlCheckMainPro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmXmlCheckMainPro_Load);
            this.tlpicMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpicMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFileImport;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pView;
        private System.Windows.Forms.Label labelview1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelview2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}