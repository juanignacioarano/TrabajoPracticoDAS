using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class FilteredComboBox : UserControl
    {
        private TextBox textBoxFilter;
        private ComboBox comboBoxItems;

        private List<object> originalItems = new List<object>();
        private Func<object, string> displayFunction;
        private string valueMember;
        private string placeholderText = "Escriba para filtrar...";

        public FilteredComboBox()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            textBoxFilter = new TextBox
            {
                Dock = DockStyle.Top
            };

            comboBoxItems = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            textBoxFilter.TextChanged += TextBoxFilter_TextChanged;
            textBoxFilter.GotFocus += TextBoxFilter_GotFocus;
            textBoxFilter.LostFocus += TextBoxFilter_LostFocus;
            comboBoxItems.DropDown += ComboBoxItems_DropDown;

            this.Controls.Add(comboBoxItems);
            this.Controls.Add(textBoxFilter);

            SetPlaceholder();
        }

        private void ComboBoxItems_DropDown(object sender, EventArgs e)
        {
            if (comboBoxItems.Items.Count == 0)
            {
                comboBoxItems.DropDownWidth = comboBoxItems.Width; // Evita problemas cuando no hay elementos
                return;
            }

            Graphics g = comboBoxItems.CreateGraphics();
            int maxWidth = comboBoxItems.Items.Cast<ComboBoxItem>()
                .Select(item => (int)g.MeasureString(item.ToString(), comboBoxItems.Font).Width + SystemInformation.VerticalScrollBarWidth)
                .Max();

            comboBoxItems.DropDownWidth = Math.Max(comboBoxItems.Width, maxWidth);
        }

        public int SelectedIndex
        {
            get => comboBoxItems.SelectedIndex;
            set => comboBoxItems.SelectedIndex = value;
        }

        public object SelectedItem
        {
            get
            {
                var selectedComboBoxItem = comboBoxItems.SelectedItem as ComboBoxItem;
                return selectedComboBoxItem?.Value;
            }
        }

        public object SelectedValue
        {
            get
            {
                var selectedComboBoxItem = comboBoxItems.SelectedItem as ComboBoxItem;
                var property = selectedComboBoxItem?.Value?.GetType().GetProperty(valueMember);
                return property?.GetValue(selectedComboBoxItem.Value);
            }
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == placeholderText) return;

            string filterText = textBoxFilter.Text.ToLower();

            var filteredItems = originalItems
                .Where(item => displayFunction(item).ToLower().Contains(filterText))
                .Select(item => new ComboBoxItem
                {
                    Value = item,
                    DisplayText = displayFunction(item)
                })
                .ToList();

            comboBoxItems.DataSource = null; // Limpia el DataSource antes de reasignarlo

            if (filteredItems.Count > 0)
            {
                comboBoxItems.DataSource = filteredItems;
                comboBoxItems.DisplayMember = "DisplayText";
                comboBoxItems.ValueMember = "Value";
                comboBoxItems.SelectedIndex = 0; // Selecciona el primer elemento si hay resultados
            }
            else
            {
                comboBoxItems.DataSource = null; // Limpia si no hay resultados
            }
        }

        private void TextBoxFilter_GotFocus(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == placeholderText)
            {
                textBoxFilter.Text = string.Empty;
                textBoxFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void TextBoxFilter_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFilter.Text))
            {
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            textBoxFilter.Text = placeholderText;
            textBoxFilter.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        public void SetItems(IEnumerable<object> items, Func<object, string> displayFunction, string valueMember)
        {
            this.displayFunction = displayFunction;
            this.valueMember = valueMember;
            originalItems = items.ToList();

            if (originalItems.Count > 0)
            {
                var itemsWithDisplay = originalItems
                    .Select(item => new ComboBoxItem
                    {
                        Value = item,
                        DisplayText = displayFunction(item)
                    })
                    .ToList();

                comboBoxItems.DataSource = itemsWithDisplay;
                comboBoxItems.DisplayMember = "DisplayText";
                comboBoxItems.ValueMember = "Value";
            }
            else
            {
                comboBoxItems.DataSource = null; // Limpia si no hay elementos originales
            }
        }

        private class ComboBoxItem
        {
            public object Value { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}
