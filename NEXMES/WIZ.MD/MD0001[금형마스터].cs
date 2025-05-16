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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0001 : WIZ.Forms.BaseMDIChildForm
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

        #endregion

        #region < CONSTRUCTOR >
        public MD0001()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0001_Load(object sender, EventArgs e)
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

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형번호", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DEGREE", "차수", true, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CODENAME", "상태", true, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Center, true, false);

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

                #endregion
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
                _GridUtil.Grid_Clear(grid1);

                DSGrid1 = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
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

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToString(txtMOLDTYPE1.Value) == "MT14" || Convert.ToString(txtMOLDTYPE1.Value) == "MT15" || Convert.ToString(txtMOLDTYPE1.Value) == "MT16")
                {
                    this.ShowDialog("금형 (폐기, 불용, 반납) 상태 변경은 금형이관폐기에서 가능합니다.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    //저장, 수정
                    helper.ExecuteNoneQuery("USP_MD0001_SAVE", CommandType.StoredProcedure

                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_MOLDCODE", txtMOLDCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDNAME", txtMOLDNAME.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_DEGREE", txtDEGREE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDMNO", txtMOLDMNO.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDPROD", txtNPRODCODE.Text, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_QRCODE", txtQRCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE1", txtMOLDTYPE1.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE2", txtMOLDTYPE2.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE3", txtMOLDTYPE3.Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_MOLDTYPE4", txtMOLDTYPE4.Value, DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_NOWSHOT", txtNOWSHOT.Text, DbType.Int16, ParameterDirection.Input)
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

                        //, helper.CreateParameter("AS_IMAGE1",  "", DbType.Binary, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_IMAGE2",  "", DbType.Binary, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_IMAGE3",  "", DbType.Binary, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_PIMAGE1", "", DbType.Binary, ParameterDirection.Input)
                        //, helper.CreateParameter("AS_PIMAGE2", "", DbType.Binary, ParameterDirection.Input)
                        );


                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    helper.Commit();
                    this.ShowDialog("금형등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                    ModeStatus = "S";
                    DoInquire();
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
                        DSGrid1 = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input));

                        listBox1.Items.Clear();
                        listBox2.Items.Clear();

                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                        {
                            listBox2.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMCODE"]) + " - " + CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                        }
                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[2].Rows.Count; grid1rowNUM++)
                        {
                            listBox1.Items.Add(CModule.ToString(DSGrid1.Tables[2].Rows[grid1rowNUM]["CORE_CoreName"]));
                        }

                        SetMoldInfo(DSGrid1.Tables[1]);

                        #region LOAD IMAGE

                        byte[] bImage1 = GetImage(sPlantCode, sMoldCode, "IMAGE1");

                        if (bImage1 != null)
                        {
                            MemoryStream MS = new MemoryStream(bImage1);
                            IMAGE1.Image = new Bitmap(MS);

                            bImage1 = null;
                            MS.Close();
                            MS.Dispose();

                            //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
                        }
                        else
                        {
                            IMAGE1.Image = null;
                        }

                        byte[] bImage2 = GetImage(sPlantCode, sMoldCode, "IMAGE2");

                        if (bImage2 != null)
                        {
                            MemoryStream MS = new MemoryStream(bImage2);
                            IMAGE2.Image = new Bitmap(MS);

                            bImage2 = null;
                            MS.Close();
                            MS.Dispose();

                            //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
                        }
                        else
                        {
                            IMAGE2.Image = null;
                        }

                        byte[] bImage3 = GetImage(sPlantCode, sMoldCode, "IMAGE3");

                        if (bImage3 != null)
                        {
                            MemoryStream MS = new MemoryStream(bImage3);
                            IMAGE3.Image = new Bitmap(MS);

                            bImage3 = null;
                            MS.Close();
                            MS.Dispose();

                            //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
                        }
                        else
                        {
                            IMAGE3.Image = null;
                        }

                        byte[] bImage4 = GetImage(sPlantCode, sMoldCode, "PIMAGE1");

                        if (bImage4 != null)
                        {
                            MemoryStream MS = new MemoryStream(bImage4);
                            PIMAGE1.Image = new Bitmap(MS);

                            bImage4 = null;
                            MS.Close();
                            MS.Dispose();

                            //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
                        }
                        else
                        {
                            PIMAGE1.Image = null;
                        }

                        byte[] bImage5 = GetImage(sPlantCode, sMoldCode, "PIMAGE2");

                        if (bImage5 != null)
                        {
                            MemoryStream MS = new MemoryStream(bImage5);
                            PIMAGE2.Image = new Bitmap(MS);

                            bImage5 = null;
                            MS.Close();
                            MS.Dispose();

                            //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
                        }
                        else
                        {
                            PIMAGE2.Image = null;
                        }

                        #endregion
                    }
                }
                catch (Exception ex)
                {

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
                txtMOLDSTATE.Text = CModule.ToString(DTinfo.Rows[0]["CODENAME"]);
                txtQRCODE.Text = CModule.ToString(DTinfo.Rows[0]["QRCODE"]);

                txtMOLDTYPE1.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE1"]);
                txtMOLDTYPE2.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE2"]);
                txtMOLDTYPE3.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE3"]);
                txtMOLDTYPE4.Text = CModule.ToString(DTinfo.Rows[0]["MOLDTYPE4"]);

                txtNPRODCODE.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtNPRODNAME.Text = CModule.ToString(DTinfo.Rows[0]["ITEMNAME"]);

                txtINITIALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["INITIALSHOT"]);
                txtUSESHOT.Text = CModule.ToString(DTinfo.Rows[0]["USESHOT"]);
                txtTOALSHOT.Text = CModule.ToString(DTinfo.Rows[0]["TOALSHOT"]);
                txtNOWSHOT.Text = CModule.ToString(DTinfo.Rows[0]["NOWSHOT"]);
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
                txtUCNAME.Text = CModule.ToString(DTinfo.Rows[0]["UCNAME"]);

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

            txtNPRODCODE.Text = "";
            txtNPRODNAME.Text = "";

            txtMOLDTYPE1.Text = "";
            txtMOLDTYPE2.Text = "";
            txtMOLDTYPE3.Text = "";
            txtMOLDTYPE4.Text = "";
            txtINITIALSHOT.Text = "";

            txtUSESHOT.Text = "";
            txtTOALSHOT.Text = "";
            txtNOWSHOT.Text = "";
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

        private void NullSetting()
        {
            if (txtMOLDNAME.Text == "")
                txtMOLDNAME.Text = " ";

            if (txtDEGREE.Text == "")
                txtDEGREE.Text = " ";

            if (txtMOLDMNO.Text == "")
                txtMOLDMNO.Text = " ";

            if (txtNPRODCODE.Text == "")
                txtNPRODCODE.Text = " ";

            if (txtNPRODNAME.Text == "")
                txtNPRODNAME.Text = " ";

            if (txtQRCODE.Text == "")
                txtQRCODE.Text = " ";

            if (Convert.ToString(txtMOLDTYPE1.Value) == "")
                txtMOLDTYPE1.Value = " ";

            if (Convert.ToString(txtMOLDTYPE2.Value) == "")
                txtMOLDTYPE2.Value = " ";

            if (Convert.ToString(txtMOLDTYPE3.Value) == "")
                txtMOLDTYPE3.Value = " ";

            if (Convert.ToString(txtMOLDTYPE4.Value) == "")
                txtMOLDTYPE4.Value = " ";

            if (txtNOWSHOT.Text == "")
                txtNOWSHOT.Text = " ";

            if (txtINITIALSHOT.Text == "")
                txtINITIALSHOT.Text = " ";

            if (txtUSESHOT.Text == "")
                txtUSESHOT.Text = " ";

            if (txtTOALSHOT.Text == "")
                txtTOALSHOT.Text = " ";

            if (txtMOLDMAKECOMPANY.Text == "")
                txtMOLDMAKECOMPANY.Text = " ";

            if (txtMOLDMAKEDATE.Text == "")
                txtMOLDMAKEDATE.Text = " ";

            if (txtCAVITYNUM.Text == "")
                txtCAVITYNUM.Text = " ";

            if (txtCAVITYSTRING.Text == "")
                txtCAVITYSTRING.Text = " ";

            if (txtWIDTH.Text == "")
                txtWIDTH.Text = " ";

            if (txtLENGTH.Text == "")
                txtLENGTH.Text = " ";

            if (txtHEIGHT.Text == "")
                txtHEIGHT.Text = " ";

            if (txtWEIGHT.Text == "")
                txtWEIGHT.Text = " ";

            if (txtLENGTH.Text == "")
                txtLENGTH.Text = " ";

            if (txtHEIGHT.Text == "")
                txtHEIGHT.Text = " ";

            if (txtMOLDUSECOMPANY.Text == "")
                txtMOLDUSECOMPANY.Text = " ";

            if (txtTRANSFERDATE.Text == "")
                txtTRANSFERDATE.Text = " ";

            if (txtUSECAVITY.Text == "")
                txtUSECAVITY.Text = " ";

            if (txtGRADE.Text == "")
                txtGRADE.Text = " ";

            if (txtCYCLETIME.Text == "")
                txtCYCLETIME.Text = " ";

            if (txtCAPADATE.Text == "")
                txtCAPADATE.Text = " ";

            if (txtCAPAMONTH.Text == "")
                txtCAPAMONTH.Text = " ";

            if (txtUSECYCLETIME.Text == "")
                txtUSECYCLETIME.Text = " ";

            if (txtUSECAPADATE.Text == "")
                txtUSECAPADATE.Text = " ";

            if (txtUSECAPAMONTH.Text == "")
                txtUSECAPAMONTH.Text = " ";

            if (txtINSPCYCLE.Text == "")
                txtINSPCYCLE.Text = " ";

            if (txtMAKECOST.Text == "")
                txtMAKECOST.Text = " ";

            if (txtDELDATE.Text == "")
                txtDELDATE.Text = " ";

            if (txtRETURNDATE.Text == "")
                txtRETURNDATE.Text = " ";
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
            try
            {
                txtTOALSHOT.Text = Convert.ToString(Convert.ToInt32(txtINITIALSHOT.Text) + Convert.ToInt32(txtUSESHOT.Text));
            }
            catch
            {

            }
        }

        private void txtNOWSHOT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUSESHOT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTOALSHOT.Text = Convert.ToString(Convert.ToInt32(txtINITIALSHOT.Text) + Convert.ToInt32(txtUSESHOT.Text));
            }
            catch
            {

            }
        }

        private void BtnProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMOLDCODE.Text == "")
                {
                    this.ShowDialog("금형을 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (txtMOLDCODE.Text == "[ NEW MOLDCODE ]")
                {
                    this.ShowDialog("금형을 등록이후 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    MD0001_POP mbp = new MD0001_POP(txtMOLDCODE.Text.Trim());
                    if (DialogResult.OK == mbp.ShowDialog())
                    {
                        DBHelper helper;
                        helper = new DBHelper(false);

                        listBox2.Items.Clear();
                        string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

                        DSGrid1 = helper.FillDataSet("USP_MD0001_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input));

                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[3].Rows.Count; grid1rowNUM++)
                        {
                            listBox2.Items.Add(CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMCODE"]) + "-" + CModule.ToString(DSGrid1.Tables[3].Rows[grid1rowNUM]["ITEMNAME"]));
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btn_NPROD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMOLDCODE.Text == "")
                {
                    this.ShowDialog("금형을 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (txtMOLDCODE.Text == "[ NEW MOLDCODE ]")
                {
                    this.ShowDialog("금형을 등록이후 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (txtNPRODCODE.Text != "")
                {
                    this.ShowDialog("금형수리의 체인지타입을 통해 변경가능합니다.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    MD0001_POP1 mbp = new MD0001_POP1(txtMOLDCODE.Text.Trim());
                    if (DialogResult.OK == mbp.ShowDialog())
                    {
                        txtNPRODCODE.Text = mbp.sITEMCODE;
                        txtNPRODNAME.Text = mbp.sITEMNAME;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtCAVITYNUM_ValueChanged(object sender, EventArgs e)
        {
            txtUSECAVITY.Text = txtCAVITYNUM.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCAVITYSTRING.TextLength) % Convert.ToInt32(txtCAVITYNUM.Text) == 0)
            {
                this.ShowDialog("캐비티적용이 가능합니다.", Forms.DialogForm.DialogType.OK);
            }
            else
            {
                this.ShowDialog("캐비티적용이 불가능합니다.", Forms.DialogForm.DialogType.OK);
            }
        }

        private void IMAGE1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                IMAGE1.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMOLDCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MD0001_U1", CommandType.StoredProcedure
                            , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_IMG", ConvertImageToByteArray(IMAGE1.Image), DbType.Binary, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_TYPE", "IMAGE1", DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }

        #region ConvertImageToByteArray

        private byte[] GetImage(string sPlantCode, string sMOLDCODE, string sTYPE)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0001_S2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_TYPE", sTYPE, DbType.String, ParameterDirection.Input));

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

            }

            if (rtnDtTemp.Rows.Count > 0 && rtnDtTemp.Rows[0]["IMG"] != DBNull.Value)
            {
                bImage = (byte[])rtnDtTemp.Rows[0]["IMG"];
            }
            else
            {
                // bImage = ConvertImageToByteArray(Properties.Resources.Default_Image);
                bImage = null;
            }

            return bImage;
        }

        public byte[] ConvertImageToByteArray(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pByte;

            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(pByte, 0, (int)ms.Length);
            ms.Close();
            return pByte;
        }

        public Image ConvertByteArrayToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();

            Image theImage = null;

            try
            {
                ms.Position = 0;

                ms.Write(pByte, 0, (int)pByte.Length);

                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return theImage;
        }
        #endregion

        private void IMAGE2_DoubleClick(object sender, EventArgs e)
        {
            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                IMAGE2.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMOLDCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MD0001_U1", CommandType.StoredProcedure
                            , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_IMG", ConvertImageToByteArray(IMAGE2.Image), DbType.Binary, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_TYPE", "IMAGE2", DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void IMAGE3_DoubleClick(object sender, EventArgs e)
        {
            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                IMAGE3.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMOLDCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MD0001_U1", CommandType.StoredProcedure
                            , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_IMG", ConvertImageToByteArray(IMAGE3.Image), DbType.Binary, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_TYPE", "IMAGE3", DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void PIMAGE1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                PIMAGE1.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMOLDCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MD0001_U1", CommandType.StoredProcedure
                            , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_IMG", ConvertImageToByteArray(PIMAGE1.Image), DbType.Binary, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_TYPE", "PIMAGE1", DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void PIMAGE2_DoubleClick(object sender, EventArgs e)
        {
            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                PIMAGE2.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMOLDCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MD0001_U1", CommandType.StoredProcedure
                            , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_MOLDCODE", sMOLDCODE, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_IMG", ConvertImageToByteArray(PIMAGE1.Image), DbType.Binary, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input)
                            , helper2.CreateParameter("AS_TYPE", "PIMAGE2", DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }
    }
}
