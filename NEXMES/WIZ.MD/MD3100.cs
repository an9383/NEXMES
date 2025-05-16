#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MD3100
//   Form Name    : 금형실사(수기)
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace WIZ.MD
{
    public partial class MD3100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Common _Common = new Common();
        #endregion

        #region < CONSTRUCTOR >

        public MD3100()
        {
            InitializeComponent();
        }
        #endregion

        #region  MD3100_Load

        private void MD3100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();

            // 실사지시정보
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDNo", "재고실사지시번호", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "저장장소", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate", "실사 시작일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate", "실사 완료일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태(진행, 완료 )", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            // 실사 대상정보
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldLoc", "현보관장소", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemNmae", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            // 실사정보
            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MoldLoc", "현보관장소", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ItemNmae", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "GetData", "수집방법 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "GETDATE", "수집일자 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스

            //사업장
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
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
        #endregion  MD3100_Load

        #region<METHOD AREA>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                base.DoInquire();  //사업장, 지시번호, 보관장소, 재고실사실 시작일                                           
                string sTakingORDNo = txtTakingORDNo.Text.Trim();                            // 지시번호                                       
                string sMoldLoc = cboMoldLoc_H.Text;                                     // 보관장소                                              
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);         // 공장코드     
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value); // 일자 FROM                                                                                                                                                                    
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);   // 일자 TO     

                grid1.DataSource = helper.FillTable("USP_MD3100_S3N", CommandType.StoredProcedure
                                                              , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("TakingORDDate1", sTakingORDDate1, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("TakingORDDate2", sTakingORDDate2, DbType.String, ParameterDirection.Input));

                grid1.DataBind();


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

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                DoInquire1();  //금형실사대상정보조회
                DoInquire2();  //금형실사정보수집조회
                txtTakingORDNo.Text = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);
            }
        }

        private void DoInquire1()  //금형실사대상정보조회
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);     // 공장코드     
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);   // 지시번호     
                string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);       // 저장위치                                                                                     

                if (sMoldLoc == "ALL") sMoldLoc = "";

                grid2.DataSource = helper.FillTable("USP_MD3100_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input));
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

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);     // 공장코드
                string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);         // 보관위치
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호

                grid3.DataSource = helper.FillTable("USP_MD3100_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)       // 공장코드
                                                                    , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)           // 보관위치
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

        private void grid2_DoubleClick(object sender, EventArgs e)
        {
            if (grid2.ActiveRow != null)
            {
                DoInquire3(); //row이동
                DoInquire4(); //금형실사정보수집조회
                              // DoDelete();   //기존 row값 지우기
                DoInquire1(); //금형실사대상정보조회 재 조회 필요 2014.7.2 Lim Y.J.
            }
        }

        private void DoInquire3()  //row이동
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PlantCode"].Value);   // 사업장
                string sMoldLoc = Convert.ToString(grid2.ActiveRow.Cells["MoldLoc"].Value);     // 보관장소
                string sMoldCode = Convert.ToString(grid2.ActiveRow.Cells["MoldCode"].Value);    // 금형코드
                string sItemCode = Convert.ToString(grid2.ActiveRow.Cells["ItemCode"].Value);    // 품목

                if (sItemCode == "ALL") sItemCode = "";

                helper.ExecuteNoneQuery("USP_MD3100_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
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

                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PlantCode"].Value);   // 공장코드
                string sMoldLoc = Convert.ToString(grid2.ActiveRow.Cells["MoldLoc"].Value);     // 보관위치
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호

                grid3.DataSource = helper.FillTable("USP_MD3100_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장 공장코드
                                                                    , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)       // 보관위치
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

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoSave();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                //2014.7.2 LIM y.j. 추가
                if (grid1.ActiveRow != null)
                {
                    string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);       // 사업장
                    string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);     // 지시번호
                    string sMoldLoc = Convert.ToString(grid1.ActiveRow.Cells["MoldLoc"].Value);         // 금형저장위치

                    helper.ExecuteNoneQuery("USP_MD3100_U2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("PLANTCODE", sPlantCode.ToString(), DbType.String, ParameterDirection.Input)      // 공장코드    
                                                           , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)             // 지시번호               
                                                           , helper.CreateParameter("MoldLoc", sMoldLoc.ToString(), DbType.String, ParameterDirection.Input));        // 금형저장위치
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
                DoInquire();
            }
        }

        public override void DoDelete()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                foreach (DataRow drRow in ((DataTable)grid2.DataSource).Rows)
                {

                    drRow.RejectChanges();

                    helper.ExecuteNoneQuery("USP_MD3100_U2"
                                      , CommandType.StoredProcedure
                                      , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 공장(사업부)
                                      , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)           // 금형코드(금형 P/no(25) )
                                      , helper.CreateParameter("TakingORDNo", drRow["TakingORDNo"].ToString(), DbType.String, ParameterDirection.Input));      // 품목코드                                                         

                }
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

        private void DoDeletegrid3()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(grid3.ActiveRow.Cells["PLANTCODE"].Value);   // 사업장
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호
                string sMoldCode = Convert.ToString(grid3.ActiveRow.Cells["MoldCode"].Value);    // 금형코드

                helper.ExecuteNoneQuery("USP_MD3100_D2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));
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

        }     //2014.7.2 Lim Y.J. 추가  -실사 정보 수정 처리

        private void grid3_DoubleClick(object sender, EventArgs e)
        {
            if (grid3.ActiveRow != null)
            {
                DoDeletegrid3(); //금형실사 정보 삭제
                DoInquire4();    //금형실사정보수집조회
                DoInquire1();    //금형실사대상정보조회 재 조회 필요 2014.7.2 Lim Y.J.
            }

        }      // 실사된 정보 더블 클릭 하면 실사 정보에서 삭제 
        #endregion
    }
}

