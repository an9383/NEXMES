#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0100Y
//   Form Name    : 품목 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2015-07-27
//   Made By      : WIZCORE
//   Description  : 기준정보 ( 품목 마스터 ) 정보 관리 폼 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0100Y : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 생성자 ]
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp4 = new DataTable(); // return DataTable 공통


        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int INSERTSAVE = 0;

        private bool formLoad = false;
        byte[] bImage = null;    // 이미지
        string ImgNM;

        int check = 0;
        #endregion

        #region [ 선언자 ]
        public BM0100Y()
        {
            InitializeComponent();
            this.plantCode = CModule.GetAppSetting("Site", "10");
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtASGNCode, txtCustName, "TBM0301", new object[] { cboPlantCode_H, "V", "", "false" });
            btbManager.PopUpAdd(txtLocation, txtBoxQty, "TBM0900Y", new object[] { cboPlantCode_H, txtWhCode });
            btbManager.PopUpAdd(txtBoxSpec, txtBoxQty, "TBM9400Y", new object[] { cboPlantCode_H, "Y" });

        }

        #endregion

        #region [ Form Load ]
        private void BM0100Y_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "MAJORITEMTYPE","품목대분류",          true, GridColDataType_emu.VarChar,  80,  80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 160, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT", "기본단위", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCOUNT", "등록검사항목수", true, GridColDataType_emu.Double, 120, 120, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXSTOCK", "적정재고", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOCCODE", "위치", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITWGT", "단위중량", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", true, GridColDataType_emu.Integer, 90, 90, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BOXSPEC", "용기코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BOXQTY", "용기수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);


            _GridUtil.InitColumnUltraGrid(grid1, "CHANGEFLAG", "주요품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHANGETIME", "교체주기", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MINORDERQTY", "최소 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "고정 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXORDERQTY", "최대 발주수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNCODE", "구매처", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNNAME", "구매처 담당자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNSPHONE", "구매처 담당 전화번호", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNSEMAIL", "구매처 담당 E-MAIL", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNFAXNO", "구매처 담당 FAX NO", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASGNADDRESS", "구매처 주소", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);





            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["MAJORITEMTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ImportInspection", "검사코드", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ImportInspectionName", "검사항목명", true, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ValueType", "측정값 구분", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SpecType", "SPEC 적용기준", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "BaseValue", "기준값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Uppervalue", "상한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LowerValue", "하한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "등록일시", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Editor", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EditDate", "수정일시", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);


            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ItemType"); //품목구분
            WIZ.Common.FillComboboxMaster(this.cboItemType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboItemType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MATTYPE"); //원자재구분
            WIZ.Common.FillComboboxMaster(this.cboMatType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            ////공정(OPCode)
            //rtnDtTemp = _Common.GET_TBM0400_CODE("");
            //WIZ.Common.FillComboboxMaster(this.cboOpCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPTYPE"); //검사구분
            WIZ.Common.FillComboboxMaster(this.cboInspFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("IMPORTINSPECTION"); //검사구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ImportInspection", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //측정값구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ValueType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE"); //SPEC 적용기준
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "SpecType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UNITCODE"); //단위
            WIZ.Common.FillComboboxMaster(this.txtBaseUnit, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("OPHEADER"); //품목대분류
            //WIZ.Common.FillComboboxMaster(this.txtMajorItemCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAJORITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE"); //창고
            WIZ.Common.FillComboboxMaster(this.txtWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("CARTYPE"); //차종
            WIZ.Common.FillComboboxMaster(this.cboCarType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CARTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE"); //위치
                                                                   //  WIZ.Common.FillComboboxMaster(this.txtWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

            cboPlantCode_H.Value = plantCode;
            ControlSetting("VIEW");

            formLoad = true;
        }

        #endregion

        #region [ TOOL BAR AREA ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid1);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sItemType = Convert.ToString(this.cboItemType_H.Value);
                //string sOpCode    = Convert.ToString(this.cboOpCode_H.Value);
                string sItemCode = txtItemCode_H.Text;
                string sItemName = txtItemName_H.Text;
                string sUseFlag = Convert.ToString(this.cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0100Y_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ItemType", sItemType, DbType.String, ParameterDirection.Input)
                                                             //, helper.CreateParameter("OpCode",    sOpCode,    DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                    check = 0;
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            int iRow = 0;

            try
            {
                base.DoNew();

                if (this.grid2.IsActivate)
                {
                    if (this.grid1.Rows.Count == 0)
                    {
                        WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm("조회 할 데이터가 없습니다.");
                        checkform.ShowDialog();
                        return;
                    }

                    this.grid2.InsertRow();

                    grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.Disabled;
                    grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.Disabled;
                    grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.Disabled;
                    grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.Disabled;

                    return;
                }

                TabControl1.SelectedTab = TabControl1.Tabs[0];


                INSERTSAVE = 1;
                ControlSetting("NEW");
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            // base.DoDelete();
            //   this.grid1.DeleteRow();
            if (this.grid2.IsActivate)
            {
                this.grid2.DeleteRow();
                return;
            }

            if (INSERTSAVE == 2)
            {
                //수정 모드에서..delete를 눌렀을 경우..delete모드로 변경
                INSERTSAVE = 3;
                DoSave();
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            Grid1ToolAct2();
            Grid1ToolAct();

        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            if (INSERTSAVE == 1)
            {
                //신규
                INSERT_SAVE();
            }
            else if (INSERTSAVE == 2)
            {
                //수정
                UPDATE_SAVE();

            }
            else if (INSERTSAVE == 3)
            {
                DELETE_SAVE();
            }
        }

        private void Grid1ToolAct2()
        {
            grid2.UpdateData();

            DataTable dt = grid2.chkChange();

            if (dt == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                string sPlantCode = string.Empty;
                string sItemCode = string.Empty;


                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["ImportInspection"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "검사 코드는 필수 입력 항목입니다.");
                            continue;
                        }
                    }

                    sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0100Y_D2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["ImportInspection"]), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM0100Y_I2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["ImportInspection"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["ImportInspectionName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("VALUETYPE", Convert.ToString(drRow["ValueType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SPECTYPE", Convert.ToString(drRow["SpecType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STDVALUE", Convert.ToString(drRow["BaseValue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USLVALUE", Convert.ToString(drRow["Uppervalue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LSLVALUE", Convert.ToString(drRow["LowerValue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   //, helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                   );
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0100Y_U2", CommandType.StoredProcedure, false, true
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["ImportInspection"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPNAME", Convert.ToString(drRow["ImportInspectionName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("VALUETYPE", Convert.ToString(drRow["ValueType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SPECTYPE", Convert.ToString(drRow["SpecType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STDVALUE", Convert.ToString(drRow["BaseValue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USLVALUE", Convert.ToString(drRow["Uppervalue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LSLVALUE", Convert.ToString(drRow["LowerValue"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                    }
                    grid2.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid2.SetAcceptChanges();
                helper.Commit();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();

                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ]
        /// <summary>
        /// 공정 조회
        /// </summary>
        //private void GetOPCode()
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        string sPlantCode = Convert.ToString(cboPlantCode_H.Value);

        //        StringBuilder command = new StringBuilder();

        //        command.AppendLine("SELECT OPCODE                             AS CODE_ID, ";
        //        command.AppendLine("       '['+ OPCODE +']' + OPNAME          AS CODE_NAME";
        //        command.AppendLine("  FROM TBM0400                                        ";
        //        command.AppendLine(" WHERE PLANTCODE LIKE '" + sPlantCode + "' + '%'      ";
        //        command.AppendLine("   AND USEFLAG = 'Y'                                  ";
        //        command.AppendLine(" ORDER BY OPCODE";

        //        DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
        //        WIZ.Common.FillComboboxMaster(cboOpCode_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

        //        if (formLoad == false)
        //        {
        //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OPCode", dttemp, "CODE_ID", "CODE_NAME");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        /// <summary>
        /// 품목정보 입력(생성)
        /// </summary>
        private void INSERT_SAVE()
        {
            DBHelper helper = new DBHelper(false);

            if (Convert.ToString(cboPlantCode.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("사업장을 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            //if (Convert.ToString(txtMajorItemCode.Value) == string.Empty)
            //{
            //    this.ShowDialog("BM00008", WIZ.Forms.DialogForm.DialogType.OK); //품목 대분류를 선택하세요.
            //    return;
            //}

            //if (txtProdItemCode.Text == string.Empty)
            //{
            //    this.ShowDialog("BM00009", WIZ.Forms.DialogForm.DialogType.OK); //생산품목을 입력하세요.
            //    return;
            //}

            if (txtItemCode.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목이 생성되지 않았습니다.\r\n생산 품목 입력 후 엔터를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtItemName.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목명을 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (Convert.ToString(cboItemType.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목 구분을 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtBaseUnit.Value.ToString() == string.Empty)
            {
                this.ShowDialog(Common.getLangText("단위는 필수 입력사항입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (cboInspFlag.Value.ToString() == string.Empty)
            {
                this.ShowDialog(Common.getLangText("검사구분은 필수 입력사항입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (cboUseFlag.Value.ToString() == string.Empty)
            {
                this.ShowDialog(Common.getLangText("사용여부는 필수 입력사항입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }


            if (Convert.ToString(cboItemType.Value) == "4" && cboMatType.Value.ToString() == string.Empty) // 원자재일경우
            {
                this.ShowDialog(Common.getLangText("원자재구분은 필수 입력사항입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //단위중량은 필수 입력사항입니다.
                return;
            }

            if (Convert.ToString(cboItemType.Value) == "4" && txtUnitWGT.Text == string.Empty)
            {
                if (Convert.ToString(cboMatType.Value) == "C")
                {
                    txtItemCode.Text = "C" + txtItemCode.Text;
                }
                else if (Convert.ToString(cboMatType.Value) == "S")
                {
                    txtItemCode.Text = "S" + txtItemCode.Text;
                }
            }

            if (this.ShowDialog(Common.getLangText("품목 [" + txtItemCode.Text + "] 를 등록하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0100Y_I1"
                                        , CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", DBHelper.nvlString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMNAME", DBHelper.nvlString(txtItemName.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMTYPE", DBHelper.nvlString(cboItemType.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WHCODE", DBHelper.nvlString(txtWhCode.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("LOCCODE", DBHelper.nvlString(txtLocation.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAXSTOCK", DBHelper.nvlString(txtMaxStock.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("SAFESTOCK", DBHelper.nvlString(txtSafeStock.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("BASEUNIT", DBHelper.nvlString(txtBaseUnit.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UNITCOST", DBHelper.nvlString(txtUnitCost.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UNITWGT", DBHelper.nvlString(txtUnitWGT.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("INSPFLAG", DBHelper.nvlString(cboInspFlag.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMSPEC", DBHelper.nvlString(txtItemSpec.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MATERIALGRADE", DBHelper.nvlString(txtMaterialGrade.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CHANGEFLAG", "", DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CHANGETIME", DBHelper.nvlString(txtChangeTime.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MINORDERQTY", DBHelper.nvlString(txtMinOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ORDERQTY", DBHelper.nvlString(txtOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAXORDERQTY", DBHelper.nvlString(txtMaxOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAKECOMPANY", DBHelper.nvlString(txtMakeCompany.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNCODE", DBHelper.nvlString(txtASGNCode.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNNAME", DBHelper.nvlString(txtASGNName.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNSPHONE", DBHelper.nvlString(txtASGNSPhone.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNSEMAIL", DBHelper.nvlString(txtASGNSEmail.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNFAXNO", DBHelper.nvlString(txtASGNFaxNo.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNADDRESS", DBHelper.nvlString(txtASGNAddress.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("USEFLAG", DBHelper.nvlString(cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("REMARK", DBHelper.nvlString(txtRemark.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("BOXSPEC", DBHelper.nvlString(txtBoxSpec.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CARTYPE", DBHelper.nvlString(cboCarType.Value), DbType.String, ParameterDirection.Input)
                                );

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    INSERTSAVE = 0;
                    check = 0;
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ThrowError(ex);
                MessageBox.Show(Convert.ToString(ex));
                INSERTSAVE = 1;
                return;
            }
            finally
            {
                helper.Close();
            }

        }

        /// <summary>
        /// 품목정보 수정
        /// </summary>
        private void UPDATE_SAVE()
        {
            DBHelper helper = new DBHelper(false);

            if (Convert.ToString(cboPlantCode.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("사업장을 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            //if (Convert.ToString(txtMajorItemCode.Value) == string.Empty)
            //{
            //    this.ShowDialog("BM00008", WIZ.Forms.DialogForm.DialogType.OK); //품목 대분류를 선택하세요.
            //    return;
            //}

            //if (txtProdItemCode.Text == string.Empty)
            //{
            //    this.ShowDialog("BM00009", WIZ.Forms.DialogForm.DialogType.OK); //생산품목을 입력하세요.
            //    return;
            //}

            if (txtItemCode.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목코드를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtItemName.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목명을 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (Convert.ToString(cboItemType.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목 구분을 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //품목 구분을 선택하세요.
                return;
            }

            if (Convert.ToString(cboItemType.Value) == "ROH" && txtUnitWGT.Text == string.Empty) // 원자재일경우
            {
                this.ShowDialog(Common.getLangText("단위중량은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("품목 [" + txtItemCode.Text + "] 를 수정하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0100Y_U1"
                                        , CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", DBHelper.nvlString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMNAME", DBHelper.nvlString(txtItemName.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMTYPE", DBHelper.nvlString(cboItemType.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WHCODE", DBHelper.nvlString(txtWhCode.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("LOCCODE", DBHelper.nvlString(txtLocation.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAXSTOCK", DBHelper.nvlString(txtMaxStock.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("SAFESTOCK", DBHelper.nvlString(txtSafeStock.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("BASEUNIT", DBHelper.nvlString(txtBaseUnit.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UNITCOST", DBHelper.nvlString(txtUnitCost.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UNITWGT", DBHelper.nvlString(txtUnitWGT.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("INSPFLAG", DBHelper.nvlString(cboInspFlag.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMSPEC", DBHelper.nvlString(txtItemSpec.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MATERIALGRADE", DBHelper.nvlString(txtMaterialGrade.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CHANGEFLAG", "", DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CHANGETIME", DBHelper.nvlString(txtChangeTime.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MINORDERQTY", DBHelper.nvlString(txtMinOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ORDERQTY", DBHelper.nvlString(txtOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAXORDERQTY", DBHelper.nvlString(txtMaxOrderQty.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAKECOMPANY", DBHelper.nvlString(txtMakeCompany.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNCODE", DBHelper.nvlString(txtASGNCode.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNNAME", DBHelper.nvlString(txtASGNName.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNSPHONE", DBHelper.nvlString(txtASGNSPhone.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNSEMAIL", DBHelper.nvlString(txtASGNSEmail.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNFAXNO", DBHelper.nvlString(txtASGNFaxNo.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ASGNADDRESS", DBHelper.nvlString(txtASGNAddress.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("USEFLAG", DBHelper.nvlString(cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("REMARK", DBHelper.nvlString(txtRemark.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("BOXSPEC", DBHelper.nvlString(txtBoxSpec.Text), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CARTYPE", DBHelper.nvlString(cboCarType.Value), DbType.String, ParameterDirection.Input)

                                             );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    INSERTSAVE = 0;
                    check = 0;
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ThrowError(ex);
                MessageBox.Show(Convert.ToString(ex));
                INSERTSAVE = 1;
                return;
            }
            finally
            {
                helper.Close();
            }

        }

        /// <summary>
        /// 품목정보 삭제
        /// </summary>
        private void DELETE_SAVE()
        {
            DBHelper helper = new DBHelper(false);

            if (txtItemCode.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("품목이 생성되지 않았습니다.\r\n생산 품목 입력 후 엔터를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("품목 [" + txtItemCode.Text + "] 를 삭제하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0100Y_D1"
                                        , CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", DBHelper.nvlString(txtItemCode.Text), DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    INSERTSAVE = 0;
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ThrowError(ex);
                MessageBox.Show(Convert.ToString(ex));
                INSERTSAVE = 2;
                return;
            }
            finally
            {
                helper.Close();
            }

        }

        /// <summary>
        /// UltraComboBox Setting
        /// </summary>
        private void FillUltraCombobox(UltraComboEditor comboBox, object DataSource, string ValueField, string DisplayField, int SelectIndex = 0)
        {
            comboBox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            comboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;

            List<KeyValuePair<string, string>> comboBoxData = new List<KeyValuePair<string, string>>();

            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow drRow1 in (DataSource as DataSet).Tables[0].Rows)
                    comboBoxData.Add(new KeyValuePair<string, string>(drRow1[ValueField].ToString(), drRow1[DisplayField].ToString()));
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow drRow2 in (DataSource as DataTable).Rows)
                    comboBoxData.Add(new KeyValuePair<string, string>(drRow2[ValueField].ToString(), drRow2[DisplayField].ToString()));
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> dValue in (DataSource as Dictionary<string, string>))
                    comboBoxData.Add(dValue);
            }

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = comboBoxData;

            comboBox.MouseWheel += new MouseEventHandler(Common.comboBox_MouseWheel);

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = SelectIndex;
        }

        /// <summary>
        /// 신규, 수정, 조회에 따른 컨트롤 상태 변경
        /// </summary>
        /// <param name="State"></param>
        private void ControlSetting(string State)
        {
            if (State == "NEW")
            {
                #region [ 신규 ]
                this.cboPlantCode.Enabled = true;
                txtMajorItemCode.Enabled = false;
                this.txtItemCode.Enabled = true;
                txtProdItemCode.Enabled = true;
                this.txtItemName.Enabled = true;
                this.cboItemType.Enabled = true;
                this.cboInspFlag.Enabled = true;
                this.txtInspCnt.Enabled = true;
                this.txtMaxStock.Enabled = true;
                this.txtSafeStock.Enabled = true;
                this.txtWhCode.Enabled = true;
                this.txtLocation.Enabled = true;
                this.txtBaseUnit.Enabled = true;
                this.txtUnitWGT.Enabled = true;
                this.cboUseFlag.Enabled = true;
                this.txtChangeTime.Enabled = true;
                this.txtUnitCost.Enabled = true;
                this.txtASGNCode.Enabled = true;
                this.txtCustName.Enabled = true;
                this.txtMakeCompany.Enabled = true;
                this.txtRemark.Enabled = true;
                this.grid2.Enabled = true;
                this.txtMinOrderQty.Enabled = true;
                this.txtMaxOrderQty.Enabled = true;
                this.txtOrderQty.Enabled = true;
                this.txtASGNName.Enabled = true;
                this.txtASGNSPhone.Enabled = true;
                this.txtASGNSEmail.Enabled = true;
                this.txtASGNFaxNo.Enabled = true;
                this.txtASGNAddress.Enabled = true;
                this.txtItemSpec.Enabled = true;
                this.txtMaterialGrade.Enabled = true;

                this.txtBoxSpec.Enabled = true;
                this.txtBoxQty.Enabled = true;

                this.cboCarType.Enabled = true;

                this.cboPlantCode.SelectedIndex = 0;
                cboPlantCode.Value = plantCode; //15-10-28 추가시 로그인 된 공장 코드로 설정 최재형 

                this.cboItemType.SelectedIndex = 0;
                this.txtMajorItemCode.SelectedIndex = 0;                //품목대분류
                this.txtProdItemCode.Text = string.Empty;
                this.txtItemCode.Text = string.Empty;     //픔목코드
                this.txtItemName.Text = string.Empty;     //품목명
                this.cboInspFlag.SelectedIndex = 0;                //검사구분
                this.txtInspCnt.Text = string.Empty;     //등록검사항목수
                this.txtMaxStock.Text = string.Empty;     //적정재고
                this.txtSafeStock.Text = string.Empty;     //안전재고
                this.txtWhCode.SelectedIndex = 0;                //창고
                this.txtLocation.Text = string.Empty;     //location
                this.txtBaseUnit.Text = string.Empty;     //단위
                this.txtUnitWGT.Text = string.Empty;     // 단충
                this.cboUseFlag.SelectedIndex = 1;                //사용여부
                this.txtChangeTime.Text = string.Empty;     //교체주기
                this.txtUnitCost.Text = string.Empty;     //단가
                this.txtASGNCode.Text = string.Empty;     //구매처
                this.txtASGNName.Text = string.Empty;
                this.txtMakeCompany.Text = string.Empty;     //제조사
                this.txtRemark.Text = string.Empty;     //비고
                this.txtItemSpec.Text = string.Empty;
                this.txtMaterialGrade.Text = string.Empty;

                this.txtBoxSpec.Text = string.Empty;     //용기코드
                this.txtBoxQty.Text = string.Empty;     //용기수량

                this.cboCarType.SelectedIndex = 0;                //차종

                //구매정보
                this.txtMinOrderQty.Text = string.Empty;            //최소발주수량
                this.txtMaxOrderQty.Text = string.Empty;            //최대발주수량
                this.txtOrderQty.Text = string.Empty;            //고정발주수량
                this.txtASGNName.Text = string.Empty;            //구매처담당자
                this.txtASGNSPhone.Text = string.Empty;            //구매처 담당전화번호
                this.txtASGNSEmail.Text = string.Empty;            //구매처 담당 email
                this.txtASGNFaxNo.Text = string.Empty;            //구매처 팩스 번호
                this.txtASGNAddress.Text = string.Empty;            //구매처 주소
                this.txtItemCode.BackColor = System.Drawing.Color.White;

                sLabel4.Appearance.ForeColor = Color.Blue;
                sLabel5.Appearance.ForeColor = Color.Blue;
                sLabel6.Appearance.ForeColor = Color.Blue;
                sLabel16.Appearance.ForeColor = Color.Blue;
                sLabel4.Appearance.ForeColor = Color.Blue;
                sLabel3.Appearance.ForeColor = Color.Blue;
                sLabel7.Appearance.ForeColor = Color.Blue;

                #endregion
            }
            else if (State == "EDIT")
            {
                #region [ 수정 ]
                this.cboPlantCode.Enabled = false;
                this.txtMajorItemCode.Enabled = false;
                this.txtProdItemCode.Enabled = false;
                this.txtItemCode.Enabled = false;
                this.txtItemName.Enabled = true;
                this.cboItemType.Enabled = true;
                this.cboInspFlag.Enabled = true;
                this.txtInspCnt.Enabled = true;
                this.txtMaxStock.Enabled = true;
                this.txtSafeStock.Enabled = true;
                this.txtWhCode.Enabled = true;
                this.txtLocation.Enabled = true;
                this.txtBaseUnit.Enabled = true;
                this.txtUnitWGT.Enabled = true;
                this.cboUseFlag.Enabled = true;
                this.txtChangeTime.Enabled = true;
                this.txtUnitCost.Enabled = true;
                this.txtASGNCode.Enabled = true;
                this.txtCustName.Enabled = true;
                this.txtMakeCompany.Enabled = true;
                this.txtRemark.Enabled = true;
                this.grid2.Enabled = true;
                this.txtMinOrderQty.Enabled = true;
                this.txtMaxOrderQty.Enabled = true;
                this.txtOrderQty.Enabled = true;
                this.txtASGNName.Enabled = true;
                this.txtASGNSPhone.Enabled = true;
                this.txtASGNSEmail.Enabled = true;
                this.txtASGNFaxNo.Enabled = true;
                this.txtASGNAddress.Enabled = true;
                this.txtItemSpec.Enabled = true;
                this.txtMaterialGrade.Enabled = true;

                this.txtBoxSpec.Enabled = true;
                this.txtBoxQty.Enabled = true;

                this.cboCarType.Enabled = true;

                sLabel4.Appearance.ForeColor = Color.Blue;
                sLabel5.Appearance.ForeColor = Color.Blue;
                sLabel6.Appearance.ForeColor = Color.Blue;
                sLabel16.Appearance.ForeColor = Color.Blue;
                sLabel4.Appearance.ForeColor = Color.Blue;
                sLabel3.Appearance.ForeColor = Color.Blue;
                sLabel7.Appearance.ForeColor = Color.Blue;

                #endregion
            }
            else if (State == "VIEW")
            {
                #region [ 조회 ]
                cboPlantCode.Enabled = false;
                txtMajorItemCode.Enabled = false;
                txtProdItemCode.Enabled = false;
                txtItemCode.Enabled = false;
                txtItemName.Enabled = false;
                cboItemType.Enabled = false;
                cboMatType.Enabled = false;
                cboInspFlag.Enabled = false;
                txtInspCnt.Enabled = false;
                txtMaxStock.Enabled = false;
                txtSafeStock.Enabled = false;
                txtWhCode.Enabled = false;
                txtLocation.Enabled = false;
                txtBaseUnit.Enabled = false;
                txtUnitWGT.Enabled = false;
                cboUseFlag.Enabled = false;
                txtChangeTime.Enabled = false;
                txtUnitCost.Enabled = false;
                txtASGNCode.Enabled = false;
                txtCustName.Enabled = false;
                txtMakeCompany.Enabled = false;
                txtRemark.Enabled = false;
                grid2.Enabled = false;
                txtMinOrderQty.Enabled = false;
                txtMaxOrderQty.Enabled = false;
                txtOrderQty.Enabled = false;
                txtASGNName.Enabled = false;
                txtASGNSPhone.Enabled = false;
                txtASGNSEmail.Enabled = false;
                txtASGNFaxNo.Enabled = false;
                txtASGNAddress.Enabled = false;
                txtItemSpec.Enabled = false;
                txtMaterialGrade.Enabled = false;

                txtBoxSpec.Enabled = false;
                txtBoxQty.Enabled = false;
                cboCarType.Enabled = false;

                #endregion
            }
        }

        /// <summary>
        /// 숫자입력
        /// </summary>
        /// <param name="_RecVal"></param>
        /// <returns></returns>
        public static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region [ Event Area ]
        /// <summary>
        /// 품목 구분에 따른 검사구분 및 창고코드 셋팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboItemType_ValueChanged(object sender, EventArgs e)
        {
            //품목 등록(생성)
            if (INSERTSAVE == 1)
            {
                //품목 구분이 원자재 이면,
                if (DBHelper.nvlString(this.cboItemType.Value) == "4")
                {
                    this.cboMatType.Enabled = true;
                    this.lblMatType.Appearance.BackColor = Color.SkyBlue;
                }
                //반제품일 경우
                else if (DBHelper.nvlString(this.cboItemType.Value) == "HALB")
                {
                    this.cboInspFlag.Value = "U";
                    this.txtWhCode.Value = "WH002";
                    sLabel14.Appearance.ForeColor = Color.Black;
                }
                //제품일 경우
                else if (DBHelper.nvlString(this.cboItemType.Value) == "FERT")
                {
                    this.cboInspFlag.Value = "I";
                    this.txtWhCode.Value = "WH003";
                    sLabel14.Appearance.ForeColor = Color.Black;
                }
                //부자재, 구매품
                else if (DBHelper.nvlString(this.cboItemType.Value) == "ROH2")
                {
                    this.cboInspFlag.Value = "I";
                    this.txtWhCode.Value = "WH001";
                    sLabel14.Appearance.ForeColor = Color.Black;
                }
                else if (DBHelper.nvlString(this.cboItemType.Value) == "ROH4")
                {
                    this.cboInspFlag.Value = "I";
                    this.txtWhCode.Value = "WH001";
                    sLabel14.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    cboInspFlag.SelectedIndex = 0;
                    txtWhCode.SelectedIndex = 0;
                    sLabel14.Appearance.ForeColor = Color.Black;
                    this.cboMatType.Enabled = false;
                    this.lblMatType.Appearance.BackColor = Color.Transparent;
                }
            }
        }

        private void cboItemType_H_TextChanged(object sender, EventArgs e)
        {
            ////부자재, 구매품
            //if (DBHelper.nvlString(this.cboItemType_H.Value) == "ROH2" || DBHelper.nvlString(this.cboItemType_H.Value) == "ROH4")
            //{
            //    this.cboOpCode_H.Enabled = false;
            //}
            //else
            //    this.cboOpCode_H.Enabled = true;

        }

        /// <summary>
        /// 공장코드 변경에 따른 공정코드 셋팅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlantCode_H_ValueChanged(object sender, EventArgs e)
        {
            //GetOPCode();
        }

        /// <summary>
        /// grid1에서 선택된 데이터 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                ControlSetting("VIEW");

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemType = Convert.ToString(grid1.ActiveRow.Cells["ITEMTYPE"].Value);
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                //string sMajorItemType = Convert.ToString(grid1.ActiveRow.Cells["MAJORITEMTYPE"].Value);
                string sItemName = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                string sBaseUnit = Convert.ToString(grid1.ActiveRow.Cells["BASEUNIT"].Value);
                string sUnitWGT = Convert.ToString(grid1.ActiveRow.Cells["UNITWGT"].Value);
                string sUnitCost = Convert.ToString(grid1.ActiveRow.Cells["UNITCOST"].Value);
                string sMakeCompany = Convert.ToString(grid1.ActiveRow.Cells["MAKECOMPANY"].Value);
                string sWhCode = Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value);
                string sLocCode = Convert.ToString(grid1.ActiveRow.Cells["LOCCODE"].Value);
                string sInspFlag = Convert.ToString(grid1.ActiveRow.Cells["INSPFLAG"].Value);
                string sInspCount = Convert.ToString(grid1.ActiveRow.Cells["INSPCOUNT"].Value);
                string sMaxStock = Convert.ToString(grid1.ActiveRow.Cells["MAXSTOCK"].Value);
                string sSafeStock = Convert.ToString(grid1.ActiveRow.Cells["SAFESTOCK"].Value);
                string sChangFlag = Convert.ToString(grid1.ActiveRow.Cells["CHANGEFLAG"].Value);
                string sChangTime = Convert.ToString(grid1.ActiveRow.Cells["CHANGETIME"].Value);
                string sMinOrderQty = Convert.ToString(grid1.ActiveRow.Cells["MINORDERQTY"].Value);
                string sOrderQty = Convert.ToString(grid1.ActiveRow.Cells["ORDERQTY"].Value);
                string sMaxOrderQty = Convert.ToString(grid1.ActiveRow.Cells["MAXORDERQTY"].Value);
                string sAsgnCode = Convert.ToString(grid1.ActiveRow.Cells["ASGNCODE"].Value);
                string sAsgnName = Convert.ToString(grid1.ActiveRow.Cells["ASGNNAME"].Value);
                string sAsgnPhone = Convert.ToString(grid1.ActiveRow.Cells["ASGNSPHONE"].Value);
                string sAsgnMail = Convert.ToString(grid1.ActiveRow.Cells["ASGNSEMAIL"].Value);
                string sAsgnFaxNo = Convert.ToString(grid1.ActiveRow.Cells["ASGNFAXNO"].Value);
                string sAsgnAddress = Convert.ToString(grid1.ActiveRow.Cells["ASGNADDRESS"].Value);
                string sUseFlag = Convert.ToString(grid1.ActiveRow.Cells["USEFLAG"].Value);
                string sRemark = Convert.ToString(grid1.ActiveRow.Cells["REMARK"].Value);

                string sBoxSpec = Convert.ToString(grid1.ActiveRow.Cells["BOXSPEC"].Value);
                string sBoxQty = Convert.ToString(grid1.ActiveRow.Cells["BOXQTY"].Value);

                string sCarType = Convert.ToString(grid1.ActiveRow.Cells["CARTYPE"].Value);

                //16-01-07 규격 재질 추가 최재형
                string sItemSpec = Convert.ToString(grid1.ActiveRow.Cells["ITEMSPEC"].Value);
                string sMATERIALGRADE = Convert.ToString(grid1.ActiveRow.Cells["MATERIALGRADE"].Value);

                //TAP 1(품목기준정보)
                cboPlantCode.Value = sPlantCode;
                //txtMajorItemCode.Value = sMajorItemType;
                txtProdItemCode.Text = sItemCode.Substring(0, sItemCode.Length - 1);
                txtItemCode.Text = sItemCode;
                txtItemName.Text = sItemName;
                cboItemType.Value = sItemType;
                cboInspFlag.Value = sInspFlag;
                txtInspCnt.Text = sInspCount;
                txtMaxStock.Text = sMaxStock;
                txtSafeStock.Text = sSafeStock;
                txtWhCode.Value = sWhCode;
                txtLocation.Text = sLocCode;
                txtBaseUnit.Value = sBaseUnit;
                txtUnitWGT.Text = sUnitWGT;
                cboUseFlag.Value = sUseFlag;
                txtChangeTime.Text = sChangTime;
                txtUnitCost.Text = sUnitCost;
                txtASGNCode.Text = sAsgnCode;
                txtMakeCompany.Text = sMakeCompany;
                txtRemark.Text = sRemark;
                txtBoxSpec.Text = sBoxSpec;
                txtBoxQty.Text = sBoxQty;
                txtItemSpec.Text = sItemSpec;
                txtMaterialGrade.Text = sMATERIALGRADE;
                cboCarType.Value = sCarType;

                //TAP 2(검사정보)
                rtnDtTemp2 = helper.FillTable("USP_BM0100Y_S2", CommandType.StoredProcedure
                                               , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                               , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                              );

                grid2.DataSource = rtnDtTemp2;
                grid2.DataBinds();

                grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;

                //16-02-03 TAP 3(구매정보) 추가 최재형
                txtMinOrderQty.Text = sMinOrderQty;
                txtMaxOrderQty.Text = sMaxOrderQty;
                txtOrderQty.Text = sOrderQty;
                txtASGNName.Text = sAsgnName;
                txtASGNSPhone.Text = sAsgnPhone;
                txtASGNSEmail.Text = sAsgnMail;
                txtASGNFaxNo.Text = sAsgnFaxNo;
                txtASGNAddress.Text = sAsgnAddress;

                rtnDtTemp3 = helper.FillTable("USP_BM0150_S1", CommandType.StoredProcedure
                                                              , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp3.Rows.Count > 0)
                    {
                        byte[] imageArr;
                        imageArr = (byte[])rtnDtTemp3.Rows[0]["ITEMIMG"];
                        MemoryStream ms = new MemoryStream(imageArr);
                        pictureBox1.Image = Image.FromStream(ms);

                        lblImgName.Visible = true;
                        lblImgDate.Visible = true;

                        lblImgName.Text = "\r\n< 이미지 파일 이름 >\r\n" + rtnDtTemp3.Rows[0]["IMGNAME"];
                        lblImgDate.Text = "\r\n< 이미지 등록 일자 >\r\n" + rtnDtTemp3.Rows[0]["MAKEDATE"];
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        lblImgName.Text = "";
                        lblImgDate.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                    return;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// 수정모드 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            ControlSetting("EDIT");
            INSERTSAVE = 2;
        }

        /// <summary>
        /// 품목 채번
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProdItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    string sProdItemCode = string.Empty;
            //    string sOPHeader = string.Empty;
            //    string sItemCode = string.Empty;

            //    if (e.KeyChar == 13)
            //    {
            //        sProdItemCode = txtProdItemCode.Text;
            //        //sOPHeader = Convert.ToString(txtMajorItemCode.Value);

            //        if (sProdItemCode == string.Empty)
            //        {
            //            this.ShowDialog("BM00009", WIZ.Forms.DialogForm.DialogType.OK); //생산품목을 입력하세요.
            //            return;
            //        }

            //if (sOPHeader == "")
            //{
            //    this.ShowDialog("BM00008", WIZ.Forms.DialogForm.DialogType.OK); //품목 대분류를 선택하세요.
            //    return;
            //}

            //        if (sOPHeader == "X")
            //        {
            //            sItemCode = sProdItemCode;
            //        }
            //        else
            //        {
            //            sItemCode = sProdItemCode + sOPHeader;
            //        }

            //        txtItemCode.Text = sItemCode;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
        }

        private void txtMaxStock_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxStock.Text.Length > 0)
            {
                string value = txtMaxStock.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtMaxStock.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtMaxStock.Text = txtMaxStock.Text.Remove(txtMaxStock.Text.Length - 1, 1);
                        txtMaxStock.Select(txtMaxStock.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtMaxStock.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtMaxStock.SelectionStart = txtMaxStock.Text.Length;
            }
        }

        private void txtSafeStock_TextChanged(object sender, EventArgs e)
        {
            if (txtSafeStock.Text.Length > 0)
            {
                string value = txtSafeStock.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtSafeStock.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtSafeStock.Text = txtSafeStock.Text.Remove(txtSafeStock.Text.Length - 1, 1);
                        txtSafeStock.Select(txtSafeStock.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtSafeStock.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtSafeStock.SelectionStart = txtSafeStock.Text.Length;
            }
        }

        private void txtUnitWGT_TextChanged(object sender, EventArgs e)
        {
            if (txtUnitWGT.Text.Length > 0)
            {
                /*   string value = txtUnitWGT.Text.Replace(",", "");
                         // value = value.Replace(".", "");

                   if (!_IsNumber(value))
                   {
                       //입력된 데이터가 존재할 경우....
                       if (txtUnitWGT.Text.Length > 0)
                       {
                           //한글자씩 뒤에서 부터 삭제
                           txtUnitWGT.Text = txtUnitWGT.Text.Remove(txtUnitWGT.Text.Length - 1, 1);
                           txtUnitWGT.Select(txtUnitWGT.Text.Length, 0);
                       }
                   }
                
                   Double data = Double.Parse(txtUnitWGT.Text);
                   txtUnitWGT.Text = string.Format("{0:###,###,###,###,###,###,###.###}", data);
                   txtUnitWGT.SelectionStart = txtUnitWGT.Text.Length;
                   */
                /*   int iDot = this.txtUnitWGT.Text.ToString().IndexOf('.');
                   if (this.txtUnitWGT.Text.ToString().Substring(iDot + 1).Length > 3)
                   {
                       this.ShowDialog("단위중량은 소수점 셋째 자리까지만 입력가능합니다. (예) 12.123", Forms.DialogForm.DialogType.OK);
                       txtUnitWGT.Text = txtUnitWGT.Text.Remove(txtUnitWGT.Text.Length - 1, 1);
                       txtUnitWGT.Select(txtUnitWGT.Text.Length, 0);
                   }


                  Double data = Double.Parse(txtUnitWGT.Text);
                   txtUnitWGT.Text = string.Format("{0:N3}",data);
                   int iDot = this.txtUnitWGT.Text.ToString().IndexOf('.');
                   txtUnitWGT.Select(txtUnitWGT.Text.ToString().Substring(0,iDot).Length, 0);

                   if (txtUnitWGT.Text.ToString().Substring(iDot + 1, 1) != "0")
                   {
                       txtUnitWGT.Select(txtUnitWGT.Text.ToString().Substring(0, iDot).Length+2, 0);
                   }
                   if (txtUnitWGT.Text.ToString().Substring(iDot + 2, 1) != "0")
                   {
                       txtUnitWGT.Select(txtUnitWGT.Text.ToString().Substring(0, iDot).Length + 3, 0);
                   }
                   if (txtUnitWGT.Text.ToString().Substring(iDot + 3, 1) != "0")
                   {
                       txtUnitWGT.Select(txtUnitWGT.Text.ToString().Substring(0, iDot).Length + 4, 0);
                   }*/

                int iDot = this.txtUnitWGT.Text.IndexOf('.');
                if (iDot != -1)
                {
                    if (this.txtUnitWGT.Text.Length - iDot > 4)
                    {
                        this.ShowDialog(Common.getLangText("단위중량은 소수점 셋째 자리까지만 입력가능합니다. 예)12.123", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        txtUnitWGT.Text = txtUnitWGT.Text.Remove(txtUnitWGT.Text.Length - 1, 1);
                        txtUnitWGT.Select(txtUnitWGT.Text.Length, 0);
                    }
                }
                else
                {
                    string lgsText;
                    lgsText = txtUnitWGT.Text.Replace(",", "");//숫자변환시 콤마로 발생하는 에러 방지

                    //16-08-22 이실장 요청으로 소수점 앞에 0이 입력가능하도록 수정 최재형
                    //기존 .123 -> 0.123으로 입력가능
                    if (txtUnitWGT.Text != "0")
                    {
                        txtUnitWGT.Text = String.Format("{0:#,###}", Convert.ToDouble(lgsText));//천 단위 찍어주기
                    }

                    txtUnitWGT.Select(txtUnitWGT.Text.Length, 0);
                }
                if (this.txtUnitWGT.Text.Length > 13)
                {
                    this.ShowDialog(Common.getLangText("소수점 포함 최대 13자리를 넘을 수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    txtUnitWGT.Text = txtUnitWGT.Text.Remove(txtUnitWGT.Text.Length - 1, 1);
                    txtUnitWGT.Select(txtUnitWGT.Text.Length, 0);
                }
            }

        }

        private void txtChangeTime_TextChanged(object sender, EventArgs e)
        {
            if (txtChangeTime.Text.Length > 0)
            {
                string value = txtChangeTime.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtChangeTime.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtChangeTime.Text = txtChangeTime.Text.Remove(txtChangeTime.Text.Length - 1, 1);
                        txtChangeTime.Select(txtChangeTime.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtChangeTime.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtChangeTime.SelectionStart = txtChangeTime.Text.Length;
            }
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            if (txtUnitCost.Text.Length > 0)
            {
                string value = txtUnitCost.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtUnitCost.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtUnitCost.Text = txtUnitCost.Text.Remove(txtUnitCost.Text.Length - 1, 1);
                        txtUnitCost.Select(txtUnitCost.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtUnitCost.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtUnitCost.SelectionStart = txtUnitCost.Text.Length;
            }
        }

        private void txtMinOrderQty_TextChanged(object sender, EventArgs e)
        {
            if (txtMinOrderQty.Text.Length > 0)
            {
                string value = txtMinOrderQty.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtMinOrderQty.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtMinOrderQty.Text = txtMinOrderQty.Text.Remove(txtMinOrderQty.Text.Length - 1, 1);
                        txtMinOrderQty.Select(txtMinOrderQty.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtMinOrderQty.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtMinOrderQty.SelectionStart = txtMinOrderQty.Text.Length;
            }

        }

        private void txtMaxOrderQty_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxOrderQty.Text.Length > 0)
            {
                string value = txtMaxOrderQty.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtMaxOrderQty.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtMaxOrderQty.Text = txtMaxOrderQty.Text.Remove(txtMaxOrderQty.Text.Length - 1, 1);
                        txtMaxOrderQty.Select(txtMaxOrderQty.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtMaxOrderQty.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtMaxOrderQty.SelectionStart = txtMaxOrderQty.Text.Length;
            }

        }

        private void txtOrderQty_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderQty.Text.Length > 0)
            {
                string value = txtOrderQty.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txtOrderQty.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txtOrderQty.Text = txtOrderQty.Text.Remove(txtOrderQty.Text.Length - 1, 1);
                        txtOrderQty.Select(txtOrderQty.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txtOrderQty.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txtOrderQty.SelectionStart = txtOrderQty.Text.Length;
            }
        }

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            POP_TBM0100Y_EXCEL pop_tbm0100Y_excel = new POP_TBM0100Y_EXCEL();
            pop_tbm0100Y_excel.ShowDialog();
            DoInquire();
        }
        #endregion

        private void txtUnitWGT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (check == 1)
                {
                    e.Handled = true;
                }
                int iDot = this.txtUnitWGT.Text.IndexOf('.');
                if (iDot != -1)
                    check = 1;
                else
                    check = 0;
            }
            //숫자,백스페이스,마이너스,소숫점 만 입력받는다.
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 46) //8:백스페이스,45:마이너스,46:소수점
            {
                e.Handled = true;
            }



        }

        private void btnERPDownload_Click(object sender, EventArgs e)
        {
            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);

            try
            {
                //데이터를 다운로드 하시겠습니까?
                if (this.ShowDialog(Common.getLangText("데이터를 다운로드 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    DBHelper helper = new DBHelper(false);

                    helper.ExecuteNoneQuery("ERPDN_ITEM_T1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", DbType.String, sPlantCode));

                    base.DoInquire();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("이미지를 등록할 대상이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";

            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = Image.FromFile(openfiledialog.FileName);
                string ImgPath = openfiledialog.FileName;
                ImgNM = openfiledialog.SafeFileName;

                FileStream stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                bImage = reader.ReadBytes((int)stream.Length);
                reader.Close();
                stream.Close();

                // 이미지 표현
                if (bImage != null)
                {
                    pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                }

                pictureBox1.BringToFront();
            }
        }

        private void btnImageIn_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (pictureBox1.Image == null)
                {
                    this.ShowDialog(Common.getLangText("이미지를 불러온 후 저장을 시도해 주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    helper.Close();
                    return;
                }

                rtnDtTemp4 = helper.FillTable("USP_BM0150_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMCODE", Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp4.Rows.Count > 0)
                {   //해당 설비에 이미 등록된 이미지가 존재합니다. \r\n다른 이미지를 추가 하시겠습니까?
                    DialogResult result = this.ShowDialog(Common.getLangText("해당 설비에 이미 등록된 이미지가 존재합니다. \r\n다른 이미지를 추가 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);
                    if (result == DialogResult.OK)
                    {
                        helper.ExecuteNoneQuery("USP_BM0150_D1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("PLANTCODE", Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("ITEMCODE", Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input));
                    }
                    else
                        return;
                }
                else
                {
                    if (this.ShowDialog(Common.getLangText("해당 이미지로 등록하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO) == DialogResult.Cancel)
                    {
                        bImage = null;
                        pictureBox1.Image = null;
                        return;
                    }
                }
                try
                {
                    helper.ExecuteNoneQuery("USP_BM0150_I1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("ITEMIMG", (bImage == null) ? SqlBinary.Null : bImage, DbType.Binary, ParameterDirection.Input)
                                                           , helper.CreateParameter("IMGNAME", ImgNM, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.ShowDialog(Common.getLangText("이미지가 등록 되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        lblImgName.Text = "\r\n< 이미지 파일 이름 >\r\n" + ImgNM;
                        lblImgDate.Text = "\r\n< 이미지 등록 일자 >\r\n" + this.grid1.ActiveRow.Cells["MAKEDATE"].Value.ToString();
                        this.DoInquire();
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG);
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    this.ShowDialog(ex.ToString());
                }
                finally
                {
                    helper.Close();
                }

            }
            catch (SException ex)
            {
                throw ex;
            }
        }

        private void btnImageDel_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (pictureBox1.Image == null)
                {
                    this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult result = this.ShowDialog(Common.getLangText("등록된 이미지를 삭제하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO);

                if (result == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_BM0150_D1", CommandType.StoredProcedure
                         , helper.CreateParameter("PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        pictureBox1.Image = null;
                        lblImgName.Text = "";
                        lblImgDate.Text = "";
                        helper.Commit();

                        DoInquire();
                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(Common.getLangText("설비 이미지 삭제 중 오류가 발생하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        helper.Rollback();
                    }

                }
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

        private void btnImageFull_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (pictureBox1.Image == null)
            {
                this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            rtnDtTemp3 = helper.FillTable("USP_BM0150_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("PLANTCODE", Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("ITEMCODE", Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input));

            if (rtnDtTemp3.Rows[0]["ITEMIMG"] != null)
            {
                byte[] bImage = (byte[])rtnDtTemp3.Rows[0]["ITEMIMG"];


            }
        }


    }
}