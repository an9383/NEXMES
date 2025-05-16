#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0030
//   Form Name    : 거래처 마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 거래처 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;

#endregion


namespace WIZ.PopUp
{
    public partial class MM0020_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        string[] argument;

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();

        #endregion

        #region < CONSTRUCTOR >

        public MM0020_POP(string[] param)
        {
            InitializeComponent();

            InitGrid();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [Parameter Show]
                switch (i)
                {
                    case 0:
                        cbo_PLANTCODE_H.Text = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장
                        break;
                    case 1:
                        //품목은 디자인에서 숨김처리 함
                        txt_ITEMCODE_H.Text = argument[1].ToUpper(); //품목코드
                        break;
                    case 2:
                        txt_CUSTCODE_H.Text = argument[2].ToUpper(); //거래처코드
                        break;
                    case 3:
                        txt_ITEMCODE_H.Value = argument[3].ToUpper(); //품목코드
                        //txt_CONTRACTNO_H.Value = argument[1].ToUpper(); //수주번호
                        break;
                    case 4:
                        txt_CUSTCODE_H.Text = argument[4].ToUpper(); //거래처코드
                        break;

                    case 5:
                        txt_PONAME_H.Text = argument[5].ToUpper(); //거래처명
                        break;
                    case 6:
                        //품목은 디자인에서 숨김처리 함
                        txt_ITEMCODE_H.Text = argument[6].ToUpper(); //품목
                        break;
                    case 7:
                        //품목은 디자인에서 숨김처리 함
                        string c = argument[7].ToUpper(); //품명
                        break;
                    case 8:
                        txt_PONAME_H.Text = argument[8].ToUpper() == "" ? "ALL" : argument[8].ToUpper(); //사용여부
                        break;
                }
                #endregion
            }

            Search();
        }
        #endregion

        #region < METHOD AREA >
        private void InitGrid()
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "수주번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PONAME", "수주이름", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",  "거래처명",   false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG",  "완료여부",   false, GridColDataType_emu.VarChar, 90,  100, Infragistics.Win.HAlign.Left,   true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Search()
        {
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sCustType = string.Empty;
            string sCustCode = string.Empty;
            string sUseFlag = string.Empty;
            string sPono = string.Empty;
            string sPoName = string.Empty;
            string sItemCode = string.Empty;
            string sSdate = string.Empty;
            string sEdate = string.Empty;
            sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

            sPono = txt_PONO_H.Text.Trim();
            sPoName = txt_PONAME_H.Text.Trim();
            sItemCode = txt_ITEMCODE_H.Text.Trim();
            sCustCode = txt_CUSTCODE_H.Text.Trim();
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);
            //_DtTemp = _biz.SEL_MM0020(sPlantCode, sContractno, sCustCode, sCustName, sItemCode, sUseFlag);
            _DtTemp = _biz.SEL_MM0020(sPlantCode, sPono, sPoName, sItemCode, sCustCode);
            grid1.DataSource = _DtTemp;
            grid1.DataBind();
        }

        #endregion

        #region < EVENT AREA >
        private void btn_SEARCH_H_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("PONO", typeof(string));
            //TmpDt.Columns.Add("CONTRACTNAME", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["PONO"].Value });

            //this.Hide();

            this.Tag = TmpDt;
            this.Close();
        }

        private void txt_CUSTCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void txt_CUSTNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }


        #endregion
    }
}
