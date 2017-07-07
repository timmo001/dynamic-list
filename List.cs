using System.Drawing;
using System.Windows.Forms;

namespace DynamicList
{
    public partial class DynamicList : Form
    {
        #region Globals
        public Font defaultFont = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);
        #endregion

        #region Constructor
        public DynamicList()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Methods
        public void AddColumn(string headingText, int width = 1, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left)
        {
            listView.Columns.Add(headingText, width, horizontalAlignment);
        }

        public void AddEntry(string[] items)
        {
            //ListViewItem listViewItem = new ListViewItem(items);
            //if (font != null) listViewItem.Font = font;
            //listView.Items.Add(listViewItem);
            listView.Items.Add(new ListViewItem(items));
        }

        public void SetCheckboxes(bool checkboxes)
        {
            listView.CheckBoxes = checkboxes;
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

        public void SetFont(Font font)
        {
            listView.Font = font;
        }

        public Font MakeFont(string familyName = "Microsoft Sans Serif", float size = 8.25f, FontStyle style = FontStyle.Regular)
        {
            return new Font(new FontFamily(familyName), size, style);
        }

        public void BorderStyle(BorderStyle borderStyle)
        {
            listView.BorderStyle = borderStyle;
        }
        #endregion

    }
}
