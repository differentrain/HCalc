using HCalc.ExpressionHelper;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;



namespace HCalc
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Simplest dirty way to make a unique window title.  
        /// </summary>
        public const String DirtyWinTitle = "HCalc\u180E\u200B\u200C\u200D";




        private Encoding mCodePage = Encoding.ASCII;



        public FormMain()
        {
            InitializeComponent();
            this.Text = DirtyWinTitle;
        }


        private void TextBoxResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) (sender as TextBox).SelectAll();
        }




        private void MenuItemOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = MenuItemOnTop.Checked;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && MenuItemCloseToTray.Checked)
            {
                e.Cancel = true;
                MimToTray();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized/* && MenuItemTray.Checked*/)
            {
                MimToTray();
            }
            else
            {
                this.TextBoxExp.Focus();
                this.TextBoxExp.Select(TextBoxExp.Text.Length, 0);
            }

        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MenuItemCodePage_Changed(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            var currentcodePage = Encoding.GetEncoding(menuItem.Text);

            if (currentcodePage.CodePage == mCodePage.CodePage) return;

            mCodePage = currentcodePage;
            menuItem.Checked = true;

            foreach (ToolStripMenuItem item in MenuItemCodePage.DropDownItems)
            {
                if (item == menuItem) continue;
                item.Checked = false;
            }
            TextBoxExp.SetCodePage(mCodePage);
        }

        private void MenuItemHomePage_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/differentrain/HCalc");
        }



        private Boolean mShowBalloon = true;

        private void MimToTray()
        {
            this.Hide();
            if (mShowBalloon)
            {
                TrayIcon.ShowBalloonTip(30000);
                mShowBalloon = false;
            }

        }

        private void TextBoxExp_ExpOutputChanged(object sender, ExpBox.ExpState e)
        {
            if (e == ExpBox.ExpState.Ignore || e == ExpBox.ExpState.Error)
            {
                TextBoxResult.Enabled = false;
                LabelHex.Cursor = Cursors.Default;
                this.LabelUINT.Cursor = Cursors.Default;
                this.LabelSignedDec.Cursor = Cursors.Default;
                this.LabelBin.Cursor = Cursors.Default;
            }
            else
            {
                TextBoxResult.Enabled = true;
                LabelHex.Cursor = Cursors.Hand;
                this.LabelUINT.Cursor = Cursors.Hand;
                this.LabelSignedDec.Cursor = Cursors.Hand;
                this.LabelBin.Cursor = Cursors.Hand;
            }

            this.LabelHex.Text = TextBoxExp.HexString;
            this.LabelUINT.Text = TextBoxExp.UnsignedDecString;
            this.LabelSignedDec.Text = TextBoxExp.SingedDecString;
            this.LabelBin.Text = TextBoxExp.BinString;
            this.TextBoxResult.Text = TextBoxExp.ByteArrayString;

        }

        private void TextBoxExp_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F1:
                    TextBoxExp.Text = "B:";
                    TextBoxExp.Select(TextBoxExp.Text.Length, 0);
                    break;
                case Keys.F2:
                    TextBoxExp.Text = "S:";
                    TextBoxExp.Select(TextBoxExp.Text.Length, 0);
                    break;
            }

        }

        private void LabelResult_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label.Cursor == Cursors.Hand)
            {
                Clipboard.SetText(label.Text);
            }
        }
    }
}
