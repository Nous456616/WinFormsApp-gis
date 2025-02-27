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
            画点ToolStripMenuItem = new ToolStripMenuItem();
            画线ToolStripMenuItem = new ToolStripMenuItem();
            画面ToolStripMenuItem = new ToolStripMenuItem();
            距离测量ToolStripMenuItem = new ToolStripMenuItem();
            关闭距离测量ToolStripMenuItem = new ToolStripMenuItem();
            添加点ToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            缓冲区分析ToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { 文件, toolStripDropDownButton1, 交互, toolStripDropDownButton2, toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
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
            文件.Size = new Size(45, 22);
            文件.Text = "文件";
            // 
            // shpToolStripMenuItem
            // 
            shpToolStripMenuItem.Name = "shpToolStripMenuItem";
            shpToolStripMenuItem.Size = new Size(180, 22);
            shpToolStripMenuItem.Text = "加载shp文件";
            shpToolStripMenuItem.Click += shpToolStripMenuItem_Click;
            // 
            // tiffToolStripMenuItem
            // 
            tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            tiffToolStripMenuItem.Size = new Size(180, 22);
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
            toolStripDropDownButton1.Size = new Size(93, 22);
            toolStripDropDownButton1.Text = "地图基本操作";
            // 
            // 选择ToolStripMenuItem
            // 
            选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            选择ToolStripMenuItem.Size = new Size(180, 22);
            选择ToolStripMenuItem.Text = "选择";
            选择ToolStripMenuItem.Click += 选择ToolStripMenuItem_Click;
            // 
            // 放大ToolStripMenuItem
            // 
            放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            放大ToolStripMenuItem.Size = new Size(180, 22);
            放大ToolStripMenuItem.Text = "放大";
            放大ToolStripMenuItem.Click += 放大ToolStripMenuItem_Click;
            // 
            // 缩小ToolStripMenuItem
            // 
            缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            缩小ToolStripMenuItem.Size = new Size(180, 22);
            缩小ToolStripMenuItem.Text = "缩小";
            缩小ToolStripMenuItem.Click += 缩小ToolStripMenuItem_Click;
            // 
            // 全景ToolStripMenuItem
            // 
            全景ToolStripMenuItem.Name = "全景ToolStripMenuItem";
            全景ToolStripMenuItem.Size = new Size(180, 22);
            全景ToolStripMenuItem.Text = "全景";
            全景ToolStripMenuItem.Click += 全景ToolStripMenuItem_Click;
            // 
            // 平移ToolStripMenuItem
            // 
            平移ToolStripMenuItem.Name = "平移ToolStripMenuItem";
            平移ToolStripMenuItem.Size = new Size(180, 22);
            平移ToolStripMenuItem.Text = "平移";
            平移ToolStripMenuItem.Click += 平移ToolStripMenuItem_Click;
            // 
            // 交互
            // 
            交互.DisplayStyle = ToolStripItemDisplayStyle.Text;
            交互.DropDownItems.AddRange(new ToolStripItem[] { 画点ToolStripMenuItem, 画线ToolStripMenuItem, 画面ToolStripMenuItem, 距离测量ToolStripMenuItem, 关闭距离测量ToolStripMenuItem, 添加点ToolStripMenuItem });
            交互.Image = (Image)resources.GetObject("交互.Image");
            交互.ImageTransparentColor = Color.Magenta;
            交互.Name = "交互";
            交互.Size = new Size(45, 22);
            交互.Text = "交互";
            // 
            // 画点ToolStripMenuItem
            // 
            画点ToolStripMenuItem.Name = "画点ToolStripMenuItem";
            画点ToolStripMenuItem.Size = new Size(180, 22);
            画点ToolStripMenuItem.Text = "画点";
            // 
            // 画线ToolStripMenuItem
            // 
            画线ToolStripMenuItem.Name = "画线ToolStripMenuItem";
            画线ToolStripMenuItem.Size = new Size(180, 22);
            画线ToolStripMenuItem.Text = "画线";
            // 
            // 画面ToolStripMenuItem
            // 
            画面ToolStripMenuItem.Name = "画面ToolStripMenuItem";
            画面ToolStripMenuItem.Size = new Size(180, 22);
            画面ToolStripMenuItem.Text = "画面";
            // 
            // 距离测量ToolStripMenuItem
            // 
            距离测量ToolStripMenuItem.Name = "距离测量ToolStripMenuItem";
            距离测量ToolStripMenuItem.Size = new Size(180, 22);
            距离测量ToolStripMenuItem.Text = "距离测量";
            // 
            // 关闭距离测量ToolStripMenuItem
            // 
            关闭距离测量ToolStripMenuItem.Name = "关闭距离测量ToolStripMenuItem";
            关闭距离测量ToolStripMenuItem.Size = new Size(180, 22);
            关闭距离测量ToolStripMenuItem.Text = "关闭距离测量";
            // 
            // 添加点ToolStripMenuItem
            // 
            添加点ToolStripMenuItem.Name = "添加点ToolStripMenuItem";
            添加点ToolStripMenuItem.Size = new Size(180, 22);
            添加点ToolStripMenuItem.Text = "添加点";
            添加点ToolStripMenuItem.Click += 添加点ToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { 缓冲区分析ToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(69, 22);
            toolStripDropDownButton2.Text = "分析处理";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(60, 22);
            toolStripButton1.Text = "开始编辑";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(60, 22);
            toolStripButton2.Text = "保存编辑";
            toolStripButton2.Click += toolStripButton2_Click;
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
            // 缓冲区分析ToolStripMenuItem
            // 
            缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            缓冲区分析ToolStripMenuItem.Size = new Size(180, 22);
            缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
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
        private ToolStripMenuItem 画点ToolStripMenuItem;
        private ToolStripMenuItem 画线ToolStripMenuItem;
        private ToolStripMenuItem 画面ToolStripMenuItem;
        private ToolStripMenuItem 距离测量ToolStripMenuItem;
        private ToolStripMenuItem 关闭距离测量ToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem 添加点ToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
    }
}
