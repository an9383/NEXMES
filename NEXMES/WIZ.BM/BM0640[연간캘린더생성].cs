#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0640
//   Form Name    : 연간캘린더생성
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 연간 일자별 주차/월/요일을 코드화 관리
// *---------------------------------------------------------------------------------------------*                                                                                               
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM0640 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        //임시로 사용할 데이터테이블 생성
        DataTable DtChange = new DataTable();

        #endregion

        #region < CONSTRUCTOR >
        public BM0640()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void BM0640_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RPT_DATE", "일자", true, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RPT_WEEK", "주차", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RPT_MONTH", "월", true, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYWEEK", "요일", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", true, GridColDataType_emu.DateTime, 180, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "RPT_WEEK", Infragistics.Win.HAlign.Right);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["RPT_DATE"].Header.Appearance.ForeColor = Color.SkyBlue;


            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = "10";

            #endregion

            DtChange = (DataTable)grid1.DataSource;
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            this.DataSelect();
        }

        #endregion

        #region < EVENT AREA >
        private void btnMake_Click(object sender, EventArgs e)
        {
            string sCboYear = Convert.ToString(cbo_YEAR_H.Value).Substring(0, 4);

            DialogResult dialogResult = this.ShowDialog(Common.getLangText(sCboYear + "년의 캘린더 정보를 등록하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);

            if (dialogResult == DialogResult.Cancel)
                return;

            if (Convert.ToString(cbo_PLANTCODE_H.Value) == "")
            {
                this.ShowDialog(Common.getLangText("사업장을 선택한 후 버튼을 누르세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

                helper.ExecuteNoneQuery("USP_BM0640_I1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_YEAR", sCboYear, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    helper.Commit();
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                base.DoInquire();
            }
        }

        #endregion

        #region < USER METHOD AREA >

        private void DataSelect()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DtChange.Clear();
                _GridUtil.Grid_Clear(grid1);



                this.ShowProgressForm("C00004");

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sYear = Convert.ToString(cbo_YEAR_H.Value);


                rtnDtTemp = helper.FillTable("USP_BM0640_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_YEAR", sYear, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        DtChange = rtnDtTemp;
                        grid1.DataSource = DtChange;
                        grid1.DataBinds();
                        //this.grid1.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                helper.Rollback();
            }
            finally
            {
                this.ClosePrgForm();
                base.DoInquire();
                helper.Close();
            }
        }
        #endregion
    }
}
