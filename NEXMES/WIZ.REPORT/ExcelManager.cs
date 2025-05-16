using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WIZ.REPORT
{
    public class ExcelManager
    {
        public ExcelManager()
        {

        }

        public void DownloadExcel(WIZ.Control.Grid Grid, string Name, bool AutoOpen = true)
        {
            try
            {
                if (Directory.Exists(Application.StartupPath + @"\Download") == false)
                    Directory.CreateDirectory(Application.StartupPath + @"\Download");

                string eFileName = Application.StartupPath + @"\DownLoad\" + Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

                UltraGridExcelExporter ExcelExport = new UltraGridExcelExporter();
                ExcelExport.DefaultWorkbookPaletteMode = Infragistics.Documents.Excel.WorkbookPaletteMode.StandardPalette;
                ExcelExport.CellExported += new CellExportedEventHandler(ExcelExport_CellExported);

                ExcelExport.Export(Grid, eFileName);

                if (AutoOpen == true)
                {
                    if (MessageBox.Show("엑셀 다운로드가 성공하였습니다. 열어보시겠습니까?", "엑셀 다운로드 완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = eFileName;
                    p.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("엑셀 실행 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + ex.Message, "엑셀 실행 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("엑셀 다운로드 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + ex.Message, "엑셀 다운로드 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void DownloadExcel(UltraGrid Grid, string Name, bool AutoOpen = true)
        {
            try
            {
                if (Directory.Exists(Application.StartupPath + @"\Download") == false)
                    Directory.CreateDirectory(Application.StartupPath + @"\Download");

                string eFileName = Application.StartupPath + @"\DownLoad\" + Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

                UltraGridExcelExporter ExcelExport = new UltraGridExcelExporter();
                ExcelExport.DefaultWorkbookPaletteMode = Infragistics.Documents.Excel.WorkbookPaletteMode.StandardPalette;
                ExcelExport.CellExported += new CellExportedEventHandler(ExcelExport_CellExported);

                ExcelExport.Export(Grid, eFileName);

                if (AutoOpen == true)
                {
                    if (MessageBox.Show("엑셀 다운로드가 성공하였습니다. 열어보시겠습니까?", "엑셀 다운로드 완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = eFileName;
                    p.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("엑셀 실행 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + ex.Message, "엑셀 실행 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("엑셀 다운로드 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + ex.Message, "엑셀 다운로드 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void DownloadExcel(UltraGrid Grid, string Name)
        {
            if (Directory.Exists(Application.StartupPath + @"\Download") == false)
                Directory.CreateDirectory(Application.StartupPath + @"\Download");

            string eFileName = Application.StartupPath + @"\DownLoad\" + Name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

            UltraGridExcelExporter ExcelExport = new UltraGridExcelExporter();
            ExcelExport.CellExported += new CellExportedEventHandler(ExcelExport_CellExported);

            ExcelExport.Export(Grid, eFileName);

            try
            {
                Process p = new Process();
                p.StartInfo.FileName = eFileName;
                p.Start();
            }
            catch
            {
            }
        }

        private void ExcelExport_CellExported(object sender, CellExportedEventArgs e)
        {
            UltraGridCell cell = e.GridRow.Cells[e.GridColumn];
            UltraGridCell[] mergedCells = cell.GetMergedCells();

            if (mergedCells != null)
            {
                bool isLastCell = true;
                foreach (UltraGridCell mergedCell in mergedCells)
                {
                    if (cell.Row.Index < mergedCell.Row.Index)
                    {
                        isLastCell = false;
                        break;
                    }
                }

                if (isLastCell)
                {
                    int rowIndex = e.CurrentRowIndex;
                    int colIndex = e.CurrentColumnIndex;
                    e.CurrentWorksheet.MergedCellsRegions.Add(rowIndex - (mergedCells.Length - 1), colIndex, rowIndex, colIndex);
                }
            }
        }
    }
}
