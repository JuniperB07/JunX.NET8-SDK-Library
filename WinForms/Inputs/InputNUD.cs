using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JunX.NET8.WinForms;

namespace JunX.NET8.WinForms.Inputs
{
    internal partial class InputNUD : Form
    {
        string _text, _caption;
        decimal? _value, _minimum, _maximum, _increment;
        

        internal InputNUD(string Text, string Caption, decimal? Value = null, decimal? Minimum = null, decimal? Maximum = null, decimal? Increment = null)
        {
            InitializeComponent();
            _text = Text;
            _caption = Caption;
            _value = Value;
            _minimum = Minimum;
            _maximum = Maximum;
            _increment = Increment;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = _caption;
            rtxtText.Text = _text;

            if (_minimum != null)
                nudInput.Minimum = _minimum.Value;

            if(_maximum != null)
                nudInput.Maximum = _maximum.Value;

            if(_increment != null)
                nudInput.Increment = _increment.Value;

            if(_value != null)
                nudInput.Value = _value.Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JXInput.result = nudInput.Value;
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
