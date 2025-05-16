#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0010
//   Form Name    : 품목마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM5100_POP : WIZ.Forms.BasePopupForm
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

        public BM5100_POP(string[] param)
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
                        //cbo_ITEMTYPE_H.Text = argument[1].ToUpper() == "" ? "ALL" : argument[1].ToUpper(); //품목유형
                        break;

                    case 2:
                        txt_ITEMCODE_H.Text = argument[2].ToUpper(); //품목
                        break;

                    case 3:
                        txt_ITEMNAME_H.Text = argument[3].ToUpper(); //품명
                        break;

                    case 4:
                        cbo_USEFLAG_H.Text = argument[4].ToUpper() == "" ? "ALL" : argument[4].ToUpper(); //사용여부                   
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

                //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장",   false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "AlarmCode", "알람코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "AlarmText", "알람내용", false, GridColDataType_emu.VarChar, 400, 200, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품명",     false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형
                //WIZ.Common.FillComboboxMaster(this.cbo_ITEMTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
            string sAlarmCdoe = string.Empty;
            string sAlarmText = string.Empty;
            string sUseFlag = string.Empty;

            sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            sAlarmCdoe = txt_ITEMCODE_H.Text.Trim();
            sAlarmText = txt_ITEMNAME_H.Text.Trim();
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);


            _DtTemp = _biz.SEL_BM5100(sPlantCode, sAlarmCdoe, sAlarmText, sUseFlag);

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
            TmpDt.Columns.Add("AlarmCode", typeof(string));
            TmpDt.Columns.Add("AlarmText", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["AlarmCode"].Value, e.Row.Cells["AlarmText"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txt_ITEMCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void txt_ITEMNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        #endregion

    }
}
