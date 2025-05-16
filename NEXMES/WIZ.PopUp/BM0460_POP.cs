#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0460_POP
//   Form Name    : 설비점검항목 마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-02-05
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 설비점검항목 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0460_POP : WIZ.Forms.BasePopupForm
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

        public BM0460_POP(string[] param)
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
                        txt_MACHKCODE_H.Text = argument[1].ToUpper(); //검사코드
                        break;

                    case 2:
                        txt_MACHKNAME_H.Text = argument[2].ToUpper(); //검사항목
                        break;
                    case 3:
                        cbo_USEFLAG_H.Text = argument[3].ToUpper() == "" ? "ALL" : argument[3].ToUpper(); //사용여부
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
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKCODE", "점검항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKNAME", "점검항목명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

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
            string sMachkCode = string.Empty;
            string sMachkName = string.Empty;
            string sUseFlag = string.Empty;

            sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            sMachkCode = txt_MACHKCODE_H.Text.Trim();
            sMachkName = txt_MACHKNAME_H.Text.Trim();
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);

            _DtTemp = _biz.SEL_BM0460(sPlantCode, sMachkCode, sMachkName, sUseFlag);

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
            TmpDt.Columns.Add("MACHKCODE", typeof(string));
            TmpDt.Columns.Add("MACHKNAME", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["MACHKCODE"].Value, e.Row.Cells["MACHKNAME"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txt_MACHKCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void txt_MACHKNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        #endregion

    }
}
