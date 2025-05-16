#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2050
//   Form Name    : 현장출고 등록
//   Name Space   : NEXPDA
//   Created Date : 2018-03-30
//   Made By      :
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고상태의 자재를 현장출고 등록 처리.
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MM
{
    public partial class PD2050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;
        private string sStorage = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public PD2050()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void PD2050_Load(object sender, EventArgs e)
        {
            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBARCODE.Select();

            //GetWhCode();

            DoSet(panel1);

            txtInputBARCODE.Focus();
        }

        private void DoSet(System.Windows.Forms.Control con)
        {
            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                switch (c.GetType().Name.ToUpper())
                {
                    case "STEXTBOX":
                        if (c.Name.Contains("BARCODE"))
                        {
                            c.BackColor = Color.FromArgb(75, 92, 118);
                            c.ForeColor = Color.Gold;
                        }
                        break;
                }
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBARCODE.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtWhCode.Text = string.Empty;
            txtWhName.Text = string.Empty;
            txtStorageLocName.Text = string.Empty;
            txtStorageLocCode.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtInDate.Text = string.Empty;
            txtDivQty.Text = string.Empty;

            txtStorageBARCODE.Text = string.Empty;
            txtStorageCode.Text = string.Empty;
            txtStorageName.Text = string.Empty;

            txtInputBARCODE.Select();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBARCODE.Text;

                if (gBarCode == string.Empty) return;

                string sItemCode = string.Empty;             //품번
                string sItemName = string.Empty;             //품명
                string sQty = string.Empty;             //수량
                string sUnitCode = string.Empty;             //단위
                string sInDate = string.Empty;             //수입검사 일자
                string sWhCode = string.Empty;             //창고
                string sWhName = string.Empty;             //창고이름
                string sStorageLocCode = string.Empty;             //위치
                string sStorageLocName = string.Empty;             //위치이름

                DataTable _dt = new DataTable();
                _dt = USP_PD2050_S1(gBarCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sItemCode = Convert.ToString(_dt.Rows[0]["ITEMCODE"]);
                        sItemName = Convert.ToString(_dt.Rows[0]["ITEMNAME"]);
                        sQty = Convert.ToString(_dt.Rows[0]["QTY"]);
                        sUnitCode = Convert.ToString(_dt.Rows[0]["UNITCODE"]);
                        sWhCode = Convert.ToString(_dt.Rows[0]["WHCODE"]);
                        sWhName = Convert.ToString(_dt.Rows[0]["WHNAME"]);
                        sStorageLocCode = Convert.ToString(_dt.Rows[0]["STORAGELOCCODE"]);
                        sStorageLocName = Convert.ToString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sInDate = Convert.ToString(_dt.Rows[0]["INDATE"]);

                        txtBarCode.Text = gBarCode;
                        txtItemCode.Text = sItemCode;
                        txtItemName.Text = sItemName;
                        txtQty.Text = sQty;
                        txtDivQty.Text = sQty;
                        txtUnitCode.Text = sUnitCode;
                        txtWhCode.Text = sWhCode;
                        txtWhName.Text = sWhName;
                        txtStorageLocCode.Text = sStorageLocCode;
                        txtStorageLocName.Text = sStorageLocName;
                        txtInDate.Text = sInDate;
                    }
                    else
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("[바코드 스캔] 바코드 정보를 확인 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    }
                }
                else if (RS_CODE == "E")
                {
                    ControlClear();
                    this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

                btnBarCode.PerformClick();
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        //private void GetWhCode()
        //{
        //    try
        //    {
        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETWHCODE("WH003", ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            if (_dt.Rows.Count > 0)
        //            {
        //                WIZ.Common.FillComboboxMaster(cboToWhCode, _dt, "WHCODE", "WHNAME", "선택하세요", "");
        //            }
        //            else
        //            {
        //                this.ShowDialog(Common.getLangText("[창고 조회] 창고 정보를 확인하세요.", "MSG"), DialogForm.DialogType.OK);
        //            }
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
        //    }
        //}

        //private DataTable USP_PDA_GETWHCODE(string sWhType, ref string RS_CODE, ref string RS_MSG)
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        rtnDtTemp = helper.FillTable("USP_PDA_GETWHCODE"
        //                                    , CommandType.StoredProcedure
        //                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("AS_WHTYPE",    sWhType,             DbType.String, ParameterDirection.Input));

        //        RS_CODE = Convert.ToString(helper.RSCODE);
        //        RS_MSG = Convert.ToString(helper.RSMSG);

        //        return rtnDtTemp;
        //    }
        //    catch (Exception ex)
        //    {
        //        RS_CODE = "E";
        //        RS_MSG = ex.Message.ToString();
        //        return new DataTable();
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        private void GetStorage()
        {
            try
            {
                sStorage = txtStorageBARCODE.Text;

                if (sStorage == string.Empty) return;

                string sStorageName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETSTORAGECODE2(sStorage, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sStorageName = Convert.ToString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sStorage = Convert.ToString(_dt.Rows[0]["STORAGELOCCODE"]);
                        txtStorageName.Text = sStorageName;
                        txtStorageCode.Text = sStorage;
                        txtStorageBARCODE.Text = string.Empty;
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("저장 위치 조회 ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
            }
        }

        private DataTable USP_PDA_GETSTORAGECODE2(string sStorage, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_STORAGELOCCODE2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STORAGELOCCODE", sStorage, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        private DataTable USP_PD2050_S1(string sBarCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2050_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        private void USP_PD2050_I1(string sBarCode, string sItemCode, string sWhCode, string sStorageLocCode, string sQty, string sDviQty, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                double iDviqty;
                double iQty;

                iQty = DBHelper.nvlDouble(sQty);
                iDviqty = DBHelper.nvlDouble(sDviQty);

                if (iDviqty == 0)
                {
                    iDviqty = iQty;
                }

                if (iQty < iDviqty)
                {
                    this.ShowDialog(Common.getLangText("분할 수량이 원래 수량보다 많습니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                helper.ExecuteNoneQuery("USP_PD2050_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AF_DVIQTY", iDviqty, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                //     , helper.CreateParameter("AS_QTY",            iQty,                DbType.String, ParameterDirection.Input)

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                if (RS_CODE == "S")
                {
                    helper.Commit();
                }
                else if (RS_CODE == "E")
                {
                    helper.Rollback();
                }
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

        private DataTable USP_PDA_GETSTORAGECODE(string sWhCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_GETSTORAGECODE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region < EVENT AREA >
        private void btnBarCode_Click(object sender, EventArgs e)
        {
            txtInputBARCODE.Text = string.Empty;
            txtInputBARCODE.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ScanLogic();
            }
        }

        private void txtStorage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetStorage();
            }
        }

        //private void cboWhCode_ValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sWhCode = Convert.ToString(cboToWhCode.Value);

        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETSTORAGECODE(sWhCode, ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            WIZ.Common.FillComboboxMaster(cboToStorageLocCode, _dt, "STORAGELOCCODE", "STORAGELOCNAME", "선택하세요", "");
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
        //    }

        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gBarCode == string.Empty) return;

            DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("공정투입 처리 하시겠습니까?", "MSG"), "현장출고", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;

            //if(Convert.ToString(cboToWhCode.Value) == string.Empty)
            //{
            //    this.ShowDialog(Common.getLangText("출고 창고를 선택해주십시오.", "MSG"), DialogForm.DialogType.OK);
            //    return;
            //}

            //if (Convert.ToString(cboToStorageLocCode.Value) == string.Empty)
            //{
            //    this.ShowDialog(Common.getLangText("출고 위치를 선택해주십시오.", "MSG"), DialogForm.DialogType.OK);
            //    return;
            //}

            try
            {
                string sItemCode = txtItemCode.Text.Trim();
                string sWhCode = "";
                string sStorageLocCode = DBHelper.nvlString(txtStorageCode.Text.Trim());
                string sQty = txtQty.Text;
                string sDviQty = txtDivQty.Text;



                USP_PD2050_I1(gBarCode
                            , sItemCode
                            , sWhCode
                            , sStorageLocCode
                            , sQty
                            , sDviQty
                            , ref RS_CODE
                            , ref RS_MSG);

                if (RS_CODE == "S")
                {
                    this.ShowDialog(Common.getLangText("[ " + RS_MSG + " ] 공정투입 완료", "MSG"), DialogForm.DialogType.OK); //[현장출고 등록] 현장출고 완료
                    ControlClear();
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[현장출고 등록] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[현장출고 등록] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }


        #endregion
    }
}
