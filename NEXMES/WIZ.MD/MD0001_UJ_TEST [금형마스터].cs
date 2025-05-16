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
using System.IO;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using System.Text;
using System.Windows.Forms.VisualStyles;
#endregion

namespace WIZ.MD
{
    public partial class MD0001_UJ : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataSet DSGrid1 = new DataSet();
        DataSet DSGrid2 = new DataSet();
        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();
        DataTable dtGrid3 = new DataTable();

        string MOLDCODE = "";

        /// <summary>
        /// N : DoNew / S : Normal
        /// </summary>
        string ModeStatus = "";
        string PicSaveStatus = "";
        int CheckCavity = 0;

        string IMAGEPATH1 = "";
        string IMAGEPATH2 = "";
        string IMAGEPATH3 = "";
        string PIMAGEPATH1 = "";
        string PIMAGEPATH2 = "";

        string PictureSaveFolder = @"C:\UJ_MES\MD_Master\";
        string PictureSaveFile1 = "";
        string PictureSaveFile2 = "";
        string PictureSaveFile3 = "";
        string PictureSaveFile4 = "";
        string PictureSaveFile5 = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0001_UJ()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD000_TEST_Load(object sender, EventArgs e)
        {
            GridInitialize();

            IMAGE1.AllowDrop = true;
            IMAGE2.AllowDrop = true;
            IMAGE3.AllowDrop = true;
            PIMAGE1.AllowDrop = true;
            PIMAGE2.AllowDrop = true;
            
            string MD = WIZ.LoginInfo.UserID;

            DoInquire();
        }

