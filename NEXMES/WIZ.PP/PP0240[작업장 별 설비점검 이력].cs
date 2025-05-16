#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0240
//   Form Name    : 작업장별 설비점검이력
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP0240 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        #endregion

        #region < CONSTRUCTOR >
        public PP0240()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장

        }
        #endregion

        #region < FORM LOAD >
        private void PP0240_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKRECDATE", "설비점검일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKCYCLE", "설비점검주기", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKNAME", "검사항목명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKYEAR", "설비점검년", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKQUARTER", "설비점검분기", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKMONTH", "설비점검월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKVALUE", "점검값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKRESULT", "점검결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKDATE", "점검일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHKUSER", "설비점검자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cbo_PLANTCODE_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHKCYCLE"); //설비점검주기
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHKCYCLE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //시간
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

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
            DBHelper helper = new DBHelper(false);

            try
            {
                //base.DoInquire();
                if (!CheckData())
                {
                    return;
                }

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                  //사업장코드                                                                                          
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sWcCode = txt_WORKCENTERCODE_H.Text.Trim();


                rtnDtTemp = helper.FillTable("USP_PP0240_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWcCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);

                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (grid1.Rows[i].Cells["MACHKRESULT"].Value.ToString() == "NG")
                            {
                                grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grid1.Rows[i].Cells["MACHKVALUE"].Appearance.BackColor = Color.DarkCyan;
                                grid1.Rows[i].Cells["MACHKVALUE"].Appearance.ForeColor = Color.White;
                            }
                        }

                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < USER METHOD AREA >

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        #endregion
    }
}