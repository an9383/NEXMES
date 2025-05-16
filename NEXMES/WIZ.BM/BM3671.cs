using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

namespace WIZ.BM
{
    public partial class BM3671 : Form
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        public BM3671(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [사업장 설비 명 Parameter Show] //사업장,  설비
                switch (i)
                {
                    case 0:  //사업장
                        cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장
                        break;

                    case 1: //설비
                        txtMachCode.Text = argument[1].ToUpper(); //설비코드
                        break;

                    case 2: //설비명
                        txtMachName.Text = argument[2].ToUpper(); //설비명
                        break;

                }
                #endregion
            }
        }
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                  

        #region 설비정보
        private void Search_Pop_TBM0700()
        {

            string sMachCode = txtMachCode.Text.Trim();       //설비코드
            string sMachName = txtMachName.Text.Trim();      //설비명 


            try
            {
                //_biz.BM0070_POP(sMachCode, sMachName, "", "", "", "", txtMachCode, txtMachName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //설비

        private void txtMachCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachName.Text = string.Empty;
        }

        private void txtMachCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }

        private void txtMachName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachCode.Text = string.Empty;
        }

        private void txtMachName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }

        #region grid POP UP 처리                                                                                                                                                 
        private void grid_POP_UP()
        {
            int iRow = this.grid2.ActiveRow.Index;
            string sPlantCode = Convert.ToString(this.grid2.Rows[iRow].Cells["PlantCode"].Value);  // 사업부


            string sUseFlag = "Y"; //사용여부 

            string sMachCode = this.grid2.Rows[iRow].Cells["MachCode"].Text.Trim();  // 설비코드
            string sMachName = this.grid2.Rows[iRow].Cells["MachName"].Text.Trim();  // 설비명


            //설비(작업설비 TBM0700)
            if (this.grid2.ActiveCell.Column.ToString() == "MachCode" || this.grid2.ActiveCell.Column.ToString() == "MachName")
            {
                //_biz.TBM0700_POP_Grid(sMachCode, sMachName, "", "", "", sUseFlag, grid2, "MachCode", "MachName");
            }// 설비(작업설비 TBM0700)선택                                                                                                                                
        }
        private void grid2_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            grid_POP_UP();
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grid_POP_UP();
            }

        }
        #endregion  //grid POP-UP 처리

        private void BM3671_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검항목", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "점검항목명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCMETHOD", "점검방법", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCRUNSTOP", "운/휴", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCINSTRUMENT", "측정기구", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCSTANDARD", "판정기준", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCCHECKCYLE", "교환,점검주기", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Machname", "설비명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid2);



            cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장


            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("MCRUNSTOP");  //운/휴
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCRUNSTOP", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCMETHOD");  //점검방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCMETHOD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCINSTRUMENT");  //측정기구
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCINSTRUMENT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCSTANDARD");  //판정기준
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCSTANDARD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");  //검사정보구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion


            search();

        }
        private void search()
        {
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
            string sMachCode = txtMachCode.Text.Trim();


            _DtTemp = SEL_TBM3671(sPlantCode, sMachCode);



            grid1.DataSource = _DtTemp;
            grid1.DataBinds();
        }
        private void insert()
        {
            //등록처리
            try
            {
                int sGrid1 = grid1.Rows.Count;
                int sGrid2 = grid2.Rows.Count;

                string sCODE = string.Empty;
                string sMSG = string.Empty;

                for (int i = 0; i < sGrid2; i++)
                {
                    string I_PlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                    string I_PlantCode2 = string.Empty;
                    string I_txtMachCode = txtMachCode.Text.Trim();
                    string I_txtMachCode1 = string.Empty;
                    string I_Maker = string.Empty;


                    if (this.txtMachCode.Text != null)
                        I_txtMachCode = txtMachCode.Text.ToString();
                    I_txtMachCode1 = this.grid2.Rows[i].Cells["MachCode"].Value.ToString();
                    I_PlantCode2 = this.grid2.Rows[i].Cells["PlantCode"].Value.ToString();


                    I_Maker = WIZ.LoginInfo.UserID;

                    INS_TBM3671(I_PlantCode, I_txtMachCode, I_PlantCode2, I_txtMachCode1, I_Maker, ref sCODE, ref sMSG);

                }

                if (sCODE == "S")
                {
                    MessageBox.Show(sMSG);
                }
            }
            catch
            {

            }
            finally
            {

            }


        }

        public DataTable SEL_TBM3671(string sPlantCode, string sMachCode)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_BM3671_S1", CommandType.StoredProcedure
                , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("MachCode", sMachCode, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            search();  //조회처리
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            _DtTemp = (DataTable)grid2.DataSource;
            //추가
            int iRow = _GridUtil.AddRow(this.grid2, _DtTemp);
            UltraGridUtil.ActivationAllowEdit(this.grid2, "PlantCode", iRow);
            UltraGridUtil.ActivationAllowEdit(this.grid2, "MachCode", iRow);
            UltraGridUtil.ActivationAllowEdit(this.grid2, "MachName", iRow);

        }

        private void bntDel_Click(object sender, EventArgs e)
        {
            //삭제
            int idx = this.grid2.ActiveRow == null ? 0 : this.grid2.ActiveRow.Index;
            if (idx >= 0)
                UltraGridUtil.GridRowDelete(grid2, idx);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogForm dialogform;

            dialogform = new DialogForm("C:Q00009");

            dialogform.ShowDialog();

            insert();

        }

        public void INS_TBM3671(string I_PlantCode, string I_txtMachCode, string I_PlantCode2, string I_txtMachCode1, string I_Maker, ref string code, ref string mesg)
        {

            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_BM3671_I1", CommandType.StoredProcedure
                , helper.CreateParameter("PlantCode", I_PlantCode, DbType.String, ParameterDirection.Input)        // 공장코드
                , helper.CreateParameter("MachCode", I_txtMachCode, DbType.String, ParameterDirection.Input)        // 항목이름
                , helper.CreateParameter("PlantCode2", I_PlantCode2, DbType.String, ParameterDirection.Input)        // 항목이름
                , helper.CreateParameter("MachCode1", I_txtMachCode1, DbType.String, ParameterDirection.Input)        // 항목이름
                , helper.CreateParameter("Maker", I_Maker, DbType.String, ParameterDirection.Input));      // 등록자  

                helper.Commit();

            }
            catch (Exception ex)
            {

                helper.Rollback();
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                helper.Close();
            }
        }
    }
}
