#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0125
//   Form Name    : 고장실적조회 및 도착등록/등록취소
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP0125 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();

        #endregion

        #region < CONSTRUCTOR >
        public PP0125()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            //this.plantCode = CModule.GetAppSetting("Site", "10");
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장
            btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" }); //설비                        
        }
        #endregion

        #region < FORM LOAD >
        private void PP0125_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-120);
            cbo_ENDDATE_H.Value = DateTime.Now;

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("COMPLETE_FLAG");
            Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INCONCAUSETYPE");
            Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INCONCAUSE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            bizGridManager.PopUpAdd("ErrorCode", "ErrorDesc", "BM0100", new string[] { "PlantCode", "", "Y" });
            #endregion

            dtGrid = (DataTable)grid1.DataSource;
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량항목", false, GridColDataType_emu.VarChar, 90, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "작업LOTNO", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 120, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 110, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "현재수량", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITINFO", "단위", false, GridColDataType_emu.VarChar, 50, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INCONCAUSE", "부적합구분", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSER", "완료자", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, true, false);

                _GridUtil.SetColumnTextHAlign(grid1, "ERRORQTY", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ERRORDESC", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Center);

                grid1.Columns["PRODQTY"].Format = "#,##0";

                grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;

                _GridUtil.SetInitUltraGridBind(grid1);

                string[] arrMerCol1 = { "CLOSEFLAG", "ERRORQTY", "ERRORCODE", "ERRORDESC" };

                _GridUtil.GridHeaderMerge(grid1, "A1", "부적합 불량 등록", new string[] { "CLOSEFLAG", "ERRORQTY", "ERRORCODE", "ERRORDESC" }, arrMerCol1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ERRORDESC"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["REMARK"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            try
            {
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sCloseFlag = Convert.ToString(cbo_CLOSEFLAG_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_QM0120_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                // 2020 - 10 - 28 EDIT: 신효철
                if (dtGrid.Rows.Count > 0)               //if (rtnDtTemp.Rows.Count > 0)
                {
                    //2020-10-28 REM : 신효철
                    grid1.DataSource = dtGrid;
                    grid1.DataBind();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "N")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightPink;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value) == "Y")
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = Color.LightGreen;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoSave()
        {
            Grid1ToolAct();
        }

        public override void DoDelete()
        {
            if (this.grid1.ActiveRow.Cells["MASTATUS"].Value.ToString() != "A")
            {
                this.ShowDialog(Common.getLangText("작업대기가 아닌 데이터는 고장실적 취소 를 할수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                if (this.ShowDialog(Common.getLangText("선택한 고장실적을 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                DBHelper helper = new DBHelper("", true);
                try
                {
                    string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();  //사업장
                    string sMaOrderNo = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();  //보전지시번호

                    helper.ExecuteNoneQuery("USP_PP0125_D1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAORDERNO", sMaOrderNo, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        helper.Close();
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        DoInquire();
                        return;
                    }
                    else if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.ToString());
                }
                finally
                {
                    this.ClosePrgFormNew();
                    helper.Close();
                    DoInquire();
                }
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void GetFailStatus()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                           AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +']' + CODENAME        AS CODE_NAME");
                command.AppendLine("  FROM BM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'FAILSTATUS' ");
                command.AppendLine("   AND RELCODE1  = 'UI' ");
                command.AppendLine("   AND MINORCODE <> '$'   ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(this.cbo_FIXSTATUS_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MASTATUS", dttemp, "CODE_ID", "CODE_NAME");
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                helper.Close();
            }


        }

        private void GetHour()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dttemp = new DataTable();
                DataRow row = null;

                dttemp.Columns.Add(new DataColumn("CODE_ID", typeof(string)));
                dttemp.Columns.Add(new DataColumn("CODE_NAME", typeof(string)));

                for (int i = 0; i < 25; i++)
                {
                    row = dttemp.NewRow();  //행추가
                    row["CODE_ID"] = i.ToString("00");
                    dttemp.Rows.Add(row);
                }

                WIZ.Common.FillComboboxMaster(cbo_STARTHOUR_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                helper.Close();
            }
        }

        private void GetMin()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dttemp = new DataTable();
                DataRow row = null;

                dttemp.Columns.Add(new DataColumn("CODE_ID", typeof(string)));
                dttemp.Columns.Add(new DataColumn("CODE_NAME", typeof(string)));

                for (int i = 0; i < 60; i++)
                {
                    row = dttemp.NewRow();  //행추가
                    row["CODE_ID"] = i.ToString("00");
                    dttemp.Rows.Add(row);
                }

                WIZ.Common.FillComboboxMaster(cbo_STARTMIN_B, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                helper.Close();
            }
        }

        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void Grid1ToolAct()
        {
            if (this.grid1.Rows.Count == 0) return;
            DBHelper helper = new DBHelper("", true);
            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();

                string sPlantCode = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sFailureType = Convert.ToString(this.cbo_FAILURETYPE_B.Value);              // 고장 분류
                string sRemark = Convert.ToString(this.txt_FAULTREMARK_B.Text);               // 고장내역
                string sMAORDERNO = this.grid1.ActiveRow.Cells["MAORDERNO"].Value.ToString();    // 보전지시번호
                if (sRemark == "")
                {
                    this.ShowDialog(Common.getLangText("고장내역을 입력하지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                helper.ExecuteNoneQuery("USP_PP0125_U1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAORDERNO", sMAORDERNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FAILURETYPE", sFailureType, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));

                // RSCODE 가 S 일경우 helper.RSMSG 로 MoldCode를 리턴함.
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    // 해당 행 선택
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["MAORDERNO"].Value.ToString() == sMAORDERNO)
                        {
                            this.grid1.Rows[i].Activated = true;
                            break;
                        }
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;


            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = "00";
            cbo_STARTMIN_B.Value = "00";
        }

        private void grid1_ClickCell_1(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //설비정보
            cbo_PLANTCODE_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            txt_MAINTRSORDNO_B.Text = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
            txt_WORKCENTERCODE_B.Text = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            txt_WORKCENTERNAME_B.Text = grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();
            txt_MACHCODE_B.Text = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            txt_MACHNAME_B.Text = grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString();
            txt_ERRORCODE_B.Text = grid1.ActiveRow.Cells["ERRORCODE"].Value.ToString();
            txt_ERRORDESC_B.Text = grid1.ActiveRow.Cells["ERRORDESC"].Value.ToString();
            txt_SERIALNO_B.Text = grid1.ActiveRow.Cells["LOTNO"].Value.ToString();
            //txt_CONTACT_B.Text = grid1.ActiveRow.Cells["CONTACT"].Value.ToString();
            //txt_LIFETIME_B.Text = grid1.ActiveRow.Cells["LIFETIME"].Value.ToString();
            txt_MAWORKER1_B.Text = grid1.ActiveRow.Cells["CLOSER"].Value.ToString();
            //txt_MAWORKER2_B.Text = grid1.ActiveRow.Cells["MAWORKER2"].Value.ToString();
            //txt_TECHWORKER_B.Text = grid1.ActiveRow.Cells["TECHWORKER"].Value.ToString();
            txt_INCONCAUSE_B.Text = grid1.ActiveRow.Cells["INCONCAUSE"].Value.ToString();
            txt_ENDDATE_B.Text = grid1.ActiveRow.Cells["CLOSEDATE"].Value.ToString();
            //txt_LASTDATE_B.Text = grid1.ActiveRow.Cells["INSPLASTDATE"].Value.ToString();

            //고장내역 초기화
            //cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            //cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            //cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");

            //txt_MAINTRSORDERNO_B.Text = "";
            //txt_WORKERID_B.Text = "";
            //txt_WORKERNAME_B.Text = "";
            //txt_WORKCENTERCODE_B.Text = "";
            //txt_WORKCENTERNAME_B.Text = "";
            //txt_FAILURECONT_B.Text = "";

            //이미지
            //this.ImageNumber = 0;
            // 설비 이미지 호출 수 초기화

            //ultraGroupBox2.Text = "설비 이미지";
            // 이미지 표현 가장 첫 이미지 0
            //FindImage(0);
            //FindImage(1);
        }

        // 고객크레임등록취소
        private void btnDELETE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            DBHelper helper = new DBHelper("", true);
            try
            {
                string sLOTNO = this.grid1.ActiveRow.Cells["LOTNO"].Value.ToString();
                string sWORKCENTERCODE = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();


                helper.ExecuteNoneQuery("USP_QM0125_U3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_REMARK", "", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "X")
                {
                    helper.Rollback();
                    helper.Close();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                DoInquire();   // 재 조회
                // 작업한 데이터 선택.
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["LOTNO"].Value.ToString() == sLOTNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        // 고객크레임등록
        private void btnSAVE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;


            //입력한 작업시작시간
            DateTime eDate = Convert.ToDateTime(cbo_STARTYYMMDD_B.Value);
            string eDay = eDate.ToString("yyyy") + "-" + eDate.ToString("MM") + "-" + eDate.ToString("dd");
            string eHour = Convert.ToString(cbo_STARTHOUR_B.Value);
            string eMin = Convert.ToString(cbo_STARTMIN_B.Value);
            string eTime = eDay + " " + eHour + ":" + eMin;


            DBHelper helper = new DBHelper("", true);
            try
            {
                string sLOTNO = this.grid1.ActiveRow.Cells["LOTNO"].Value.ToString();
                string sWORKCENTERCODE = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                string sPLANTCODE = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sREMARK = this.txt_FAULTREMARK_B.Text.Trim();

                helper.ExecuteNoneQuery("USP_QM0125_U3", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_REMARK", sREMARK, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "X")
                {
                    helper.Rollback();
                    helper.Close();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("조회 이후 작업상태가 변경되었습니다.확인후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    return;
                }
                helper.Commit();
                this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                DoInquire(); // 재 조회
                // 작업한 데이터 선택.
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["LOTNO"].Value.ToString() == sLOTNO)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        #endregion
    }
}