#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.PP
{
    public partial class PP9110 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        public string sWorkerID = string.Empty;
        #endregion

        #region<CONSTRUCTOR>
        public PP9110()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 로더
        private void PP9110_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "알람수신여부", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ALARMFLAG", "알람구분", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CODENAME", "알람구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "팀구분", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("YesNo");      //예/아니오
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE", @"ISNULL(RELCODE1, '') != '' ");      //예/아니오
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("WALARMFLAG");      //예/아니오
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ALARMFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }


        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(txtworkerid.Text);
                sWorkerID = txtworkerid.Text.Trim();
                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                grid1.DataSource = helper.FillTable("USP_PP9110_S1", CommandType.StoredProcedure//,ref RS_CODE,ref RS_MSG
                                                                   , helper.CreateParameter("WORKERID", sPlantCode, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();



                //if (grid1.Rows.Count > 0)
                //{
                //    for (int i = 0; i < grid1.Rows.Count; i++)
                //    {
                //        if (grid1.Rows[i].Cells["USEFLAG"].Value.ToString() == "Y")
                //        {
                //            //grid1.Rows[i].Cells["USEFLAG"].Appearance.BackColor = Color.LightGreen;
                //            grid1.Rows[i].Cells["USEFLAG"].Appearance.ForeColor = Color.Green;
                //            grid1.Rows[i].Cells["USEFLAG"].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //        }
                //        else
                //        {
                //            //grid1.Rows[i].Cells["USEFLAG"].Appearance.BackColor = Color.Red;
                //            grid1.Rows[i].Cells["USEFLAG"].Appearance.ForeColor = Color.Red;
                //            grid1.Rows[i].Cells["USEFLAG"].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //        }
                //    }
                //}

                //_Common.Grid_Column_Width(this.grid1); //grid 정리용   
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
            }
        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();
                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:

                            #region 수정
                            //param = new System.Data.Common.DbParameter[8];

                            //param[0] = helper.CreateParameter("WORKERID",sWorkerID, DbType.String, ParameterDirection.Input);         // 공장코드
                            //param[1] = helper.CreateParameter("ALARMFLAG", DBHelper.gGetCode(drRow["ALARMFLAG"]), DbType.String, ParameterDirection.Input);           // 품목
                            //param[2] = helper.CreateParameter("PLANTCODE", DBHelper.gGetCode(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input);           // 관리항목
                            //param[3] = helper.CreateParameter("DEPTCODE", DBHelper.gGetCode(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input);         // 공장코드
                            //param[4] = helper.CreateParameter("USER",WIZ.LoginInfo.UserID , DbType.String, ParameterDirection.Input);           // 품목
                            //param[5] = helper.CreateParameter("USEFLAG", DBHelper.gGetCode(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input);           // 관리항목

                            //param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_PP9110_U1", CommandType.StoredProcedure, param);

                            //if (param[6].Value.ToString() == "E") throw new Exception(param[7 ].Value.ToString());
                            helper.ExecuteNoneQuery("USP_PP9110_U1", CommandType.StoredProcedure//,ref RS_CODE , ref RS_MSG
                            , helper.CreateParameter("WORKERID", sWorkerID, DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("ALARMFLAG", Convert.ToString(drRow["ALARMFLAG"]), DbType.String, ParameterDirection.Input)           // 품목
                            , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)           // 관리항목
                            , helper.CreateParameter("DEPTCODE", Convert.ToString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("USER", this.WorkerID, DbType.String, ParameterDirection.Input)           // 품목
                            , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input));           // 관리항목

                            #endregion

                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
            }
        }
        #endregion
    }
}