namespace HCalc
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LabelSignedDec = new System.Windows.Forms.Label();
            this.LabelHex = new System.Windows.Forms.Label();
            this.LabelBin = new System.Windows.Forms.Label();
            this.TextBoxResult = new System.Windows.Forms.TextBox();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemCodePage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAscii = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUTF16 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGB2312 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBig5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShiftJis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWin1250 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCloseToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelUINT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LableLONG = new System.Windows.Forms.Label();
            this.TextBoxExp = new HCalc.ExpBox();
            this.MenuItemHomepage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelSignedDec
            // 
            this.LabelSignedDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelSignedDec.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelSignedDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelSignedDec.Location = new System.Drawing.Point(183, 40);
            this.LabelSignedDec.Name = "LabelSignedDec";
            this.LabelSignedDec.Size = new System.Drawing.Size(150, 22);
            this.LabelSignedDec.TabIndex = 3;
            this.LabelSignedDec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelSignedDec.Click += new System.EventHandler(this.LabelResult_Click);
            // 
            // LabelHex
            // 
            this.LabelHex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelHex.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelHex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelHex.Location = new System.Drawing.Point(7, 40);
            this.LabelHex.Name = "LabelHex";
            this.LabelHex.Size = new System.Drawing.Size(127, 22);
            this.LabelHex.TabIndex = 8;
            this.LabelHex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelHex.Click += new System.EventHandler(this.LabelResult_Click);
            // 
            // LabelBin
            // 
            this.LabelBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelBin.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelBin.Location = new System.Drawing.Point(7, 68);
            this.LabelBin.Name = "LabelBin";
            this.LabelBin.Size = new System.Drawing.Size(460, 23);
            this.LabelBin.TabIndex = 10;
            this.LabelBin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelBin.Click += new System.EventHandler(this.LabelResult_Click);
            // 
            // TextBoxResult
            // 
            this.TextBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBoxResult.Enabled = false;
            this.TextBoxResult.Font = new System.Drawing.Font("Consolas", 10F);
            this.TextBoxResult.Location = new System.Drawing.Point(7, 97);
            this.TextBoxResult.Name = "TextBoxResult";
            this.TextBoxResult.ReadOnly = true;
            this.TextBoxResult.Size = new System.Drawing.Size(460, 23);
            this.TextBoxResult.TabIndex = 13;
            this.TextBoxResult.TabStop = false;
            this.TextBoxResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxResult_KeyDown);
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "Hi, I\'m here!";
            this.TrayIcon.ContextMenuStrip = this.ContextMenuStripTray;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Hack Calculator";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // ContextMenuStripTray
            // 
            this.ContextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen,
            this.toolStripSeparator1,
            this.MenuItemCodePage,
            this.toolStripSeparator2,
            this.MenuItemOnTop,
            this.MenuItemCloseToTray,
            this.toolStripSeparator4,
            this.MenuItemHomepage,
            this.toolStripSeparator3,
            this.ToolStripMenuItemExit});
            this.ContextMenuStripTray.Name = "ContextMenuStripTray";
            this.ContextMenuStripTray.Size = new System.Drawing.Size(181, 182);
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemOpen.Text = "Open HCalc";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItemCodePage
            // 
            this.MenuItemCodePage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAscii,
            this.MenuItemUTF16,
            this.MenuItemGB2312,
            this.MenuItemBig5,
            this.MenuItemShiftJis,
            this.MenuItemWin1250});
            this.MenuItemCodePage.Name = "MenuItemCodePage";
            this.MenuItemCodePage.Size = new System.Drawing.Size(180, 22);
            this.MenuItemCodePage.Text = "Codepage";
            // 
            // MenuItemAscii
            // 
            this.MenuItemAscii.Checked = true;
            this.MenuItemAscii.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemAscii.Name = "MenuItemAscii";
            this.MenuItemAscii.Size = new System.Drawing.Size(159, 22);
            this.MenuItemAscii.Text = "us-ascii";
            this.MenuItemAscii.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // MenuItemUTF16
            // 
            this.MenuItemUTF16.Name = "MenuItemUTF16";
            this.MenuItemUTF16.Size = new System.Drawing.Size(159, 22);
            this.MenuItemUTF16.Text = "utf-16";
            this.MenuItemUTF16.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // MenuItemGB2312
            // 
            this.MenuItemGB2312.Name = "MenuItemGB2312";
            this.MenuItemGB2312.Size = new System.Drawing.Size(159, 22);
            this.MenuItemGB2312.Text = "gb2312";
            this.MenuItemGB2312.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // MenuItemBig5
            // 
            this.MenuItemBig5.Name = "MenuItemBig5";
            this.MenuItemBig5.Size = new System.Drawing.Size(159, 22);
            this.MenuItemBig5.Text = "big5";
            this.MenuItemBig5.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // MenuItemShiftJis
            // 
            this.MenuItemShiftJis.Name = "MenuItemShiftJis";
            this.MenuItemShiftJis.Size = new System.Drawing.Size(159, 22);
            this.MenuItemShiftJis.Text = "shift_jis";
            this.MenuItemShiftJis.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // MenuItemWin1250
            // 
            this.MenuItemWin1250.Name = "MenuItemWin1250";
            this.MenuItemWin1250.Size = new System.Drawing.Size(159, 22);
            this.MenuItemWin1250.Text = "windows-1250";
            this.MenuItemWin1250.Click += new System.EventHandler(this.MenuItemCodePage_Changed);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItemOnTop
            // 
            this.MenuItemOnTop.CheckOnClick = true;
            this.MenuItemOnTop.Name = "MenuItemOnTop";
            this.MenuItemOnTop.Size = new System.Drawing.Size(180, 22);
            this.MenuItemOnTop.Text = "Top";
            this.MenuItemOnTop.CheckedChanged += new System.EventHandler(this.MenuItemOnTop_Click);
            // 
            // MenuItemCloseToTray
            // 
            this.MenuItemCloseToTray.CheckOnClick = true;
            this.MenuItemCloseToTray.Name = "MenuItemCloseToTray";
            this.MenuItemCloseToTray.Size = new System.Drawing.Size(180, 22);
            this.MenuItemCloseToTray.Text = "Close to Tray";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemExit.Text = "Exit";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // LabelUINT
            // 
            this.LabelUINT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelUINT.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelUINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelUINT.Location = new System.Drawing.Point(380, 40);
            this.LabelUINT.Name = "LabelUINT";
            this.LabelUINT.Size = new System.Drawing.Size(87, 22);
            this.LabelUINT.TabIndex = 22;
            this.LabelUINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelUINT.Click += new System.EventHandler(this.LabelResult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "UINT";
            // 
            // LableLONG
            // 
            this.LableLONG.AutoSize = true;
            this.LableLONG.Location = new System.Drawing.Point(142, 44);
            this.LableLONG.Name = "LableLONG";
            this.LableLONG.Size = new System.Drawing.Size(35, 14);
            this.LableLONG.TabIndex = 25;
            this.LableLONG.Text = "LONG";
            // 
            // TextBoxExp
            // 
            this.TextBoxExp.Location = new System.Drawing.Point(7, 9);
            this.TextBoxExp.MaxLength = 255;
            this.TextBoxExp.Name = "TextBoxExp";
            this.TextBoxExp.Size = new System.Drawing.Size(460, 22);
            this.TextBoxExp.TabIndex = 23;
            this.TextBoxExp.ExpOutputChanged += new System.EventHandler<HCalc.ExpBox.ExpState>(this.TextBoxExp_ExpOutputChanged);
            this.TextBoxExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxExp_KeyUp);
            // 
            // MenuItemHomepage
            // 
            this.MenuItemHomepage.Name = "MenuItemHomepage";
            this.MenuItemHomepage.Size = new System.Drawing.Size(180, 22);
            this.MenuItemHomepage.Text = "Homepage";
            this.MenuItemHomepage.Click += new System.EventHandler(this.MenuItemHomePage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 128);
            this.Controls.Add(this.LableLONG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxExp);
            this.Controls.Add(this.LabelUINT);
            this.Controls.Add(this.TextBoxResult);
            this.Controls.Add(this.LabelBin);
            this.Controls.Add(this.LabelHex);
            this.Controls.Add(this.LabelSignedDec);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HCalc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ContextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelSignedDec;
        private System.Windows.Forms.Label LabelHex;
        private System.Windows.Forms.Label LabelBin;
        private System.Windows.Forms.TextBox TextBoxResult;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.Label LabelUINT;
        private ExpBox TextBoxExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LableLONG;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOnTop;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCodePage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCloseToTray;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAscii;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUTF16;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGB2312;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBig5;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShiftJis;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWin1250;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHomepage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

