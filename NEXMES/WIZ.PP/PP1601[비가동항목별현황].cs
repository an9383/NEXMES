using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP1601 : Form
    {
        #region<MEMBER AREA>
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();
        #endregion

        public PP1601(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [사업장 설비 명 Parameter Show] //사업장,  설비
                switch (i)
                {
                    case 0:  //사업장
                        cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper();
                        break;

                    case 1: //팀구분
                        cboDeptCode.Value = argument[1].ToUpper() == "" ? "ALL" : argument[1].ToUpper();
                        break;

                    case 2: //작업장
                        txtOPCode.Text = argument[2].ToUpper();
                        break;

                    case 3: //작업라인
                        txtWorkCenterCode.Text = argument[3].ToUpper();
                        break;

                    case 4: //비가동구분
                        cboStopType_H.Text = argument[4].ToUpper() == "" ? "ALL" : argument[4].ToUpper();
                        break;

                    case 5: //비가동항목
                        txtStopCode.Text = argument[5].ToUpper();
                        break;

                    case 6: //시작일자
                        CboStartdate_H.Value = argument[6].ToUpper(); //설비명
                        break;

                    case 7: //종료일자
                        CboEnddate_H.Value = argument[7].ToUpper(); //설비명
                        break;

                    case 8: //종료일자
                        txtOPName.Text = argument[8].ToUpper(); //설비명
                        break;

                }
                #endregion
            }
        }
        #endregion

        #region<METHOD AREA>
        private void search()
        {
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);          //사업장코드
            string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
            string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
            string sOPCode = txtOPCode.Text.Trim();
            string stxtWorkCenterCode = txtWorkCenterCode.Text.Trim();
            string sStopType = DBHelper.nvlString(cboStopType_H.Value);
            string sStopCode = txtStopCode.Text.Trim();
            string sDeptCode = DBHelper.nvlString(cboDeptCode.Value, "");     //팀구분

            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[11];

            try
            {
                param[0] = helper.CreateParameter("@STARTDATE", sStartDate, DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@ENDDATE", sEndDate, DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@OPCODE", sOPCode, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@WorkCenterCode", stxtWorkCenterCode, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("@StopType", sStopType, DbType.String, ParameterDirection.Input);
                param[6] = helper.CreateParameter("@StopCode", sStopCode, DbType.String, ParameterDirection.Input);
                param[7] = helper.CreateParameter("@DeptCode", sDeptCode, DbType.String, ParameterDirection.Input);
                param[8] = helper.CreateParameter("@Param1", DBNull.Value, DbType.String, ParameterDirection.Input);
                param[9] = helper.CreateParameter("@Param2", DBNull.Value, DbType.String, ParameterDirection.Input);
                param[10] = helper.CreateParameter("@Param3", DBNull.Value, DbType.String, ParameterDirection.Input);

                rtnDtTemp = helper.FillTable("USP_PP1601_S1", CommandType.StoredProcedure, param);

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                UltraGridRow ugr = grid1.DoSummaries(new string[] { "STATUSTIME" });


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }


        }

        private void PP1601_Load(object sender, EventArgs e)
        {

            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASS", "비가동유형", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASSNM", "비가동\n\r유형명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE", "비가동구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPENM", "비가동\n\r구분명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "비가동시간(H)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스 셋팅
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPCLASS");  //비가동 유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");  //비가동 타입
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode", @"ISNULL(RELCODE1, '') != '' ");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            // WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion 콤보박스 셋팅

            cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장
            cboDeptCode.Value = argument[1].ToUpper() == "" ? "ALL" : argument[1].ToUpper(); //사업장
            cboStopType_H.Value = argument[4].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장

            search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
