using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DynamicList
{
    public partial class DynamicList : Form
    {
        #region Globals
        public Font defaultFont = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);

        public object Arrays { get; private set; }
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
            if (listView.CheckBoxes)
            {
                List<string> arrayList = new List<string>();
                arrayList.Add("");
                arrayList.AddRange(items);
                items = arrayList.ToArray();
            }
            listView.Items.Add(new ListViewItem(items));
        }

        public void SetCheckboxes(bool checkboxes)
        {
            listView.CheckBoxes = checkboxes;
            listView.Columns.Add("", 20, HorizontalAlignment.Center);
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

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0 && listView.CheckBoxes)
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
            if (e.Column == 0 && listView.CheckBoxes)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.listView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.listView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.listView.Items)
                    item.Checked = !value;

                this.listView.Invalidate();
            }
        }
        #endregion

    }
}
