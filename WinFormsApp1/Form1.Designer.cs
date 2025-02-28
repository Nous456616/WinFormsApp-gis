namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            文件 = new ToolStripDropDownButton();
            shpToolStripMenuItem = new ToolStripMenuItem();
            tiffToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            选择ToolStripMenuItem = new ToolStripMenuItem();
            放大ToolStripMenuItem = new ToolStripMenuItem();
            缩小ToolStripMenuItem = new ToolStripMenuItem();
            全景ToolStripMenuItem = new ToolStripMenuItem();
            平移ToolStripMenuItem = new ToolStripMenuItem();
            交互 = new ToolStripDropDownButton();
            添加点ToolStripMenuItem = new ToolStripMenuItem();
            删除所选要素ToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            缓冲区分析ToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            legend1 = new DotSpatial.Controls.Legend();
            lstlayers = new ListView();
            label1 = new Label();
            添加ToolStripMenuItem = new ToolStripMenuItem();
            添加面ToolStripMenuItem = new ToolStripMenuItem();
            点距离ToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { 文件, toolStripDropDownButton1, 交互, toolStripDropDownButton2, toolStripButton1, toolStripButton3, toolStripButton2, toolStripButton4 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 4, 0);
            toolStrip1.Size = new Size(1600, 41);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // 文件
            // 
            文件.DisplayStyle = ToolStripItemDisplayStyle.Text;
            文件.DropDownItems.AddRange(new ToolStripItem[] { shpToolStripMenuItem, tiffToolStripMenuItem });
            文件.Image = (Image)resources.GetObject("文件.Image");
            文件.ImageTransparentColor = Color.Magenta;
            文件.Name = "文件";
            文件.Size = new Size(84, 35);
            文件.Text = "文件";
            // 
            // shpToolStripMenuItem
            // 
            shpToolStripMenuItem.Name = "shpToolStripMenuItem";
            shpToolStripMenuItem.Size = new Size(284, 44);
            shpToolStripMenuItem.Text = "加载shp文件";
            shpToolStripMenuItem.Click += shpToolStripMenuItem_Click;
            // 
            // tiffToolStripMenuItem
            // 
            tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            tiffToolStripMenuItem.Size = new Size(284, 44);
            tiffToolStripMenuItem.Text = "加载tiff文件";
            tiffToolStripMenuItem.Click += tiffToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { 选择ToolStripMenuItem, 放大ToolStripMenuItem, 缩小ToolStripMenuItem, 全景ToolStripMenuItem, 平移ToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(180, 35);
            toolStripDropDownButton1.Text = "地图基本操作";
            // 
            // 选择ToolStripMenuItem
            // 
            选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            选择ToolStripMenuItem.Size = new Size(195, 44);
            选择ToolStripMenuItem.Text = "选择";
            选择ToolStripMenuItem.Click += 选择ToolStripMenuItem_Click;
            // 
            // 放大ToolStripMenuItem
            // 
            放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            放大ToolStripMenuItem.Size = new Size(195, 44);
            放大ToolStripMenuItem.Text = "放大";
            放大ToolStripMenuItem.Click += 放大ToolStripMenuItem_Click;
            // 
            // 缩小ToolStripMenuItem
            // 
            缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            缩小ToolStripMenuItem.Size = new Size(195, 44);
            缩小ToolStripMenuItem.Text = "缩小";
            缩小ToolStripMenuItem.Click += 缩小ToolStripMenuItem_Click;
            // 
            // 全景ToolStripMenuItem
            // 
            全景ToolStripMenuItem.Name = "全景ToolStripMenuItem";
            全景ToolStripMenuItem.Size = new Size(195, 44);
            全景ToolStripMenuItem.Text = "全景";
            全景ToolStripMenuItem.Click += 全景ToolStripMenuItem_Click;
            // 
            // 平移ToolStripMenuItem
            // 
            平移ToolStripMenuItem.Name = "平移ToolStripMenuItem";
            平移ToolStripMenuItem.Size = new Size(195, 44);
            平移ToolStripMenuItem.Text = "平移";
            平移ToolStripMenuItem.Click += 平移ToolStripMenuItem_Click;
            // 
            // 交互
            // 
            交互.DisplayStyle = ToolStripItemDisplayStyle.Text;
            交互.DropDownItems.AddRange(new ToolStripItem[] { 添加点ToolStripMenuItem, 添加ToolStripMenuItem, 添加面ToolStripMenuItem, 删除所选要素ToolStripMenuItem });
            交互.Image = (Image)resources.GetObject("交互.Image");
            交互.ImageTransparentColor = Color.Magenta;
            交互.Name = "交互";
            交互.Size = new Size(84, 35);
            交互.Text = "交互";
            // 
            // 添加点ToolStripMenuItem
            // 
            添加点ToolStripMenuItem.Name = "添加点ToolStripMenuItem";
            添加点ToolStripMenuItem.Size = new Size(291, 44);
            添加点ToolStripMenuItem.Text = "添加点";
            添加点ToolStripMenuItem.Click += 添加点ToolStripMenuItem_Click;
            // 
            // 删除所选要素ToolStripMenuItem
            // 
            删除所选要素ToolStripMenuItem.Name = "删除所选要素ToolStripMenuItem";
            删除所选要素ToolStripMenuItem.Size = new Size(291, 44);
            删除所选要素ToolStripMenuItem.Text = "删除所选要素";
            删除所选要素ToolStripMenuItem.Click += 删除所选要素ToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { 缓冲区分析ToolStripMenuItem, 点距离ToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(132, 35);
            toolStripDropDownButton2.Text = "分析处理";
            // 
            // 缓冲区分析ToolStripMenuItem
            // 
            缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            缓冲区分析ToolStripMenuItem.Size = new Size(359, 44);
            缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            缓冲区分析ToolStripMenuItem.Click += 缓冲区分析ToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(114, 35);
            toolStripButton1.Text = "开始编辑";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(108, 22);
            toolStripButton3.Text = "创建一个矢量图层";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(114, 35);
            toolStripButton2.Text = "保存编辑";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(60, 22);
            toolStripButton4.Text = "删除图层";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // legend1
            // 
            legend1.BackColor = Color.White;
            legend1.ControlRectangle = new Rectangle(0, 0, 224, 780);
            legend1.Dock = DockStyle.Left;
            legend1.DocumentRectangle = new Rectangle(0, 0, 187, 428);
            legend1.HorizontalScrollEnabled = true;
            legend1.Indentation = 30;
            legend1.IsInitialized = false;
            legend1.Location = new Point(0, 41);
            legend1.Margin = new Padding(6, 5, 6, 5);
            legend1.MinimumSize = new Size(10, 9);
            legend1.Name = "legend1";
            legend1.ProgressHandler = null;
            legend1.ResetOnResize = false;
            legend1.SelectionFontColor = Color.Black;
            legend1.SelectionHighlight = Color.FromArgb(215, 238, 252);
            legend1.Size = new Size(224, 780);
            legend1.TabIndex = 2;
            legend1.Text = "legend1";
            legend1.UseLegendForSelection = true;
            legend1.VerticalScrollEnabled = true;
            legend1.Click += legend1_Click;
            // 
            // lstlayers
            // 
            lstlayers.AutoArrange = false;
            lstlayers.CheckBoxes = true;
            lstlayers.Location = new Point(0, 102);
            lstlayers.Margin = new Padding(6, 5, 6, 5);
            lstlayers.Name = "lstlayers";
            lstlayers.Size = new Size(220, 693);
            lstlayers.TabIndex = 3;
            lstlayers.UseCompatibleStateImageBehavior = false;
            lstlayers.ItemChecked += lstlayers_ItemChecked;
            lstlayers.SelectedIndexChanged += lstlayers_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 66);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 31);
            label1.TabIndex = 4;
            label1.Text = "Maplayer";
            // 
            // 添加ToolStripMenuItem
            // 
            添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            添加ToolStripMenuItem.Size = new Size(180, 22);
            添加ToolStripMenuItem.Text = "添加线";
            添加ToolStripMenuItem.Click += 添加ToolStripMenuItem_Click;
            // 
            // 添加面ToolStripMenuItem
            // 
            添加面ToolStripMenuItem.Name = "添加面ToolStripMenuItem";
            添加面ToolStripMenuItem.Size = new Size(148, 22);
            添加面ToolStripMenuItem.Text = "添加面";
            // 
            // 点距离ToolStripMenuItem
            // 
            点距离ToolStripMenuItem.Name = "点距离ToolStripMenuItem";
            点距离ToolStripMenuItem.Size = new Size(180, 22);
            点距离ToolStripMenuItem.Text = "点距离";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 821);
            Controls.Add(label1);
            Controls.Add(lstlayers);
            Controls.Add(legend1);
            Controls.Add(toolStrip1);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton 文件;
        private ToolStripMenuItem shpToolStripMenuItem;
        private ToolStripMenuItem tiffToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem 选择ToolStripMenuItem;
        private ToolStripMenuItem 放大ToolStripMenuItem;
        private ToolStripMenuItem 缩小ToolStripMenuItem;
        private ToolStripMenuItem 全景ToolStripMenuItem;
        private ToolStripMenuItem 平移ToolStripMenuItem;
        private ToolStripDropDownButton 交互;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem 添加点ToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
        private DotSpatial.Controls.Legend legend1;
        private ListView lstlayers;
        private ToolStripMenuItem 删除所选要素ToolStripMenuItem;
        private Label label1;
        private ToolStripButton toolStripButton4;
        private ToolStripMenuItem 添加ToolStripMenuItem;
        private ToolStripMenuItem 添加面ToolStripMenuItem;
        private ToolStripMenuItem 点距离ToolStripMenuItem;
    }
}
