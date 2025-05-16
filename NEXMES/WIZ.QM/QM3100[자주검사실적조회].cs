#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM3100
//   Form Name    : 자주검사실적조회
//   Name Space   : WIZ.QM
//   Created Date : 2017-06-15
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM3100 : WIZ.Forms.BaseMDIChildForm
    {
        #region< MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();


        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region< CONSTRUCTOR >
        public QM3100()
        {
            InitializeComponent();
        }
        #endregion

        #region< FORM EVENT >
        private void QM3100_Load(object sender, EventArgs e)
        {
            #region ▶ GRID
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRCODE", "측정항목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRNAME", "측정항목명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRDATE", "측정일자", false, GridColDataType_emu.DateTime, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRVALUE", "측정값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESRRESULT", "측정결과", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);


            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "MESRNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECNOL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECUSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECLSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "MESRVALUE", Infragistics.Win.HAlign.Right);

            #endregion

            #region --- Combobox & Popup Setting ---
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });

            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;
            CboStartDate_H.Value = DateTime.Now.AddDays(-7);
            CboEndDate_H.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            _GridUtil.SetInitUltraGridBind(grid1);

            if (Convert.ToDateTime(CboStartDate_H.Value) > Convert.ToDateTime(CboEndDate_H.Value))
            {
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sItemCode = DBHelper.nvlString(txtItemCode_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_QM3100_S1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AD_STARTDATE", CboStartDate_H.Value, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AD_ENDDATE", CboEndDate_H.Value, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBind();
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ClosePrgForm();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); // 조회할 데이터가 없습니다.
                        return;
                    }

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(grid1.Rows[i].Cells["MESRRESULT"].Value) != "OK")
                        {
                            grid1.Rows[i].Cells["MESRRESULT"].Appearance.BackColor = Color.LightPink;
                            grid1.Rows[i].Cells["MESRRESULT"].Appearance.ForeColor = Color.Black;
                        }
                        else
                        {
                            grid1.Rows[i].Cells["MESRRESULT"].Appearance.BackColor = Color.LightBlue;
                            grid1.Rows[i].Cells["MESRRESULT"].Appearance.ForeColor = Color.Black;
                        }
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgForm();
                helper.Close();
            }

        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 클릭
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 클릭
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion
    }
}
