#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0130
//   Form Name    : 고장실적등록
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
using System.IO;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.QM
{
    public partial class QM0130 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        private int ImageNumber = 0;       // 가져올 이미지의 순번
        private int Imageseq = 0;       // 가져온 이미지의 순번
        private int ImageCount = 0;       // 설비의 총 이미지 수

        private bool bNew = false;

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable dtGrid = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public QM0130()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", "" });         // 설비
            btbManager.PopUpAdd(txt_MACHTYPE_H, txt_MACHTYPENAME_H, "BM0071", new object[] { cbo_PLANTCODE_H, "", "", "" });         // 설비구분
            btbManager.PopUpAdd(txt_WORKCENTERCODE_B, txt_WORKCENTERNAME_B, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); // 작업장
            btbManager.PopUpAdd(txt_WORKERID_B, txt_WORKERNAME_B, "BM0020", new object[] { cbo_PLANTCODE_H, "", "", "", "" });     // 작업자

        }
        #endregion

        #region < FORM LOAD >
        private void QM0130_Load(object sender, EventArgs e)
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
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 120, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 80, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "작업LOTNO", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 110, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
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
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 150, true, true);

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

                //grid1.DataSource = dtGrid;
                //grid1.DataBind();

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
        #endregion

        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //설비정보
            cbo_PLANTCODE_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            //txt_MACHTYPE_B.Text = grid1.ActiveRow.Cells["MACHTYPE"].Value.ToString();
            //txt_MACHTYPENAME_B.Text = grid1.ActiveRow.Cells["MACHTYPENAME"].Value.ToString();
            txt_MACHCODE_B.Text = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            txt_MACHNAME_B.Text = grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString();
            //txt_MAKECOMPANY_B.Text = grid1.ActiveRow.Cells["MAKECOMPANY"].Value.ToString();
            //txt_MODELNAME_B.Text = grid1.ActiveRow.Cells["MODELNAME"].Value.ToString();
            txt_SERIALNO_B.Text = grid1.ActiveRow.Cells["LOTNO"].Value.ToString();
            //txt_CONTACT_B.Text = grid1.ActiveRow.Cells["CONTACT"].Value.ToString();
            //txt_LIFETIME_B.Text = grid1.ActiveRow.Cells["LIFETIME"].Value.ToString();
            txt_MAWORKER1_B.Text = grid1.ActiveRow.Cells["CLOSER"].Value.ToString();
            //txt_MAWORKER2_B.Text = grid1.ActiveRow.Cells["MAWORKER2"].Value.ToString();
            //txt_TECHWORKER_B.Text = grid1.ActiveRow.Cells["TECHWORKER"].Value.ToString();
            //txt_INSPCYCLE_B.Text = grid1.ActiveRow.Cells["INSPCYCLE"].Value.ToString();
            //txt_CAVITY_B.Text = grid1.ActiveRow.Cells["CAVITY"].Value.ToString();
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


        private void btnImageNext_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txt_MACHCODE_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            //ImageNumber = ImageNumber - 1;
            //FindImage(ImageNumber);

            if (Imageseq == ImageCount)
                return;

            Imageseq += 1;
            FindImage(Imageseq);
        }

        private void btnImageBefor_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.txt_MACHCODE_B.Text == "" || this.Imageseq == 0)
            {
                return;
            }
            //ImageNumber = ImageNumber + 1;
            //FindImage(ImageNumber);

            if (Imageseq == 1)
                return;

            Imageseq -= 1;
            FindImage(Imageseq);
        }

        private void btnSAVE_B_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;

            //신고일시 필수입력
            if (cbo_STARTYYMMDD_B.Value == null)
            {
                this.ShowDialog(Common.getLangText("저장시 신고일시는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //신고자 필수입력
            if (txt_WORKERNAME_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("신고자는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //고장내용 필수입력
            if (txt_FAILURECONT_B.Text == "")
            {
                this.ShowDialog(Common.getLangText("고장내용은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //입력한 작업시작시간
            DateTime sDate = Convert.ToDateTime(cbo_STARTYYMMDD_B.Value);
            string sDay = sDate.ToString("yyyy") + "-" + sDate.ToString("MM") + "-" + sDate.ToString("dd");
            string sHour = Convert.ToString(cbo_STARTHOUR_B.Value);
            string sMin = Convert.ToString(cbo_STARTMIN_B.Value);
            string sTime = sDay + " " + sHour + ":" + sMin;

            string sPlantCode = plantCode;                                                    //사업장
            string sWorkerCenterCode = Convert.ToString(txt_WORKCENTERCODE_B.Text);                  //작업장
            string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);    //설비
            string sWorker = Convert.ToString(txt_WORKERID_B.Text);                        //신고자
            string sDesc = Convert.ToString(txt_FAILURECONT_B.Text);                     //신고내용
            string sFaulType = Convert.ToString(cbo_FAULTTYPE_B.Value);                      //고장분류


            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_QM0130_I1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    // 공장
                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkerCenterCode, DbType.String, ParameterDirection.Input)    // 작업장
                                    , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)    // 고장장(설)비코드 
                                    , helper.CreateParameter("AS_STARTDATE", sTime, DbType.DateTime, ParameterDirection.Input)  // 작업시작시간
                                    , helper.CreateParameter("AS_FAULTTYPE", sFaulType, DbType.String, ParameterDirection.Input)    // 고장분류
                                    , helper.CreateParameter("AS_FAULTWORKER", sWorker, DbType.String, ParameterDirection.Input)    // 신고자
                                    , helper.CreateParameter("AS_REMARK", sDesc, DbType.String, ParameterDirection.Input)    // 고장내역
                                    , helper.CreateParameter("AS_MAKER", WorkerID, DbType.String, ParameterDirection.Input)    // 만든이
                                    , helper.CreateParameter("AS_MAORDERNO", DbType.String, ParameterDirection.Output, '0', 15));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();

                    //보전작업지시번호 표시
                    txt_MAINTRSORDERNO_B.Text = helper.Parameters[8].Value.ToString();

                    this.ShowDialog(Common.getLangText("저장이 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
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
            }

        }

        private void btnRESET_B_Click(object sender, EventArgs e)
        {
            //고장내역 초기화
            cbo_STARTYYMMDD_B.Value = DateTime.Now.ToString("yyyy-MM-dd");
            cbo_STARTHOUR_B.Value = DateTime.Now.Hour.ToString("00");
            cbo_STARTMIN_B.Value = DateTime.Now.Minute.ToString("00");

            txt_MAINTRSORDERNO_B.Text = "";
            txt_WORKERID_B.Text = "";
            txt_WORKERNAME_B.Text = "";
            txt_WORKCENTERCODE_B.Text = "";
            txt_WORKCENTERNAME_B.Text = "";
            txt_FAILURECONT_B.Text = "";

        }

        #endregion

        #region < USER METHOD AREA >
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        // 이미지 호출
        private void FindImage(int ImageSeq)
        {
            DBHelper helper = new DBHelper("", false);
            try
            {
                // 이미지 호출
                DataTable DtPlant = helper.FillTable("USP_QM0130_S2", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_NUMBER", ImageSeq, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHCODE", this.grid1.ActiveRow.Cells["MACHCODE"].Value.ToString(), DbType.String, ParameterDirection.Input));

                if (DtPlant.Rows.Count > 0 && DtPlant.Rows[0]["MACHIMG"].ToString() != string.Empty)
                {
                    byte[] bImage = null;
                    bImage = (byte[])DtPlant.Rows[0]["MACHIMG"];
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Imageseq = Convert.ToInt32(DtPlant.Rows[0]["MACHSEQ"]);
                    this.ImageCount = Convert.ToInt32(DtPlant.Rows[0]["LICOUNT"]);

                }
                else
                {
                    this.Imageseq = 0;
                    this.ImageCount = 0;
                    this.pictureBox1.Image = null;
                }
                ultraGroupBox2.Text = "설비 이미지     " + Imageseq + " / " + ImageCount;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        #endregion


    }
}