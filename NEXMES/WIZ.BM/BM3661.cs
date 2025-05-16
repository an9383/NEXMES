using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

namespace WIZ.BM
{
    public partial class BM3661 : Form
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        public BM3661(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [사업장 품목 명 Parameter Show] //사업장, 공정, 설비
                switch (i)
                {
                    case 0:  //사업장
                        cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장
                        break;

                    case 1: //공정
                        txtOPCode.Text = argument[1].ToUpper(); //공정
                        break;

                    case 2: //공정명
                        txtOPName.Text = argument[2].ToUpper(); //공정
                        break;

                    case 3: //설비
                        txtMachCode.Text = argument[3].ToUpper(); //설비코드
                        break;

                    case 4: //설비명
                        txtMachName.Text = argument[4].ToUpper(); //설비명
                        break;

                    case 5: //
                        txtWorkCenterCode.Text = argument[5].ToUpper(); //
                        break;

                    case 6: //
                        txtWorkCenterName.Text = argument[6].ToUpper(); //
                        break;


                }
                #endregion
            }
        }
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                  


        private void BM3651_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "OpNo", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검항목", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "관리항목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAManaSpec", "점검기준", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAStandard", "등록형태", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격하한치", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격상한치", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "점검방법", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaLSL", "관리하한치", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaUSL", "관리상한치", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspPeriod", "검사주기(일/주/월)", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCycle", "검사주기(별)", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCount", "검사횟수", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCode", "공정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPName", "공정명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Workcentercode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkcenterName", "작업장명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Machname", "설비명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid2);


            //////MERGE
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;



            cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "ALL" : argument[0].ToUpper(); //사업장


            #region 콤보박스           
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("DAManaSpec");  //점검기준
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAManaSpec", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAStandard");  //등록형태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAStandard", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");  //점검방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); // 검사필수여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspRequired", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("InspPeriod");  //검사주기(일/주/월)
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspPeriod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspMethod");  //수집방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspMethod", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            BizGridManager BIZPOP = new BizGridManager(grid2);

            BIZPOP.PopUpAdd("MachCode", "MachName", "TBM0700", new string[] { "", "", "", "Y" });
            BIZPOP.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "Y" });
            BIZPOP.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "OPCode", "", "Y" });

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });


            #endregion


            search();

        }
        private void search()
        {
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sMachCode = txtMachCode.Text.Trim();
            string sOPCode = txtOPCode.Text.Trim();
            string sWorkcentercode = txtWorkCenterCode.Text.Trim();

            if (this.cboPlantCode_H.Value != null)
                sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();


            _DtTemp = SEL_TBM3661(sPlantCode, sOPCode, sMachCode, sWorkcentercode);

            grid1.DataSource = _DtTemp;
            grid1.DataBinds();
        }
        private void insert()
        {
            try
            {
                int sGrid1 = grid1.Rows.Count;
                int sGrid2 = grid2.Rows.Count;
                string sCODE = string.Empty;
                string sMSG = string.Empty;

                for (int i = 0; i < sGrid2; i++)
                {
                    string I_PlantCode = string.Empty;
                    string I_OpCode = txtOPCode.Text.Trim();
                    string I_Workcentercode = txtWorkCenterCode.Text.Trim();
                    string I_MachCode = txtMachCode.Text.Trim();
                    string I_OpCode2 = this.grid2.Rows[i].Cells["OPCode"].Value.ToString();
                    string I_Workcentercode2 = this.grid2.Rows[i].Cells["Workcentercode"].Value.ToString();
                    string I_MachCode2 = this.grid2.Rows[i].Cells["MachCode"].Value.ToString();
                    string I_PlantCode2 = this.grid2.Rows[i].Cells["PlantCode"].Value.ToString();
                    string I_Maker = string.Empty;

                    if (this.cboPlantCode_H.Value != null)
                        I_PlantCode = cboPlantCode_H.Value.ToString();

                    if (this.txtOPCode.Text != null)
                        I_OpCode = txtOPCode.Text.ToString();
                    I_MachCode = txtMachCode.Text.ToString();
                    I_OpCode2 = this.grid2.Rows[i].Cells["OPCode"].Value.ToString();
                    I_MachCode2 = this.grid2.Rows[i].Cells["MachCode"].Value.ToString();
                    I_PlantCode2 = this.grid2.Rows[i].Cells["PlantCode"].Value.ToString();


                    I_Maker = WIZ.LoginInfo.UserID;

                    INS_TBM3661(I_PlantCode, I_OpCode, I_Workcentercode, I_MachCode, I_OpCode2, I_Workcentercode2, I_MachCode2, I_PlantCode2, I_Maker, ref sCODE, ref sMSG);

                }

                if (sCODE == "S")
                {

                    DialogForm dialogform;

                    dialogform = new DialogForm("C:R00005", DialogForm.DialogType.OK);

                    dialogform.ShowDialog();

                }
            }
            catch
            {

            }
            finally
            {

            }

        }

        public DataTable SEL_TBM3661(string sPlantCode, string sOPCode, string sMachCode, string sWorkcentercode)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM3661_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MachCode", sMachCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("Workcentercode", sWorkcentercode, DbType.String, ParameterDirection.Input));




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

        public void INS_TBM3661(string I_PlantCode, string I_OpCode, string I_Workcentercode, string I_MachCode, string I_OpCode2, string I_Workcentercode2, string I_MachCode2, string I_PlantCode2, string I_Maker, ref string code, ref string mesg)
        {

            DBHelper helper = new DBHelper("", true);
            string RS_CODE = string.Empty, RS_MSG = string.Empty;

            this.grid1.UpdateData();

            try
            {

                helper.ExecuteNoneQuery("USP_BM3661_I1", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG
                                                       , helper.CreateParameter("PlantCode", I_PlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("opcode", I_OpCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("MachCode", I_MachCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("opcode2", I_OpCode2, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("MachCode2", I_MachCode2, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("PlantCode2", I_PlantCode2, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("Workcentercode", I_Workcentercode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("Workcentercode2", I_Workcentercode2, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("Maker", I_Maker, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    MessageBox.Show("등록되었습니다.");
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }
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
            _GridUtil.AddRow(this.grid2, _DtTemp);
            UltraGridUtil.ActivationAllowEdit(this.grid2, "PlantCode");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "OPCode");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "OPName");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "MachCode");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "MachName");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "Workcentercode");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "WorkcenterName");

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

            dialogform = new DialogForm("C:Q00009", DialogForm.DialogType.YESNO);

            dialogform.ShowDialog();

            if (dialogform.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                insert();
            }
        }


    }
}
