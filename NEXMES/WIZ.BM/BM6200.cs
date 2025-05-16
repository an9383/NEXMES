#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6200
//   Form Name    : 자주 검사 계획별 실적 조회
//   Name Space   : WIZ.AP
//   Created Date : 2015-10-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;


#endregion

namespace WIZ.BM
{
    using System.Configuration;
    using WIZ.Forms;

    public partial class BM6200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string sGunbun; // 측정값구분자
        string sChk;    // 공차적용여부 체크 구분자
        string b;

        //int AFTERSAVE = 0; //저장후, 재조회인지 구분.
        //int GRIDROWID = 0;  //저장후, 재조회시 이전 ROW로 ACTIVE.

        #endregion

        #region < CONSTRUCTOR >

        public BM6200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600", new object[] { "", "", "", "" });
            btbManager.PopUpAdd(txtInspCode_H, txtInspName_H, "TBM6000", new object[] { "", "" });
            btbManager.PopUpAdd(txtMeasureCode_H, txtMeasureName_H, "TBM6100", new object[] { "", "" });


        }
        #endregion

        #region BM6200_Load
        private void BM6200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "MEASURESEQ", "측정순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MEASURECODE", "측정항목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MEASURENAME", "측정항목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "검사실적\n등록여부코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "STANDSPECUSEFLAG", "기준규격\n적용여부코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            // _GridUtil.InitColumnUltraGrid(grid3, "STANDSPECUSEFLAG2", "기준규격적용여부",     false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);
            #endregion

            #region 콤보박스 
            DataTable rtnDtTemp = new DataTable();
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 검사기준등록여부, 기준규격 적용 여부
            WIZ.Common.FillComboboxMaster(this.cbostandsflag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null); //검사기준등록여부코드
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");  //검사기준등록여부코드
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "STANDSPECUSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME"); //기준규격적용여부코드

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASURETYPE");  //측정값 구분
            WIZ.Common.FillComboboxMaster(this.cbomeatype, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);

            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");     //SPEC 적용기준
            WIZ.Common.FillComboboxMaster(this.cbosepctype, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbosepctype.Value = "B";
            #endregion

            #region
            this.cbomeatype.Enabled = false;
            this.cbosepctype.Enabled = false;
            this.txtspecvalue.Enabled = false;
            this.chktolflag.Enabled = false;
            this.txtutolvalue.Enabled = false;
            this.txtltolvalue.Enabled = false;
            this.txtsepcusl.Enabled = false;
            this.txtspeclsl.Enabled = false;
            this.cbostandsflag.Enabled = false;
            #endregion

        }
        #endregion BM6200_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string WORKCENTERCODE = this.txtWorkCenterCode_H.Text.Trim();
                string WORKCENTERNAME = this.txtWorkCenterName_H.Text.Trim();
                string ITEMCODE = txtItemCode_H.Text.Trim();


                rtnDtTemp = helper.FillTable("USP_BM6200_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERNAME", WORKCENTERNAME, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                          );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();


                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                    //if (AFTERSAVE == 1)
                    //{
                    //    grid1.Rows[GRIDROWID].Activate();
                    //    AFTERSAVE = 0;
                    //}
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);

                    this.txtMeaCode.Text = "";
                    this.txtMeaName.Text = "";
                    this.txtItemCode.Text = "";
                    this.txtItemName.Text = "";
                    this.txtInspCode.Text = "";
                    this.txtinspname.Text = "";
                    this.cbomeatype.Value = "";
                    this.cbosepctype.Value = "";
                    this.txtspecvalue.Text = "";
                    this.chktolflag.Checked = false;
                    this.txtutolvalue.Text = "";
                    this.txtltolvalue.Text = "";
                    this.txtsepcusl.Text = "";
                    this.txtspeclsl.Text = "";
                    this.cbostandsflag.Value = "";

                    this.cbomeatype.Enabled = false;
                    this.cbosepctype.Enabled = false;
                    this.txtspecvalue.Enabled = false;
                    this.chktolflag.Enabled = false;
                    this.txtutolvalue.Enabled = false;
                    this.txtltolvalue.Enabled = false;
                    this.txtsepcusl.Enabled = false;
                    this.txtspeclsl.Enabled = false;
                    this.cbostandsflag.Enabled = false;

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

        #region 그리드 활성화
        private void grid1_ClickCell(object sender, EventArgs e)
        {

            DBHelper helper = new DBHelper(false);

            try
            {
                string WORKCENTERCODE = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                string ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                string INSPCODE = Convert.ToString(txtInspCode_H.Text);

                rtnDtTemp = helper.FillTable("USP_BM6200_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", INSPCODE, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);

                    this.txtMeaCode.Text = "";
                    this.txtMeaName.Text = "";
                    this.txtItemCode.Text = "";
                    this.txtItemName.Text = "";
                    this.txtInspCode.Text = "";
                    this.txtinspname.Text = "";
                    this.cbomeatype.Value = "V";
                    this.cbosepctype.Value = "B";
                    this.txtspecvalue.Text = "";
                    this.chktolflag.Checked = false;
                    this.txtutolvalue.Text = "";
                    this.txtltolvalue.Text = "";
                    this.txtsepcusl.Text = "";
                    this.txtspeclsl.Text = "";
                    this.cbostandsflag.Value = "N";

                    this.cbomeatype.Enabled = false;
                    this.cbosepctype.Enabled = false;
                    this.txtspecvalue.Enabled = false;
                    this.chktolflag.Enabled = false;
                    this.txtutolvalue.Enabled = false;
                    this.txtltolvalue.Enabled = false;
                    this.txtsepcusl.Enabled = false;
                    this.txtspeclsl.Enabled = false;
                    this.cbostandsflag.Enabled = false;

                    //15-11-30 기준규격적용을 버튼에서 체크로 변경하여 추가함 최재형
                    this.chkStandard.Checked = false;
                    this.chktolflag.Checked = false;
                    // this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
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

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string WORKCENTERCODE = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
                string ITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                string INSPCODE = grid2.ActiveRow.Cells["INSPCODE"].Value.ToString();
                string MEASURECODE = txtMeasureCode_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_BM6200_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", INSPCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURECODE", MEASURECODE, DbType.String, ParameterDirection.Input));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds();



                }
                else
                {
                    _GridUtil.Grid_Clear(grid3);
                    this.txtMeaCode.Text = "";
                    this.txtMeaName.Text = "";
                    this.txtItemCode.Text = "";
                    this.txtItemName.Text = "";
                    this.txtInspCode.Text = "";
                    this.txtinspname.Text = "";
                    this.cbomeatype.Value = "V";
                    this.cbosepctype.Value = "B";
                    this.txtspecvalue.Text = "";
                    this.chktolflag.Checked = false;
                    this.txtutolvalue.Text = "";
                    this.txtltolvalue.Text = "";
                    this.txtsepcusl.Text = "";
                    this.txtspeclsl.Text = "";
                    this.cbostandsflag.Value = "N";

                    this.cbomeatype.Enabled = false;
                    this.cbosepctype.Enabled = false;
                    this.txtspecvalue.Enabled = false;
                    this.chktolflag.Enabled = false;
                    this.txtutolvalue.Enabled = false;
                    this.txtltolvalue.Enabled = false;
                    this.txtsepcusl.Enabled = false;
                    this.txtspeclsl.Enabled = false;
                    this.cbostandsflag.Enabled = false;
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

        private void grid3_ClickCell(object sender, EventArgs e)
        {
            if (grid3.Rows.Count == 0)
            {
                this.txtMeaCode.Text = "";
                this.txtMeaName.Text = "";
                this.txtItemCode.Text = "";
                this.txtItemName.Text = "";
                this.txtInspCode.Text = "";
                this.txtinspname.Text = "";
                this.cbomeatype.Value = "V";
                this.cbosepctype.Value = "B";
                this.txtspecvalue.Text = "";
                this.chktolflag.Checked = false;
                this.txtutolvalue.Text = "";
                this.txtltolvalue.Text = "";
                this.txtsepcusl.Text = "";
                this.txtspeclsl.Text = "";
                this.cbostandsflag.Value = "N";

                this.cbomeatype.Enabled = false;
                this.cbosepctype.Enabled = false;
                this.txtspecvalue.Enabled = false;
                this.chktolflag.Enabled = false;
                this.txtutolvalue.Enabled = false;
                this.txtltolvalue.Enabled = false;
                this.txtsepcusl.Enabled = false;
                this.txtspeclsl.Enabled = false;
                this.cbostandsflag.Enabled = false;

                return;

            }
            else
            {
                try
                {
                    this.txtMeaCode.Text = grid3.ActiveRow.Cells["MEASURECODE"].Value.ToString();
                    this.txtMeaName.Text = grid3.ActiveRow.Cells["MEASURENAME"].Value.ToString();
                    this.txtItemCode.Text = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                    this.txtItemName.Text = grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString();
                    this.txtInspCode.Text = grid2.ActiveRow.Cells["INSPCODE"].Value.ToString();
                    this.txtinspname.Text = grid2.ActiveRow.Cells["INSPNAME"].Value.ToString();// rtnDtTemp.Rows[0]["MEASURENAME"].ToString();

                }
                catch
                {
                }
                DBHelper helper = new DBHelper(false);
                try
                {
                    rtnDtTemp = helper.FillTable("USP_BM6200_S4", CommandType.StoredProcedure
                                                                , helper.CreateParameter("WORKCENTERCODE", grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("ITEMCODE", Convert.ToString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("INSPCODE", Convert.ToString(txtInspCode.Text), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("MEASURECODE", Convert.ToString(txtMeaCode.Text), DbType.String, ParameterDirection.Input));
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        this.cbomeatype.Value = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[0]);
                        this.cbosepctype.Value = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[1]);
                        this.txtspecvalue.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[2]);
                        this.txtMEASURESEQ.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[9]);
                        this.chktolflag.Checked = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[3]) == "Y" ? true : false;
                        this.chktolflag.Enabled = true; // 15-10-28 조회된 경우 수정이 불가하여 추가 최재형

                        //15-11-30 기준규격적용을 버튼에서 체크로 변경하여 추가함 최재형
                        this.chkStandard.Checked = Convert.ToString(grid3.ActiveRow.Cells["STANDSPECUSEFLAG"].Value) == "Y" ? true : false;
                        this.chktolflag.Checked = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[10]) == "1" ? true : false;

                        //공차적용여부가 체크인 경우 상한,하한공차 필수입력
                        if (this.chktolflag.Checked.ToString() == "True")
                        {
                            //   txtutolvalue.Enabled = true;
                            //   txtltolvalue.Enabled = true;
                            txtutolvalue.Enabled = true;
                            txtltolvalue.Enabled = true;
                        }

                        //공차적용여부가 체크가 아닌 경우 상한,하한공차 입력불가
                        if (this.chktolflag.Checked.ToString() == "False")
                        {
                            this.txtutolvalue.Enabled = false;
                            this.txtltolvalue.Enabled = false;
                        }

                        this.txtutolvalue.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[4]);
                        this.txtltolvalue.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[5]);
                        this.txtsepcusl.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[6]);
                        this.txtspeclsl.Text = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[7]);
                        this.cbostandsflag.Value = Convert.ToString(rtnDtTemp.Rows[0].ItemArray[8]);


                        this.cbomeatype.Enabled = true;
                        this.cbosepctype.Enabled = true;
                        this.txtspecvalue.Enabled = true;

                        this.txtsepcusl.Enabled = false;
                        this.txtspeclsl.Enabled = false;
                        this.cbostandsflag.Enabled = true;
                        if (rtnDtTemp.Rows[0]["MEASURETYPE"].ToString() == "D" || rtnDtTemp.Rows[0]["MEASURETYPE"].ToString() == "V")
                        {
                            cbosepctype.ReadOnly = false;
                            cbosepctype.Enabled = true;
                            txtspecvalue.Enabled = true;
                            txtsepcusl.Enabled = false;
                            txtspeclsl.Enabled = false;

                        }
                        else
                        {

                            cbosepctype.ReadOnly = false;
                            cbosepctype.Enabled = false;
                            txtspecvalue.Enabled = false;
                            txtsepcusl.Enabled = false;
                            txtspeclsl.Enabled = false;
                            txtutolvalue.Enabled = false;
                            txtltolvalue.Enabled = false;
                        }
                    }
                    else
                    {
                        this.cbomeatype.Value = "V";
                        this.cbosepctype.Value = "B";
                        this.txtspecvalue.Text = "";
                        this.chktolflag.Checked = false;
                        this.txtutolvalue.Text = "";
                        this.txtltolvalue.Text = "";
                        this.txtsepcusl.Text = "";
                        this.txtspeclsl.Text = "";
                        this.cbostandsflag.Value = "N";

                        this.cbomeatype.Enabled = false;
                        this.cbosepctype.Enabled = false;
                        this.txtspecvalue.Enabled = false;
                        this.chktolflag.Enabled = false;
                        this.txtutolvalue.Enabled = false;
                        this.txtltolvalue.Enabled = false;
                        this.txtsepcusl.Enabled = false;
                        this.txtspeclsl.Enabled = false;
                        this.cbostandsflag.Enabled = false;
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
        #endregion

        #region event
        //toolbar 저장 클릭시,
        public override void DoSave()
        {
            if (grid3.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("저장할 데이터가 없습니다.", "MSG"));
                return;
            }
            string gubun = "SAVE";
            string WORKCENTERCODE = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            string ITEMCODE = this.txtItemCode.Text.ToString();
            string INSPCODE = this.txtInspCode.Text.ToString();
            string MEASURECODE = this.txtMeaCode.Text.ToString();
            string MESULETYPE = Convert.ToString(this.cbomeatype.Value);
            string SEPCTYPE = Convert.ToString(this.cbosepctype.Value);
            string SPECVALUE = this.txtspecvalue.Text.ToString();
            string TOLFLAG = this.chktolflag.Checked == true ? "Y" : "N";
            string UTOLVALUE = this.txtutolvalue.Text.ToString();
            string LTOLVALUE = this.txtltolvalue.Text.ToString();
            string SEPCUSL = this.txtsepcusl.Text.ToString();
            string SPECLSL = this.txtspeclsl.Text.ToString();
            string USEFLAG = Convert.ToString(this.cbostandsflag.Value);
            string MEASURESEQ = this.txtMEASURESEQ.Text;

            //측정값 구분이 값 또는 값+판정이면 규격, USL, LSL 필수입력
            if (MESULETYPE == "V" || MESULETYPE == "D")
            {
                if (SPECVALUE == "")
                {
                    this.ShowDialog(Common.getLangText("규격을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                // USL 과 LSL 이 규격 에 맞는 값인지 체크
                if (Convert.ToDouble(SPECVALUE) < Convert.ToDouble(SPECLSL))
                {
                    this.ShowDialog(Common.getLangText("LSL 은 규격보다 클 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                else if (Convert.ToDouble(SPECVALUE) > Convert.ToDouble(SEPCUSL))
                {
                    this.ShowDialog(Common.getLangText("USL 은 규격보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                else if (Convert.ToDouble(SEPCUSL) < 0 || Convert.ToDouble(SPECLSL) < 0)
                {
                    //// 온도 등을 제외한 음수값의 기준정보 입력 체크
                    //this.ShowDialog("USL , LSL 은 음수의 값을 가질수 없습니다.", Forms.DialogForm.DialogType.OK);
                    //return;
                }
            }
            ////공차적용여부가 체크인 경우 상한,하한공차 필수입력
            //if (MESULETYPE != "D")
            //{
            //    if (UTOLVALUE == "0" || LTOLVALUE == "0")
            //    {
            //        this.ShowDialog("상한공차, 하한공차를 입력하세요.", Forms.DialogForm.DialogType.OK);
            //        return;
            //    }
            //}

            //15-11-30 미사용으로 변경하여 저장시 기준규격여부 체크 해제
            //if (chkStandard.Checked == true && USEFLAG == "N")
            //{
            //    this.ShowDialog("미사용으로 변경시 기준규격여부를 체크 해제 후 진행하세요.", Forms.DialogForm.DialogType.OK);
            //    return;
            //}

            string STANDSPECUSEFLAG = "N";
            string MachMeasureFLAG = "0";
            //15-11-30 기준규격적용을 버튼에서 체크로 변경하여 추가함 최재형
            if (chkStandard.Checked == true)
            {
                gubun = "STAND";
                STANDSPECUSEFLAG = "Y";
            }

            if (chktolflag.Checked == true)
            {
                MachMeasureFLAG = "1";
            }
            SAVE(gubun, WORKCENTERCODE, ITEMCODE, INSPCODE, MEASURECODE,
                 MESULETYPE, SEPCTYPE, SPECVALUE, TOLFLAG, UTOLVALUE,
                 LTOLVALUE, SEPCUSL, SPECLSL, USEFLAG, MEASURESEQ, STANDSPECUSEFLAG, MachMeasureFLAG);
        }

        // 기준규격 적용 버튼 클릭시,
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //  if (grid3.Rows.Count == 0)
            //  {
            //      MessageBox.Show("저장할 데이터가 없습니다.");
            //      return;
            //  }
            //string gubun               = "STAND";
            //string WORKCENTERCODE      = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            //string ITEMCODE            = this.txtItemCode.Text.ToString();
            //string INSPCODE            = this.txtInspCode.Text.ToString();
            //string MEASURECODE         = this.txtMeaCode.Text.ToString();
            //string MEASURESEQ          = this.txtMEASURESEQ.Text;
            //string MESULETYPE          = "";
            //string SEPCTYPE            = "";
            //string SPECVALUE           = "";
            //string TOLFLAG             = "";
            //string UTOLVALUE           = "";
            //string LTOLVALUE           = "";
            //string SEPCUSL             = "";
            //string SPECLSL             = "";
            //string USEFLAG             = "";

            //SAVE(gubun, WORKCENTERCODE, ITEMCODE, INSPCODE, MEASURECODE,
            //     MESULETYPE, SEPCTYPE, SPECVALUE, TOLFLAG, UTOLVALUE,
            //     LTOLVALUE, SEPCUSL, SPECLSL, USEFLAG, MEASURESEQ);
        }

        // 품목별 검사 기준 규격 적용 버큰 클릭시
        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (grid3.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("품목의 검사기준 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            string gubun = "INSP";
            string WORKCENTERCODE = grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString();
            string ITEMCODE = this.txtItemCode.Text.ToString();
            string INSPCODE = this.txtInspCode.Text.ToString();
            string MEASURECODE = this.txtMeaCode.Text.ToString();
            string MEASURESEQ = this.txtMEASURESEQ.Text;
            string MESULETYPE = "";
            string SEPCTYPE = "";
            string SPECVALUE = "";
            string TOLFLAG = "";
            string UTOLVALUE = "";
            string LTOLVALUE = "";
            string SEPCUSL = "";
            string SPECLSL = "";
            string USEFLAG = "";

            SAVE(gubun, WORKCENTERCODE, ITEMCODE, INSPCODE, MEASURECODE,
                 MESULETYPE, SEPCTYPE, SPECVALUE, TOLFLAG, UTOLVALUE,
                 LTOLVALUE, SEPCUSL, SPECLSL, USEFLAG, MEASURESEQ);
        }

        #endregion


        #region function

        public void SAVE(string gubun, string WORKCENTERCODE, string ITEMCODE, string INSPCODE, string MEASURECODE,
                 string MESULETYPE, string SEPCTYPE, string SPECVALUE, string TOLFLAG, string UTOLVALUE,
                 string LTOLVALUE, string SEPCUSL, string SPECLSL, string USEFLAG, string MEASURESEQ, string STANDSPECUSEFLAG, string MACHMEASUREFLAG)
        {

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper(false);
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM6200_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("gubun", gubun, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", INSPCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURECODE", MEASURECODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURETYPE", MESULETYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SEPCTYPE", SEPCTYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SPECVALUE", SPECVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TOLFLAG", TOLFLAG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("UTOLVALUE", UTOLVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("LTOLVALUE", LTOLVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SEPCUSL", SEPCUSL, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SPECLSL", SPECLSL, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("USEFLAG", USEFLAG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURESEQ", MEASURESEQ, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STANDSPECUSEFLAG", STANDSPECUSEFLAG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MACHMEASURE", MACHMEASUREFLAG, DbType.String, ParameterDirection.Input)
                                                            );
                if (helper.RSCODE == "S")
                {
                    string sMsg = helper.RSMSG;
                    this.ClosePrgFormNew();
                    helper.Commit();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    //this.ShowDialog("데이터가 저장되었습니다.", Forms.DialogForm.DialogType.OK);

                    string sMEACODE = Convert.ToString(this.grid3.ActiveRow.Cells["MEASURECODE"].Value);
                    grid2_ClickCell(null, null);
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(this.grid3.Rows[i].Cells["MEASURECODE"].Value) == sMEACODE)
                        {
                            this.grid3.Rows[i].Activated = true;
                            break;
                        }
                    }


                    //AFTERSAVE = 1;
                    // GRIDROWID = grid1.ActiveRow.Index;
                    // DoInquire();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
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


        public void SAVE(string gubun, string WORKCENTERCODE, string ITEMCODE, string INSPCODE, string MEASURECODE,
                 string MESULETYPE, string SEPCTYPE, string SPECVALUE, string TOLFLAG, string UTOLVALUE,
                 string LTOLVALUE, string SEPCUSL, string SPECLSL, string USEFLAG, string MEASURESEQ)
        {

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper(false);
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM6200_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("gubun", gubun, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKCENTERCODE", WORKCENTERCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", INSPCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURECODE", MEASURECODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURETYPE", MESULETYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SEPCTYPE", SEPCTYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SPECVALUE", SPECVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TOLFLAG", TOLFLAG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("UTOLVALUE", UTOLVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("LTOLVALUE", LTOLVALUE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SEPCUSL", SEPCUSL, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SPECLSL", SPECLSL, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("USEFLAG", USEFLAG, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MEASURESEQ", MEASURESEQ, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STANDSPECUSEFLAG", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MACHMEASURE", "", DbType.String, ParameterDirection.Input)
                                                            );
                if (helper.RSCODE == "S")
                {
                    string sMsg = helper.RSMSG;
                    this.ClosePrgFormNew();
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                    string sMEACODE = Convert.ToString(this.grid3.ActiveRow.Cells["MEASURECODE"].Value);
                    grid2_ClickCell(null, null);
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(this.grid3.Rows[i].Cells["MEASURECODE"].Value) == sMEACODE)
                        {
                            this.grid3.Rows[i].Activated = true;
                            break;
                        }
                    }


                    //AFTERSAVE = 1;
                    // GRIDROWID = grid1.ActiveRow.Index;
                    // DoInquire();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
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
        private new void KeyPress(object sender, KeyPressEventArgs e)
        {
            string values = ((WIZ.Control.STextBox)sender).Text;

            ///숫자,백스페이스,마이너스,소숫점 만 입력받는다.
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 45) //8:백스페이스,46:소수점
            {
                e.Handled = true;
                return;
            }
            // - 입력시


            //소수점입력시
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (values == "")
                {
                    e.Handled = true;
                    ((WIZ.Control.STextBox)sender).Text = "0.";
                    ((WIZ.Control.STextBox)sender).SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = values;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }


            // 소수점 3자리까지 입력가능
            string InspValue1 = values;
            string[] a1 = InspValue1.Split('.');
            if (a1.Length > 1)
            {
                if (a1[1].Length > 2)
                {
                    //문자 전체 선택시, 숫자, 백스페이스 입력가능하게
                    if (((WIZ.Control.STextBox)sender).SelectionLength == values.Length)
                    {
                        if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8) //8:백스페이스,46:소수점
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (e.KeyChar != 8)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }

            // 엔터입력시 형식 바꿔줌.
            if (e.KeyChar == 13)
            {
                string InspValue2 = values;
                string[] a2 = InspValue2.Split('.');
                if (a2.Length > 1)
                {
                    ((WIZ.Control.STextBox)sender).Text = string.Format("{0:#,##0}", double.Parse(a2[0])) + "." + a2[1];
                }
                else
                {
                    if (a2[0].Length > 1)
                        ((WIZ.Control.STextBox)sender).Text = string.Format("{0:#,##0}", double.Parse(a2[0]));
                }
                ((WIZ.Control.STextBox)sender).Select(((WIZ.Control.STextBox)sender).Text.Length, 0);
            }

        }

        //엔터입력 없이, 형식 바꿔줌.
        private new void Validated(object sender, EventArgs e)
        {
            string InspValue2 = ((WIZ.Control.STextBox)sender).Text;
            string[] a2 = InspValue2.Split('.');
            if (a2.Length > 1)
            {
                if (a2[0].Substring(0, 1) == "-")
                    ((WIZ.Control.STextBox)sender).Text = Convert.ToString(Convert.ToDouble(string.Format("{0:#,##0}", double.Parse(a2[0])) + "." + a2[1]) * -1);
                else
                    ((WIZ.Control.STextBox)sender).Text = string.Format("{0:#,##0}", double.Parse(a2[0])) + "." + a2[1];
            }
            else
            {
                if (a2[0].Length > 1)
                {
                    if (a2[0].Substring(0, 1) == "-")
                        ((WIZ.Control.STextBox)sender).Text = Convert.ToString(Convert.ToDouble(string.Format("{0:#,##0}", double.Parse(a2[0]))) * -1);
                }
            }
        }

        #endregion

        private void cbomeatype_ValueChanged(object sender, EventArgs e)
        {
            sGunbun = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value.ToString();

            //측정값 구분이 판정이면 값 입력 불가
            if (sGunbun == "J")
            {
                txtspecvalue.Enabled = false;
                txtutolvalue.Enabled = false;
                txtltolvalue.Enabled = false;
                txtsepcusl.Enabled = false;
                txtspeclsl.Enabled = false;
                chktolflag.Checked = false;
                chktolflag.Enabled = false;
                cbosepctype.ReadOnly = true;
                cbosepctype.Enabled = false;

            }

            //측정값 구분이 값 또는 값+판정이면 규격, USL, LSL 필수입력
            if (sGunbun == "V" || sGunbun == "D")
            {

                txtspecvalue.Enabled = true;
                txtutolvalue.Enabled = true;
                txtltolvalue.Enabled = true;
                txtsepcusl.Enabled = false;
                txtspeclsl.Enabled = false;
                chktolflag.Checked = true;
                chktolflag.Enabled = true;
                cbosepctype.ReadOnly = false;
                cbosepctype.Enabled = true;

            }
        }

        private void chktolflag_CheckedChanged(object sender, EventArgs e)
        {
            sChk = ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Checked.ToString();

            //공차적용여부가 체크인 경우 상한,하한공차 필수입력
            if (sChk == "True")
            {
                txtutolvalue.Enabled = true;
                txtltolvalue.Enabled = true;
            }

            //공차적용여부가 체크가 아닌 경우 상한,하한공차 입력불가
            if (sChk == "False")
            {
                txtutolvalue.Enabled = false;
                txtltolvalue.Enabled = false;

            }
        }

        private void txtspecvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtUTOLVALUE = 0;
                double stxtLTOLVALUE = 0;

                if (txtspecvalue.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtspecvalue.Text);
                if (txtutolvalue.Text == "") stxtUTOLVALUE = 0;
                else stxtUTOLVALUE = Convert.ToDouble(txtutolvalue.Text);

                txtsepcusl.Text = Convert.ToString(stxtSPECVALUE + stxtUTOLVALUE);

                if (txtltolvalue.Text == "") stxtLTOLVALUE = 0;
                else stxtLTOLVALUE = Convert.ToDouble(txtltolvalue.Text);

                txtspeclsl.Text = Convert.ToString(stxtSPECVALUE - stxtLTOLVALUE);
            }
            catch
            {
            }
        }

        private void txtltolvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtLTOLVALUE = 0;

                if (txtspecvalue.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtspecvalue.Text);
                if (txtltolvalue.Text == "") stxtLTOLVALUE = 0;
                else stxtLTOLVALUE = Convert.ToDouble(txtltolvalue.Text);

                txtspeclsl.Text = Convert.ToString(stxtSPECVALUE - stxtLTOLVALUE);
            }
            catch
            {
            }
        }

        private void txtutolvalue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtUTOLVALUE = 0;

                if (txtspecvalue.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtspecvalue.Text);
                if (txtutolvalue.Text == "") stxtUTOLVALUE = 0;
                else stxtUTOLVALUE = Convert.ToDouble(txtutolvalue.Text);

                txtsepcusl.Text = Convert.ToString(stxtSPECVALUE + stxtUTOLVALUE);
            }
            catch
            {
            }
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void grid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void grid3_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

    }
}
