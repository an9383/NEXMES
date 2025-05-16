using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

namespace WIZ.BM
{

    public partial class BM2501 : WIZ.Forms.BaseForm
    {

        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        public string PplantCode = string.Empty;

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        #endregion

        public BM2501(string PlantCode, string ItemCode, string ItemName)
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid2);

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });    //품목            

            this.PplantCode = PlantCode;
            txtItemCode.Text = ItemCode;
            txtItemName.Text = ItemName;

        }
        // Form에서 사용할 함수나 메소드를 정의                                                                                                                                  

        private void BM2501_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Plant", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorTypeNm", "불량구분명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClassNm", "불량유형명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);

            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 400, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = this.PplantCode;
            //////MERGE
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            _GridUtil.SetInitUltraGridBind(grid2);


            //1. 사업자와, 품목이 선택되어 있으면 grid1에 tbm3650의 정보를 보여줌
            search();

        }
        private void search()
        {
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
            string sItemCode = txtItemCode.Text.Trim();
            string sItemNmae = txtItemName.Text.Trim();

            _DtTemp = SEL_BM2501(sPlantCode, sItemCode);

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
                    string I_PlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                    string I_ItemCode = txtItemCode.Text.Trim();
                    string I_ItemCode1 = this.grid2.Rows[i].Cells["ItemCode"].Value.ToString();
                    string I_Maker = string.Empty;

                    if (this.txtItemCode.Text != null)
                        I_ItemCode = txtItemCode.Text.ToString();
                    I_ItemCode1 = this.grid2.Rows[i].Cells["ItemCode"].Value.ToString();
                    I_Maker = WIZ.LoginInfo.UserID;

                    INS_BM2501(I_PlantCode, I_ItemCode, I_ItemCode1, I_Maker, ref sCODE, ref sMSG);

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

        public DataTable SEL_BM2501(string sPlantCode, string sItemCode)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM2501_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));

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

        public void INS_BM2501(string I_PlantCode, string I_ItemCode, string I_ItemCode1, string I_Maker, ref string code, ref string mesg)
        {

            DBHelper helper = new DBHelper("", true);

            this.grid2.UpdateData();

            try
            {
                helper.ExecuteNoneQuery("USP_BM2501_I1", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG
                                                        , helper.CreateParameter("PlantCode", I_PlantCode, DbType.String, ParameterDirection.Input)        // 공장코드
                                                        , helper.CreateParameter("ItemCode", I_ItemCode, DbType.String, ParameterDirection.Input)        // 항목이름
                                                        , helper.CreateParameter("ItemCode1", I_ItemCode1, DbType.String, ParameterDirection.Input)        // 항목이름
                                                        , helper.CreateParameter("Maker", I_Maker, DbType.String, ParameterDirection.Input));      // 등록자  
                if (helper.RSCODE == "S")
                {
                    //성공처리 여부 메세지 쇼
                    helper.Commit();
                    MessageBox.Show("처리되었습니다.");

                }
                else
                {
                    //실패처리 여부 메세지 쇼~~
                    //RS_MSG
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
            int iRow = _GridUtil.AddRow(this.grid1, _DtTemp);
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
