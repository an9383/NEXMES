#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_MM0130
//   Form Name    : 발주정보 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < HEADER AREA >

using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace WIZ.PopUp
{
    public partial class POP_MM0130 : WIZ.Forms.BasePopupForm
    {

        #region < MEMBER AREA >
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        ////비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        private string plantCode = string.Empty; //plantcode default 설정

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public POP_MM0130()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");
        }
        #endregion

        #region < FORM LOAD >
        private void POP_MM0130_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POORDERDATE", "발주일", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COILNO", "업체 LOT NO", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "업체", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            // _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            // _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC",      "규격",       true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",      "품목분류",   true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            //   _GridUtil.InitColumnUltraGrid(grid1, "POORDERQTY",    "발주량",    true, GridColDataType_emu.IntegerNonNegative, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "TOTINQTY",      "총 입고량",  true, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "TOTGAINQTY",    "총 가입고량(ⓑ)", true, GridColDataType_emu.Integer, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "REINQTY",       "입고잔량(ⓐ-ⓑ)", true, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "LASTINDATE",    "최종입고일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "FINISHFLAG",    "진행여부",   true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "SAVEBUTTON",    "가입고",     true, GridColDataType_emu.Button, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "MAKER",         "등록자",     true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",      "등록일시",   true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",        "수정자",     true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",      "수정일시",   true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //공장 콤보박스 기본 value 설정
            cboPlantCode_H.Value = this.plantCode;
            cboStartDate_H.Value = DateTime.Now.AddDays(-5);

            //조회
            search();
        }
        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                string PLANTCODE = Convert.ToString(cboPlantCode_H.Value);
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string PONO = txtPoNo_H.Text.Trim();
                string COILNO = lblCoilNo.Text.Trim();
                string ITEMCODE = txtItemCode.Text.Trim();
                string ITEMNAME = txtItemName.Text.Trim();
                string CUSTCODE = txtCustCode.Text.Trim();
                string CUSTNAME = txtCustName.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_POP_MM0130_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PONO", PONO, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_COILNO", COILNO, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            //DataTable TmpDt = new DataTable();
            //TmpDt.Columns.Add("WorkerID", typeof(string));
            //TmpDt.Columns.Add("WorkerName", typeof(string));
            //TmpDt.Columns.Add("OPCode", typeof(string));
            //TmpDt.Columns.Add("LineCode", typeof(string));
            //TmpDt.Columns.Add("WorkCenterCode", typeof(string));

            //TmpDt.Rows.Add(new object[] { e.Row.Cells["WorkerID"].Value, e.Row.Cells["WorkerName"].Value
            //    , e.Row.Cells["OPCode"].Value, e.Row.Cells["LineCode"].Value, e.Row.Cells["WorkCenterCode"].Value });

            string TmpDt = e.Row.Cells["PLANTCODE"].Value.ToString() + "," + e.Row.Cells["COILNO"].Value.ToString() + "," + e.Row.Cells["ITEMCODE"].Value.ToString() + "," + e.Row.Cells["CUSTCODE"].Value.ToString() + "," + e.Row.Cells["UNITCODE"].Value.ToString() + "," + e.Row.Cells["PONO"].Value.ToString();

            this.Tag = TmpDt;

            this.Close();
        }

        private void txtWorkerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

    }
}
