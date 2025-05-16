
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0090
//   Form Name    : 저장위치 마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 저장위치 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0090_POP : WIZ.Forms.BasePopupForm
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

        public BM0090_POP(string[] param)
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
                        txt_WHNAME_H.Text = argument[1].ToUpper(); //창고정보
                        break;

                    case 2:
                        txt_LOC_H.Text = argument[2].ToUpper(); //저장위치코드
                        break;

                    case 3:
                        txt_LOCNAME_H.Text = argument[3].ToUpper(); //저장위치명
                        break;

                    case 4:
                        txt_POSITION_H.Text = argument[4].ToUpper(); //위취정보
                        break;

                    case 5:
                        cbo_USEFLAG_H.Text = argument[5].ToUpper() == "" ? "ALL" : argument[5].ToUpper(); //사용여부
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
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "POSITION", "위치", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE"); //저장위치구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


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
            string sLoc = string.Empty;
            string sLocName = string.Empty;
            string sPosition = string.Empty;
            string sUseFlag = string.Empty;
            string sWHName = string.Empty;

            sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            sLoc = txt_LOC_H.Text.Trim();
            sLocName = txt_LOCNAME_H.Text.Trim();
            sPosition = txt_POSITION_H.Text.Trim();
            sWHName = txt_WHNAME_H.Text.Trim();
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);

            //public DataTable SEL_BM0090(string sPlantCode, string sLoc, string sLocName, string sPosition, string sWHName, string sUseFlag)
            _DtTemp = _biz.SEL_BM0090(sPlantCode, sLoc, sLocName, sPosition, sWHName, sUseFlag);

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
            TmpDt.Columns.Add("STORAGELOCCODE", typeof(string));
            TmpDt.Columns.Add("STORAGELOCNAME", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["STORAGELOCCODE"].Value, e.Row.Cells["STORAGELOCNAME"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txt_STORAGELOCCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void txt_STORAGELOCNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void txt_OPCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        #endregion


    }
}
