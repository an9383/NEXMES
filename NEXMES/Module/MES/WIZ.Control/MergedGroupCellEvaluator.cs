using Infragistics.Win.UltraWinGrid;
using System.Collections.Generic;

namespace WIZ.Control
{
    public class MergedGroupCellEvaluator : IMergedCellEvaluator
    {
        private List<string> mergeColList = new List<string>();

        public MergedGroupCellEvaluator(params string[] columnnames)
        {
            for (int i = 0; i < columnnames.Length; i++)
            {
                mergeColList.Add(columnnames[i]);
            }
        }

        public bool ShouldCellsBeMerged(UltraGridRow row1, UltraGridRow row2, UltraGridColumn column)
        {
            bool result = false;
            if (!mergeColList.Contains(column.Key))
            {
                return false;
            }
            for (int i = 0; i < mergeColList.Count; i++)
            {
                if (row1.Cells[mergeColList[i]].Text == row2.Cells[mergeColList[i]].Text)
                {
                    result = true;
                    if (mergeColList[i] == column.Key)
                    {
                        break;
                    }
                    continue;
                }
                result = false;
                break;
            }
            return result;
        }
    }
}
