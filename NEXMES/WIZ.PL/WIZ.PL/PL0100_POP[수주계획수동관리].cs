#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Text;
using System.Net;
#endregion

namespace WIZ.PL
{
    public partial class PL0100_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();
        DataSet DSGrid1 = new DataSet();

        public Control.Grid trGrid;
        DateTime dtFirstDay;
        DateTime dtSecondDay;

        #endregion

        #region < CONSTRUCTOR >
        public PL0100_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0100_POP_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "OD_VEND", "고객사코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Vend", "고객사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OD_ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_PartName", "제품명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_OrderQTY", "발주수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Jego", "재고수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Order", "계획수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Residual", "수주잔량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Chk", "상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PL4_date",      "수주일자", true, GridColDataType_emu.VarChar, 80, 100,  Infragistics.Win.HAlign.Center, true, false);  
            _GridUtil.InitColumnUltraGrid(grid2, "PL4_Vend",      "고객사",   true, GridColDataType_emu.VarChar, 80, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PL4_PartName",  "제품명",   true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PL4_FixedDate", "납기일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PL4_OrderQTY",  "발주수량", true, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PL4_Residual",  "수주잔량", true, GridColDataType_emu.VarChar, 70, 100,  Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "MOLDCODE",   "금형코드",     true, GridColDataType_emu.VarChar,     100, 100, Infragistics.Win.HAlign.Center, true, false); // 고객사       
            _GridUtil.InitColumnUltraGrid(grid3, "MOLDNAME",   "금형명",       true, GridColDataType_emu.VarChar,     120, 100, Infragistics.Win.HAlign.Center, true, false); // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid3, "DEGREE",     "차수",         true, GridColDataType_emu.VarChar,      50, 100, Infragistics.Win.HAlign.Center, true, false); // 수주고유번호
            _GridUtil.InitColumnUltraGrid(grid3, "MOLDSTATE",  "상태",         true, GridColDataType_emu.VarChar,      80, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid3, "TOALSHOT",   "누적샷",       true, GridColDataType_emu.VarChar,      80, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid3, "USECAVITY",  "현재CAVITY",   true, GridColDataType_emu.VarChar,      80, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid4, "WorkCenter", "작업장명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid5, "PL_CAPA",     "주간CAPA",  true, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "Mold", "금형명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "MoldState", "금형상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "Part", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "MakePlanDay", "계획일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "Cnt", "수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "PL_State", "상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid5, "Work",        "작업량",    true, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid5, "TotalWork",   "총작업량",  true, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true, false); 

            _GridUtil.SetInitUltraGridBind(grid4);

            _GridUtil.InitializeGrid(this.grid5, true, true, false, "", false);
      
            _GridUtil.InitColumnUltraGrid(grid5, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "WORKCENTERNAME", "작업장명",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "PL_ConPlanDate", "연속일자",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid5, "PLANMOLDCODE",   "금형코드",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid5, "PLANMOLD",       "계획금형",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid5, "PLANMOLDCAVITY", "계획금형캐비티", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid5, "PL_CUSTCODE",    "고객사코드", true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "PL_CUSTNAME",    "고객사",     true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "PL_ITEMCODE",    "물품코드",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "PLANPART",       "계획물품",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid5, "DAYCAPA",        "일생산수량", true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "PLANCOUNT",      "계획수량",   true, GridColDataType_emu.VarChar, 100, 100,  Infragistics.Win.HAlign.Center, true, true);

            _GridUtil.SetInitUltraGridBind(grid5);

            cbo_GUBUN.Items.Add("긴급");
            cbo_GUBUN.Items.Add("납품");

            dtp_STARTDATE.Value = DateTime.Today;
            dtp_STARTDATE.Value.ToString("yyyy-MM-dd");

            #endregion

            #region < GRID LOAD >

            DBHelper helper = new DBHelper(false);

            // GRID5
            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0100_POP_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_SEARCHDAY", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid5.DataSource = rtnDtTemp;
                    grid5.DataBinds();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid3);
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

            // GRID1
            try
            {
                DSGrid1 = helper.FillDataSet("USP_PL0100_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = DSGrid1.Tables[0];
                    grid1.DataBind();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    DSGrid1 = helper.FillDataSet("USP_PL0100_POP_S3", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_ITEMNAME", grid1.Rows[i].Cells["PL1_PartName"].Value, DbType.String, ParameterDirection.Input));

                    if (DSGrid1.Tables[1].Rows.Count > 0)
                    {
                        grid1.Rows[i].Cells["PL1_Jego"].Value = DSGrid1.Tables[1].Rows[0]["STOCK"];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >



        #endregion

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                grid5.ActiveRow.Cells["PLANMOLD"].Value       = grid3.ActiveRow.Cells["MOLDNAME"].Value + "(" + grid3.ActiveRow.Cells["DEGREE"].Value + ")";
                grid5.ActiveRow.Cells["PLANMOLDCODE"].Value   = grid3.ActiveRow.Cells["MOLDCODE"].Value;
                grid5.ActiveRow.Cells["PLANMOLDCAVITY"].Value = grid3.ActiveRow.Cells["USECAVITY"].Value;


                DSGrid1 = helper.FillDataSet("USP_PL0100_MD_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", grid3.ActiveRow.Cells["MOLDCODE"].Value, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    txtCYCLETIME.Text = Convert.ToString(DSGrid1.Tables[0].Rows[0]["USECYCLETIME"]);
                }

                grid5.ActiveRow.Cells["DAYCAPA"].Value = Convert.ToInt32(3600 * 22 / Convert.ToInt32(txtCYCLETIME.Text) * Convert.ToInt32(grid3.ActiveRow.Cells["USECAVITY"].Value));
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

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0000_S6", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);
                
                for (int i = 0; i < grid5.Rows.Count; i++)
                {
                    int PLUS = 0;
                    if (Convert.ToInt32(grid5.Rows[i].Cells["PLANCOUNT"].Value) != 0 && Convert.ToString(grid5.Rows[i].Cells["PLANPART"].Value) != "" && Convert.ToString(grid5.Rows[i].Cells["PLANMOLD"].Value) != "")
                    {
                        if (Convert.ToString(grid5.Rows[i].Cells["PL_conPlanDate"].Value) == "")
                        {
                            grid5.Rows[i].Cells["PL_conPlanDate"].Value = 7;
                        }

                        else
                        {

                        }

                        for (int j = 0; j < Convert.ToInt32(grid5.Rows[i].Cells["PL_ConPlanDate"].Value); j++)
                        {
                            rtnDtTemp = helper.FillTable("USP_PL0100_I", CommandType.StoredProcedure

                              , helper.CreateParameter("AS_PLANTCODE",         LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER",              LoginInfo.UserID,    DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_TIME",              DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_PL_DATE",           DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_MAKEPLANDAY",    dtp_STARTDATE.Value.AddDays(PLUS).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_GUBUN",          cbo_GUBUN.Text, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_TON",            "", DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_PL_ITEMCODE",       grid5.Rows[i].Cells["PL_ITEMCODE"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_CUSTCODE",       grid5.Rows[i].Cells["PL_CUSTCODE"].Value, DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_PL_MOLDCODE",       grid5.Rows[i].Cells["PLANMOLDCODE"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_MOLDCAVITY",     grid5.Rows[i].Cells["PLANMOLDCAVITY"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_CYCLETIME",      txtCYCLETIME.Text, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_WORKCENTERCODE", grid5.Rows[i].Cells["WORKCENTERCODE"].Value, DbType.String, ParameterDirection.Input)

                              , helper.CreateParameter("AS_PL_WORK",           grid5.Rows[i].Cells["DAYCAPA"].Value, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_PL_COUNT",          Convert.ToInt32(grid5.Rows[i].Cells["PLANCOUNT"].Value), DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                throw new Exception(helper.RSMSG);
                            }

                            helper.Commit();

                            PLUS++;
                        }
                    }
                }

                this.ShowDialog("계획등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        private void grid4_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DSGrid1 = helper.FillDataSet("USP_PL0100_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_CUSTITEMCODE", grid1.ActiveRow.Cells["OD_ITEMCODE"].Value, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE",     grid1.ActiveRow.Cells["OD_VEND"].Value,     DbType.String, ParameterDirection.Input));

                if (Convert.ToInt32(DSGrid1.Tables[0].Rows[0]["CNT"]) > 0)
                {
                    grid5.ActiveRow.Cells["PLANPART"].Value    = grid1.ActiveRow.Cells["PL1_PartName"].Value;
                    grid5.ActiveRow.Cells["PL_CUSTNAME"].Value = grid1.ActiveRow.Cells["PL1_Vend"].Value;
                    grid5.ActiveRow.Cells["PL_CUSTCODE"].Value = grid1.ActiveRow.Cells["OD_VEND"].Value;
                    grid5.ActiveRow.Cells["PL_ITEMCODE"].Value = grid1.ActiveRow.Cells["OD_ITEMCODE"].Value;

                    txtPROD.Text    = Convert.ToString(grid1.ActiveRow.Cells["PL1_PartName"].Value);
                    txtVEND.Text    = Convert.ToString(grid1.ActiveRow.Cells["PL1_Vend"].Value);
                }
                else
                {
                    this.ShowDialog("고객사에 해당하는 품목이 없습니다.", Forms.DialogForm.DialogType.OK);
                }
            
                DSGrid1 = helper.FillDataSet("USP_PL0100_S4", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE",  grid1.ActiveRow.Cells["OD_ITEMCODE"].Value, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    _GridUtil.Grid_Clear(grid3);
                    grid2.DataSource = DSGrid1.Tables[0];
                    grid2.DataBinds();
                }
                if (DSGrid1.Tables[1].Rows.Count > 0)
                {
                    txtRECENTHO.Text = "";
                    txtDATE.Text = "";

                    txtRECENTHO.Text = Convert.ToString(DSGrid1.Tables[1].Rows[0]["WORKCENTERNAME"]);
                    txtDATE.Text = Convert.ToString(DSGrid1.Tables[1].Rows[0]["PL_MAKEPLANDAY"]);
                }

                DSGrid1 = helper.FillDataSet("USP_PL0100_POP_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_CUSTITEMCODE", grid1.ActiveRow.Cells["OD_ITEMCODE"].Value, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE",     grid1.ActiveRow.Cells["OD_VEND"].Value,     DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[1].Rows.Count > 0)
                {
                    grid3.DataSource = DSGrid1.Tables[1];
                    grid3.DataBinds();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid3);
                    ShowDialog(Common.getLangText("물품에 맞는 금형이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
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

        private void dtp_STARTDATE_ValueChanged(object sender, EventArgs e)
        {
            string chk = "A";
            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0100_POP_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_SEARCHDAY", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid5.DataSource = rtnDtTemp;
                    grid5.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid3);
                    return;
                }

                chk_DAY.Checked = false;

                rtnDtTemp = helper.FillTable("USP_PL0100_S5", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_FisrtDay",  dtp_STARTDATE.Value.ToString("yyyy-MM-dd"),  DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SP_TYPE",   "A", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds();

                    for (int i = 0; i < grid4.Rows.Count; i++)
                    {
                        int result = DateTime.Compare(Convert.ToDateTime(grid4.Rows[i].Cells["MakePlanDay"].Value), DateTime.Today);


                        if (Convert.ToString(grid4.Rows[i].Cells["MakePlanDay"].Value) == DateTime.Today.ToString("yyyy-MM-dd"))
                        {
                            grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Blue;
                        }
                        else if (result < 0)
                        {
                            grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Red;
                        }
                        else if (result > 0)
                        {
                            grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Yellow;
                            if (Convert.ToString(grid4.Rows[i].Cells["PL_State"].Value) == "비가동")
                            {
                                grid4.Rows[i].Cells["PL_State"].Value = "대기";
                            }
                        }
                    }
                }
                else
                {
                    ShowDialog(Common.getLangText("등록된 주간계획이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid4);
                    return;
                }
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

        private void grid3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                }
                else
                {

                }
            }
            catch
            {

            }
        }

        /*private void CALDAYWEEK() // 주간 나누는공식
        {
            DateTime dtDay = dtp_STARTDATE.Value;
            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwCal   = ciCurrent.Calendar.GetDayOfWeek(dtDay);

            int iDiff = dwCal - dwFirst;
            dtFirstDay  = dtDay.AddDays(-iDiff + 1);
            dtSecondDay = dtFirstDay.AddDays(6);
        }*/

        private void grid5_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void btn_INSERTROW_Click(object sender, EventArgs e)
        {
            grid5.InsertRow(true);
        }

        private void chk_DAY_CheckedChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                if (chk_DAY.Checked == true)
                {
                    rtnDtTemp = helper.FillTable("USP_PL0100_S5", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_FisrtDay", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SP_TYPE", "D", DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid4.DataSource = rtnDtTemp;
                        grid4.DataBinds();

                        for (int i = 0; i < grid4.Rows.Count; i++)
                        {
                            int result = DateTime.Compare(Convert.ToDateTime(grid4.Rows[i].Cells["MakePlanDay"].Value), DateTime.Today);

                            if (Convert.ToString(grid4.Rows[i].Cells["MakePlanDay"].Value) == DateTime.Today.ToString("yyyy-MM-dd"))
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Blue;
                            }
                            else if (result < 0)
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Red;
                            }
                            else if (result > 0)
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Yellow;
                                if (Convert.ToString(grid4.Rows[i].Cells["PL_State"].Value) == "비가동")
                                {
                                    grid4.Rows[i].Cells["PL_State"].Value = "대기";
                                }
                            }
                        }
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("등록된 주간계획이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        _GridUtil.Grid_Clear(grid4);
                        return;
                    }
                }
                else if (chk_DAY.Checked == false)
                {
                    rtnDtTemp = helper.FillTable("USP_PL0100_S5", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_FisrtDay", dtp_STARTDATE.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SP_TYPE", "A", DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid4.DataSource = rtnDtTemp;
                        grid4.DataBinds();

                        for (int i = 0; i < grid4.Rows.Count; i++)
                        {
                            int result = DateTime.Compare(Convert.ToDateTime(grid4.Rows[i].Cells["MakePlanDay"].Value), DateTime.Today);

                            if (Convert.ToString(grid4.Rows[i].Cells["MakePlanDay"].Value) == DateTime.Today.ToString("yyyy-MM-dd"))
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Blue;
                            }
                            else if (result < 0)
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Red;
                            }
                            else if (result > 0)
                            {
                                grid4.Rows[i].Cells["MakePlanDay"].Appearance.BackColor = Color.Yellow;
                                if (Convert.ToString(grid4.Rows[i].Cells["PL_State"].Value) == "비가동")
                                {
                                    grid4.Rows[i].Cells["PL_State"].Value = "대기";
                                }
                            }
                        }
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("등록된 주간계획이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        _GridUtil.Grid_Clear(grid4);
                        return;
                    }
                }
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

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                PL0100_POP2 mbp = new PL0100_POP2();
                if (DialogResult.OK == mbp.ShowDialog())
                {
                    DSGrid1 = helper.FillDataSet("USP_PL0100_S1", CommandType.StoredProcedure);

                    if (DSGrid1.Tables[0].Rows.Count > 0)
                    {
                        grid1.DataSource = DSGrid1.Tables[0];
                        grid1.DataBind();
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch
            {

            }
        }
    }
}