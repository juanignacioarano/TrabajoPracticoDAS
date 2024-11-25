using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class HideButton : UserControl
    {
        private Button button;

        public HideButton()
        {
            InitializeComponent();
            InitializeCustomButton();
        }

        private void InitializeCustomButton()
        {
            button = new Button
            {
                Text = "Menu",
                Dock = DockStyle.Fill
            };

            button.Click += Button_Click;
            this.Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm(); 
            if (parentForm != null)
            {
                parentForm.Hide(); // Oculta el formulario padre
            }
        }
    }
}
