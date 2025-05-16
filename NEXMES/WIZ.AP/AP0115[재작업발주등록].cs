#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0115
//   Form Name    : ���� ��Ȳ
//   Name Space   : WIZ.AP
//   Created Date : 2019-11-11
//   Made By      : ��������� �ֹ���
//   Description  : ���� ��Ȳ ������ ����
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0115 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();

        string sColorType = "";

        #endregion

        #region < CONSTRUCTOR >
        public AP0115()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0115_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        protected override void SetSubData()
        {
            // �����͸� ���� �߰� ó�� ��� ����
            DataRow dr = subData["METHOD_TYPE", "ROWCOLOR"];

            if (dr != null)
            {
                sColorType = CModule.ToString(dr["RELCODE1"]);
            }

            WIZ.Control.GridExtendUtil.SetUnitTrans(subData, grid2);
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "�����", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINDATE", "���԰�����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "���ֹ�ȣ", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "���ּ���", true, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINGROUPNO", "���ֱ׷����", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "ǰ��", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "ǰ��", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "â���ڵ�", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "��ġ�ڵ�", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "���ʼ���", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "���ϼ���", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT����", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "��뿩��", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "���", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "�����", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "����Ͻ�", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "������", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "�����Ͻ�", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEFLAG", "�ϷῩ��", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "�����", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "���ֹ�ȣ", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "���ּ���", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "ǰ��", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "ǰ��", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "����ȣ", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "����", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "������ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKID", "����ũID", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "���ּ���", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "���ϼ���", false, GridColDataType_emu.Double, 150, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "���", false, GridColDataType_emu.Double, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "����", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "��������", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEDATE", "�Ϸ�����", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSER", "�Ϸ���", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "���", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);
                grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;
                grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue; _GridUtil.SetInitUltraGridBind(grid2);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);
                cbo_NEWCONTRACTDATE_H.Value = DateTime.Now.AddDays(1);

                //rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //�����
                //WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE");  //â����ġ�ڵ�
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0010_CODE("ITEMCODE");   //ǰ��
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0080_CODE("WHCODE");  //â��
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //��뿩��
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("AP0110_FLAG");
                Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                bizGrid1Manager = new BizGridManager(grid2);
                bizGrid1Manager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "ALL", "Y" });

                bizGrid2Manager = new BizGridManager(grid2);
                bizGrid2Manager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "1", "Y" });

                bizGrid2Manager.PopUpClosed += BizGridManager_PopUpClosed;

                #endregion

                //dtGrid = (DataTable)grid1.DataSource;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void BizGridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            if (bFindOK)
            {

                DBHelper helper = new DBHelper(false);

                string sPlantCode = CModule.ToString(grid.ActiveRow.Cells["PLANTCODE"].Value);
                string sContractNo = CModule.ToString(grid.ActiveRow.Cells["CONTRACTNO"].Value);
                string sContractSeq = CModule.ToString(grid.ActiveRow.Cells["SEQ"].Value);

                DataSet ds = helper.FillDataSet("USP_AP0110_S4", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sCode, DbType.String, ParameterDirection.Input));

                if (ds.Tables.Count >= 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        grid.ActiveRow.Cells["UNITCODE"].Value = CModule.ToString(ds.Tables[0].Rows[0]["UNITCODE"]);
                        grid.ActiveRow.Cells["NOWQTY"].Value = CModule.ToString(ds.Tables[0].Rows[0]["NOWQTY"]);
                    }
                }

                if (ds.Tables.Count >= 2)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTNO"]) == sContractNo && CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTSEQ"]) == sContractSeq)
                        {
                            grid.ActiveRow.Cells["OUTQTY"].Value = string.Format("{0:#,##0}", CModule.ToDouble(ds.Tables[1].Rows[i]["OUTQTY"]));
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // ��ȸ�� �׸��� �ʱ�ȭ

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            // �����(����)
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   // ���԰��������
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     // ���԰� ������
                //string sLotNo     = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());                          // LOTNO
                //string sPoNo      = DBHelper.nvlString(txt_PONO_H.Text.Trim());                           // ���ֹ�ȣ
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_MM0025_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    //, helper.CreateParameter("AS_LOTNO",     sLotNo,     DbType.String, ParameterDirection.Input)
                                                                    //, helper.CreateParameter("AS_PONO",      sPoNo,      DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("��ȸ�� �����Ͱ� �����ϴ�.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void SetColor(WIZ.Control.Grid grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                Color coBack = Color.White;
                Color coFore = Color.Black;

                string sClose = CModule.ToString(grid.Rows[i].Cells["CLOSEFLAG"].Value);

                if (sClose != "D")
                {
                    if (sClose == "A")
                    {
                        // ���ÿϷ�
                        coBack = Color.LightGreen;
                        coFore = Color.Black;
                    }
                    else if (sClose == "B")
                    {
                        // ������
                        coBack = Color.LemonChiffon;
                        coFore = Color.Black;
                    }
                    else if (sClose == "C")
                    {
                        // ��ȹ��
                        coBack = Color.LightPink;
                        coFore = Color.Black;
                    }

                    if (sColorType == "COLOR1")
                    {
                        grid2.Rows[i].CellAppearance.BackColor = coBack;
                        grid2.Rows[i].CellAppearance.ForeColor = coFore;
                    }
                    else
                    {
                        grid2.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = coBack;
                        grid2.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = coFore;
                    }
                }
            }
        }

        public override void DoNew()
        {
            base.DoNew();

            try
            {
                //if (grid1.IsActivate)
                //{
                //    if (bNew)
                //    {
                //        this.ShowDialog(Common.getLangText("�Է� ���� ���ְ� �ֽ��ϴ�.", "MSG"), Forms.DialogForm.DialogType.OK);
                //        return;
                //    }

                //    AddGrid1Row();
                //}
                //else if (grid2.IsActivate)

                if (grid2.IsActivate)
                {
                    //grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                    //grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.White;
                    //grid2.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.White;

                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("���ֹ�ȣ�� �������ּ���.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    int iRow = grid2.InsertRow();
                    //grid2.Rows[iRow].Cells["CONTRACTNO"].Value = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    grid2.Rows[iRow].Cells["DUEDATE"].Value = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                    grid2.Rows[iRow].Cells["CLOSEFLAG"].Value = "D";
                    grid2.Rows[iRow].Cells["PLANTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                    grid2.Rows[iRow].Cells["CLOSEFLAG"].Activation = Activation.Disabled;
                    grid2.Rows[iRow].Cells["FRAMEID"].Activation = Activation.AllowEdit;
                    grid2.Rows[iRow].Cells["MASKID"].Activation = Activation.AllowEdit;
                    grid2.Rows[iRow].Cells["UNITCODE"].Activation = Activation.Disabled;
                    grid2.Rows[iRow].Cells["NOWQTY"].Activation = Activation.Disabled;
                    grid2.Rows[iRow].Cells["OUTQTY"].Activation = Activation.Disabled;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        private void AddGrid1Row()
        {
            _GridUtil.Grid_Clear(grid1);
            grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            bNew = true;

            string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

            int iRow = grid1.InsertRow();

            grid2.Rows[iRow].Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            grid2.Rows[iRow].Cells["CONTRACTDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            grid2.Rows[iRow].Cells["CONTRACTNO"].Activation = Activation.Disabled;
            if (!chk5.Checked)
            {
                grid2.Rows[iRow].Cells["CONTRACTNO"].Value = "[ REPAIR CONTRACT ]";
                grid2.UpdateData();
                // _GridUtil.Grid_Clear(grid2);
            }
            else
            {
                grid2.Rows[iRow].Cells["CONTRACTNO"].Value = "[ TEST CONTRACT ]";
                grid2.UpdateData();
                //_GridUtil.Grid_Clear(grid2);
            }

        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();
            DataTable dtChange2 = grid2.chkChange();

            if (dtChange2 == null && dtChange == null)
            {
                return;
            }

            if (this.ShowDialog(Common.getLangText("����� ������ �����Ͻðڽ��ϱ�?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            string sPlantCode = "";
            string sContractNO = string.Empty;
            string sItemCode = string.Empty;
            string sContractDate = string.Empty;
            string sDueDate = string.Empty;
            string sCustCode = string.Empty;
            string sFrameID = string.Empty;
            string sMASKID = string.Empty;
            string sCloseDate = string.Empty;
            string sCloseFlag = string.Empty;
            string sCloser = string.Empty;
            string sRemark = string.Empty;
            string sSeq = "";
            string sUser = LoginInfo.UserID;

            double dContractQty;

            string sRT_ContractNo = "";

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                // grid2 - ���� ��
                if (dtChange2 != null)
                {
                    foreach (DataRow drChange in dtChange2.Rows)
                    {
                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- ���� ---
                                drChange.RejectChanges();

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                helper.ExecuteNoneQuery("USP_AP0115_D1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", CModule.ToString(drChange["SEQ"]), DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region --- �߰� ---
                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid1.ActiveRow.Cells["CONTRACTDATE"].Value));
                                sCustCode = CModule.ToString(grid2.ActiveRow.Cells["CUSTCODE"].Value);
                                sRemark = CModule.ToString(grid2.ActiveRow.Cells["REMARK"].Value);
                                sFrameID = CModule.ToString(grid2.ActiveRow.Cells["FRAMEID"].Value);
                                sMASKID = CModule.ToString(grid2.ActiveRow.Cells["MASKID"].Value);

                                sItemCode = CModule.ToString(drChange["ITEMCODE"]);
                                dContractQty = DBHelper.nvlDouble(drChange["CONTRACTQTY"]);
                                sDueDate = string.Format("{0:yyyy-MM-dd}", drChange["DUEDATE"]);
                                sCloseFlag = CModule.ToString(drChange["CLOSEFLAG"]);
                                sSeq = CModule.ToString(drChange["SEQ"]);

                                helper.ExecuteNoneQuery("USP_AP0115_I1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MASKID", sMASKID, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG.StartsWith("CONNO"))
                                {
                                    sRT_ContractNo = helper.RSMSG.Split('|')[1];
                                }

                                #endregion
                                break;

                        }
                    }
                }

                // ���� ����
                if (dtChange != null)
                {
                    foreach (DataRow drChange in dtChange.Rows)
                    {

                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- ���� ---
                                drChange.RejectChanges();

                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);

                                helper.ExecuteNoneQuery("USP_AP0115_D1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", sContractNO, DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region --- �߰� ---

                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid2.ActiveRow.Cells["CONTRACTDATE"].Value));
                                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                                sRemark = CModule.ToString(drChange["REMARK"]);

                                sItemCode = "";
                                dContractQty = 0;
                                sDueDate = "";
                                sCloseFlag = "";
                                sSeq = CModule.ToString(grid2.ActiveRow.Cells["SEQ"].Value);

                                helper.ExecuteNoneQuery("USP_AP0115_U2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG.StartsWith("CONNO"))
                                {
                                    sRT_ContractNo = helper.RSMSG.Split('|')[1];
                                }
                                #endregion
                                break;
                        }
                    }
                }

                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >
        //private void btn_COPY_H_Click(object sender, EventArgs e)
        //{
        //    DBHelper helper;

        //    try
        //    {
        //        helper = new DBHelper("", true);

        //        string sMakeDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);

        //        try
        //        {
        //            helper.ExecuteNoneQuery("USP_AP0115_C1", CommandType.StoredProcedure
        //          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_STANDDATE", "", DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //            if (helper.RSCODE == "S")
        //            {
        //                helper.Commit();

        //                DoInquire();
        //            }
        //            else if (helper.RSCODE == "C")
        //            {
        //                string sStandDate = helper.RSMSG;

        //                helper = new DBHelper("", true);

        //                try
        //                {
        //                    DialogResult result = MessageBox.Show("���� ���� �� ���������� �����ϴ�." + Environment.NewLine + sStandDate + " �� ���������� ���� �մϴ�. ���� �Ͻðڽ��ϱ�?", "�������� ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        //                    if (result.ToString().ToUpper() == "YES")
        //                    {
        //                        helper.ExecuteNoneQuery("USP_AP0115_C1", CommandType.StoredProcedure
        //                      , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_STANDDATE", sStandDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //                        if (helper.RSCODE == "S")
        //                        {
        //                            helper.Commit();

        //                            DoInquire();
        //                        }
        //                        else
        //                        {
        //                            helper.Rollback();

        //                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                            return;
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    helper.Rollback();

        //                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //                }
        //                finally
        //                {
        //                    helper.Close();
        //                }
        //            }
        //            else if (helper.RSCODE == "E")
        //            {
        //                helper.Rollback();

        //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            helper.Rollback();

        //            this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //        }
        //        finally
        //        {
        //            helper.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        ClosePrgFormNew();
        //    }
        //}
        #endregion

        #region < METHOD AREA >

        #endregion
        private void btn_COPY_ITEM_Click(object sender, EventArgs e)
        {
            DBHelper helper;

            try
            {
                helper = new DBHelper("", true);

                string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sContractDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);
                double dContractQty = Convert.ToDouble(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);

                try
                {
                    helper.ExecuteNoneQuery("USP_AP0115_C2", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    grid1.SetAcceptChanges();

                    helper.Commit();

                    DoInquire();
                }
                catch (Exception ex)
                {
                    helper.Rollback();

                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.ActiveCell == null)
            {
                this.ShowDialog("�� ������ ��Ȯ�ϰ� �ϼ���.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                _GridUtil.Grid_Clear(grid2);

                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sCONTRACTNO = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);

                string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
                sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
                sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
                sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");

                dtGrid = helper.FillTable("USP_AP0115_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid;
                grid2.DataBinds(dtGrid);

                SetColor(grid2);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
    }
}
