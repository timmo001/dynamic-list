using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DynamicList
{
    public partial class List : Form
    {
        #region Globals
        private ListViewColumnSorter lvwColumnSorter;

        public Font defaultFont = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);

        public object Arrays { get; private set; }
        #endregion

        #region Constructor
        public List()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            mListView.ListViewItemSorter = lvwColumnSorter;
        }
        #endregion

        #region public Methods
        public void AddColumn(string headingText, int width = 1, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left, bool hidden = false, ColumnHeaderAutoResizeStyle autoResizeStyle = ColumnHeaderAutoResizeStyle.None)
        {
            if (hidden) mListView.SuspendLayout();
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = headingText;
            columnHeader.Width = width;
            columnHeader.TextAlign = horizontalAlignment;
            columnHeader.AutoResize(autoResizeStyle);
            mListView.Columns.Add(columnHeader);
            if (hidden) mListView.ResumeLayout();
        }

        public void AddEntry(object[] items)
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
            //if (font != null) listViewItem.Font = font;
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

        public Font MakeFont(string familyName = "Microsoft Sans Serif", double size = 8.25, FontStyle style = FontStyle.Regular)
        {
            return new Font(new FontFamily(familyName), (float)size, style);
        }

        public void SetBorderStyle(BorderStyle borderStyle)
        {
            mListView.BorderStyle = borderStyle;
        }

        public void CheckItems(int columnIndex, object[] items)
        {
            List<string> itemsList = new List<string>();
            foreach (object item in items) itemsList.Add(item.ToString());

            foreach (ListViewItem listViewItem in mListView.Items)
            {
                string curText = listViewItem.SubItems[columnIndex].Text;
                listViewItem.Checked = itemsList.Contains(curText);
            }
            mListView.Invalidate(true);
        }

        public object[] GetCheckedItems(int columnIndex)
        {
            //return mListView.CheckedItems;
            object[] checkedItems = new object[mListView.CheckedItems.Count];
            int i = 0;
            foreach (ListViewItem listViewItem in mListView.CheckedItems)
            {
                checkedItems[i] = listViewItem.SubItems[columnIndex].Text;
                i++;
            }
            return checkedItems;
        }

        public void CleanupAndClose()
        {
            mListView.Visible = false;
            Visible = false;
            Close();
        }
        #endregion

        #region private Methods
        private void SetCheckboxTag()
        {
            try
            {
                if (mListView.CheckedItems.Count > 0)
                {
                    if (mListView.CheckedItems.Count < mListView.Items.Count)
                    {
                        mListView.Columns[0].Tag = 1;
                    }
                    else
                    {
                        mListView.Columns[0].Tag = 2;
                    }
                }
                else
                {
                    mListView.Columns[0].Tag = 0;
                }
                mListView.Invalidate(true);
            }
            catch (Exception) { }
        }
        #endregion

        #region Events
        private void mListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && mListView.CheckBoxes)
            {
                try
                {
                    int value = Convert.ToInt32(mListView.Columns[e.Column].Tag);
                    //mListView.Columns[e.Column].Tag = value == 0 ? 2 : 0;
                    SetCheckboxTag();
                    foreach (ListViewItem item in mListView.Items)
                    {
                        if (value != 2) { item.Checked = true; }
                        else { item.Checked = false; }
                    }
                }
                catch (Exception)
                {
                }
                mListView.Invalidate(true);
            }
            else
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                mListView.Sort();
            }
        }

        private void mListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0 && mListView.CheckBoxes)
            {
                e.DrawBackground();
                CheckBoxState checkBoxState = CheckBoxState.UncheckedNormal;
                try
                {
                    switch (Convert.ToInt32(e.Header.Tag))
                    {
                        case 0:
                            checkBoxState = CheckBoxState.UncheckedNormal;
                            break;
                        case 1:
                            checkBoxState = CheckBoxState.MixedNormal;
                            break;
                        case 2:
                            checkBoxState = CheckBoxState.CheckedNormal;
                            break;
                    }
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                        checkBoxState);
                }
                catch (Exception) { }
            }
            else { e.DrawDefault = true; }
        }

        private void mListView_DrawItem(object sender, DrawListViewItemEventArgs e) { e.DrawDefault = true; }

        private void mListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) { e.DrawDefault = true; }

        private void mListView_ItemChecked(object sender, ItemCheckedEventArgs e) { SetCheckboxTag(); }
        #endregion

    }
}
