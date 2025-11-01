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
    internal partial class InputDTP : Form
    {
        string _text, _caption;
        DateTime? _value, _minDate, _maxDate;
        

        internal InputDTP(string Text, string Caption, DateTime? Value = null, DateTime? MinDate = null, DateTime? MaxDate = null)
        {
            InitializeComponent();
            _text = Text;
            _caption = Caption;
            _value = Value;
            _minDate = MinDate;
            _maxDate = MaxDate;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = _caption;
            rtxtText.Text = _text;

            if (_minDate != null)
                dtpInput.MinDate = _minDate.Value;

            if(_maxDate != null)
                dtpInput.MaxDate = _maxDate.Value;

            if(_value != null)
                dtpInput.Value = _value.Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JXInput.result = dtpInput.Value;
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
