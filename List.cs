using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DynamicList
{
    public partial class List : Form
    {
        #region Globals
        public Font defaultFont = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);

        public object Arrays { get; private set; }
        #endregion

        #region Constructor
        public List()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Methods
        public void AddColumn(string headingText, int width = 1, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left, bool hidden = false, ColumnHeaderAutoResizeStyle resizeStyle = ColumnHeaderAutoResizeStyle.None)
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = headingText;
            columnHeader.Width = hidden ? 0 : width;
            columnHeader.TextAlign = horizontalAlignment;
            columnHeader.AutoResize(resizeStyle);
            mListView.Columns.Add(columnHeader);
        }

        public void AddEntry(object[] items, Font font = null)
        {
            // Create List<object> to store object array
            List<object> list = new List<object>();
            if (mListView.CheckBoxes) list.Add("");
            list.AddRange(items);
            // Convert List<object> to string array
            string[] itemsStr = ((IEnumerable)list).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
            // Create ListViewItem from string array
            ListViewItem listViewItem = new ListViewItem(itemsStr);
            // Set props
            if (font != null) listViewItem.Font = font;
            // Add the ListViewItem
            mListView.Items.Add(listViewItem);
        }

        public void SetCheckboxes(bool checkboxes)
        {
            mListView.CheckBoxes = checkboxes;
            mListView.Columns.Add("", 20, HorizontalAlignment.Center);
        }

        public void AutoResizeColumns()
        {
            mListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void SetBackgroundColor(string hexColor)
        {
            mListView.BackColor = ColorTranslator.FromHtml(hexColor);
        }

        public void SetForegroundColor(string hexColor)
        {
            mListView.ForeColor = ColorTranslator.FromHtml(hexColor);
        }

        public void SetFont(Font font)
        {
            mListView.Font = font;
        }

        public Font MakeFont(string familyName = "Microsoft Sans Serif", float size = 8.25f, FontStyle style = FontStyle.Regular)
        {
            return new Font(new FontFamily(familyName), size, style);
        }

        public void BorderStyle(BorderStyle borderStyle)
        {
            mListView.BorderStyle = borderStyle;
        }

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0 && mListView.CheckBoxes)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && mListView.CheckBoxes)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.mListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                mListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.mListView.Items)
                    item.Checked = !value;

                mListView.Invalidate();
            }
        }

        public void CleanupAndClose()
        {
            mListView.Visible = false;
            Visible = false;
            Close();
        }
        #endregion

    }
}
