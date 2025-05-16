#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0050
//   Form Name    : 3차원 측정 이력 조회
//   Name Space   : WIZ.BM
//   Created Date : 2018-03-26
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      : 
//   Description  : 3차원 측정 이력 조회
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
    public partial class QM0050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public QM0050()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0050_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "검사일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "검사값", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);

            grid1.Columns["SPECNOL"].Format = "#,##0.##";
            grid1.Columns["SPECLSL"].Format = "#,##0.##";
            grid1.Columns["SPECUSL"].Format = "#,##0.##";
            grid1.Columns["INSPVALUE"].Format = "#,##0.##";

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region COMBOBOX SETTING

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion

            #region POPUP SETTING
            //품목
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" }); ;
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_QM0050_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBind();

                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (grid1.Rows[i].Cells["INSPRESULT"].Value.ToString() == "NG")
                            {
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.White;
                            }
                        }
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ClosePrgForm();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); // 조회할 데이터가 없습니다.
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion
    }
}
