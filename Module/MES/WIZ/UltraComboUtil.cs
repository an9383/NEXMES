using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data;

namespace WIZ
{
    public class UltraComboUtil
    {
        public void DataBind(UltraCombo ultraCombo, DataTable DtSouce)
        {
            string[] strColName = new string[0];
            DataBind(ultraCombo, DtSouce, strColName);
        }

        public void DataBind(UltraCombo ultraCombo, DataTable DtSouce, string[] strColName)
        {
            if (strColName.Length != 0)
            {
                ultraCombo.DisplayMember = strColName[0];
                ultraCombo.ValueMember = strColName[1];
            }
            else
            {
                ultraCombo.DisplayMember = DtSouce.Columns[0].ColumnName;
                ultraCombo.ValueMember = DtSouce.Columns[1].ColumnName;
            }
            ultraCombo.DataSource = DtSouce;
            for (int i = 0; i < ultraCombo.DisplayLayout.Bands.Count; i++)
            {
                ultraCombo.DisplayLayout.Bands[i].PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All);

                for (int j = 0; j < ultraCombo.DisplayLayout.Bands[i].Columns.Count; j++)
                {
                    ultraCombo.DisplayLayout.Bands[i].Columns[j].CellAppearance.TextHAlign = HAlign.Center;
                }
            }
        }
    }
}
