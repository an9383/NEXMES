#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0360
//   Form Name    : 외주임가공 반출증 관리(자재)
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0360 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        private string plantCode = string.Empty; //plantcode default 설정

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        bool CHK = false;
        #endregion

        #region < CONSTRUCTOR >

        public MM0360()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemcode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });

            this.plantCode = CModule.GetAppSetting("Site", "10");
        }
        #endregion

        #region  MM0360_Load
        private void MM0360_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTWORKER", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");  //창고
                                                            // WIZ.Common.FillComboboxMaster(this.cbowhcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            GetWhcode();

            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE");  //창고위치
                                                                    // WIZ.Common.FillComboboxMaster(this.cbostorage, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboPlantCode_H.Value = plantCode;
            #endregion

            DoInquire();

        }
        #endregion  MM0360_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            CHK = true;
            DoFind();
        }

        private void DoFind()
        {
            if (!CheckData())
            {
                return;
            }
            DBHelper helper = new DBHelper(false);

            try
            {
                //    base.DoInquire();


                string PLANTCODE = Convert.ToString(cboPlantCode_H.Value);
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string LOTNO = this.txtlotno_H.Text;
                string ITEMCODE = this.txtItemcode_H.Text.Trim();
                string TAB = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) TAB = "TAB1"; else TAB = "TAB2";
                rtnDtTemp = helper.FillTable("USP_MM0360_S1", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("TAB", TAB, DbType.String, ParameterDirection.Input)
                                              );
                this.ClosePrgFormNew();

                if (TAB == "TAB1")
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }
                this.cbostorage.SelectedIndex = 0;
                this.cbowhcode.SelectedIndex = 0;

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


        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        #region <METHOD AREA>
        #endregion
        public override void DoSave()
        {
            int cnt = 0;
            int cnt1 = 0;
            string TAB = string.Empty;
            DataTable dt = new DataTable();
            if (tabControl1.SelectedTab.Index == 0)
            {
                dt = grid1.chkChange();
                TAB = "TAB1";
            }
            else
            {
                dt = grid2.chkChange();
                TAB = "TAB2";
            }

            if (dt == null)
                return;

            DBHelper helper = new DBHelper("", false);

            try
            {
                this.Select();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                //    base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (TAB == "TAB2")
                        {
                            if (Convert.ToString(this.cbowhcode.Value) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("입고 창고는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            if (Convert.ToString(this.cbostorage.Value) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("입고 저장 위치는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            if (Convert.ToString(drRow["CHK"]) == "True")
                            {
                                string PLANTCODE = Convert.ToString(drRow["PLANTCODE"]);
                                string LOTNO = Convert.ToString(drRow["LOTNO"]);
                                string UNITCODE = Convert.ToString(drRow["UNITCODE"]);
                                string ITEMCODE = Convert.ToString(drRow["ITEMCODE"]);
                                string QTY = string.Empty;
                                string WHCODE = string.Empty;
                                string STORAGE = string.Empty;
                                if (TAB == "TAB1")
                                {
                                    QTY = Convert.ToString(drRow["STOCKQTY"]);
                                    WHCODE = Convert.ToString(drRow["WHCODE"]);
                                    STORAGE = Convert.ToString(drRow["STORAGELOCCODE"]);
                                }
                                else
                                {
                                    QTY = Convert.ToString(drRow["OUTQTY"]);
                                    WHCODE = Convert.ToString(this.cbowhcode.Value);
                                    STORAGE = Convert.ToString(this.cbostorage.Value);
                                }

                                helper.ExecuteNoneQuery("USP_MM0360_U1"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("UNITCODE", UNITCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("QTY", QTY, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WHCODE", WHCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("STORAGE", STORAGE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("TAB", TAB, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));
                                cnt1++;
                            }
                            else
                            {
                                cnt++;
                            }

                            //선입선출 위반시
                            if (helper.RSCODE == "X")
                            {
                                if (MessageBox.Show("선입 자재가 존재합니다." + Environment.NewLine + "그래도 진행 하시겠습니까?",
                                                    "선입선출체크",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    helper.Rollback();
                                    DoInquire();
                                    return;
                                }
                            }

                            //15-09-30 마감이후 수불체크
                            if (helper.RSCODE == "E")
                            {
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                helper.Rollback();
                                return;
                            }

                            #endregion
                            break;
                    }
                }
                if (tabControl1.SelectedTab.Index == 0) grid1.SetAcceptChanges();
                else grid2.SetAcceptChanges();
                helper.Commit();
                this.ClosePrgFormNew();
                this.ShowDialog(cnt1 + "건의 데이터가 저장 되었습니다.", Forms.DialogForm.DialogType.OK);
                DoInquire();
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

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                this.cbowhcode.ReadOnly = true;
                this.cbowhcode.Enabled = false;
                this.cbostorage.Enabled = false;
                this.cbostorage.ReadOnly = true;
                this.cbostorage.SelectedIndex = 0;
                this.cbowhcode.SelectedIndex = 0;
            }
            else
            {
                this.cbowhcode.ReadOnly = false;
                this.cbowhcode.Enabled = true;
                this.cbostorage.ReadOnly = false;
                this.cbostorage.Enabled = true;
                this.cbostorage.SelectedIndex = 0;
                this.cbowhcode.SelectedIndex = 0;

            }

            if (CHK == true)
            {
                DoInquire();
            }
        }

        private void GetStorage()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sWhcode = Convert.ToString(this.cbowhcode.Value);


                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                             AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +'] ' + CODENAME       AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE LEFT(MINORCODE,5) = '" + sWhcode + "'             ");
                command.AppendLine("   AND USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'STORAGELOCCODE'                      ");
                command.AppendLine("   AND MINORCODE != '$'                                  ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(cbostorage, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
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

        private void GetWhcode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE                             AS CODE_ID, ");
                command.AppendLine("       '['+ MINORCODE +'] ' + CODENAME       AS CODE_NAME");
                command.AppendLine("  FROM TBM0000                                           ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                     ");
                command.AppendLine("   AND MAJORCODE = 'WHCODE'                              ");
                command.AppendLine("   AND MINORCODE IN ('WH001','WH002')                    ");
                command.AppendLine(" ORDER BY MINORCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(cbowhcode, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
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
        private void choWhcode_TextChanged(object sender, EventArgs e)
        {
            if (this.cbowhcode.Value.ToString() == "WH003" || this.cbowhcode.Value.ToString() == "WH004")
            {
                this.ShowDialog(Common.getLangText("자재 창고만 선택가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                //  choWhcode.Value = "ALL";
                return;
            }
            GetStorage();
        }

    }
}

