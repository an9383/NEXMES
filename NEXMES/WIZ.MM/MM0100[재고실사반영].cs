#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0100
//   Form Name    : 재고실사반영
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-30
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고실사반영
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace WIZ.MM
{
    public partial class MM0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();


        #endregion

        #region < CONSTRUCTOR >

        public MM0100()
        {
            InitializeComponent();
        }
        #endregion

        #region  < FORM EVENT >
        private void MM0100_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >         
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "재고실사사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGSTARTDATE", "실사 시작일", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGENDDATE", "실사 완료일", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHTYPE", "창고구분", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(grid1);


            // 전산재고
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHTYPE", "창고구분", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "GETDATE", "실사일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "전산재고량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사재고량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "GAP", "차이값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 300, true, false);

            _GridUtil.SetColumnTextHAlign(grid2, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "NOWQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "GAP", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "REMARK", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["NOWQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["GAP"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBO BOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");      //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_WHCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetWhCode("", grid1);

            //rtnDtTemp = _Common.GET_BM0080_CODE("");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                //rtnDtTemp.Clear();

                base.DoInquire();

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                                  // 사업장
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);                   // 일자 FROM
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);                     // 일자 TO   
                string sWhcode = Convert.ToString(cbo_WHCODE_H.Value);                                     // 지시창고                                               
                string sTakingORDNo = txt_TAKINGORDERNO_H.Text.Trim();                                          // 지시번호     

                rtnDtTemp = helper.FillTable("USP_MM0100_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장    
                                            , helper.CreateParameter("AS_TAKINGORDDATE_FROM", sTakingORDDate1, DbType.String, ParameterDirection.Input)     // 일자 FROM          
                                            , helper.CreateParameter("AS_TAKINGORDDATE_TO", sTakingORDDate2, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                            , helper.CreateParameter("AS_WHCODE", sWhcode, DbType.String, ParameterDirection.Input)     // 지시창고
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));   // 지시번호  

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
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
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
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
            if (grid2.Rows.Count == 0)
            {
                ShowDialog(Common.getLangText("입력된 실사내용이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false, "", true);

            try
            {
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);

                if (grid1.ActiveRow == null)
                {
                    this.ShowDialog("재고실사지시가 선택되지 않았습니다.", Forms.DialogForm.DialogType.OK);
                    return;
                }

                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    string sPlantCode = Convert.ToString(grid2.Rows[i].Cells["PLANTCODE"].Value);
                    string sWHCode = Convert.ToString(grid2.Rows[i].Cells["WHCODE"].Value);
                    string sWHType = Convert.ToString(grid2.Rows[i].Cells["WHTYPE"].Value);
                    string sLotNo = Convert.ToString(grid2.Rows[i].Cells["LOTNO"].Value);
                    string sItemCode = Convert.ToString(grid2.Rows[i].Cells["ITEMCODE"].Value);
                    string sNowQty = Convert.ToString(grid2.Rows[i].Cells["NOWQTY"].Value);
                    string sTakingQty = Convert.ToString(grid2.Rows[i].Cells["TAKINGQTY"].Value);
                    string sUnitCode = Convert.ToString(grid2.Rows[i].Cells["UNITCODE"].Value);
                    string sGap = Convert.ToString(grid2.Rows[i].Cells["GAP"].Value);
                    string sRemark = Convert.ToString(grid2.Rows[i].Cells["REMARK"].Value);

                    helper.ExecuteNoneQuery("USP_MM0100_U2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHTYPE", sWHType, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_NOWQTY", sNowQty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGQTY", sTakingQty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_INVQTYDIFF", sGap, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E") { throw new Exception(helper.RSMSG.ToString()); }

                    helper.ExecuteNoneQuery("USP_MM0100_U1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHTYPE", sWHType, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGQTY", sTakingQty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E") { throw new Exception(helper.RSMSG.ToString()); }

                }

                helper.ExecuteNoneQuery("USP_MM0100_U3"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E") { throw new Exception(helper.RSMSG.ToString()); }

                helper.Commit();

                this.ShowDialog("재고실사 조정이 완료되었습니다.", Forms.DialogForm.DialogType.OK);

            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                DoInquire();
            }
        }
        #endregion

        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            GetWhCode(Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value), grid2);

            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 공장코드    
                string sTakingOrdNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);   // 지시번호
                //string sWhCode = Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value);        // 지시창고
                string sWhType = Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value);        // 창고구분

                rtnDtTemp = helper.FillTable("USP_MM0100_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();

                        for (int i = 0; i < grid2.Rows.Count; i++)
                        {
                            if (((Convert.ToString(grid2.Rows[i].Cells["TAKINGORDNO"].Value) != "" && Convert.ToString(grid2.Rows[i].Cells["GAP"].Value) != "")
                                && Convert.ToString(grid2.Rows[i].Cells["GAP"].Value) != "0"))
                            {
                                grid2.Rows[i].Cells["GAP"].Appearance.BackColor = Color.Gold;
                            }

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
                this.ShowErrorMessage(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }

        }

        #endregion

        #region < METHOD AREA >

        private void GetWhCode(string sWhType, WIZ.Control.Grid grid)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0100_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

                WIZ.UltraGridUtil.SetComboUltraGrid(grid, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

    }
}
