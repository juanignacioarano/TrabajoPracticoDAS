using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class EmailTextBox : UserControl
    {
        private TextBox textBox;

        public EmailTextBox()
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
        }

        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public bool IsEmpty => string.IsNullOrWhiteSpace(this.Text);

        public void Clear() {
            textBox.Clear();
        }

        public bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(textBox.Text, emailPattern);
        }
    }
}
