using System.Drawing;
using System.Windows.Forms;

namespace DynamicList
{
    public partial class DynamicList : Form
    {
        public DynamicList()
        {
            InitializeComponent();
        }
        
        public void AddColumn(string headingText, int width = 1, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left)
        {
            listView.Columns.Add(headingText, width, horizontalAlignment);
        }

        public void AddEntry(string text)
        {
            listView.Items.Add(text);
        }

        public void SetCheckboxes(bool on)
        {
            listView.CheckBoxes = on;
        }

        public void AutoResizeColumns()
        {
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void SetBackgroundColor(string hexColor)
        {
            listView.BackColor = ColorTranslator.FromHtml(hexColor);
        }

        public void SetForegroundColor(string hexColor)
        {
            listView.ForeColor = ColorTranslator.FromHtml(hexColor);
        }

        public void SetFont(string familyName = "Microsoft Sans Serif", float size = 8.25f, FontStyle style = FontStyle.Regular)
        {
            listView.Font = new Font(new FontFamily(familyName), size, style);
        }

        public void BorderStyle(BorderStyle borderStyle)
        {
            listView.BorderStyle = borderStyle;
        }

    }
}
