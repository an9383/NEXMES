#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM3000
//   Form Name    : 자주검사실적등록
//   Name Space   : WIZ.QM
//   Created Date : 2017-06-15
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.QM
{
    public partial class QM3000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        private string sPlant = string.Empty;
        private int OK = 0;
        private int NG = 0;
        private int TOTAL = 0;
        string sResult = "";

        private string sPort_COM6 = string.Empty;


        Image img;

        //Serial Port 통신 변수
        private SerialPort[] sPort;
        private SerialPort sCurrentPort;
        string sRev_Data = string.Empty;

        //delegate
        delegate void SetValueCallback(string Value);
        delegate void SetPerpormClick();
        #endregion

        #region < CONSTRUCTOR >
        public QM3000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM3000_Load(object sender, EventArgs e)
        {
            GridInitialize();
            ComPortOpen();

            #region < COMBOBOX >

            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;

            //SPEC구분(상한관리,하한관리,양쪽관리)
            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //측정구분(값, OK/NG)
            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //IP주소 가져오기
            lblIPAddress.Text = Client_IP;
            #endregion

            #region < POP-UP >

            //품목
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "", "" });

            #endregion
        }

        #region < GRID >

        private void GridInitialize()
        {
            try
            {
                //GRID1-  품목별 측정항목
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRCODE", "측정항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRNAME", "측정항목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "측정구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRVALUE", "측정값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRRESULT", "측정결과", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 245, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.DefaultRowHeight = 50;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        #endregion

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            lblNotice.Text = "";

            //조회 필수조건 확인
            if (Convert.ToString(cboPlantCode_H.Value) == string.Empty)
            {
                lblNotice.Text = Common.getLangText("사업장을 선택해주세요", "MSG");
                return;
            }

            if (Convert.ToString(txtItemCode_H.Value) == string.Empty)
            {
                lblNotice.Text = Common.getLangText("품목을 선택해주세요", "MSG");
                return;
            }


            OK = 0;
            NG = 0;
            TOTAL = 0;
            sResult = "";

            DBHelper helper = new DBHelper(false);
            _GridUtil.Grid_Clear(grid1);

            try
            {
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sItemCode = Convert.ToString(this.txtItemCode_H.Value);

                base.DoInquire();


                //품목별 측정항목 조회
                rtnDtTemp = helper.FillTable("USP_QM3000_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    TOTAL = rtnDtTemp.Rows.Count;
                    lblTotal.Text = Common.getLangText("전체", "TEXT") + " : " + TOTAL + Common.getLangText("건", "TEXT");
                    lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                    if (picView.Image != null)
                    {
                        picView.Image.Dispose();
                        picView.Image = null;
                    }

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();


                        grid1.Rows[0].Activated = true;
                        grid1_ClickCell(this.grid1, new ClickCellEventArgs(this.grid1.Rows[0].Cells[0]));
                    }
                    else
                    {
                        lblNotice.Text = Common.getLangText("조회할 데이터가 없습니다.", "MSG");
                    }

                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }

        #endregion

        #region < EVANT AREA >

        #region < GRID ClickCell EVENT >
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sMesrCode = Convert.ToString(this.grid1.ActiveRow.Cells["MESRCODE"].Value);

            byte[] bImage = GetImage(sPlantCode, sItemCode, sMesrCode);

            if (bImage != null)
            {
                MemoryStream MS = new MemoryStream(bImage);
                img = new Bitmap(MS);
                picView.Image = img;
            }
            else
            {
                picView.Image = null;
            }


            //측정구분에 따른 버튼 컨트롤 입력제한
            if (Convert.ToString(grid1.ActiveRow.Cells["VALUETYPE"].Value) == "V")
            {
                btnOK.Visible = false;
                btnNG.Visible = false;

                btn1.Visible = true;
                btn2.Visible = true;
                btn3.Visible = true;
                btn4.Visible = true;
                btn5.Visible = true;
                btn6.Visible = true;
                btn7.Visible = true;
                btn8.Visible = true;
                btn9.Visible = true;
                btn0.Visible = true;
                btnSpace.Visible = true;
                btnCom.Visible = true;
                btnBack.Visible = true;
                btnDelete.Visible = true;
                btnInsert.Visible = true;


            }

            else if (Convert.ToString(grid1.ActiveRow.Cells["VALUETYPE"].Value) == "J")
            {
                btnNG.Visible = true;
                btnOK.Visible = true;

                btn1.Visible = false;
                btn2.Visible = false;
                btn3.Visible = false;
                btn4.Visible = false;
                btn5.Visible = false;
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn0.Visible = false;
                btnSpace.Visible = false;
                btnCom.Visible = false;
                btnBack.Visible = false;
                btnDelete.Visible = false;
                btnInsert.Visible = false;
            }
        }
        #endregion

        #region < 측정값 및 OK/NG 버튼 Click EVENT >
        private void btn1_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) + "0";
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            string sValue = grid1.ActiveRow.Cells["MESRVALUE"].Value.ToString();

            if (sValue.Length == 0)
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "-";
            }
            else if (sValue == "-")
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = sValue.Replace("-", "");
            }
            else
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "-" + sValue;
            }
        }

        private void btnCom_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            string sValue = grid1.ActiveRow.Cells["MESRVALUE"].Value.ToString();
            string[] sValueList = sValue.ToString().Split('.');
            if (sValue.ToString().Length == 0)
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "0.";
            }
            else if (sValue.ToString().Substring(0, 1) == "-")
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "-0.";
            }
            else if (Convert.ToDouble(sValue) == 0 && sValue.ToString().Substring(0, 1) != "-")
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "0.";
            }
            else if (sValue.ToString().Length > 1 && sValue.ToString().Substring(1, 1) == ".") return;
            else if (sValueList.Length > 1) return;
            else grid1.ActiveRow.Cells["MESRVALUE"].Value = sValue.ToString() + ".";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "OK")
            {
                OK = OK - 1;
                lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
            }
            else if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "NG")
            {
                NG = NG - 1;
                lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");

                lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
            }

            grid1.ActiveRow.Cells["MESRVALUE"].Value = null;
            grid1.ActiveRow.Cells["MESRRESULT"].Value = null;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count < 1)
            {
                return;
            }

            string sValue = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value);

            if (Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value).Length == 0)
            {
                return;
            }
            else
            {
                grid1.ActiveRow.Cells["MESRVALUE"].Value = sValue.Substring(0, sValue.Length - 1);
                sValue = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value);

                if (sValue.Length == 0)
                {
                    grid1.ActiveRow.Cells["MESRVALUE"].Value = null;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            lblNotice.Text = "";

            if (grid1.Rows.Count < 1 || Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value) == "")
            {
                lblNotice.Text = Common.getLangText("측정값이 입력되지 않았습니다.", "MSG");
                return;
            }

            //숫자인지 체크
            string sMesrValue = Convert.ToString(grid1.ActiveRow.Cells["MESRVALUE"].Value);
            double Num;
            bool isNum = double.TryParse(sMesrValue, out Num);

            if (isNum == false)
            {
                lblNotice.Text = Common.getLangText("입력된 값이 숫자가 아닙니다", "MSG");
                return;
            }

            //VALUETYPE이 값일 경우 OK/NG를 기준값과 상한/하한을 기준으로 판단해야함(SPECTYPE을 통해 양측/상한/하한 판단)
            if (Convert.ToString(grid1.ActiveRow.Cells["VALUETYPE"].Value) == "V")
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["SPECTYPE"].Value) == "U")
                {
                    if (Convert.ToDouble(grid1.ActiveRow.Cells["MESRVALUE"].Value) < Convert.ToDouble(grid1.ActiveRow.Cells["SPECUSL"].Value))
                    {
                        sResult = "OK";
                    }
                    else
                    {
                        sResult = "NG";
                    }
                }

                if (Convert.ToString(grid1.ActiveRow.Cells["SPECTYPE"].Value) == "L")
                {
                    if (Convert.ToDouble(grid1.ActiveRow.Cells["MESRVALUE"].Value) > Convert.ToDouble(grid1.ActiveRow.Cells["SPECLSL"].Value))
                    {
                        sResult = "OK";
                    }
                    else
                    {
                        sResult = "NG";
                    }
                }

                if (Convert.ToString(grid1.ActiveRow.Cells["SPECTYPE"].Value) == "B")
                {
                    if (Convert.ToDouble(grid1.ActiveRow.Cells["MESRVALUE"].Value) > Convert.ToDouble(grid1.ActiveRow.Cells["SPECLSL"].Value) &&
                        Convert.ToDouble(grid1.ActiveRow.Cells["MESRVALUE"].Value) < Convert.ToDouble(grid1.ActiveRow.Cells["SPECUSL"].Value))
                    {
                        sResult = "OK";
                    }
                    else
                    {
                        sResult = "NG";
                    }
                }
            }
            else
            {
                grid1.ActiveRow.Cells["SPECNOL"].Value = "0";
                grid1.ActiveRow.Cells["SPECUSL"].Value = "0";
                grid1.ActiveRow.Cells["SPECLSL"].Value = "0";
                grid1.ActiveRow.Cells["MESRVALUE"].Value = "0";
            }


            if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "")
            {
                if (sResult == "OK")
                {
                    OK = OK + 1;
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");
                }
                else
                {
                    NG = NG + 1;
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");
                }

                lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
            }
            else
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "OK" && sResult == "NG")
                {
                    OK = OK - 1;
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                    NG = NG + 1;
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");
                }
                else if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "NG" && sResult == "OK")
                {
                    OK = OK + 1;
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                    NG = NG - 1;
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");
                }
                else
                {

                }
            }

            grid1.ActiveRow.Cells["MESRRESULT"].Value = sResult;

            if (grid1.ActiveRow.Index < grid1.Rows.Count - 1)
            {
                grid1.Rows[grid1.ActiveRow.Index + 1].Activated = true;
                grid1_ClickCell(this.grid1, new ClickCellEventArgs(this.grid1.Rows[grid1.ActiveRow.Index].Cells[0]));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblNotice.Text = "";

            if (grid1.Rows.Count < 1)
            {
                return;
            }

            if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "")
            {
                OK = OK + 1;
                lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
            }
            else
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "NG")
                {
                    OK = OK + 1;
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                    NG = NG - 1;
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");
                }
            }


            grid1.ActiveRow.Cells["MESRRESULT"].Value = "OK";

            if (grid1.ActiveRow.Index < grid1.Rows.Count - 1)
            {
                grid1.Rows[grid1.ActiveRow.Index + 1].Activated = true;
                grid1_ClickCell(this.grid1, new ClickCellEventArgs(this.grid1.Rows[grid1.ActiveRow.Index].Cells[0]));
            }
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            lblNotice.Text = "";

            if (grid1.Rows.Count < 1)
            {
                return;
            }

            if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "")
            {
                NG = NG + 1;
                lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");

                lblPre.Text = Common.getLangText("검사전", "TEXT") + " : " + (TOTAL - (OK + NG)) + Common.getLangText("건", "TEXT");
            }
            else
            {
                if (Convert.ToString(grid1.ActiveRow.Cells["MESRRESULT"].Value) == "OK")
                {
                    OK = OK - 1;
                    lblOK.Text = Common.getLangText("OK", "TEXT") + " : " + OK + Common.getLangText("건", "TEXT");

                    NG = NG + 1;
                    lblNG.Text = Common.getLangText("NG", "TEXT") + " : " + NG + Common.getLangText("건", "TEXT");
                }
            }

            grid1.ActiveRow.Cells["MESRRESULT"].Value = "NG";

            if (grid1.ActiveRow.Index < grid1.Rows.Count - 1)
            {
                grid1.Rows[grid1.ActiveRow.Index + 1].Activated = true;
                grid1_ClickCell(this.grid1, new ClickCellEventArgs(this.grid1.Rows[grid1.ActiveRow.Index].Cells[0]));
            }
        }

        private void btnReflect_Click(object sender, EventArgs e)
        {
            //측정값 입력
            ValueInsert();
        }

        #endregion

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                sCurrentPort = ((SerialPort)(sender));
                string sData = string.Empty;
                string sPortName = string.Empty;

                sData = sCurrentPort.ReadExisting();
                sPortName = sCurrentPort.PortName;

                Thread.Sleep(300);

                switch (sCurrentPort.PortName)
                {
                    case "COM6":
                        if (sData.IndexOf("M\r") > 0)
                        {
                            sPort_COM6 = sPort_COM6 + sData;

                            if (grid1.ActiveRow != null)
                            {
                                SetValue(sPort_COM6.Substring(7, 12));
                            }

                            sPort_COM6 = string.Empty;
                        }
                        else
                        {
                            sPort_COM6 = sPort_COM6 + sData;
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    sCurrentPort.DiscardOutBuffer();
                    sCurrentPort.DiscardInBuffer();

                    this.ClosePrgFormNew();
                }));


            }
        }

        private void QM3000_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < sPort.Length; i++)
            {
                sPort[i].Close();
            }
        }

        #endregion

        #region < METHOD >

        private byte[] GetImage(string sPlantCode, string sItemCode, string sMesrCode)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM9600_GETIMAGE", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MESRCODE", sMesrCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {

                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();

            }

            if (rtnDtTemp.Rows.Count > 0 && rtnDtTemp.Rows[0]["IMG"] != DBNull.Value)
            {
                bImage = (byte[])rtnDtTemp.Rows[0]["IMG"];
            }

            return bImage;
        }

        private void ValueInsert()
        {
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.Rows[i].Cells["MESRRESULT"].Value) == "")
                {
                    lblNotice.Text = Common.getLangText("모든 측정항목의 값이 입력되지 않았습니다.", "MSG");
                    return;
                }
            }



            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                string sSpecNol = grid1.Rows[i].Cells["SPECNOL"].Value.ToString() == "" ? "0" : grid1.Rows[i].Cells["SPECNOL"].Value.ToString();
                string sSpecUsl = grid1.Rows[i].Cells["SPECUSL"].Value.ToString() == "" ? "0" : grid1.Rows[i].Cells["SPECUSL"].Value.ToString();
                string sSpecLsl = grid1.Rows[i].Cells["SPECLSL"].Value.ToString() == "" ? "0" : grid1.Rows[i].Cells["SPECLSL"].Value.ToString();
                string sMesrValue = grid1.Rows[i].Cells["MESRVALUE"].Value.ToString() == "" ? "0" : grid1.Rows[i].Cells["MESRVALUE"].Value.ToString();

                DBHelper helper2 = new DBHelper("", true);

                try
                {
                    helper2.ExecuteNoneQuery("USP_QM3000_I1", CommandType.StoredProcedure
                     , helper2.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_MESRCODE", DBHelper.nvlString(grid1.Rows[i].Cells["MESRCODE"].Value), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AD_SPECNOL", Convert.ToDouble(sSpecNol), DbType.Double, ParameterDirection.Input)
                     , helper2.CreateParameter("AD_SPECUSL", Convert.ToDouble(sSpecUsl), DbType.Double, ParameterDirection.Input)
                     , helper2.CreateParameter("AD_SPECLSL", Convert.ToDouble(sSpecLsl), DbType.Double, ParameterDirection.Input)
                     , helper2.CreateParameter("AD_MESRVALUE", Convert.ToDouble(sMesrValue), DbType.Double, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_MESRRESULT", Convert.ToString(grid1.Rows[i].Cells["MESRRESULT"].Value), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_IP", Convert.ToString(lblIPAddress.Text), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_REMARK", DBHelper.nvlString(grid1.ActiveRow.Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                     , helper2.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                    if (helper2.RSCODE == "S")
                    {
                        helper2.Commit();
                        this.ClosePrgFormNew();
                    }
                    else
                    {
                        helper2.Rollback();
                        this.ClosePrgFormNew();
                        this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                    helper2.Rollback();
                }
                finally
                {
                    helper2.Close();
                }
            }

            DoInquire();

            lblNotice.Text = Common.getLangText("측정실적이 등록되었습니다.", "MSG");
        }

        public static string Client_IP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = host.AddressList[i].ToString();
                    }
                }
                return ClientIP;
            }
        }

        private void ComPortOpen()
        {
            DataTable dtSPort = new DataTable();

            DBHelper helper = new DBHelper(false);

            try
            {
                dtSPort = _Common.GET_BM0000_CODE("SERIALPORT");

                if (dtSPort.Rows.Count > 0)
                {
                    sPort = new SerialPort[dtSPort.Rows.Count];

                    for (int i = 0; i < dtSPort.Rows.Count; i++)
                    {
                        sPort[i] = new SerialPort();

                        sPort[i].PortName = Convert.ToString(dtSPort.Rows[i]["RELCODE1"]);
                        sPort[i].BaudRate = int.Parse(dtSPort.Rows[i]["RELCODE2"].ToString());
                        sPort[i].DataBits = int.Parse(dtSPort.Rows[i]["RELCODE3"].ToString());

                        switch (Convert.ToString(dtSPort.Rows[i]["RELCODE4"]))
                        {
                            case "Parity.None":
                                sPort[i].Parity = Parity.None;
                                break;
                            case "Parity.Odd":
                                sPort[i].Parity = Parity.Odd;
                                break;
                            case "Parity.Even":
                                sPort[i].Parity = Parity.Even;
                                break;
                            default:
                                sPort[i].Parity = Parity.None;
                                break;
                        }

                        switch (Convert.ToString(dtSPort.Rows[i]["RELCODE5"]))
                        {
                            case "StopBits.None":
                                sPort[i].StopBits = StopBits.None;
                                break;
                            case "StopBits.One":
                                sPort[i].StopBits = StopBits.One;
                                break;
                            case "StopBits.Two":
                                sPort[i].StopBits = StopBits.Two;
                                break;
                            default:
                                sPort[i].StopBits = StopBits.One;
                                break;
                        }

                        sPort[i].DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                        sPort[i].RtsEnable = true;
                        sPort[i].DtrEnable = true;

                        sPort[i].Close();
                        sPort[i].Open();
                    }
                }
            }
            catch (Exception ex)
            {
                lblNotice.Text = Common.getLangText("시리얼PORT가 연결되지 않았습니다.", "MSG");
            }
        }

        //계측기 TEXTBOX에 값 뿌려주기
        private void SetValue(string value)
        {
            grid1.ActiveRow.Cells["MESRVALUE"].Value = value;
        }

        //계측기 검사완료 버튼 클릭
        private void SetCilck()
        {
            btnInsert.PerformClick();
        }


        #endregion


    }
}
