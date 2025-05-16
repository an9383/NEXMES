#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0130
//   Form Name    : 단위코드 마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 단위코드 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0130_POP : WIZ.Forms.BasePopupForm
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

        public BM0130_POP(string[] param)
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
                        txt_UNITCODE_H.Text = argument[0].ToUpper(); //단위코드
                        break;

                    case 1:
                        txt_UNITNAME_H.Text = argument[1].ToUpper(); //단위명
                        break;

                    case 2:
                        cbo_USEFLAG_H.Text = argument[2].ToUpper() == "" ? "ALL" : argument[2].ToUpper(); //사용여부
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
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITNAME", "단위명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

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
            string sUnitCode = string.Empty;
            string sUnitName = string.Empty;
            string sUseFlag = string.Empty;

            sUnitName = txt_UNITCODE_H.Text.Trim();
            sUnitCode = txt_UNITNAME_H.Text.Trim();
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);

            _DtTemp = _biz.SEL_BM0130(sUnitCode, sUnitName, sUseFlag);

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
            TmpDt.Columns.Add("UNITCODE", typeof(string));
            TmpDt.Columns.Add("UNITNAME", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["UNITCODE"].Value, e.Row.Cells["UNITNAME"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txt_UNITCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        #endregion


    }
}
