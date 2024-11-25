using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class NumericTextBox : UserControl
    {
        private TextBox textBox;

        public NumericTextBox()
        {
            InitializeComponent();
            InitializeCustomTextBox();
        }

        private void InitializeCustomTextBox()
        {
            textBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(textBox);

            textBox.KeyPress += TextBox_KeyPress;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.KeyDown += TextBox_KeyDown;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string validText = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (textBox.Text != validText)
            {
                textBox.Text = validText;
                textBox.SelectionStart = validText.Length;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
            }
        }

        public void Clear()
        {
            textBox.Clear();
        }

        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public bool IsEmpty => string.IsNullOrWhiteSpace(this.Text);
    }
}
