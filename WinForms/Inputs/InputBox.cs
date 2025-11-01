using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace JunX.NET8.WinForms.Inputs
{
    internal partial class InputBox : Form
    {
        string _text, _caption, _value;

        internal InputBox(string Text, string Caption, string Value = "")
        {
            InitializeComponent();
            _text = Text;
            _caption = Caption;
            _value = Value;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = _caption;
            rtxtText.Text = _text;
            JXInput.result = _value;
            txtInput.Text = JXInput.result.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JXInput.result = txtInput.Text;
            Close();
        }

        private void InputBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
            else if(e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();
        }
    }
}
