#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD3200
//   Form Name    : 금형실사확인 및 반영
//   Name Space   : WIZ.MD
//   Created Date :
//   Made By      : WIZCORE
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

#endregion

namespace WIZ.MD
{
    public partial class MD3200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>


        Common _Common = new Common();

        private DataTable DtChange = null;    //grid1
        private DataTable DtChange1 = null;   //grid2
        private DataTable DtChange2 = null;   //grid3

        #endregion

        #region < CONSTRUCTOR >

        public MD3200()
        {
            InitializeComponent();
        }
        #endregion

        #region  MD3200_Load
        private void MD3200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            // 금형실사지시정보조회
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDNo", "재고실사지시번호", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "저정장소", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate", "실사 시작일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate", "실사 완료일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태(G-진행,F-완료 )", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            // 금형실사대상정보조회
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldLoc", "저장위치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);


            //금형실사정보수집조회
            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MoldLoc", "저장위치", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MoldCode", "금형코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "Moldname", "금형명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ItemName", "품목", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "GetData", "수집방법", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "GETDATE", "수집일자", false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            DtChange = (DataTable)grid1.DataSource;
            DtChange1 = (DataTable)grid2.DataSource;
            DtChange2 = (DataTable)grid3.DataSource;

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //보관위치
            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

        }
        #endregion  MD3200_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DtChange.Clear();
                DtChange1.Clear();
                DtChange2.Clear();

                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);         // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value); // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);   // 일자 TO 
                string sTakingORDNo = txtTakingORDNo.Text.Trim();                          // 지시번호
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);           // 보관장소

                //              rtnDtTemp = helper.FillTable("USP_MD3200_S1", CommandType.StoredProcedure   2014.7.2 Lim Y.J.
                grid1.DataSource = helper.FillTable("USP_MD3200_S1N", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)   // 사업장 공장코드
                                                            , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)   // 지시번호
                                                            , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)   // 보관장소
                                                            , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)   // 일자 FROM
                                                            , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)); // 일자 TO


                grid1.DataBinds();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
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
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);
            this.grid1.UpdateData();
            try
            {
                this.Focus();
                base.DoSave();
                /////2014.7.2 임영조 변경
                //if (grid3.ActiveRow == null)
                //{
                //    MessageBox.Show("실사지시정보가 선택되지 않았습니다.확인바람.", " 실사 등록");
                //    return;
                //}

                //string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                //string sPlantCode   = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);   // 사업장
                //string sMoldLoc     = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);     // 보관장소
                //string sMoldCode    = Convert.ToString(grid3.ActiveRow.Cells["MoldCode"].Value);    // 금형코드
                //string sItemCode    = Convert.ToString(grid3.ActiveRow.Cells["ItemCode"].Value);    // 품목

                //if (sItemCode == "ALL") sItemCode = "";

                //helper.ExecuteNoneQuery("USP_MD3200_I1N", CommandType.StoredProcedure
                //                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                //                                        , helper.CreateParameter("PlantCode",   sPlantCode,   DbType.String, ParameterDirection.Input)
                //                                        , helper.CreateParameter("MoldLoc",     sMoldLoc,     DbType.String, ParameterDirection.Input)
                //                                        , helper.CreateParameter("MoldCode",    sMoldCode,    DbType.String, ParameterDirection.Input)
                //                                        , helper.CreateParameter("ItemCode",    sItemCode,    DbType.String, ParameterDirection.Input));

                if (grid1.ActiveRow == null)
                {
                    MessageBox.Show(Common.getLangText("실사지시정보가 선택되지 않았습니다.확인바람.", "MSG"), " 실사 등록");
                    return;
                }

                // 실사 완료 정보 갱신
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 사업장
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);        // 금형저장위치

                helper.ExecuteNoneQuery("USP_MD3200_U2", CommandType.StoredProcedure
                        , helper.CreateParameter("PLANTCODE", sPlantCode.ToString(), DbType.String, ParameterDirection.Input)      // 사업장 공장코드    
                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)             // 출고(투입)일자               
                        , helper.CreateParameter("MoldLoc", sMoldLoc.ToString(), DbType.String, ParameterDirection.Input));        // 금형코드(금형 P/no(25) )         

                // 전산재고 반영
                foreach (DataRow drRow in DtChange1.Rows)
                {
                    helper.ExecuteNoneQuery("USP_MD3200_I2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("PlantCode", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldLoc", drRow["MoldLoc"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("TakingType", "1", DbType.String, ParameterDirection.Input));
                }

                // 실사실적 반영
                foreach (DataRow drRow in DtChange2.Rows)
                {
                    helper.ExecuteNoneQuery("USP_MD3200_I2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("PlantCode", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("MoldLoc", drRow["MoldLoc"].ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("TakingType", "2", DbType.String, ParameterDirection.Input));
                }


                helper.Commit();


            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
            DoInquire();
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
        }
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>

        #endregion

        #region<Event>
        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                DoInquire1();  //금형실사대상정보조회
                DoInquire2();  //금형실사정보수집조회
            }
        }
        private void DoInquire1()  //금형실사대상정보조회
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DtChange1.Clear();
                //금형실사정보수집조회
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);   // 공장코드
                //string sStartDate   = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);        // 시작일자
                //string sEndDate     = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);          // 종료일자
                string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);     // 보관위치
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호

                if (sMoldLoc == "ALL") sMoldLoc = "";
                //         rtnDtTemp = helper.FillTable("USP_MD3200_S2", CommandType.StoredProcedure   2014.7.2 Lim Y.j.
                grid2.DataSource = helper.FillTable("USP_MD3200_S2N", CommandType.StoredProcedure
                                                              , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)   // 사업장 공장코드
                                                              , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)   // 보관위치
                                                              , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)); // 지시번호

                grid2.DataBind();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void DoInquire2()  //금형실사정보수집조회
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DtChange2.Clear();

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);       // 공장코드
                //string sStartDate   = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);        // 시작일자
                //string sEndDate     = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);          // 종료일자
                string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);           // 보관위치
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);   // 지시번호

                grid3.DataSource = helper.FillTable("USP_MD3200_S3", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)       // 사업장 공장코드
                                                                                                                                                                    //, helper.CreateParameter("StartDate",   sStartDate,   DbType.String, ParameterDirection.Input)   // 일자 FROM
                                                                                                                                                                    //, helper.CreateParameter("EndDate",     sEndDate,     DbType.String, ParameterDirection.Input)   // 일자 TO
                                                                   , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)            // 보관위치
                                                                   , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input));  // 지시번호


                grid3.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        //맞는지..
        private void grid2_DoubleClick(object sender, EventArgs e)
        {
            if (grid2.ActiveRow != null)
            {
                DoInquire3(); // row이동 실사정보삭제
                DoInquire5(); // 실사정보대상 삭제
                DoInquire4(); // 금형실사정보수집조회

            }
        }
        private void DoInquire3()  //row이동
        {
            DBHelper helper = new DBHelper(false);


            if (grid2.ActiveRow == null)
            {
                MessageBox.Show(Common.getLangText("실사대상정보가 선택되지 않았습니다.확인바람.", "MSG"), " 실사 등록");
                return;
            }


            try
            {
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PlantCode"].Value);   // 사업장
                string sMoldLoc = Convert.ToString(grid2.ActiveRow.Cells["MoldLoc"].Value);     // 보관장소
                string sMoldCode = Convert.ToString(grid2.ActiveRow.Cells["MoldCode"].Value);    // 금형코드
                string sItemCode = Convert.ToString(grid2.ActiveRow.Cells["ItemCode"].Value);    // 품목


                if (sItemCode == "ALL") sItemCode = "";

                helper.ExecuteNoneQuery("USP_MD3200_I2N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                        );
                helper.Commit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void DoInquire5()  //실사정보대상 삭제
        {
            DBHelper helper = new DBHelper(false);

            if (grid2.ActiveRow == null)
            {
                MessageBox.Show(Common.getLangText("실사대상정보가 선택되지 않았습니다.확인바람.", "MSG"), "실사 등록");
                return;
            }

            try
            {
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PlantCode"].Value);     // 사업장
                string sMoldLoc = Convert.ToString(grid2.ActiveRow.Cells["MoldLoc"].Value);         // 보관장소
                string sMoldCode = Convert.ToString(grid2.ActiveRow.Cells["MoldCode"].Value);       // 금형코드
                string sItemCode = Convert.ToString(grid2.ActiveRow.Cells["ItemCode"].Value);       // 품목


                if (sItemCode == "ALL") sItemCode = "";

                helper.ExecuteNoneQuery("USP_MD3200_I2N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                        );
                helper.Commit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void DoInquire4()  //금형실사정보수집조회
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DtChange2.Clear();

                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PlantCode"].Value);   // 공장코드
                string sMoldLoc = Convert.ToString(grid2.ActiveRow.Cells["MoldLoc"].Value);     // 보관위치
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호

                grid3.DataSource = helper.FillTable("USP_MD3200_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)   // 사업장 공장코드
                                                                                                                                                         //, helper.CreateParameter("StartDate",   sStartDate,   DbType.String, ParameterDirection.Input)   // 일자 FROM
                                                                                                                                                         //, helper.CreateParameter("EndDate",     sEndDate,     DbType.String, ParameterDirection.Input)   // 일자 TO
                                                            , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)   // 보관위치
                                                            , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)); // 지시번호


                grid3.DataBind();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}
