#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0110
//   Form Name    : 재고실사이력
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-28
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고실사이력
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
    public partial class MM0110 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public MM0110()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0110_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
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
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, false, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(grid1);

            // 전산 및 실사 재공정보 이력
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGTYPE", "구분", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHTYPE", "창고구분", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "전산재고", false, GridColDataType_emu.VarChar, 90, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사재고", false, GridColDataType_emu.VarChar, 90, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INVQTYDIFF", "수량차이", false, GridColDataType_emu.VarChar, 90, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "반영사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "반영일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "반영자", false, GridColDataType_emu.VarChar, 90, true, false);

            _GridUtil.SetColumnTextHAlign(grid2, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "NOWQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "INVQTYDIFF", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "REMARK", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["NOWQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["INVQTYDIFF"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");   //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_WHTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
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
                base.DoInquire();

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sTakingORDStDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sTakingORDEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sWhType = Convert.ToString(cbo_WHTYPE_H.Value);
                string sTakingORDNo = txt_TAKINGORDNO_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_MM0110_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDDATE_FROM", sTakingORDStDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDDATE_TO", sTakingORDEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));

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
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            GetWhCode(Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value), grid2);

            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);     // 공장코드     
                string sTakingORDNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);   // 지시번호     

                rtnDtTemp = helper.FillTable("USP_MM0110_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)      // 사업장
                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input));    // 품목       

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();
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
                        grid2.Rows[i].Cells["NOWQTY"].Appearance.BackColor = Color.Gold;
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
