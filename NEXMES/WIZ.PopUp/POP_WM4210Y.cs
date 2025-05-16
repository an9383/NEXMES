#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_WM4410Y
//   Form Name    : 팝업-고객사발주서 상차지시 편성
//   Name Space   : P4017
//   Created Date : 2014.11.21
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Documents.Excel;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_WM4210Y : WIZ.Forms.BaseMDIChildForm
    {
        #region < Member Field >
        private DataTable dtGrid1 = new DataTable();

        private Common _Common = new Common();
        private UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        //비지니스 로직 객체 생성             
        private PopUp_Biz _biz = new PopUp_Biz();

        private string fileId = String.Empty;
        private const int HEADER_ROW_CNT = 1;                   // Excel Upload File Header Row 수

        string fileTemp;
        #endregion < Member Field >

        public POP_WM4210Y()
        {
            InitializeComponent();
        }

        private void POP_WM4210Y_Load(object sender, EventArgs e)
        {
            #region -- Grid1 Setting --
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.caption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            // 거래처 발주번호, 발주유형 품목코드 수량 단위 납기요청일 납품처 국가
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "일련번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOTYPE", "발주유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SODATE", "발주일자", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, "yyyy-MM-dd", "yyyy-mm-dd", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOQTY", "발주수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANSHIPDATE", "납품요청일", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, "yyyy-MM-dd", "yyyy-mm-dd", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "VENDOR", "납품처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DLVYLOC", "하치장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PACKTYPE", "포장유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOGB", "발주구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COUNTRYNAME", "국가", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            dtGrid1 = (DataTable)grid1.DataSource;
            grid1.DataSource = dtGrid1;
            grid1.DataBind();
            #endregion -- Grid1 Setting --

            #region -- ComboBox Setting --
            #endregion -- ComboBox Setting --
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lblFile_Click(object sender, EventArgs e)
        {
            bool exfile = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            if (openFileDialog1.FileName == "") return;

            // C00008 : 발주서정보를 업로드 중 입니다.
            //((WIZ.Forms.BaseMDIChildForm)this.Parent).ShowProgressForm("C00008");

            DBHelper helper = new DBHelper("", true);

            dtGrid1.Clear();

            // 파일의 절대 경로 검색 및 EXCEL 파일 객체 생성
            string filePath = openFileDialog1.FileName;
            Workbook workbook = null;

            try
            {
                workbook = Workbook.Load(filePath, true);
            }

            catch (System.IO.IOException ex)
            {
                //this.ShowDialog("R00163", WIZ.Forms.DialogForm.DialogType.OK); // R00163 : 엑셀파일이 다른프로그램에서 사용중입니다.
                //return;

                //2015-06-23 엑셀 사용중일때 업로드 가능 최재형
                fileTemp = filePath + "_tmp";
                File.Copy(filePath, fileTemp, true);
                workbook = Workbook.Load(fileTemp);
                File.Delete(fileTemp);
                exfile = true;
            }

            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("엑셀파일 형식이 틀립니다. 확인하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); // R00164 : 엑셀파일 형식이 틀립니다. 확인하세요.
                return;
            }
            //catch (Infragistics.Documents.Excel.Serialization.Excel2007.OpenPackagingNonConformanceException ex)
            //{
            //    this.ShowDialog("R00164", WIZ.Forms.DialogForm.DialogType.OK); // R00164 : 엑셀파일 형식이 틀립니다. 확인하세요.
            //    return;
            //}
            //catch (System.InvalidOperationException ex)
            //{
            //    this.ShowDialog("R00164", WIZ.Forms.DialogForm.DialogType.OK); // R00164 : 엑셀파일 형식이 틀립니다. 확인하세요.
            //    return;
            //}
            //catch (System.NotSupportedException     ex)
            //{
            //    this.ShowDialog("R00164", WIZ.Forms.DialogForm.DialogType.OK); // R00164 : 엑셀파일 형식이 틀립니다. 확인하세요.
            //    return;
            //}
            //catch (System.ArgumentException         ex)
            //{
            //    this.ShowDialog("R00164", WIZ.Forms.DialogForm.DialogType.OK); // R00164 : 엑셀파일 형식이 틀립니다. 확인하세요.
            //    return;
            //}

            // 엑셀 파일에 Sheet1이 없는 경우(엑셀 양식에 Sheet1에 발주서업로드 대상이 들어 있어야 함)
            if (workbook.Worksheets.Count == 0)
            {
                this.ShowDialog(Common.getLangText("발주서 업로드 엑셀 시트가 잘못되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            Worksheet worksheet = workbook.Worksheets[0];
            bool iserror = false;
            bool isrowerror = false;
            string plantcode = "1000";
            string itemcode = String.Empty;
            string sodate = String.Empty;
            string planshipdate = String.Empty;
            int rowcount = 0;

            // WorkSheet에 있는 Row를 DataTable에 추가
            foreach (WorksheetRow worksheetrow in worksheet.Rows)
            {
                rowcount++;
                isrowerror = false;

                // HEADER 행 SKIP 발주량이 없을 경우 SKIP
                if (rowcount <= HEADER_ROW_CNT) continue;
                if (Convert.ToString(worksheetrow.Cells[7].Value) == "") continue;

                DataRow datarow = this.dtGrid1.NewRow();
                datarow["PLANTCODE"] = plantcode;
                itemcode = worksheetrow.Cells[2].Value.ToString();
                datarow["ITEMCODE"] = itemcode;
                datarow["ITEMNAME"] = this.GetItemName(plantcode, itemcode);
                datarow["SONO"] = worksheetrow.Cells[0].Value;
                datarow["SOTYPE"] = worksheetrow.Cells[1].Value;
                datarow["CARTYPE"] = worksheetrow.Cells[3].Value;
                datarow["CARTYPE"] = worksheetrow.GetCellValue(3);
                datarow["CUSTCODE"] = worksheetrow.Cells[4].Value;
                datarow["CUSTNAME"] = this.GetCustName(plantcode, datarow["CUSTCODE"].ToString());
                datarow["MakeDate"] = System.DateTime.Now.ToString("yyyy-MM-dd"); //2015.04.28 등록일시 추가

                // Excel에서 import 받는 형이 double일 경우 날짜 형식으로 변경
                if (worksheetrow.Cells[5].Value.GetType() == typeof(double))
                    sodate = DateTime.FromOADate(Convert.ToDouble(worksheetrow.Cells[5].Value)).ToString("yyyy-MM-dd");
                else
                {
                    sodate = Convert.ToString(worksheetrow.Cells[5].Value);
                }
                if (!Regex.IsMatch(sodate, @"\d{4,4}-\d{2,2}-\d{2,2}"))
                    iserror = true;

                datarow["SODATE"] = sodate;
                // Excel에서 import 받는 형이 double일 경우 날짜 형식으로 변경
                if (worksheetrow.Cells[6].Value.GetType() == typeof(double))
                    planshipdate = DateTime.FromOADate(Convert.ToDouble(worksheetrow.Cells[6].Value)).ToString("yyyy-MM-dd");
                else
                {
                    planshipdate = Convert.ToString(worksheetrow.Cells[6].Value);
                }
                if (!Regex.IsMatch(sodate, @"\d{4,4}-\d{2,2}-\d{2,2}"))
                    iserror = true;
                datarow["PLANSHIPDATE"] = planshipdate;

                // 발주수량이 숫자 형식이 아니면, Error를 등록하고, DB에 업데이트 하지 않음
                double soqty = 0;
                if (!Double.TryParse(worksheetrow.Cells[7].Value.ToString(), out soqty))
                {
                    iserror = true;
                    isrowerror = true;
                    datarow.RowError = ((WIZ.Forms.BaseMDIChildForm)this.Owner).FormInformation.GetMessage("R00162");
                }

                datarow["SOQTY"] = soqty;
                datarow["UNITCODE"] = worksheetrow.Cells[8].Value;
                datarow["VENDOR"] = worksheetrow.Cells[9].Value;
                datarow["DLVYLOC"] = worksheetrow.Cells[10].Value;
                datarow["COUNTRYNAME"] = worksheetrow.Cells[11].Value;
                datarow["PACKTYPE"] = worksheetrow.Cells[12].Value;
                datarow["SOGB"] = worksheetrow.Cells[13].Value;
                datarow["REMARK"] = worksheetrow.Cells[14].Value;

                this.dtGrid1.Rows.Add(datarow);

                if (isrowerror) continue;

                DbParameter[] parameters = new DbParameter[]
                                        {
                                         helper.CreateParameter("PLANTCODE",    DbType.String, datarow["PLANTCODE"])
                                        ,helper.CreateParameter("SONO",         DbType.String, datarow["SONO"])
                                        ,helper.CreateParameter("SEQNO",        DbType.Int32,  1)
                                        ,helper.CreateParameter("CUSTCODE",     DbType.String, datarow["CUSTCODE"])
                                        ,helper.CreateParameter("SOTYPE",       DbType.String, datarow["SOTYPE"])
                                        ,helper.CreateParameter("SODATE",       DbType.String, datarow["SODATE"])
                                        ,helper.CreateParameter("ITEMCODE",     DbType.String, datarow["ITEMCODE"])
                                        ,helper.CreateParameter("CARTYPE",      DbType.String, datarow["CARTYPE"])
                                        ,helper.CreateParameter("SOQTY",        DbType.Double, datarow["SOQTY"])
                                        ,helper.CreateParameter("UNITCODE",     DbType.String, datarow["UNITCODE"])
                                        ,helper.CreateParameter("PLANSHIPDATE", DbType.String, datarow["PLANSHIPDATE"])
                                        ,helper.CreateParameter("VENDOR",       DbType.String, datarow["VENDOR"])
                                        ,helper.CreateParameter("DLVYLOC",      DbType.String, datarow["DLVYLOC"])
                                        ,helper.CreateParameter("COUNTRYNAME",  DbType.String, datarow["COUNTRYNAME"])
                                        ,helper.CreateParameter("PACKTYPE",     DbType.String, datarow["PACKTYPE"])
                                        ,helper.CreateParameter("SOGB",         DbType.String, datarow["SOGB"])
                                        ,helper.CreateParameter("REMARK",       DbType.String, datarow["REMARK"])
                                        ,helper.CreateParameter("WORKERID",     DbType.String, this.WorkerID)
                                        };
                helper.ExecuteNoneQuery("USP_WM4200_I2", CommandType.StoredProcedure, parameters);
                if (helper.RSCODE == "E")
                {
                    iserror = true;
                    datarow.RowError = ((WIZ.Forms.BaseMDIChildForm)this.Owner).FormInformation.GetMessage(helper.RSMSG);
                }
            }

            grid1.DataSource = dtGrid1;
            grid1.DataBind();

            //프로그래스 바 자원 해제
            //((WIZ.Forms.BaseMDIChildForm)this.Parent).clo

            if (iserror)
            {
                helper.Rollback();
                this.ShowDialog(Common.getLangText("발주서 업로드 중 오류가 발생했습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            }
            else
            {
                helper.Commit();
                dtGrid1.AcceptChanges();
                this.grid1.UpdateData();
                this.ShowDialog(Common.getLangText("발주서 업로드가 완료되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                this.Close();
            }
        }

        private string GetItemName(string plantcode, string itemcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(ITEMNAME, '') FROM TBM0100Y WHERE PLANTCODE = '" + plantcode + "' AND ITEMCODE = '" + itemcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetCustCode(string plantcode, string refcustcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CustCode, '') FROM TBM0300 WHERE PLANTCODE = '" + plantcode + "' AND REFCUSTCODE = '" + refcustcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetCustName(string plantcode, string custcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CustName, '') FROM TBM0300 WHERE PlantCode = '" + plantcode + "' AND CUSTCODE = '" + custcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetWorkCenterName(string plantcode, string workcentercode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(WorkCenterName, '') FROM TBM0600 WHERE PlantCode = '" + plantcode + "' AND WorkCenterCode = '" + workcentercode + "'"));

            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetOPName(string plantcode, string opcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(OPName, '') FROM TBM0400 WHERE PlantCode = '" + plantcode + "' AND OPCode = '" + opcode + "'"));

            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }
    }
}