        public float CAPA(float cycle, float cavity, float sub)
        {
            float set = 0;

            if (cycle != 0)
            {
                //사이클타임, 캐비티, 일 수

                // CAPA/일 : 22시간 * 60분 * 60초 = 79200
                // CAPA/월 : CAPA/일 * 25일
                set = 79200 / cycle * cavity * sub;
            }
            else
            {
                set = 0;
            }
            return set;
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형번호", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DEGREE",   "차수", true, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                //DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE1"); //신작 증작 이관
                WIZ.Common.FillComboboxMaster(this.txtMOLDTYPE1, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

                rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE2"); //개발 양산
                WIZ.Common.FillComboboxMaster(this.txtMOLDTYPE2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

                rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE3"); //소형 중형 대형
                WIZ.Common.FillComboboxMaster(this.txtMOLDTYPE3, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

                rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTYPE4"); //슬라이드 2단 3단
                WIZ.Common.FillComboboxMaster(this.txtMOLDTYPE4, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

                //rtnDtTemp = _Common.GET_BM0000_CODE("MOLDGRADE"); //금형등급, 개발 후 선택
                //WIZ.Common.FillComboboxMaster(this.txtGRADE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

                btbManager.PopUpAdd(txtMOLDMAKECOMPANY, txtMCNAME, "BM0030", new object[] { 10, "", "", "" });
                btbManager.PopUpAdd(txtMOLDUSECOMPANY, txtUCNAME, "BM0030", new object[] { 10, "", "", "" });
                
                //bizGrid2Manager.PopUpClosed += BizGridManager_PopUpClosed;

                #endregion

                //dtGrid = (DataTable)grid1.DataSource;
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
            ClosePrgFormNew();
            DBHelper helper = new DBHelper(false);

            try
            {
                //string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                //string sUseFlag = CModule.ToString(cbo_USEFLAG_H.Value);

                _GridUtil.Grid_Clear(grid1);

                //base.DoInquire();

                DSGrid1 = helper.FillDataSet("USP_MD0000_UJ_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_MOLDCODE", "", DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = DSGrid1.Tables[0];
                    grid1.DataBinds();
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

        public override void DoNew()
        {
            ModeStatus = "N";

            try
            {
                base.DoNew();

                if (bNew)
                {
                    this.ShowDialog(Common.getLangText("입력 중인 금형정보가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

                txtMOLDMAKEDATE.Value = DateTime.Now;

                CLEAN();

                txtMOLDCODE.Text = "[ NEW MOLDCODE ]";


                grid1.UpdateData();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        public override void DoDelete()
        {
           // base.DoDelete();

            //this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            //DBHelper helper = new DBHelper("", true);
            DBHelper helper = new DBHelper(false);

            if (CheckCavity == 1)
            {
                try
                {
                    //저장, 수정
                    rtnDtTemp = helper.FillTable("USP_MD0000_UJ_SAVE", CommandType.StoredProcedure

                        //, helper.CreateParameter("AS_MOLDCODE", grid1.ActiveRow.Cells["MOLDCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDCODE", txtMOLDCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDNAME", txtMOLDNAME.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_DEGREE", txtDEGREE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDMNO", txtMOLDMNO.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDPROD", cbo_NPRODITEM.Text, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_QRCODE", txtQRCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE1", txtMOLDTYPE1.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE2", txtMOLDTYPE2.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE3", txtMOLDTYPE3.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE4", txtMOLDTYPE4.Value, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_INITIALSHOT", txtINITIALSHOT.Text, DbType.Int16, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USESHOT", txtUSESHOT.Text, DbType.Int16, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TOALSHOT", txtTOALSHOT.Text, DbType.Int16, ParameterDirection.Input)

                        , helper.CreateParameter("AS_MOLDMAKECOMPANY", txtMOLDMAKECOMPANY.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDMAKEDATE", txtMOLDMAKEDATE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CAVITYNUM", txtCAVITYNUM.Text, DbType.Int16, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CAVITYSTRING", txtCAVITYSTRING.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WIDTH", txtWIDTH.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_LENGTH", txtLENGTH.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_HEIGHT", txtHEIGHT.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_WEIGHT", txtWEIGHT.Text, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_MOLDUSECOMPANY", txtMOLDUSECOMPANY.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TRANSFERDATE", txtTRANSFERDATE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USECAVITY", txtUSECAVITY.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_GRADE", txtGRADE.Value, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_CYCLETIME", txtCYCLETIME.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CAPADATE", txtCAPADATE.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CAPAMONTH", txtCAPAMONTH.Text, DbType.Double, ParameterDirection.Input)

                        , helper.CreateParameter("AS_USECYCLETIME", txtUSECYCLETIME.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USECAPADATE", txtUSECAPADATE.Text, DbType.Double, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USECAPAMONTH", txtUSECAPAMONTH.Text, DbType.Double, ParameterDirection.Input)

                        , helper.CreateParameter("AS_INSPCYCLE", txtINSPCYCLE.Text, DbType.Int16, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MAKECOST", txtMAKECOST.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_DELDATE", txtDELDATE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_RETURNDATE", txtRETURNDATE.Text, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_IMAGE1", PictureSaveFolder + @"" + txtMOLDCODE.Text + "_001.jpg", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_IMAGE2", PictureSaveFolder + @"" + txtMOLDCODE.Text + "_002.jpg", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_IMAGE3", PictureSaveFolder + @"" + txtMOLDCODE.Text + "_003.jpg", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PIMAGE1", PictureSaveFolder + @"" + txtMOLDCODE.Text + "_004.jpg", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PIMAGE2", PictureSaveFolder + @"" + txtMOLDCODE.Text + "_005.jpg", DbType.String, ParameterDirection.Input));


                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    MOLDCODE = DBHelper.nvlString(rtnDtTemp.Rows[0]["RS_MOLDCODE"]);

                    helper.Commit();

                    try
                    {
                        string[] CVTnum;

                        string sCAVITYSTRING = txtCAVITYSTRING.Text.Trim();
                        int Leng = txtCAVITYSTRING.Text.Trim().Length;

                        CVTnum = new string[Leng];

                        string query = "DELETE FROM MD0010_UJ ";
                        query += "WHERE MOLDCODE = '" + MOLDCODE + "'";
                        helper.ExecuteNoneQuery(query);


                        for (int i = 0; i < sCAVITYSTRING.Length; i++)
                        {
                            CVTnum[i] = sCAVITYSTRING.Substring(i, 1);

                            //저장, 수정
                            helper.ExecuteNoneQuery("USP_MD0010_UJ_SAVE", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_MOLDCODE", MOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CAVITYNAME", CVTnum[i], DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));
                        }

                        if (helper.RSCODE == "E")
                        {
                            throw new Exception(helper.RSMSG);
                        }

                        ModeStatus = "S";
                        DoInquire();

                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
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
            else
            {
                this.ShowDialog("캐비티 코드를 확인해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
            }

        }
        #endregion



        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (ModeStatus == "N")
            {
                if (this.ShowDialog("추가를 취소하시겠습니까?", WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    ModeStatus = "S";
                    DoInquire();
                }
                else
                {
                    DoNew();
                }
            }
            else
            {

                if (grid1.ActiveCell == null)
                {
                    return;
                }

                try
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                    string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

                    if (sMoldCode == "[ NEW MOLDCODE ]")
                    {
                        CLEAN();
                    }

                    else
                    {
                        DSGrid1 = helper.FillDataSet("USP_MD0000_UJ_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input));

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        cbo_NPRODITEM.Items.Clear();
                        CheckCavity = 0;

                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                        {
                            listBox2.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMCODE"]) + " - " + CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                        }
                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[2].Rows.Count; grid1rowNUM++)
                        {
                            listBox1.Items.Add(CModule.ToString(DSGrid1.Tables[2].Rows[grid1rowNUM]["CORE_CoreName"]));
                        }
                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                        {
                            cbo_NPRODITEM.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                        }

                        SetMoldInfo(DSGrid1.Tables[1]);
                    }
                }
                catch (Exception ex)
                {
                    //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
        }
        //금형코드로 검색 후 상세정보 텍스트박스에 기입 
        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtMOLDCODE.Text = CModule.ToString(DTinfo.Rows[0]["MOLDCODE"]);
                txtMOLDNAME.Text = CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);

                txtDEGREE.Text = CModule.ToString(DTinfo.Rows[0]["DEGREE"]);
                txtMOLDMNO.Text = CModule.ToString(DTinfo.Rows[0]["MOLDMNO"]);
                txtQRCODE.Text = CModule.ToString(DTinfo.Rows[0]["QRCODE"]);
                txtMOLDTYPE1.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE1"]);
                txtMOLDTYPE2.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE2"]);
                txtMOLDTYPE3.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE3"]);
                txtMOLDTYPE4.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE4"]);

                cbo_NPRODITEM.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtINITIALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["INITIALSHOT"]);
                txtUSESHOT.Text = CModule.ToString(DTinfo.Rows[0]["USESHOT"]);
                txtTOALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["TOALSHOT"]);

                txtMOLDMAKECOMPANY.Text = CModule.ToString(DTinfo.Rows[0]["MOLDMAKECOMPANY"]);
                txtMCNAME.Text = CModule.ToString(DTinfo.Rows[0]["MCNAME"]);
                txtMOLDMAKEDATE.Text = CModule.ToString(DTinfo.Rows[0]["MOLDMAKEDATE"]);
                txtCAVITYNUM.Text = CModule.ToString(DTinfo.Rows[0]["CAVITYNUM"]);
                txtCAVITYSTRING.Text = CModule.ToString(DTinfo.Rows[0]["CAVITYSTRING"]);
                txtWIDTH.Text = CModule.ToString(DTinfo.Rows[0]["WIDTH"]);
                txtLENGTH.Text = CModule.ToString(DTinfo.Rows[0]["LENGTH"]);
                txtHEIGHT.Text = CModule.ToString(DTinfo.Rows[0]["HEIGHT"]);
                txtWEIGHT.Text = CModule.ToString(DTinfo.Rows[0]["WEIGHT"]);

                txtMOLDUSECOMPANY.Text = CModule.ToString(DTinfo.Rows[0]["MOLDUSECOMPANY"]);
                txtUCNAME.Text = CModule.ToString(DTinfo.Rows[0]["MOLDUSECOMPANY"]);
                txtTRANSFERDATE.Text = CModule.ToString(DTinfo.Rows[0]["TRANSFERDATE"]);
                txtUSECAVITY.Text = CModule.ToString(DTinfo.Rows[0]["USECAVITY"]);
                txtGRADE.Text = CModule.ToString(DTinfo.Rows[0]["GRADE"]);

                txtCYCLETIME.Text = CModule.ToString(DTinfo.Rows[0]["CYCLETIME"]);
                txtCAPADATE.Text = CModule.ToString(DTinfo.Rows[0]["CAPADATE"]);
                txtCAPAMONTH.Text = CModule.ToString(DTinfo.Rows[0]["CAPAMONTH"]);

                txtUSECYCLETIME.Text = CModule.ToString(DTinfo.Rows[0]["USECYCLETIME"]);
                txtUSECAPADATE.Text = CModule.ToString(DTinfo.Rows[0]["USECAPADATE"]);
                txtUSECAPAMONTH.Text = CModule.ToString(DTinfo.Rows[0]["USECAPAMONTH"]);

                txtINSPCYCLE.Text = CModule.ToString(DTinfo.Rows[0]["INSPCYCLE"]);
                txtMAKECOST.Text = CModule.ToString(DTinfo.Rows[0]["MAKECOST"]);
                txtDELDATE.Text = CModule.ToString(DTinfo.Rows[0]["DELDATE"]);
                txtRETURNDATE.Text = CModule.ToString(DTinfo.Rows[0]["RETURNDATE"]);

                if (CModule.ToString(DTinfo.Rows[0]["IMAGE1"]) == "" || CModule.ToString(DTinfo.Rows[0]["IMAGE1"]) == null)
                {
                    IMAGE1.Image = default;
                }
         
                else
                    IMAGE1.Load(@"" + CModule.ToString(DTinfo.Rows[0]["IMAGE1"]) + "");

                if (CModule.ToString(DTinfo.Rows[0]["IMAGE2"]) == "" || CModule.ToString(DTinfo.Rows[0]["IMAGE2"]) == null)
                {
                    IMAGE2.Image = default;
                }
                else
                    IMAGE2.Load(@"" + CModule.ToString(DTinfo.Rows[0]["IMAGE2"]) + "");

                if (CModule.ToString(DTinfo.Rows[0]["IMAGE3"]) == "" || CModule.ToString(DTinfo.Rows[0]["IMAGE3"]) == null)
                {
                    IMAGE3.Image = default;
                }
                else
                    IMAGE3.Load(@"" + CModule.ToString(DTinfo.Rows[0]["IMAGE3"]) + "");

                if (CModule.ToString(DTinfo.Rows[0]["PIMAGE1"]) == "" || CModule.ToString(DTinfo.Rows[0]["PIMAGE1"]) == null)
                {
                    PIMAGE1.Image = default;
                }
                else
                    PIMAGE1.Load(@"" + CModule.ToString(DTinfo.Rows[0]["PIMAGE1"]) + "");

                if (CModule.ToString(DTinfo.Rows[0]["PIMAGE2"]) == "" || CModule.ToString(DTinfo.Rows[0]["PIMAGE2"]) == null)
                {
                    PIMAGE2.Image = default;
                }
                else
                    PIMAGE2.Load(@"" + CModule.ToString(DTinfo.Rows[0]["PIMAGE2"]) + "");
                //사용가능 설비 리스트
            }
            else
            {
                CLEAN();
            }

        }

        private void CLEAN()
        {
            txtMOLDCODE.Text = "";
            txtMOLDNAME.Text = "";

            txtDEGREE.Text = "";
            txtMOLDMNO.Text = "";
            txtQRCODE.Text = "";
            txtMOLDTYPE1.Text = "";
            txtMOLDTYPE2.Text = "";
            txtMOLDTYPE3.Text = "";
            txtMOLDTYPE4.Text = "";

            txtINITIALSHOT.Text = "";
            txtUSESHOT.Text = "";
            txtTOALSHOT.Text = "";

            txtMOLDMAKECOMPANY.Text = "";
            txtMCNAME.Text = "";
            txtMOLDMAKEDATE.Text = "";
            txtCAVITYNUM.Text = "";
            txtCAVITYSTRING.Text = "";
            txtWIDTH.Text = "";
            txtLENGTH.Text = "";
            txtHEIGHT.Text = "";
            txtWEIGHT.Text = "";

            txtMOLDUSECOMPANY.Text = "";
            txtUCNAME.Text = "";
            txtTRANSFERDATE.Text = "";
            txtUSECAVITY.Text = "";
            txtGRADE.Text = "";

            txtCYCLETIME.Text = "";
            txtCAPADATE.Text = "";
            txtCAPAMONTH.Text = "";

            txtUSECYCLETIME.Text = "";
            txtUSECAPADATE.Text = "";
            txtUSECAPAMONTH.Text = "";

            txtINSPCYCLE.Text = "";
            txtMAKECOST.Text = "";
            txtDELDATE.Text = "";
            txtRETURNDATE.Text = "";

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            IMAGE1.Image = default;
            IMAGE2.Image = default;
            IMAGE3.Image = default;
            PIMAGE1.Image = default;
            PIMAGE1.Image = default;
        }

        #region <IMAGE EVENT>

        private void ImageCopy(string orgFilename, string NewFileName)
        {
            File.Copy(orgFilename, NewFileName, true);
            this.ShowDialog("사진 저장 완료", WIZ.Forms.DialogForm.DialogType.OK);
        }

        private void IMAGE1_DragDrop(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {

            }
            else
            {
                try
                {
                    var directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                    IMAGEPATH1 = directoryName[0];
                    ImageCopy(IMAGEPATH1, PictureSaveFolder + @"" + txtMOLDCODE.Text + "_001.jpg");
                    IMAGE1.Image = Image.FromFile(directoryName[0], true);
                }
                catch
                {

                }
            }
        }

        private void IMAGE1_DragEnter(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {
            }
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void IMAGE2_DragDrop(object sender, DragEventArgs e)
        {

            if (ModeStatus == "N")
            {

            }
            else
            {
                try
                {
                    var directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                    IMAGEPATH2 = directoryName[0];
                    ImageCopy(IMAGEPATH2, PictureSaveFolder + @"" + txtMOLDCODE.Text + "_002.jpg");
                    IMAGE2.Image = Image.FromFile(directoryName[0], true);
                }
                catch
                {

                }
            }
        }

        private void IMAGE2_DragEnter(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {
            }
            else
                e.Effect = DragDropEffects.Copy;

        }

        private void IMAGE3_DragDrop(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {

            }
            else
            {
                try
                {
                    var directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                    IMAGEPATH3 = directoryName[0];
                    ImageCopy(IMAGEPATH3, PictureSaveFolder + @"" + txtMOLDCODE.Text + "_003.jpg");
                    IMAGE3.Image = Image.FromFile(directoryName[0], true);
                }
                catch
                {

                }
            }
        }

        private void IMAGE3_DragEnter(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {
            }
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void PIMAGE1_DragDrop(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {

            }
            else
            {
                try
                {
                    var directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                    PIMAGEPATH1 = directoryName[0];
                    ImageCopy(PIMAGEPATH1, PictureSaveFolder + @"" + txtMOLDCODE.Text + "_004.jpg");
                    PIMAGE1.Image = Image.FromFile(directoryName[0], true);
                }
                catch
                {

                }
            }
        }

        private void PIMAGE1_DragEnter(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {
            }
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void PIMAGE2_DragDrop(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {
            }
            else
            {
                try
                {
                    var directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                    PIMAGEPATH2 = directoryName[0];
                    ImageCopy(PIMAGEPATH2, PictureSaveFolder + @"" + txtMOLDCODE.Text + "_005.jpg");
                    PIMAGE2.Image = Image.FromFile(directoryName[0], true);
                }
                catch
                {

                }
            }
        }

        private void PIMAGE2_DragEnter(object sender, DragEventArgs e)
        {
            if (ModeStatus == "N")
            {

            }
            else
                e.Effect = DragDropEffects.Copy;
        }

        #endregion

        private void txtCAVITYNUM_TextChanged(object sender, EventArgs e)
        {
            /*
            if (txtCAVITYNUM.Text.Length == 0)
                return;

            ////아스키65 = A
            //char c = (char)65;
            //char c = Convert.ToChar(65);
            //string s = Encoding.ASCII.GetString(new byte[]{ 65 });

            int ascii = 65;
            char code = Convert.ToChar(ascii);

            txtCAVITYSTRING.Text = "";

            //캐비티 수 별 캐비티리스트 생성
            for (int c = 0; c < Convert.ToInt16(txtCAVITYNUM.Text); c++)
            {
                txtCAVITYSTRING.Text += Convert.ToChar(ascii + c);
            }

            txtCAPADATE.Value = CAPA(CModule.ToFloat(txtCYCLETIME.Text), CModule.ToFloat(txtCAVITYNUM.Text), 1);
            txtCAPAMONTH.Value = CAPA(CModule.ToFloat(txtCYCLETIME.Text), CModule.ToFloat(txtCAVITYNUM.Text), 25); // txtCAPADATE.Value * 25
            */
        }

        private void txtCYCLETIME_TextChanged(object sender, EventArgs e)
        {
            txtCAPADATE.Value = CAPA(CModule.ToFloat(txtCYCLETIME.Text), CModule.ToFloat(txtCAVITYNUM.Text), 1);
            txtCAPAMONTH.Value = CAPA(CModule.ToFloat(txtCYCLETIME.Text), CModule.ToFloat(txtCAVITYNUM.Text), 25); // txtCAPADATE.Value * 25
        }

        private void txtUSECYCLETIME_TextChanged(object sender, EventArgs e)
        {
            txtUSECAPADATE.Value = CAPA(CModule.ToFloat(txtUSECYCLETIME.Text), CModule.ToFloat(txtUSECAVITY.Text), 1);
            txtUSECAPAMONTH.Value = CAPA(CModule.ToFloat(txtUSECYCLETIME.Text), CModule.ToFloat(txtUSECAVITY.Text), 25); // txtCAPADATE.Value * 25
        }

        private void txtINITIALSHOT_TextChanged(object sender, EventArgs e)
        {
            txtTOALSHOT.Value = CModule.ToInt32(txtINITIALSHOT.Text) + CModule.ToInt32(txtUSESHOT.Text);
        }

        private void BtnProd_Click(object sender, EventArgs e)
        {
            try
            {
                MD0000_BM0010_POP mbp = new MD0000_BM0010_POP(txtMOLDCODE.Text.Trim());
                if (DialogResult.OK == mbp.ShowDialog())
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    listBox2.Items.Clear();

                    string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                    DSGrid1 = helper.FillDataSet("USP_MD0000_UJ_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input));
                    for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                    {
                        listBox2.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMCODE"]) + "-" + CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                    }

                    for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                    {
                        cbo_NPRODITEM.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                    }
                }
            }
            catch
            {
                
            }
        }

        private void txtUSESHOT_TextChanged(object sender, EventArgs e)
        {
            txtTOALSHOT.Value = CModule.ToInt32(txtINITIALSHOT.Text) + CModule.ToInt32(txtUSESHOT.Text);
        }

        private void txtCAVITYSTRING_TextChanged(object sender, EventArgs e)
        {
            txtCAVITYCNT.Text = txtCAVITYSTRING.Text.Length.ToString();
            CheckCavity = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCAVITYSTRING.Text.Length == 16 || txtCAVITYSTRING.Text.Length == 8)
            {
                this.ShowDialog("캐비티 글자 수 기준에 맞습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                CheckCavity = 1;
            }
            else
            {
                this.ShowDialog("캐비티 글자 수 기준에 맞지않습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                CheckCavity = 0;
            }


        }
    }
}
