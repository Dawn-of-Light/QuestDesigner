using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace QuestDesigner.Controls
{
	// Implements the manual sorting of items by columns.
	class ListViewItemComparer : IComparer
	{
		public int Column;
		public bool Invert = false;
		public ListViewItemComparer() : this(0, false) { }
		public ListViewItemComparer(int column) : this(column, false) { }
		public ListViewItemComparer(int column, bool invert)
		{
			this.Column = column;
			this.Invert = invert;
		}
		public int Compare(object x, object y)
		{
			int result = String.Compare(((ListViewItem)x).SubItems[Column].Text, ((ListViewItem)y).SubItems[Column].Text);
			if (Invert)
				result *= -1;
			return result;
		}
	}
}
