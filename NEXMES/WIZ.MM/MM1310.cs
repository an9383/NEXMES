#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1310
//   Form Name    : 재고실사반영
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
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
    public partial class MM1310 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public MM1310()
        {
            InitializeComponent();
        }
        #endregion

        #region  < FORM EVENT >
        private void MM1310_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >         
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "재고실사사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGSTARTDATE", "실사 시작일", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGENDDATE", "실사 완료일", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고", false, GridColDataType_emu.VarChar, 160, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 120, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(grid1);

            // 전산재고
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "GETDATE", "실사일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCKQTY", "전산재고량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사재고량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "GAP", "차이값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 300, true, false);

            _GridUtil.SetColumnTextHAlign(grid2, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "STOCKQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "GAP", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "INWORKFLAG", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "REMARK", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["STOCKQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["GAP"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBO BOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");      //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            dtStart_H.Value = DateTime.Now.AddDays(-7);

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
            try
            {
                rtnDtTemp.Clear();

                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                       // 공장코드     
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                        // 일자 FROM
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                          // 일자 TO                                                                                       
                string sTakingORDNo = txtTakingORDNo.Text.Trim();                                                 // 지시번호     

                rtnDtTemp = helper.FillTable("USP_MM1310_S1N"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장 공장코드    
                                            , helper.CreateParameter("AS_TAKINGORDDATE_FROM", sTakingORDDate1, DbType.String, ParameterDirection.Input)     // 일자 FROM          
                                            , helper.CreateParameter("AS_TAKINGORDDATE_TO", sTakingORDDate2, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));   // 지시번호          

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                    else
                    {
                        this.ShowDialog("조회 할 데이터가 없습니다.", Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.

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
            DBHelper helper = new DBHelper(false);

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
                    string sLotNo = Convert.ToString(grid2.Rows[i].Cells["LOTNO"].Value);
                    string sItemCode = Convert.ToString(grid2.Rows[i].Cells["ITEMCODE"].Value);
                    string sStockQty = Convert.ToString(grid2.Rows[i].Cells["STOCKQTY"].Value);
                    string sTakingQty = Convert.ToString(grid2.Rows[i].Cells["TAKINGQTY"].Value);
                    string sUnitCode = Convert.ToString(grid2.Rows[i].Cells["UNITCODE"].Value);
                    string sGap = Convert.ToString(grid2.Rows[i].Cells["GAP"].Value);
                    string sRemark = Convert.ToString(grid2.Rows[i].Cells["REMARK"].Value);

                    helper.ExecuteNoneQuery("USP_MM1310_U2", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_STOCKQTY", sStockQty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGQTY", sTakingQty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_INVQTYDIFF", sGap, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
);

                    if (helper.RSCODE == "E") { this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK); return; }

                    if (grid2.Rows[i].Cells["GAP"].Appearance.BackColor == Color.Gold)
                    {
                        helper.ExecuteNoneQuery("USP_MM1310_U1"
                                               , CommandType.StoredProcedure
                                               , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_TAKINGQTY", sTakingQty, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E") { throw new Exception(helper.RSMSG.ToString()); }
                    }
                }

                helper.ExecuteNoneQuery("USP_MM1310_U3"
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }


        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 공장코드     
                string sTakingOrdNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);      // 품목

                rtnDtTemp = helper.FillTable("USP_MM1310_S2N"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHCODE", sTakingOrdNo, DbType.String, ParameterDirection.Input));



                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();

                        for (int i = 0; i < grid2.Rows.Count; i++)
                        {
                            if ((Convert.ToString(grid2.Rows[i].Cells["TAKINGORDNO"].Value) != "" && Convert.ToString(grid2.Rows[i].Cells["GAP"].Value) != ""))
                            {
                                grid2.Rows[i].Cells["GAP"].Appearance.BackColor = Color.Gold;
                            }

                        }
                    }
                    else
                    {
                        _GridUtil.SetInitUltraGridBind(grid2);
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

        private void DoInquire2()  //PDA 재고 실사정보
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                //PDA 실사 재고 표시

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);     // 공장코드     
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호     
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);       // 품목
                string sWHCode = Convert.ToString(grid1.ActiveRow.Cells["WHCode"].Value);           // 창고O                                                                                       

                if (sItemCode == "ALL") sItemCode = "";
                if (sWHCode == "ALL") sWHCode = "";

                //grid3.DataSource = helper.FillTable("USP_MM1310_S3N", CommandType.StoredProcedure
                //                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장 공장코드    
                //                                             , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)         // 품목         
                //                                             , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)               // 품목         
                //                                             , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input));                    // 창고            

                //grid3.DataBinds();
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
