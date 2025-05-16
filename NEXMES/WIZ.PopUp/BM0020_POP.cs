#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0020
//   Form Name    : 작업자 마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업자 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0020_POP : WIZ.Forms.BasePopupForm
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

        public BM0020_POP(string[] param)
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
                        cbo_DEPTCODE_H.Text = argument[1].ToUpper() == "" ? "ALL" : argument[1].ToUpper(); //부서
                        break;

                    case 2:
                        txt_WORKERID_H.Text = argument[2].ToUpper(); //사번
                        break;

                    case 3:
                        txt_WORKERNAME_H.Text = argument[3].ToUpper(); //작업자명
                        break;

                    case 4:
                        cbo_USEFLAG_H.Text = argument[4].ToUpper() == "" ? "ALL" : argument[4].ToUpper(); ; //사용여부
                        break;
                }
                #endregion
            }

            search();

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
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자 ID", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //부서
                WIZ.Common.FillComboboxMaster(this.cbo_DEPTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

        private void search()
        {
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sWorkerID = string.Empty;
            string sWorkerName = string.Empty;
            string sDeptCode = string.Empty;
            string sUseFlag = string.Empty;

            sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            sWorkerID = txt_WORKERID_H.Text.Trim();
            sWorkerName = txt_WORKERNAME_H.Text.Trim();
            sDeptCode = Convert.ToString(cbo_DEPTCODE_H.Value);
            sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);

            _DtTemp = _biz.SEL_BM0020(sPlantCode, sWorkerID, sWorkerName, sDeptCode, sUseFlag);

            grid1.DataSource = _DtTemp;
            grid1.DataBind();
        }

        #endregion

        #region < EVENT AREA >
        private void btn_SEARCH_H_Click(object sender, EventArgs e)
        {
            search();
        }

        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("WORKERID", typeof(string));
            TmpDt.Columns.Add("WORKERNAME", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["WORKERID"].Value, e.Row.Cells["WORKERNAME"].Value });

            this.Tag = TmpDt;
            this.Close();
        }
        private void txt_WORKERID_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void txt_WORKERNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }


        #endregion

    }
}
