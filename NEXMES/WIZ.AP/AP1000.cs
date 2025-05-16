#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP1000
//   Form Name    : 자주 검사 계획별 실적 조회
//   Name Space   : WIZ.AP
//   Created Date : 2015-10-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통2
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        #region < CONSTRUCTOR >

        public AP1000()
        {
            // bPopUp = true;
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" });

            //   BizGridManager gridManager = new BizGridManager(grid1);
            //   gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });
            //    gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });
        }
        #endregion

        #region AP1000_Load
        private void AP1000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNCODE", "검사계획번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "계획생성일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNDATE", "계획일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNTYPE", "구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREFINFLAG", "검사완료여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREFINDATE", "검사완료일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MESSUREFINWORKER", "검사자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASURETOTJUD", "종합판정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREPLNCNT", "측정할항목수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREFINCNT", "측정된항목수", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREPLNCODE", "검사계획번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURECODE", "측정항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURENAME", "측정항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREVALUE", "측정값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TOLVAL", "오차", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREJUD", "판정", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MDATE", "검사일시 ", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region 콤보박스 
            DataTable rtnDtTemp = new DataTable();
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("USEFLAG");  // 사용유무, MES적용유무
            //WIZ.Common.FillComboboxMaster(this.cboYesNo, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASURETYPE");  //측정값 구분
            WIZ.Common.FillComboboxMaster(this.cboMEASURETYPE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");     //SPEC 적용기준
            WIZ.Common.FillComboboxMaster(this.cboSEPCTYPE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASUREPLNTYPE");  // 검사계획 구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASUREPLNTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERCLOSE");  // 완료여부
            WIZ.Common.FillComboboxMaster(this.cboFinFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASUREFINFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASURETOTJUD");  // 종합판정여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MEASURETOTJUD", rtnDtTemp, "CODE_ID", "CODE_NAME");


            // 초중종물 검사화면(mt0100y)에서 open시,
            if (this.Tag != null)
            {
                string words = this.Tag.ToString();
                this.txtWorkCenterName_H.Text = words;
                GetOPCode();
                DoInquire();
            }


            #endregion
        }
        #endregion AP1000_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string WORKCENTERCODE = txtWorkCenterCode_H.Text.Trim();
                string ITEMCODE = txtItemCode_H.Text.Trim();
                string ORDERNO = txtORDERNO.Text.Trim();        // 작업지시번호
                string MEASUREPLNCODE = txtMEASUREPLNCODE.Text.Trim(); // 검사계획번호
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_date.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_dateto.Value);
                string sFInFlag = Convert.ToString(cboFinFlag.Value);


                rtnDtTemp = helper.FillTable("USP_AP1000_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ORDERNO", ORDERNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASUREPLNCODE", MEASUREPLNCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sEndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("sFInFlag", sFInFlag, DbType.String, ParameterDirection.Input)
                                                            );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    //16-05-18 유지보수 요청으로 수정 최재형
                    DataTable dt = rtnDtTemp.DefaultView.ToTable(true, "WORKCENTERCODE");
                    DataTable dt1;
                    DataTable dt2;

                    //조회된 데이터에서 작업장만 가져와 FOR문
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string sWORKCNETERCODECHK;
                        sWORKCNETERCODECHK = Convert.ToString(dt.Rows[k]["WORKCENTERCODE"]);

                        //작업장의 최신계획지시 확인
                        dt1 = helper.FillTable(" SELECT TOP 1 MEASUREPLNCODE, ORDERNO, MEASUREPLNTYPE, MEASUREFINFLAG, MAKEDATE  FROM TAP1000 WHERE WORKCENTERCODE = '" + sWORKCNETERCODECHK + "' ORDER BY MAKETIME DESC, MEASUREPLNTYPE ASC", CommandType.Text);
                        string sMEASUREPLNCODECHK1;
                        DateTime sMAKEDATECHK1;

                        //작업장의 최신완료계획 확인
                        dt2 = helper.FillTable(" SELECT TOP 1 MEASUREPLNCODE, ORDERNO, MEASUREPLNTYPE, MEASUREFINFLAG, MAKEDATE  FROM TAP1000 WHERE MEASUREFINFLAG = 'Y' AND WORKCENTERCODE = '" + sWORKCNETERCODECHK + "' ORDER BY MAKETIME DESC, MEASUREPLNTYPE ASC", CommandType.Text);
                        string sMEASUREPLNCODECHK2;
                        DateTime sMAKEDATECHK2;

                        //작업장의 최신계획지시, 최신완료계획이 모두 존재하는 경우
                        if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                        {
                            sMEASUREPLNCODECHK1 = Convert.ToString(dt1.Rows[0]["MEASUREPLNCODE"]);
                            sMAKEDATECHK1 = Convert.ToDateTime(dt1.Rows[0]["MAKEDATE"]);

                            sMEASUREPLNCODECHK2 = Convert.ToString(dt2.Rows[0]["MEASUREPLNCODE"]);
                            sMAKEDATECHK2 = Convert.ToDateTime(dt2.Rows[0]["MAKEDATE"]);
                        }

                        //작업장의 최신완료계획이 없는경우
                        else if (dt2.Rows.Count == 0)
                        {
                            sMEASUREPLNCODECHK1 = Convert.ToString(dt1.Rows[0]["MEASUREPLNCODE"]);
                            sMAKEDATECHK1 = Convert.ToDateTime(dt1.Rows[0]["MAKEDATE"]);

                            sMEASUREPLNCODECHK2 = "";
                            sMAKEDATECHK2 = default(DateTime);
                        }

                        //작업장의 최신계획지시가 없는경우
                        else
                        {
                            continue;
                        }

                        //GRID1 FOR문으로 앞서 조회된 데이터와 비교
                        int j = 0;
                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            string sMEASUREPLNCODE = Convert.ToString(grid1.Rows[i].Cells["MEASUREPLNCODE"].Value);
                            DateTime sMAKEDATE = Convert.ToDateTime(grid1.Rows[i].Cells["MAKEDATE"].Value);
                            string sWORKCNETERCODE = Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value);

                            //판정결과 NG는 빨간색 표시
                            if (grid1.Rows[i].Cells["MEASURETOTJUD"].Value.ToString() == "NG")
                            {
                                grid1.Rows[i].Cells["MEASURETOTJUD"].Appearance.BackColor = Color.Red;
                            }

                            //동일 작업장에 최신검사계획 완료시간부터 현재 최신검사계획작업시간 사이에 존재하고 미 완료인 경우 노란색 미등록 알람표시
                            if (sWORKCNETERCODE == sWORKCNETERCODECHK && grid1.Rows[i].Cells["MEASUREFINFLAG"].Value.ToString() == "N" && sMAKEDATECHK2 <= sMAKEDATE && sMAKEDATE <= sMAKEDATECHK1)
                            {
                                grid1.Rows[i].Cells["MEASUREFINFLAG"].Appearance.BackColor = Color.Yellow;
                                j = i;
                            }

                            //동일 작업장에 최신검사계획 완료시간이전이며 미 완료인 경우 빨간색 실적누락 알람표시
                            if (sWORKCNETERCODE == sWORKCNETERCODECHK && grid1.Rows[i].Cells["MEASUREFINFLAG"].Value.ToString() == "N" && sMAKEDATECHK2 > sMAKEDATE)
                            {
                                grid1.Rows[i].Cells["MEASUREFINFLAG"].Appearance.BackColor = Color.Red;
                                j = i;
                            }
                        }

                    }

                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion


        /// 작업장 코드 조회
        /// </summary>
        private void GetOPCode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sWORKCENTERCODE = string.Empty;
                string sWORKCENTERNAME = this.Tag.ToString();

                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT WORKCENTERCODE               AS WORKCENTERCODE ");
                command.AppendLine("  FROM TBM0600Y                                       ");
                command.AppendLine(" WHERE PLANTCODE LIKE '" + sPlantCode + "' + '%'      ");
                command.AppendLine("   AND WORKCENTERNAME LIKE '" + sWORKCENTERNAME + "' + '%'      ");
                command.AppendLine("   AND USEFLAG = 'Y'                                  ");
                command.AppendLine(" ORDER BY OPCODE");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                sWORKCENTERCODE = dttemp.Rows[0]["WORKCENTERCODE"].ToString();
                txtWorkCenterCode_H.Text = sWORKCENTERCODE;
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

        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string MEASUREPLNCODE = grid1.ActiveRow.Cells["MEASUREPLNCODE"].Value.ToString();


                grid2.DataSource = helper.FillTable("USP_AP1000_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASUREPLNCODE", MEASUREPLNCODE, DbType.String, ParameterDirection.Input));
                grid2.DataBinds();
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (grid2.Rows[i].Cells["MEASUREJUD"].Value.ToString() == "NG")
                    {
                        grid2.Rows[i].Cells["MEASUREJUD"].Appearance.BackColor = Color.Red;
                    }
                    grid2.Rows[i].Cells["MEASUREVALUE"].Appearance.BackColor = Color.Yellow;
                }
                if (grid2.Rows.Count == 0)
                {
                    this.cboMEASURETYPE.Value = "";
                    this.cboSEPCTYPE.Value = "";
                    this.txtSPECVALUE.Text = "";
                    this.txtSEPCUSL.Text = "";
                    this.txtSPECLSL.Text = "";
                    //this.cboTOLFLAG.Value = "";
                    this.txtUTOLVALUE.Text = "";
                    this.txtLTOLVALUE.Text = "";
                    this.cboMAKEDATE.Value = "";
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid2_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string WORKCENTERCODE = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                string ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                string INSPCODE = grid2.ActiveRow.Cells["INSPCODE"].Value.ToString();
                string MEASURECODE = grid2.ActiveRow.Cells["MEASURECODE"].Value.ToString();
                //string MEASUREPLNCODE = grid2.ActiveRow.Cells["MEASUREPLNCODE"].Value.ToString();
                //string PLANTCODE      = CModule.GetAppSetting("Site", "10");

                rtnDtTemp = helper.FillTable("USP_AP1000_S3", CommandType.StoredProcedure
                                                            //, helper.CreateParameter("MEASUREPLNCODE", MEASUREPLNCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", INSPCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURECODE", MEASURECODE, DbType.String, ParameterDirection.Input));
                if (rtnDtTemp != null && rtnDtTemp.Rows.Count > 0)
                {
                    this.cboMEASURETYPE.Value = rtnDtTemp.Rows[0]["MEASURETYPE"].ToString();
                    this.cboSEPCTYPE.Value = rtnDtTemp.Rows[0]["SEPCTYPE"].ToString();
                    this.txtSPECVALUE.Text = rtnDtTemp.Rows[0]["SPECVALUE"].ToString();
                    this.txtSEPCUSL.Text = rtnDtTemp.Rows[0]["SEPCUSL"].ToString();
                    this.txtSPECLSL.Text = rtnDtTemp.Rows[0]["SPECLSL"].ToString();
                    this.chktolflag.Checked = rtnDtTemp.Rows[0]["TOLFLAG"].ToString() == "true" ? true : false;
                    this.txtUTOLVALUE.Text = rtnDtTemp.Rows[0]["UTOLVALUE"].ToString();
                    this.txtLTOLVALUE.Text = rtnDtTemp.Rows[0]["LTOLVALUE"].ToString();
                    this.cboMAKEDATE.Value = rtnDtTemp.Rows[0]["MAKEDATE"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
