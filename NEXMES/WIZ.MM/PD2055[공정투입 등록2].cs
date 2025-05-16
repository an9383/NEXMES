#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD2055
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
    public partial class PD2055 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        private string gBarCode = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public PD2055()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void PD2055_Load(object sender, EventArgs e)
        {
            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";

            txtInputBarCode.Select();

            GridInit();
            //GetWhCode();
        }

        private void GridInit()
        {
            //지시번호 클릭 시 출력
            grid3.View = View.Details;
            grid3.Columns.Clear();
            grid3.Columns.Add(new Grid.ColHeader("PLANTCODE", 0, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("품목", 60, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("LOTNO", 120, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("수량", 50, HorizontalAlignment.Right, true));
            grid3.Columns.Add(new Grid.ColHeader("품명", 0, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("창고코드", 0, HorizontalAlignment.Center, true));
            grid3.Columns.Add(new Grid.ColHeader("창고이름", 0, HorizontalAlignment.Right, true));
            grid3.Columns.Add(new Grid.ColHeader("저장코드", 0, HorizontalAlignment.Center, true));
            grid3.Columns.Add(new Grid.ColHeader("저장이름", 0, HorizontalAlignment.Right, true));
            grid3.Columns.Add(new Grid.ColHeader("단위", 0, HorizontalAlignment.Left, true));
            grid3.Columns.Add(new Grid.ColHeader("날짜", 0, HorizontalAlignment.Left, true));

        }

        #endregion

        #region < USER METHOD AREA >
        private void ControlClear()
        {
            txtInputBarCode.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            //txtWhCode.Text         = string.Empty;
            txtWhName.Text = string.Empty;
            txtStorageLocName.Text = string.Empty;
            //txtStorageLocCode.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUnitCode.Text = string.Empty;
            txtInDate.Text = string.Empty;
            txtDivQty.Text = string.Empty;
            txtLocName.Text = string.Empty;
            //cboToWhCode.SelectedIndex = 0;
            //cboToStorageLocCode.SelectedIndex = 0;

            txtInputBarCode.Select();

            gBarCode = string.Empty;
        }

        private void ScanLogic()
        {
            try
            {
                gBarCode = txtInputBarCode.Text;

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
                if (txtItemCode.Text.Trim() == "")
                {
                    DataRow dr = LOC_LotList(gBarCode, "C");

                    if (RS_CODE == "S")
                    {
                        SetLotData(dr);
                    }
                }
                else
                {
                    // 선택된 품목이 있는 경우
                    DataRow dr = LOC_LotList(gBarCode, "");

                    if (RS_CODE == "S")
                    {
                        SetLotData(dr);
                    }
                    else if (RS_CODE == "L")
                    {
                        txtLocName.Tag = gBarCode;
                        txtLocName.Text = RS_MSG;
                    }
                    else if (RS_CODE == "E")
                    {
                        ControlClear();
                        this.ShowDialog(Common.getLangText("[현장출고 등록] ", "MSG") + RS_MSG, DialogForm.DialogType.OK);
                    }
                }

                btnBarCode.PerformClick();

                SetCheck();
            }
            catch (Exception ex)
            {
                ControlClear();
                this.ShowDialog(Common.getLangText("[바코드 스캔] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
            finally
            {
                txtInputBarCode.Text = string.Empty;
            }
        }

        private void SetLotData(DataRow dr)
        {
            if (dr != null)
            {
                txtBarCode.Text = Convert.ToString(dr["LOTNO"]);
                txtItemCode.Text = Convert.ToString(dr["ITEMCODE"]);
                txtItemName.Text = Convert.ToString(dr["ITEMNAME"]);
                txtQty.Text = Convert.ToString(dr["QTY"]);
                txtDivQty.Text = Convert.ToString(dr["QTY"]);
                txtUnitCode.Text = Convert.ToString(dr["UNITCODE"]);
                //txtWhCode.Text         Convert.ToString(dr["STORAGELOCCODE"]);
                txtWhName.Text = Convert.ToString(dr["WHNAME"]);
                //txtStorageLocCode.Text Convert.ToString(dr["INDATE"]);
                txtStorageLocName.Text = Convert.ToString(dr["STORAGELOCNAME"]);
                txtInDate.Text = Convert.ToString(dr["INDATE"]);
            }
            else
            {
                this.ShowDialog(Common.getLangText("현장출고 등록 ", "MSG") + "조회 결과가 없습니다.", DialogForm.DialogType.OK);
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

        private DataTable USP_PD2055_S1(string sBarCode, string sPcCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PD2050_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("PC_CODE", sPcCode, DbType.String, ParameterDirection.Input));

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

        private void USP_PD2055_I1(string sBarCode, string sItemCode, string sStorageLocCode, string sQty, string sDviQty, ref string RS_CODE, ref string RS_MSG)
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


                sBarCode = DBHelper.nvlString(txtBarCode.Text);

                if (sBarCode == "")
                {
                    return;
                }

                helper.ExecuteNoneQuery("USP_PD2055_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AF_DVIQTY", iDviqty, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_REMPRINT", chkRem.Checked ? "Y" : "N", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_OUTPRINT", chkOut.Checked ? "Y" : "N", DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input)
                                       );

                //     , helper.CreateParameter("AS_QTY",            iQty,                DbType.String, ParameterDirection.Input)

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                if (RS_CODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    throw new Exception(helper.RSMSG);
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
            txtInputBarCode.Text = string.Empty;
            txtInputBarCode.Focus();
        }

        private DataRow LOC_LotList(string sLOC, string sPCCODE)
        {
            DataTable dt2 = new DataTable();
            dt2 = USP_PD2055_S1(sLOC, sPCCODE, ref RS_CODE, ref RS_MSG);

            string sItemCode = string.Empty;
            string sItemName = string.Empty;
            string sQty = string.Empty;
            string sUnitCode = string.Empty;
            string sInDate = string.Empty;
            string sWhCode = string.Empty;
            string sWhName = string.Empty;
            string sStorageLocCode = string.Empty;
            string sstorageLocName = string.Empty;

            grid3.Location = new Point(37, 75);
            grid3.Size = new Size(255, 303);

            if (RS_CODE == "S")
            {
                if (dt2.Rows.Count == 1)
                {
                    grid3.Visible = false;

                    return dt2.Rows[0];
                }
                else if (dt2.Rows.Count > 1)
                {
                    grid3.Visible = true;
                    grid3.Items.Clear();
                    grid3.BringToFront();

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        ListViewItem lvl3 = new ListViewItem();
                        //string a = dt2.Rows[i]["QTY"].ToString();
                        lvl3.SubItems.Add(dt2.Rows[i]["ITEMCODE"].ToString());
                        lvl3.SubItems.Add(dt2.Rows[i]["LOTNO"].ToString());
                        lvl3.SubItems.Add(dt2.Rows[i]["QTY"].ToString());
                        grid3.Items.Add(lvl3);
                        grid3.EndUpdate();
                    }

                    RS_CODE = "C";
                }
                else
                {
                    grid3.Visible = false;
                }
            }

            return null;
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

            DialogResult result = MessageBox.Show("[" + gBarCode + "]" + Common.getLangText("현장출고 처리 하시겠습니까?", "MSG"), "현장출고", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result.ToString().ToUpper() != "YES")
                return;


            try
            {
                string sItemCode = txtItemCode.Text.Trim();
                string sWhCode = "";
                string sStorageLocCode = DBHelper.nvlString(txtLocName.Tag);
                string sQty = txtQty.Text;
                string sDviQty = txtDivQty.Text;



                USP_PD2055_I1(gBarCode
                            , sItemCode
                            , sStorageLocCode
                            , sQty
                            , sDviQty
                            , ref RS_CODE
                            , ref RS_MSG);

                if (RS_CODE == "S")
                {
                    this.ShowDialog(Common.getLangText("[ " + RS_MSG + " ] 현장출고 완료", "MSG"), DialogForm.DialogType.OK); //[현장출고 등록] 현장출고 완료
                    ControlClear();
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[현장출고 등록] ", "MSG") + ex.Message, DialogForm.DialogType.OK);
            }
        }


        #endregion

        private void grid3_ItemActivate(object sender, EventArgs e)
        {
            txtItemCode.Text = grid3.FocusedItem.SubItems[1].Text;
            txtInputBarCode.Text = grid3.FocusedItem.SubItems[2].Text;

            grid3.Visible = false;
            if (txtInputBarCode.Text != "")
            {
                ScanLogic();
            }
        }

        private void SetCheck()
        {
            double sQty = DBHelper.nvlDouble(txtQty.Text);
            double sDviQty = DBHelper.nvlDouble(txtDivQty.Text);

            bool bDefault = false;

            int iRowCount = subData.GetRowCount();

            for (int i = 0; i < iRowCount; i++)
            {
                if (subData[i, "METHOD_TYPE"] == "CHECK")
                {
                    bDefault = subData[i, "RELCODE1"] == "Y";
                }
            }

            chkRem.Checked = bDefault;

            if (sQty > sDviQty)
            {
                chkRem.Checked = bDefault;

                if (txtLocName.Text.Trim() != "")
                {
                    chkOut.Checked = false;
                }
                else
                {
                    chkOut.Checked = true;
                }
            }
        }

        private void txtDivQty_Leave(object sender, EventArgs e)
        {
            SetCheck();
        }
    }
}
