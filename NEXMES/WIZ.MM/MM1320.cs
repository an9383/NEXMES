#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1320
//   Form Name    : 재고실사이력 정보 조회
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
    public partial class MM1320 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public MM1320()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM1320_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "재고실사사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGSTARTDATE", "실사 시작일", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGENDDATE", "실사 완료일", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고", false, GridColDataType_emu.VarChar, 260, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 150, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, false, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(grid1);


            // 전산 및 실사 재공정보 이력
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGTYPE", "구분", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 150, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOT NO.", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCKQTY", "전산재고", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사재고", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INVQTYDIFF", "수량차이", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "반영사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "반영일자", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "반영자", false, GridColDataType_emu.VarChar, 100, true, false);

            _GridUtil.SetColumnTextHAlign(grid2, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "STOCKQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "INVQTYDIFF", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "REMARK", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["STOCKQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["INVQTYDIFF"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            //PDA 실사정보

            //_GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            //// InitColumnUltraGrid 90 180 65 165 134 97 150 96 164 55 78 64 100 100 
            //_GridUtil.InitColumnUltraGrid(grid3, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "TakingORDNo", "지시번호", false, GridColDataType_emu.VarChar, 260, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "WHName", "장고명", false, GridColDataType_emu.VarChar, 165, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "LotNO", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "TakingType", "실사구분", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "Status", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "StockQty", "재고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "MakeDate", "생성일자", false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "TakingQty", "실사량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "RecDate", "수불일자", false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "WorkerID", "작업자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "DayNight", "주야구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "ShiftGb", "조구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "ReportQty", "전산재고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid3, "InvQtyDiff", "실사차이", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            //_GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";



            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");      //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 진행상태 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");     // 진행상태

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");      //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("ShiftGb");   //조구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ShiftGb", rtnDtTemp, "CODE_ID", "CODE_NAME");     //조구분

            //rtnDtTemp = _Common.GET_TBM0000_CODE("DayNight");   //주야구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");     //주야구분

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
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sTakingORDStDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sTakingORDEndDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sTakingORDNo = txtTakingORDNo.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_MM1320_S1N"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDDATE_FROM", sTakingORDStDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDDATE_TO", sTakingORDEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog("조회 할 데이터가 없습니다", WIZ.Forms.DialogForm.DialogType.OK);  // 조회할 데이터가 없습니다.
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
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
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
        }
        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 공장코드     
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);   // 지시번호     

                rtnDtTemp = helper.FillTable("USP_MM1320_S2N"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)      // 사업장 공장코드    
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));    // 품목       

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                        this.ShowDialog("조회 할 데이터가 없습니다", WIZ.Forms.DialogForm.DialogType.OK);  // 조회할 데이터가 없습니다.
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                    return;
                }

                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (Convert.ToString(grid2.Rows[i].Cells["TAKINGTYPE"].Value) == "실사")
                        grid2.Rows[i].Cells["TAKINGQTY"].Appearance.BackColor = Color.Gold;
                    else
                        grid2.Rows[i].Cells["STOCKQTY"].Appearance.BackColor = Color.Gold;
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

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            //if (grid1.ActiveRow != null)
            //{
            //    DoInquire1();  //전산재고
            //    DoInquire2();  //PDA 재고 실사정보
            //}
        }
        #endregion

        #region < METHOD AREA >
        private void DoInquire1()  //전산재고정보
        {
            //DBHelper helper = new DBHelper(false);
            //try
            //{
            //    //전산  재고 표시
            //    string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);     // 공장코드     
            //    string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호     
            //    string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);       // 품목
            //    string sWHCode = Convert.ToString(grid1.ActiveRow.Cells["WHCode"].Value);           // 창고O                                                                                       

            //    if (sItemCode == "ALL") sItemCode = "";
            //    if (sWHCode == "ALL") sWHCode = "";

            //    grid2.DataSource = helper.FillTable("USP_MM1320_S2N", CommandType.StoredProcedure
            //                                                        , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                // 사업장 공장코드    
            //                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)            // 품목         
            //                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                  // 품목         
            //                                                        , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input));                    // 창고     
            //    grid2.DataBinds();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        private void DoInquire2()  //PDA 재고 실사정보
        {
            //DBHelper helper = new DBHelper(false);
            //try
            //{
            //    string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);     // 공장코드     
            //    string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value); // 지시번호     
            //    string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);       // 품목
            //    string sWHCode = Convert.ToString(grid1.ActiveRow.Cells["WHCode"].Value);           // 창고                                                                                        

            //    if (sItemCode == "ALL") sItemCode = "";
            //    if (sWHCode == "ALL") sWHCode = "";

            //    grid3.DataSource = helper.FillTable("USP_MM1320_S3N", CommandType.StoredProcedure
            //                                                        , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)              // 사업장 공장코드    
            //                                                        , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)          // 품목         
            //                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                // 품목         
            //                                                        , helper.CreateParameter("WHCode", sWHCode, DbType.String, ParameterDirection.Input));                  // 창고            
            //    grid3.DataBinds();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }
        #endregion


    }
}
