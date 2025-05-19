using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0010 : BaseMDIChildForm
    {
        private DataTable DtGrid1 = new DataTable();

        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private DataTable rtnDtTemp = new DataTable();

        private Common _Common = new Common();

        private bool StatusCheck = false;

        private bool binit = false;

        private Binding INQFLAG = null;

        private Binding DELFLAG = null;

        private Binding PRNFLAG = null;

        private Binding NEWFLAG = null;

        private Binding SAVEFLAG = null;

        private Binding EXCELFLAG = null;

        private Binding EXCELIMFLAG = null;

        private new IContainer components = null;

        private WIZ.Control.Grid grid1;

        private SLabel lblUseFlag_H;

        private SLabel lblProgramID_H;

        private UltraGroupBox ultraGroupBox1;

        private SLabel lblRemark;

        private SLabel lblContact;

        private SLabel lblDeveloper;

        private SLabel lblParameter;

        private SLabel lblFileID;

        private SLabel lblNameSpace;

        private UltraCheckEditor uceExcelFlag;

        private UltraCheckEditor ucePrnFlag;

        private UltraCheckEditor uceSaveFlag;

        private UltraCheckEditor uceDelFlag;

        private UltraCheckEditor uceNewFlag;

        private UltraCheckEditor uceInqFlag;

        private SLabel sLabel2;

        private SLabel sLabel1;

        private UltraSplitter ultraSplitter1;

        private SLabel lblUseFlag;

        private UltraCheckEditor uceSumFlag;

        private SLabel sLabel6;

        private SCodeNMComboBox cboSystemType_H;

        private SCodeNMComboBox cboUseFlag_H;

        private SCodeNMComboBox cboMenuType;

        private SCodeNMComboBox UseFlag;

        private SLabel sLabel3;

        private UltraCheckEditor uceExcelIMFlag;

        private WIZ.Control.STextBox txtProgramID_H;

        private WIZ.Control.STextBox txtProgramName;

        private WIZ.Control.STextBox txtProgramID;

        private WIZ.Control.STextBox txtProgramNM;

        private WIZ.Control.STextBox txtTopicID;

        private WIZ.Control.STextBox txtNameSpace;

        private WIZ.Control.STextBox txtFileID;

        private WIZ.Control.STextBox txtParameter;

        private WIZ.Control.STextBox txtDeveloper;

        private WIZ.Control.STextBox txtContact;

        private WIZ.Control.STextBox txtRemark;

        public SY0010()
        {
            InitializeComponent();
        }

        private void SY0010_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", activeRowWhiteColor: true);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGRAMID", "프로그램ID", true, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGTYPE", "메뉴TYPE", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CODENAME", "프로그램유형", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGRAMNAME", "프로그램명", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INQFLAG", "조회", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NEWFLAG", "추가", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DELFLAG", "삭제", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAVEFLAG", "저장", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRNFLAG", "Print", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EXCELFLAG", "Excel_DOWN", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EXEIMFLAG", "Excel_UP", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEID", "FILEID", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NAMESPACE", "NAMESPACE", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEVELOPER", "DEVELOPER", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "CONTACT", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AUTHDATE", "AUTHDATE", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARAM", "PARAM", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SYSTEMID", "SYSTEMID", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LANG", "언어", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UIDNAME", "다국어명", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOPICID", "도움말ID", false, GridColDataType_emu.Integer, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            rtnDtTemp = _Common.GET_BM0000_CODE("MENUTYPE");
            UltraGridUtil.SetComboUltraGrid(grid1, "PROGTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("SYSTEMID");
            UltraGridUtil.SetComboUltraGrid(grid1, "SYSTEMID", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboSystemType_H.Value = Common.SystemID;
            UltraGridUtil.SetGridDataCopy(grid1);
            DtGrid1 = (DataTable)grid1.DataSource;
            binit = true;
        }

        public override void DoInquire()
        {
            base.DoInquire();
            _GridUtil.Grid_Clear(grid1);
            USP_SY0000_S1();
        }

        public override void DoNew()
        {
            base.DoNew();
            grid1.InsertRow();
            grid1.ActiveRow.Cells["UseFlag"].Value = "Y";
            txtProgramID.Focus();
        }

        public override void DoDelete()
        {
            base.DoDelete();
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            base.DoSave();
            grid1.SetRow();
            grid1.PerformAction(UltraGridAction.DeactivateCell);
            if (UltraGridUtil.CheckSaveDataGrid(this, grid1, DtGrid1))
            {
                USP_SY0000_CRUD(DtGrid1, WorkerID);
                StatusCheck = false;
            }
            else
            {
                StatusCheck = true;
            }
        }

        private void cboSystemType_H_ValueChanged(object sender, EventArgs e)
        {
            if (binit)
            {
                DoInquire();
                ClosePrgForm();
            }
        }

        public void USP_SY0000_CRUD(DataTable DtChange, string USER_ID)
        {
            DataTable dataTable = grid1.chkChange();
            if (dataTable != null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                txtProgramID_H.Focus();
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Deleted:
                                row.RejectChanges();
                                dBHelper.ExecuteNoneQuery("USP_SY0010_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input));
                                row.Delete();
                                break;
                            case DataRowState.Added:
                                dBHelper.ExecuteNoneQuery("USP_SY0010_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMNAME", Convert.ToString(row["PROGRAMNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGTYPE", Convert.ToString(row["PROGTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("INQFLAG", (Convert.ToString(row["INQFLAG"]) == "True" || Convert.ToString(row["INQFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("NEWFLAG", (Convert.ToString(row["NEWFLAG"]) == "True" || Convert.ToString(row["NEWFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SAVEFLAG", (Convert.ToString(row["SAVEFLAG"]) == "True" || Convert.ToString(row["SAVEFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DELFLAG", (Convert.ToString(row["DELFLAG"]) == "True" || Convert.ToString(row["DELFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EXCELFLAG", (Convert.ToString(row["EXCELFLAG"]) == "True" || Convert.ToString(row["EXCELFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PRNFLAG", (Convert.ToString(row["PRNFLAG"]) == "True" || Convert.ToString(row["PRNFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EXEIMFLAG", (Convert.ToString(row["EXEIMFLAG"]) == "True" || Convert.ToString(row["EXEIMFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("NAMESPACE", Convert.ToString(row["NAMESPACE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DEVELOPER", Convert.ToString(row["DEVELOPER"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CONTACT", Convert.ToString(row["CONTACT"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AUTHDATE", Convert.ToString(row["AUTHDATE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PARAM", Convert.ToString(row["PARAM"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UIDNAME", row["UIDNAME"], DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("TOPICID", row["TOPICID"], DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Modified:
                                dBHelper.ExecuteNoneQuery("USP_SY0010_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMNAME", Convert.ToString(row["PROGRAMNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGTYPE", Convert.ToString(row["PROGTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("INQFLAG", (Convert.ToString(row["INQFLAG"]) == "True" || Convert.ToString(row["INQFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("NEWFLAG", (Convert.ToString(row["NEWFLAG"]) == "True" || Convert.ToString(row["NEWFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SAVEFLAG", (Convert.ToString(row["SAVEFLAG"]) == "True" || Convert.ToString(row["SAVEFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DELFLAG", (Convert.ToString(row["DELFLAG"]) == "True" || Convert.ToString(row["DELFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EXCELFLAG", (Convert.ToString(row["EXCELFLAG"]) == "True" || Convert.ToString(row["EXCELFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PRNFLAG", (Convert.ToString(row["PRNFLAG"]) == "True" || Convert.ToString(row["PRNFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EXEIMFLAG", (Convert.ToString(row["EXEIMFLAG"]) == "True" || Convert.ToString(row["EXEIMFLAG"]) == "1") ? 1 : 0, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("NAMESPACE", Convert.ToString(row["NAMESPACE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DEVELOPER", Convert.ToString(row["DEVELOPER"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CONTACT", Convert.ToString(row["CONTACT"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AUTHDATE", Convert.ToString(row["AUTHDATE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PARAM", Convert.ToString(row["PARAM"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UIDNAME", row["UIDNAME"], DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("TOPICID", row["TOPICID"], DbType.String, ParameterDirection.Input));
                                break;
                        }
                        grid1.SetRowError(row, dBHelper.RSMSG, dBHelper.RSCODE);
                    }
                    grid1.SetAcceptChanges();
                    dBHelper.Commit();
                }
                catch (Exception ex)
                {
                    dBHelper.Rollback();
                    ThrowError(ex);
                }
                finally
                {
                    dBHelper.Close();
                }
            }
        }

        private void USP_SY0000_S1()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                if (!StatusCheck)
                {
                    base.DoInquire();
                    string text = DBHelper.nvlString(cboUseFlag_H.Value);
                    text = ((text == "ALL") ? "" : text);
                    DataTable dataTable = dBHelper.FillTable("USP_SY0010_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("PROGRAMID", txtProgramID_H.Text, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMNAME", txtProgramName.Text, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", text, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input));
                    if (dataTable.Rows.Count > 0)
                    {
                        grid1.DataSource = dataTable;
                        grid1.DataBinds();
                        DtGrid1 = dataTable;
                        grid1.GetRow();
                        txtProgramID.DataBindings.Clear();
                        txtProgramID.DataBindings.Add("Value", DtGrid1, "PROGRAMID");
                        txtProgramNM.DataBindings.Clear();
                        txtProgramNM.DataBindings.Add("Value", DtGrid1, "PROGRAMNAME");
                        cboMenuType.DataBindings.Clear();
                        cboMenuType.DataBindings.Add("Value", DtGrid1, "PROGTYPE");
                        UseFlag.DataBindings.Clear();
                        UseFlag.DataBindings.Add("Value", DtGrid1, "USEFLAG");
                        INQFLAG = new Binding("Checked", DtGrid1, "INQFLAG");
                        DELFLAG = new Binding("Checked", DtGrid1, "DELFLAG");
                        PRNFLAG = new Binding("Checked", DtGrid1, "PRNFLAG");
                        NEWFLAG = new Binding("Checked", DtGrid1, "NEWFLAG");
                        SAVEFLAG = new Binding("Checked", DtGrid1, "SAVEFLAG");
                        EXCELFLAG = new Binding("Checked", DtGrid1, "EXCELFLAG");
                        EXCELIMFLAG = new Binding("Checked", DtGrid1, "EXEIMFLAG");
                        INQFLAG.Format += ComboBind;
                        DELFLAG.Format += ComboBind;
                        PRNFLAG.Format += ComboBind;
                        NEWFLAG.Format += ComboBind;
                        SAVEFLAG.Format += ComboBind;
                        EXCELFLAG.Format += ComboBind;
                        EXCELIMFLAG.Format += ComboBind;
                        uceInqFlag.DataBindings.Clear();
                        uceInqFlag.DataBindings.Add(INQFLAG);
                        uceDelFlag.DataBindings.Clear();
                        uceDelFlag.DataBindings.Add(DELFLAG);
                        ucePrnFlag.DataBindings.Clear();
                        ucePrnFlag.DataBindings.Add(PRNFLAG);
                        uceNewFlag.DataBindings.Clear();
                        uceNewFlag.DataBindings.Add(NEWFLAG);
                        uceSaveFlag.DataBindings.Clear();
                        uceSaveFlag.DataBindings.Add(SAVEFLAG);
                        uceExcelFlag.DataBindings.Clear();
                        uceExcelFlag.DataBindings.Add(EXCELFLAG);
                        uceExcelIMFlag.DataBindings.Clear();
                        uceExcelIMFlag.DataBindings.Add(EXCELIMFLAG);
                        txtNameSpace.DataBindings.Clear();
                        txtNameSpace.DataBindings.Add("Value", DtGrid1, "NAMESPACE");
                        txtFileID.DataBindings.Clear();
                        txtFileID.DataBindings.Add("Value", DtGrid1, "FILEID");
                        txtParameter.DataBindings.Clear();
                        txtParameter.DataBindings.Add("Value", DtGrid1, "PARAM");
                        txtDeveloper.DataBindings.Clear();
                        txtDeveloper.DataBindings.Add("Value", DtGrid1, "DEVELOPER");
                        txtContact.DataBindings.Clear();
                        txtContact.DataBindings.Add("Value", DtGrid1, "CONTACT");
                        txtRemark.DataBindings.Clear();
                        txtRemark.DataBindings.Add("Value", DtGrid1, "REMARK");
                        txtTopicID.DataBindings.Clear();
                        txtTopicID.DataBindings.Add("Value", DtGrid1, "TOPICID");
                    }
                }
                else if (UltraGridUtil.CheckSearchDataGrid(this, grid1, DtGrid1))
                {
                    DialogForm dialogForm = new DialogForm(Common.getLangText("자료를 저장하지 않았습니다. \n\r\n\r저장하지 않고 검색하겠습니까?", "MSG"));
                    dialogForm.ShowDialog();
                    if (dialogForm.result == "OK")
                    {
                        StatusCheck = true;
                    }
                    else
                    {
                        StatusCheck = false;
                        DoInquire();
                    }
                }
                else
                {
                    StatusCheck = false;
                    DoInquire();
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = false;
            }
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DoInquire();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private new void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            txtRemark = new WIZ.Control.STextBox(components);
            txtContact = new WIZ.Control.STextBox(components);
            txtDeveloper = new WIZ.Control.STextBox(components);
            txtParameter = new WIZ.Control.STextBox(components);
            txtFileID = new WIZ.Control.STextBox(components);
            txtNameSpace = new WIZ.Control.STextBox(components);
            txtTopicID = new WIZ.Control.STextBox(components);
            txtProgramID = new WIZ.Control.STextBox(components);
            txtProgramNM = new WIZ.Control.STextBox(components);
            uceExcelIMFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            cboMenuType = new WIZ.Control.SCodeNMComboBox();
            UseFlag = new WIZ.Control.SCodeNMComboBox();
            lblUseFlag = new WIZ.Control.SLabel();
            lblRemark = new WIZ.Control.SLabel();
            lblContact = new WIZ.Control.SLabel();
            lblDeveloper = new WIZ.Control.SLabel();
            lblParameter = new WIZ.Control.SLabel();
            lblFileID = new WIZ.Control.SLabel();
            sLabel3 = new WIZ.Control.SLabel();
            lblNameSpace = new WIZ.Control.SLabel();
            uceSumFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceExcelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ucePrnFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceSaveFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceDelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceNewFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            uceInqFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            sLabel2 = new WIZ.Control.SLabel();
            sLabel1 = new WIZ.Control.SLabel();
            lblUseFlag_H = new WIZ.Control.SLabel();
            lblProgramID_H = new WIZ.Control.SLabel();
            grid1 = new WIZ.Control.Grid(components);
            sLabel6 = new WIZ.Control.SLabel();
            cboUseFlag_H = new WIZ.Control.SCodeNMComboBox();
            cboSystemType_H = new WIZ.Control.SCodeNMComboBox();
            txtProgramName = new WIZ.Control.STextBox(components);
            txtProgramID_H = new WIZ.Control.STextBox(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox1).BeginInit();
            ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtRemark).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContact).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDeveloper).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtParameter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFileID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNameSpace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTopicID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramNM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelIMFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboMenuType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceSumFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucePrnFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceSaveFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceDelFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceNewFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uceInqFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboSystemType_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID_H).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(txtProgramID_H);
            gbxHeader.Controls.Add(txtProgramName);
            gbxHeader.Controls.Add(cboSystemType_H);
            gbxHeader.Controls.Add(cboUseFlag_H);
            gbxHeader.Controls.Add(sLabel6);
            gbxHeader.Controls.Add(lblUseFlag_H);
            gbxHeader.Controls.Add(lblProgramID_H);
            gbxHeader.Size = new System.Drawing.Size(1317, 70);
            gbxHeader.Controls.SetChildIndex(lblProgramID_H, 0);
            gbxHeader.Controls.SetChildIndex(lblUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(sLabel6, 0);
            gbxHeader.Controls.SetChildIndex(cboUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(cboSystemType_H, 0);
            gbxHeader.Controls.SetChildIndex(txtProgramName, 0);
            gbxHeader.Controls.SetChildIndex(txtProgramID_H, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(ultraGroupBox1);
            gbxBody.Controls.Add(ultraSplitter1);
            gbxBody.Controls.Add(grid1);
            gbxBody.Size = new System.Drawing.Size(1317, 672);
            ultraSplitter1.Location = new System.Drawing.Point(561, 6);
            ultraSplitter1.Name = "ultraSplitter1";
            ultraSplitter1.RestoreExtent = 0;
            ultraSplitter1.Size = new System.Drawing.Size(6, 660);
            ultraSplitter1.TabIndex = 1;
            ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            ultraGroupBox1.Controls.Add(txtRemark);
            ultraGroupBox1.Controls.Add(txtContact);
            ultraGroupBox1.Controls.Add(txtDeveloper);
            ultraGroupBox1.Controls.Add(txtParameter);
            ultraGroupBox1.Controls.Add(txtFileID);
            ultraGroupBox1.Controls.Add(txtNameSpace);
            ultraGroupBox1.Controls.Add(txtTopicID);
            ultraGroupBox1.Controls.Add(txtProgramID);
            ultraGroupBox1.Controls.Add(txtProgramNM);
            ultraGroupBox1.Controls.Add(uceExcelIMFlag);
            ultraGroupBox1.Controls.Add(cboMenuType);
            ultraGroupBox1.Controls.Add(UseFlag);
            ultraGroupBox1.Controls.Add(lblUseFlag);
            ultraGroupBox1.Controls.Add(lblRemark);
            ultraGroupBox1.Controls.Add(lblContact);
            ultraGroupBox1.Controls.Add(lblDeveloper);
            ultraGroupBox1.Controls.Add(lblParameter);
            ultraGroupBox1.Controls.Add(lblFileID);
            ultraGroupBox1.Controls.Add(sLabel3);
            ultraGroupBox1.Controls.Add(lblNameSpace);
            ultraGroupBox1.Controls.Add(uceSumFlag);
            ultraGroupBox1.Controls.Add(uceExcelFlag);
            ultraGroupBox1.Controls.Add(ucePrnFlag);
            ultraGroupBox1.Controls.Add(uceSaveFlag);
            ultraGroupBox1.Controls.Add(uceDelFlag);
            ultraGroupBox1.Controls.Add(uceNewFlag);
            ultraGroupBox1.Controls.Add(uceInqFlag);
            ultraGroupBox1.Controls.Add(sLabel2);
            ultraGroupBox1.Controls.Add(sLabel1);
            ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraGroupBox1.Location = new System.Drawing.Point(567, 6);
            ultraGroupBox1.Name = "ultraGroupBox1";
            ultraGroupBox1.Size = new System.Drawing.Size(744, 660);
            ultraGroupBox1.TabIndex = 2;
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            txtRemark.Appearance = appearance;
            txtRemark.AutoSize = false;
            txtRemark.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtRemark.Location = new System.Drawing.Point(23, 514);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtRemark.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtRemark.Size = new System.Drawing.Size(714, 288);
            txtRemark.TabIndex = 248;
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            txtContact.Appearance = appearance2;
            txtContact.AutoSize = false;
            txtContact.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtContact.Location = new System.Drawing.Point(23, 410);
            txtContact.Name = "txtContact";
            txtContact.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtContact.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtContact.Size = new System.Drawing.Size(714, 27);
            txtContact.TabIndex = 247;
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            txtDeveloper.Appearance = appearance3;
            txtDeveloper.AutoSize = false;
            txtDeveloper.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtDeveloper.Location = new System.Drawing.Point(23, 357);
            txtDeveloper.Name = "txtDeveloper";
            txtDeveloper.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtDeveloper.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtDeveloper.Size = new System.Drawing.Size(714, 27);
            txtDeveloper.TabIndex = 246;
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            txtParameter.Appearance = appearance4;
            txtParameter.AutoSize = false;
            txtParameter.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtParameter.Location = new System.Drawing.Point(23, 304);
            txtParameter.Name = "txtParameter";
            txtParameter.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtParameter.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtParameter.Size = new System.Drawing.Size(714, 27);
            txtParameter.TabIndex = 245;
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            txtFileID.Appearance = appearance5;
            txtFileID.AutoSize = false;
            txtFileID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtFileID.Location = new System.Drawing.Point(23, 251);
            txtFileID.Name = "txtFileID";
            txtFileID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtFileID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtFileID.Size = new System.Drawing.Size(714, 27);
            txtFileID.TabIndex = 244;
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            txtNameSpace.Appearance = appearance6;
            txtNameSpace.AutoSize = false;
            txtNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtNameSpace.Location = new System.Drawing.Point(23, 198);
            txtNameSpace.Name = "txtNameSpace";
            txtNameSpace.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtNameSpace.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtNameSpace.Size = new System.Drawing.Size(714, 27);
            txtNameSpace.TabIndex = 243;
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            txtTopicID.Appearance = appearance7;
            txtTopicID.AutoSize = false;
            txtTopicID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtTopicID.Location = new System.Drawing.Point(400, 86);
            txtTopicID.Name = "txtTopicID";
            txtTopicID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtTopicID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtTopicID.Size = new System.Drawing.Size(337, 27);
            txtTopicID.TabIndex = 242;
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            txtProgramID.Appearance = appearance8;
            txtProgramID.AutoSize = false;
            txtProgramID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramID.Location = new System.Drawing.Point(23, 33);
            txtProgramID.Name = "txtProgramID";
            txtProgramID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID.Size = new System.Drawing.Size(169, 27);
            txtProgramID.TabIndex = 241;
            appearance9.FontData.BoldAsString = "False";
            appearance9.FontData.UnderlineAsString = "False";
            appearance9.ForeColor = System.Drawing.Color.Black;
            txtProgramNM.Appearance = appearance9;
            txtProgramNM.AutoSize = false;
            txtProgramNM.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramNM.Location = new System.Drawing.Point(194, 33);
            txtProgramNM.Name = "txtProgramNM";
            txtProgramNM.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramNM.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramNM.Size = new System.Drawing.Size(543, 27);
            txtProgramNM.TabIndex = 241;
            uceExcelIMFlag.Location = new System.Drawing.Point(359, 146);
            uceExcelIMFlag.Name = "uceExcelIMFlag";
            uceExcelIMFlag.Size = new System.Drawing.Size(144, 20);
            uceExcelIMFlag.TabIndex = 27;
            uceExcelIMFlag.Text = "엑셀 ▲";
            cboMenuType.AutoSize = false;
            cboMenuType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboMenuType.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cboMenuType.DbConfig = null;
            cboMenuType.DefaultValue = "";
            appearance10.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboMenuType.DisplayLayout.Appearance = appearance10;
            cboMenuType.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboMenuType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboMenuType.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.Color.Gray;
            cboMenuType.DisplayLayout.CaptionAppearance = appearance11;
            cboMenuType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboMenuType.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboMenuType.DisplayLayout.InterBandSpacing = 2;
            cboMenuType.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance12.BackColor = System.Drawing.Color.RoyalBlue;
            appearance12.FontData.BoldAsString = "True";
            appearance12.ForeColor = System.Drawing.Color.White;
            cboMenuType.DisplayLayout.Override.ActiveRowAppearance = appearance12;
            appearance13.FontData.BoldAsString = "True";
            cboMenuType.DisplayLayout.Override.ActiveRowCellAppearance = appearance13;
            cboMenuType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboMenuType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboMenuType.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboMenuType.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance14.BackColor = System.Drawing.Color.DimGray;
            appearance14.BackColor2 = System.Drawing.Color.Silver;
            appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.Color.White;
            appearance14.FontData.BoldAsString = "True";
            appearance14.ForeColor = System.Drawing.Color.White;
            cboMenuType.DisplayLayout.Override.HeaderAppearance = appearance14;
            cboMenuType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance15.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance15.BackColor2 = System.Drawing.Color.Gray;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboMenuType.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance15;
            cboMenuType.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboMenuType.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboMenuType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboMenuType.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance16.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance16.FontData.BoldAsString = "True";
            cboMenuType.DisplayLayout.Override.SelectedRowAppearance = appearance16;
            cboMenuType.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboMenuType.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboMenuType.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboMenuType.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboMenuType.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboMenuType.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            cboMenuType.Location = new System.Drawing.Point(23, 87);
            cboMenuType.MajorCode = "MENUTYPE";
            cboMenuType.Name = "cboMenuType";
            cboMenuType.SelectedValue = null;
            cboMenuType.ShowDefaultValue = false;
            cboMenuType.Size = new System.Drawing.Size(216, 25);
            cboMenuType.TabIndex = 6;
            UseFlag.AutoSize = false;
            UseFlag.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            UseFlag.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            UseFlag.DbConfig = null;
            UseFlag.DefaultValue = "";
            appearance17.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            appearance17.TextHAlignAsString = "Left";
            UseFlag.DisplayLayout.Appearance = appearance17;
            UseFlag.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            UseFlag.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            UseFlag.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            UseFlag.DisplayLayout.CaptionAppearance = appearance18;
            UseFlag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            UseFlag.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            UseFlag.DisplayLayout.InterBandSpacing = 2;
            UseFlag.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance19.BackColor = System.Drawing.Color.RoyalBlue;
            appearance19.FontData.BoldAsString = "True";
            appearance19.ForeColor = System.Drawing.Color.White;
            UseFlag.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            appearance20.FontData.BoldAsString = "True";
            UseFlag.DisplayLayout.Override.ActiveRowCellAppearance = appearance20;
            UseFlag.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            UseFlag.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            UseFlag.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            UseFlag.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance21.BackColor = System.Drawing.Color.DimGray;
            appearance21.BackColor2 = System.Drawing.Color.Silver;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.BorderColor = System.Drawing.Color.White;
            appearance21.FontData.BoldAsString = "True";
            appearance21.ForeColor = System.Drawing.Color.White;
            UseFlag.DisplayLayout.Override.HeaderAppearance = appearance21;
            UseFlag.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance22.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance22.BackColor2 = System.Drawing.Color.Gray;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            UseFlag.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance22;
            UseFlag.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            UseFlag.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            UseFlag.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            UseFlag.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance23.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance23.FontData.BoldAsString = "True";
            UseFlag.DisplayLayout.Override.SelectedRowAppearance = appearance23;
            UseFlag.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            UseFlag.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            UseFlag.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            UseFlag.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            UseFlag.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            UseFlag.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            UseFlag.Location = new System.Drawing.Point(23, 463);
            UseFlag.MajorCode = "USEFLAG";
            UseFlag.Name = "UseFlag";
            UseFlag.SelectedValue = null;
            UseFlag.ShowDefaultValue = false;
            UseFlag.Size = new System.Drawing.Size(216, 25);
            UseFlag.TabIndex = 24;
            appearance24.FontData.BoldAsString = "False";
            appearance24.FontData.UnderlineAsString = "False";
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Left";
            lblUseFlag.Appearance = appearance24;
            lblUseFlag.DbField = null;
            lblUseFlag.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUseFlag.Location = new System.Drawing.Point(23, 438);
            lblUseFlag.Name = "lblUseFlag";
            lblUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUseFlag.Size = new System.Drawing.Size(562, 23);
            lblUseFlag.TabIndex = 26;
            lblUseFlag.Text = "사용구분";
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Left";
            lblRemark.Appearance = appearance25;
            lblRemark.DbField = null;
            lblRemark.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblRemark.Location = new System.Drawing.Point(23, 489);
            lblRemark.Name = "lblRemark";
            lblRemark.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblRemark.Size = new System.Drawing.Size(562, 23);
            lblRemark.TabIndex = 24;
            lblRemark.Text = "비고";
            appearance26.FontData.BoldAsString = "False";
            appearance26.FontData.UnderlineAsString = "False";
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Left";
            lblContact.Appearance = appearance26;
            lblContact.DbField = null;
            lblContact.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblContact.Location = new System.Drawing.Point(23, 385);
            lblContact.Name = "lblContact";
            lblContact.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblContact.Size = new System.Drawing.Size(562, 23);
            lblContact.TabIndex = 22;
            lblContact.Text = "연락처";
            appearance27.FontData.BoldAsString = "False";
            appearance27.FontData.UnderlineAsString = "False";
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Left";
            lblDeveloper.Appearance = appearance27;
            lblDeveloper.DbField = null;
            lblDeveloper.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblDeveloper.Location = new System.Drawing.Point(23, 332);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblDeveloper.Size = new System.Drawing.Size(562, 23);
            lblDeveloper.TabIndex = 20;
            lblDeveloper.Text = "개발자";
            appearance28.FontData.BoldAsString = "False";
            appearance28.FontData.UnderlineAsString = "False";
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Left";
            lblParameter.Appearance = appearance28;
            lblParameter.DbField = null;
            lblParameter.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblParameter.Location = new System.Drawing.Point(23, 279);
            lblParameter.Name = "lblParameter";
            lblParameter.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblParameter.Size = new System.Drawing.Size(562, 23);
            lblParameter.TabIndex = 18;
            lblParameter.Text = "파라메터";
            appearance29.FontData.BoldAsString = "False";
            appearance29.FontData.UnderlineAsString = "False";
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            lblFileID.Appearance = appearance29;
            lblFileID.DbField = null;
            lblFileID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblFileID.Location = new System.Drawing.Point(23, 226);
            lblFileID.Name = "lblFileID";
            lblFileID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblFileID.Size = new System.Drawing.Size(562, 23);
            lblFileID.TabIndex = 16;
            lblFileID.Text = "파일";
            appearance30.FontData.BoldAsString = "False";
            appearance30.FontData.UnderlineAsString = "False";
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.TextHAlignAsString = "Left";
            sLabel3.Appearance = appearance30;
            sLabel3.DbField = null;
            sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel3.Location = new System.Drawing.Point(400, 63);
            sLabel3.Name = "sLabel3";
            sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel3.Size = new System.Drawing.Size(180, 23);
            sLabel3.TabIndex = 14;
            sLabel3.Text = "도움말ID";
            appearance31.FontData.BoldAsString = "False";
            appearance31.FontData.UnderlineAsString = "False";
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Left";
            lblNameSpace.Appearance = appearance31;
            lblNameSpace.DbField = null;
            lblNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblNameSpace.Location = new System.Drawing.Point(23, 173);
            lblNameSpace.Name = "lblNameSpace";
            lblNameSpace.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblNameSpace.Size = new System.Drawing.Size(562, 23);
            lblNameSpace.TabIndex = 14;
            lblNameSpace.Text = "네임스페이스";
            uceSumFlag.Location = new System.Drawing.Point(523, 147);
            uceSumFlag.Name = "uceSumFlag";
            uceSumFlag.Size = new System.Drawing.Size(144, 20);
            uceSumFlag.TabIndex = 13;
            uceSumFlag.Text = "합계";
            uceSumFlag.Visible = false;
            uceExcelFlag.Location = new System.Drawing.Point(190, 147);
            uceExcelFlag.Name = "uceExcelFlag";
            uceExcelFlag.Size = new System.Drawing.Size(144, 20);
            uceExcelFlag.TabIndex = 13;
            uceExcelFlag.Text = "엑셀 ▼";
            ucePrnFlag.Location = new System.Drawing.Point(23, 146);
            ucePrnFlag.Name = "ucePrnFlag";
            ucePrnFlag.Size = new System.Drawing.Size(144, 20);
            ucePrnFlag.TabIndex = 12;
            ucePrnFlag.Text = "출력";
            uceSaveFlag.Location = new System.Drawing.Point(523, 121);
            uceSaveFlag.Name = "uceSaveFlag";
            uceSaveFlag.Size = new System.Drawing.Size(144, 20);
            uceSaveFlag.TabIndex = 11;
            uceSaveFlag.Text = "저장";
            uceDelFlag.Location = new System.Drawing.Point(359, 121);
            uceDelFlag.Name = "uceDelFlag";
            uceDelFlag.Size = new System.Drawing.Size(144, 20);
            uceDelFlag.TabIndex = 10;
            uceDelFlag.Text = "삭제";
            uceNewFlag.Location = new System.Drawing.Point(190, 120);
            uceNewFlag.Name = "uceNewFlag";
            uceNewFlag.Size = new System.Drawing.Size(144, 20);
            uceNewFlag.TabIndex = 9;
            uceNewFlag.Text = "신규";
            uceInqFlag.Location = new System.Drawing.Point(23, 120);
            uceInqFlag.Name = "uceInqFlag";
            uceInqFlag.Size = new System.Drawing.Size(144, 20);
            uceInqFlag.TabIndex = 8;
            uceInqFlag.Text = "조회";
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Left";
            sLabel2.Appearance = appearance32;
            sLabel2.DbField = null;
            sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel2.Location = new System.Drawing.Point(23, 63);
            sLabel2.Name = "sLabel2";
            sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel2.Size = new System.Drawing.Size(232, 23);
            sLabel2.TabIndex = 6;
            sLabel2.Text = "프로그램유형";
            appearance33.FontData.BoldAsString = "False";
            appearance33.FontData.UnderlineAsString = "False";
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextHAlignAsString = "Left";
            sLabel1.Appearance = appearance33;
            sLabel1.DbField = null;
            sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel1.Location = new System.Drawing.Point(23, 9);
            sLabel1.Name = "sLabel1";
            sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel1.Size = new System.Drawing.Size(562, 23);
            sLabel1.TabIndex = 3;
            sLabel1.Text = "프로그램";
            appearance34.FontData.BoldAsString = "False";
            appearance34.FontData.UnderlineAsString = "False";
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            lblUseFlag_H.Appearance = appearance34;
            lblUseFlag_H.DbField = null;
            lblUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUseFlag_H.Location = new System.Drawing.Point(724, 10);
            lblUseFlag_H.Name = "lblUseFlag_H";
            lblUseFlag_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUseFlag_H.Size = new System.Drawing.Size(145, 25);
            lblUseFlag_H.TabIndex = 21;
            lblUseFlag_H.Text = "사용여부";
            appearance35.FontData.BoldAsString = "False";
            appearance35.FontData.UnderlineAsString = "False";
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            lblProgramID_H.Appearance = appearance35;
            lblProgramID_H.DbField = null;
            lblProgramID_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblProgramID_H.Location = new System.Drawing.Point(110, 10);
            lblProgramID_H.Name = "lblProgramID_H";
            lblProgramID_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblProgramID_H.Size = new System.Drawing.Size(145, 25);
            lblProgramID_H.TabIndex = 2;
            lblProgramID_H.Text = "프로그램";
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance36.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grid1.DisplayLayout.Appearance = appearance36;
            grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance37.BackColor = System.Drawing.Color.Gray;
            grid1.DisplayLayout.CaptionAppearance = appearance37;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.InterBandSpacing = 2;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance38.BackColor = System.Drawing.Color.RoyalBlue;
            appearance38.FontData.BoldAsString = "True";
            appearance38.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance38;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance39.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            grid1.DisplayLayout.Override.DataErrorRowAppearance = appearance39;
            appearance40.BackColor = System.Drawing.Color.DimGray;
            appearance40.BackColor2 = System.Drawing.Color.Silver;
            appearance40.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance40.BorderColor = System.Drawing.Color.White;
            appearance40.FontData.BoldAsString = "True";
            appearance40.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.HeaderAppearance = appearance40;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            grid1.DisplayLayout.Override.RowEditTemplateUIType = Infragistics.Win.UltraWinGrid.RowEditTemplateUIType.None;
            appearance41.TextHAlignAsString = "Center";
            grid1.DisplayLayout.Override.RowSelectorAppearance = appearance41;
            appearance42.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance42.BackColor2 = System.Drawing.Color.Gray;
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance42;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.RowsAndCells;
            grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            grid1.Dock = System.Windows.Forms.DockStyle.Left;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(555, 660);
            grid1.TabIndex = 0;
            grid1.Text = "grid1";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            appearance43.FontData.BoldAsString = "False";
            appearance43.FontData.UnderlineAsString = "False";
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            sLabel6.Appearance = appearance43;
            sLabel6.DbField = null;
            sLabel6.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel6.Location = new System.Drawing.Point(478, 10);
            sLabel6.Name = "sLabel6";
            sLabel6.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel6.Size = new System.Drawing.Size(145, 25);
            sLabel6.TabIndex = 218;
            sLabel6.Text = "시스템구분";
            cboUseFlag_H.AutoSize = false;
            cboUseFlag_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboUseFlag_H.ComboDataType = WIZ.Control.ComboDataType.All;
            cboUseFlag_H.DbConfig = null;
            cboUseFlag_H.DefaultValue = "";
            appearance44.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboUseFlag_H.DisplayLayout.Appearance = appearance44;
            cboUseFlag_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboUseFlag_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboUseFlag_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance45.BackColor = System.Drawing.Color.Gray;
            cboUseFlag_H.DisplayLayout.CaptionAppearance = appearance45;
            cboUseFlag_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboUseFlag_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboUseFlag_H.DisplayLayout.InterBandSpacing = 2;
            cboUseFlag_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance46.BackColor = System.Drawing.Color.RoyalBlue;
            appearance46.FontData.BoldAsString = "True";
            appearance46.ForeColor = System.Drawing.Color.White;
            cboUseFlag_H.DisplayLayout.Override.ActiveRowAppearance = appearance46;
            appearance47.FontData.BoldAsString = "True";
            cboUseFlag_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance47;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance48.BackColor = System.Drawing.Color.DimGray;
            appearance48.BackColor2 = System.Drawing.Color.Silver;
            appearance48.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance48.BorderColor = System.Drawing.Color.White;
            appearance48.FontData.BoldAsString = "True";
            appearance48.ForeColor = System.Drawing.Color.White;
            cboUseFlag_H.DisplayLayout.Override.HeaderAppearance = appearance48;
            cboUseFlag_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance49.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance49.BackColor2 = System.Drawing.Color.Gray;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance49;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboUseFlag_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance50.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance50.FontData.BoldAsString = "True";
            cboUseFlag_H.DisplayLayout.Override.SelectedRowAppearance = appearance50;
            cboUseFlag_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboUseFlag_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboUseFlag_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboUseFlag_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboUseFlag_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboUseFlag_H.Location = new System.Drawing.Point(724, 35);
            cboUseFlag_H.MajorCode = "USEFLAG";
            cboUseFlag_H.Name = "cboUseFlag_H";
            cboUseFlag_H.SelectedValue = "";
            cboUseFlag_H.ShowDefaultValue = true;
            cboUseFlag_H.Size = new System.Drawing.Size(150, 26);
            cboUseFlag_H.TabIndex = 6;
            cboSystemType_H.AutoSize = false;
            cboSystemType_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboSystemType_H.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cboSystemType_H.DbConfig = null;
            cboSystemType_H.DefaultValue = "";
            appearance51.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboSystemType_H.DisplayLayout.Appearance = appearance51;
            cboSystemType_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboSystemType_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboSystemType_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance52.BackColor = System.Drawing.Color.Gray;
            cboSystemType_H.DisplayLayout.CaptionAppearance = appearance52;
            cboSystemType_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboSystemType_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboSystemType_H.DisplayLayout.InterBandSpacing = 2;
            cboSystemType_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance53.BackColor = System.Drawing.Color.RoyalBlue;
            appearance53.FontData.BoldAsString = "True";
            appearance53.ForeColor = System.Drawing.Color.White;
            cboSystemType_H.DisplayLayout.Override.ActiveRowAppearance = appearance53;
            appearance54.FontData.BoldAsString = "True";
            cboSystemType_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance54;
            cboSystemType_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemType_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemType_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemType_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance55.BackColor = System.Drawing.Color.DimGray;
            appearance55.BackColor2 = System.Drawing.Color.Silver;
            appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance55.BorderColor = System.Drawing.Color.White;
            appearance55.FontData.BoldAsString = "True";
            appearance55.ForeColor = System.Drawing.Color.White;
            cboSystemType_H.DisplayLayout.Override.HeaderAppearance = appearance55;
            cboSystemType_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance56.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance56.BackColor2 = System.Drawing.Color.Gray;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance56;
            cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboSystemType_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboSystemType_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboSystemType_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance57.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance57.FontData.BoldAsString = "True";
            cboSystemType_H.DisplayLayout.Override.SelectedRowAppearance = appearance57;
            cboSystemType_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboSystemType_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboSystemType_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboSystemType_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboSystemType_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboSystemType_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboSystemType_H.Location = new System.Drawing.Point(478, 35);
            cboSystemType_H.MajorCode = "SYSTEMID";
            cboSystemType_H.Name = "cboSystemType_H";
            cboSystemType_H.SelectedValue = null;
            cboSystemType_H.ShowDefaultValue = false;
            cboSystemType_H.Size = new System.Drawing.Size(200, 26);
            cboSystemType_H.TabIndex = 5;
            cboSystemType_H.ValueChanged += new System.EventHandler(cboSystemType_H_ValueChanged);
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            txtProgramName.Appearance = appearance58;
            txtProgramName.AutoSize = false;
            txtProgramName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramName.Location = new System.Drawing.Point(232, 35);
            txtProgramName.Name = "txtProgramName";
            txtProgramName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramName.Size = new System.Drawing.Size(200, 27);
            txtProgramName.TabIndex = 239;
            appearance59.FontData.BoldAsString = "False";
            appearance59.FontData.UnderlineAsString = "False";
            appearance59.ForeColor = System.Drawing.Color.Black;
            txtProgramID_H.Appearance = appearance59;
            txtProgramID_H.AutoSize = false;
            txtProgramID_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtProgramID_H.Location = new System.Drawing.Point(110, 35);
            txtProgramID_H.Name = "txtProgramID_H";
            txtProgramID_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtProgramID_H.Size = new System.Drawing.Size(120, 27);
            txtProgramID_H.TabIndex = 240;
            base.ClientSize = new System.Drawing.Size(1317, 742);
            base.Name = "SY0010";
            base.Load += new System.EventHandler(SY0010_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox1).EndInit();
            ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtRemark).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContact).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDeveloper).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtParameter).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFileID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNameSpace).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTopicID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramNM).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelIMFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboMenuType).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceSumFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceExcelFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucePrnFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceSaveFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceDelFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceNewFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)uceInqFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboSystemType_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProgramID_H).EndInit();
            ResumeLayout(false);
        }
    }
}
