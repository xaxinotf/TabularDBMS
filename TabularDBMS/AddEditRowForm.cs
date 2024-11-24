using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TabularDBMS.Models;

namespace TabularDBMS
{
    public partial class AddEditRowForm : Form
    {
        public Row Row { get; private set; }
        private List<Column> _columns;
        private bool _isEditMode;

        public AddEditRowForm(List<Column> columns, Row existingRow = null)
        {
            InitializeComponent();
            _columns = columns;
            Row = existingRow ?? new Row();
            _isEditMode = existingRow != null;

            InitializeForm(existingRow);
        }

        private void InitializeForm(Row existingRow)
        {
            tableLayoutPanel.Controls.Clear(); // Очищаємо всі існуючі контролі, якщо такі є

            tableLayoutPanel.RowCount = _columns.Count;
            tableLayoutPanel.RowStyles.Clear();

            foreach (var column in _columns)
            {
                // Створюємо Label для кожного стовпця
                Label label = new Label()
                {
                    Text = column.Name,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                };

                // Створюємо Control для введення даних на основі типу даних стовпця
                Control inputControl = CreateControlForDataType(column.Type);
                inputControl.Name = column.Name;

                // Якщо це режим редагування, встановлюємо значення у відповідний контроль
                if (_isEditMode && existingRow != null)
                {
                    var value = existingRow.GetData(column.Name);
                    SetValueToControl(inputControl, column.Type, value);
                }

                // Додаємо мітку і поле введення до tableLayoutPanel
                tableLayoutPanel.Controls.Add(label);
                tableLayoutPanel.Controls.Add(inputControl);
            }

            if (_isEditMode)
                this.Text = "Edit Row";
            else
                this.Text = "Add Row";
        }

        private Control CreateControlForDataType(DataType type)
        {
            switch (type)
            {
                case DataType.Integer:
                    return new NumericUpDown() { Minimum = int.MinValue, Maximum = int.MaxValue, Anchor = AnchorStyles.Left };
                case DataType.Real:
                    return new TextBox() { Anchor = AnchorStyles.Left };
                case DataType.Char:
                    return new TextBox() { MaxLength = 1, Anchor = AnchorStyles.Left };
                case DataType.String:
                    return new TextBox() { Anchor = AnchorStyles.Left };
                case DataType.Currency:
                    return new NumericUpDown() { Minimum = 0, Maximum = Currency.MaxValue, DecimalPlaces = 2, Anchor = AnchorStyles.Left, ThousandsSeparator = true };
                case DataType.MoneyInterval:
                    return new TextBox() { Anchor = AnchorStyles.Left }; // Просто текстове поле для формату інтервалу
                default:
                    return new TextBox() { Anchor = AnchorStyles.Left };
            }
        }

        private void SetValueToControl(Control control, DataType type, object value)
        {
            switch (type)
            {
                case DataType.Integer:
                    if (control is NumericUpDown numericControlInt && value is int intValue)
                        numericControlInt.Value = intValue;
                    break;
                case DataType.Real:
                    if (control is TextBox textControlReal && value is double doubleValue)
                        textControlReal.Text = doubleValue.ToString();
                    break;
                case DataType.Char:
                    if (control is TextBox textControlChar && value is char charValue)
                        textControlChar.Text = charValue.ToString();
                    break;
                case DataType.String:
                    if (control is TextBox textControlString && value is string strValue)
                        textControlString.Text = strValue;
                    break;
                case DataType.Currency:
                    if (control is NumericUpDown numericControlCurrency && value is Currency currencyValue)
                        numericControlCurrency.Value = currencyValue.Value;
                    break;
                case DataType.MoneyInterval:
                    if (control is TextBox textControlInterval && value is MoneyInterval interval)
                        textControlInterval.Text = $"[{interval.Start.Value}, {interval.End.Value}]";
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var column in _columns)
                {
                    var control = tableLayoutPanel.Controls.Find(column.Name, true).FirstOrDefault();
                    if (control == null)
                        throw new Exception($"Control for column '{column.Name}' not found.");

                    object value;
                    switch (column.Type)
                    {
                        case DataType.Integer:
                            value = (int)((NumericUpDown)control).Value;
                            break;
                        case DataType.Real:
                            if (!double.TryParse(((TextBox)control).Text, out double realValue))
                                throw new FormatException($"Invalid real number format for column '{column.Name}'.");
                            value = realValue;
                            break;
                        case DataType.Char:
                            string charText = ((TextBox)control).Text;
                            if (string.IsNullOrEmpty(charText))
                                throw new Exception($"Column '{column.Name}' requires a char value.");
                            value = charText[0];
                            break;
                        case DataType.String:
                            value = ((TextBox)control).Text;
                            break;
                        case DataType.Currency:
                            value = new Currency(((NumericUpDown)control).Value);
                            break;
                        case DataType.MoneyInterval:
                            string text = ((TextBox)control).Text.Trim();
                            if (text.StartsWith("[") && text.EndsWith("]"))
                            {
                                text = text.Substring(1, text.Length - 2);
                                var parts = text.Split(',');
                                if (parts.Length != 2)
                                    throw new FormatException($"Invalid format for MoneyInterval in column '{column.Name}'.");
                                if (!decimal.TryParse(parts[0].Trim(), out decimal start) || !decimal.TryParse(parts[1].Trim(), out decimal end))
                                    throw new FormatException($"Invalid decimal values for MoneyInterval in column '{column.Name}'.");
                                value = new MoneyInterval(start, end);
                            }
                            else
                            {
                                throw new FormatException($"Invalid format for MoneyInterval in column '{column.Name}'.");
                            }
                            break;
                        default:
                            throw new NotSupportedException($"Data type '{column.Type}' is not supported.");
                    }

                    // Передаємо всі необхідні параметри в SetData
                    Row.SetData(column.Name, value, _columns);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
