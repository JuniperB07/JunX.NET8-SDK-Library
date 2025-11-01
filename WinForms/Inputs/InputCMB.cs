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
    internal partial class InputCMB : Form
    {
        string _text, _caption, _value;
        IEnumerable<string>? _items;

        internal InputCMB(string Text, string Caption, string Value = "", IEnumerable<string>? Items = null)
        {
            InitializeComponent();
            _text = Text;
            _caption = Caption;
            _value = Value;
            _items = Items;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            this.Text = _caption;
            rtxtText.Text = _text;

            if (_items != null)
                Forms.FillComboBox(cmbInput, _items);

            if(!string.IsNullOrWhiteSpace(_value))
            {
                if (cmbInput.Items.Contains(_value))
                    cmbInput.Text = _value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            JXInput.result = cmbInput.Text;
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
