#region ▶ HEADER AREA 
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0500
//   Form Name    : 실적/라인/작업자 수작업 등록(미집계 포함)
//   Name Space   : WIZ.AP
//   Created Date : 2015-11-11
//   Made By      : WIZCORE CO.,LTD
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region ▶ USING AREA 
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
using WIZ.REPORT;
#endregion

namespace WIZ.AP
{
    public partial class AP0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region ▶ MEMBER AREA 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();         //COMMON 객체 생성        
        BizTextBoxManager btbManager = new BizTextBoxManager(); //팝업 매니저
        BizGridManager gridManager1;
        BizGridManager gridManager2;

        PopUp_Biz _biz = new PopUp_Biz();                       //팝업 비지니스 로직 객체 생성

        DataSet rtnDsTemp = new DataSet();            //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통

        DataTable _DtTemp = new DataTable();         //임시로 사용할 데이터테이블 생성
        DataTable _DtChange1 = new DataTable();         //GRID1 DataSource
        DataTable _DtChange2 = new DataTable();         //GRID2 DataSource
        DataTable _DtChange3 = new DataTable();         //GRID3 DataSource
        #endregion

        #region ▶ CONSTRUCTOR 
        public AP0500()
        {
            InitializeComponent();
        }
        #endregion

        #region ▶ FORM LOAD 
        private void AP0500_Load(object sender, EventArgs e)
        {
            try
            {
                GridInit();

                //-- ComboBox Setting 
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
                this.cboPlantCode_H.Value = "1100";

                rtnDtTemp = _Common.GET_BM0000_CODE("RUNSTOP");    //가동, 비가동
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LINESTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //--

                //-- POPUP Setting 
                btbManager.PopUpAdd(txtWcCode, txtWcName, "TBM0600", new object[] { cboPlantCode_H, "", "", "", "Y" });

                gridManager1 = new BizGridManager(this.grid1);
                gridManager1.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600", new string[] { "PLANTCODE", "", "", "Y" });
                gridManager1.PopUpAdd("ORDERNO", "ITEMCODE", "TAP0200", new string[] { "PLANTCODE", "WORKCENTERCODE", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd") });
                gridManager1.PopUpAdd("ERRORCODE", "ERRORDESC", "TBM1000X", new string[] { "PLANTCODE", "", "", "", "Y" });
                gridManager1.PopUpAdd("ERRORITEMCODE", "ERRORITEMNAME", "TBM1200X", new string[] { "PLANTCODE", "ORDERNO", "ITEMCODE" });
                gridManager1.PopUpAdd("WORKERID1", "WORKERNAME1", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID1", "WORKERNAME1" });
                gridManager1.PopUpAdd("WORKERID2", "WORKERNAME2", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID2", "WORKERNAME2" });
                gridManager1.PopUpAdd("WORKERID3", "WORKERNAME3", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID3", "WORKERNAME3" });
                gridManager1.PopUpAdd("WORKERID4", "WORKERNAME4", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID4", "WORKERNAME4" });
                gridManager1.PopUpAdd("WORKERID5", "WORKERNAME5", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID5", "WORKERNAME5" });
                gridManager1.PopUpAdd("WORKERID6", "WORKERNAME6", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID6", "WORKERNAME6" });
                gridManager1.PopUpAdd("WORKERID7", "WORKERNAME7", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID7", "WORKERNAME7" });
                gridManager1.PopUpAdd("WORKERID8", "WORKERNAME8", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID8", "WORKERNAME8" });
                gridManager1.PopUpAdd("WORKERID9", "WORKERNAME9", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID9", "WORKERNAME9" });
                gridManager1.PopUpAdd("WORKERID10", "WORKERNAME10", "TBM0200X", new string[] { "PLANTCODE", "WORKCENTERCODE", "WORKERID10", "WORKERNAME10" });

                gridManager2 = new BizGridManager(this.grid3);
                gridManager2.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "TBM0600", new string[] { "PLANTCODE", "", "", "Y" });
                gridManager2.PopUpAdd("ORDERNO", "ITEMCODE", "TAP0200", new string[] { "PLANTCODE", "WORKCENTERCODE", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd") });
                gridManager2.PopUpAdd("ERRORITEMCODE", "ERRORITEMNAME", "TBM1200X", new string[] { "PLANTCODE", "ORDERNO", "ITEMCODE" });
                gridManager2.PopUpAdd("ERRORCODE", "ERRORDESC", "TBM1000X", new string[] { "PLANTCODE", "", "", "", "Y" });
                //--

                cboRecdata_H.Value = DateTime.Now;
                rbtnRunProd.Checked = true;
                cboPlantCode_H.Select();
                cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion FORM LOAD

        #region ▶ Grid Setting 
        private void GridInit()
        {
            #region ▷ Grid1 
            try
            {
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "RNUM", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 55, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "라인코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "수불일자", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "계획번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "작업수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "작업시작시간", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "작업종료시간", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LINESTATUS", "라인상태코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "조업코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMCODE", "불량품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMNAME", "불량품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID1", "작업자ID1", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID2", "작업자ID2", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID3", "작업자ID3", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID4", "작업자ID4", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID5", "작업자ID5", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID6", "작업자ID6", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID7", "작업자ID7", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID8", "작업자ID8", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID9", "작업자ID9", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID10", "작업자ID10", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME1", "작업자명1", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME2", "작업자명2", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME3", "작업자명3", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME4", "작업자명4", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME5", "작업자명5", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME6", "작업자명6", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME7", "작업자명7", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME8", "작업자명8", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME9", "작업자명9", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME10", "작업자명10", false, GridColDataType_emu.VarChar, 85, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);

                UltraGridColumn col1 = this.grid1.Columns["STARTDATE"];
                col1.MaskInput = "####-##-## ##:##:##";
                col1.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                col1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                UltraGridColumn col2 = this.grid1.Columns["ENDDATE"];
                col2.MaskInput = "####-##-## ##:##:##";
                col2.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                col2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  // RowSeletor Visible False
                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                _DtChange1 = (DataTable)this.grid1.DataSource;
            }
            catch
            {
            }
            #endregion

            #region ▷ Grid2 
            try
            {
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "RNUM", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "라인", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "작업일자", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "STARTDATE", "가동시간", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ENDDATE", "종료시간", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "STATUS", "상태", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "STOPCODE", "조업상태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERNO", "계획번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORITEMCODE", "결품품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "업체", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ERRORMACHCODE", "고장설비", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid2);

                UltraGridColumn col3 = this.grid2.Columns["STARTDATE"];
                col3.MaskInput = "####-##-## ##:##:##";
                col3.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                col3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                UltraGridColumn col4 = this.grid2.Columns["ENDDATE"];
                col4.MaskInput = "####-##-## ##:##:##";
                col4.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                col4.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                grid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  // RowSeletor Visible False
                grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                _DtChange2 = (DataTable)this.grid2.DataSource;
            }
            catch
            {
            }
            #endregion

            #region ▷ Grid3 
            try
            {
                _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "RNUM", "NO", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 55, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKCENTERCODE", "라인코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "RECDATE", "수불일자", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ORDERNO", "계획번호", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODQTY", "작업수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODDATE", "작업시간", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORITEMCODE", "불량품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORITEMNAME", "불량품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORDESC", "불량명", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid3);

                UltraGridColumn col5 = this.grid3.Columns["PRODDATE"];
                col5.MaskInput = "##:##:##";
                col5.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
                col5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                col5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

                grid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  // RowSeletor Visible False
                grid3.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                _DtChange3 = (DataTable)this.grid3.DataSource;
            }
            catch
            {
            }
            #endregion
        }
        #endregion 

        #region ▶ TOOL BAR AREA 
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (Convert.ToString(this.cboPlantCode_H.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("사업장을 먼저 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //공장을 먼저 선택하세요.
                return;
            }

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);               //공장코드
                string ls_recdate = string.Format("{0:yyyy-MM-dd}", cboRecdata_H.Value);  //실적일자                                
                string ls_wccode = txtWcCode.Text.Trim();                                //라인코드

                #region ▶ 엑셀수작업 등록 이력 조회 ◀
                if (rbtnRunProd.Checked == true)
                {
                    #region ▷ 가동/실적
                    rtnDtTemp = helper.FillTable("USP_AP0500Y_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)    //공장코드
                                                    , helper.CreateParameter("AS_RECDATE", ls_recdate, DbType.String, ParameterDirection.Input)    //실적일자                                                    
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", ls_wccode, DbType.String, ParameterDirection.Input));          //작업장코드
                    this.ClosePrgFormNew();
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();

                        _DtChange1 = rtnDtTemp;

                        grid1.ActiveRow = grid1.Rows[0];
                        grid1_ClickCell(this.grid1, new ClickCellEventArgs(this.grid1.Rows[0].Cells[0]));
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                    }
                    #endregion

                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
                }
                else
                {
                    #region ▷ 실적 
                    rtnDtTemp = helper.FillTable("USP_AP0500Y_S3", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)    //공장코드
                                                    , helper.CreateParameter("AS_RECDATE", ls_recdate, DbType.String, ParameterDirection.Input)    //실적일자                                                    
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", ls_wccode, DbType.String, ParameterDirection.Input));  //라인코드
                    this.ClosePrgFormNew();
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds();

                        _DtChange3 = rtnDtTemp;

                        grid3.ActiveRow = grid3.Rows[0];
                        grid3_ClickCell(this.grid3, new ClickCellEventArgs(this.grid3.Rows[0].Cells[0]));
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid3);
                    }
                    #endregion

                    grid3.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid3.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
                }
                #endregion

                #region ▶ 가동/비가동 이력 조회(라인코드 입력 시) ◀
                rtnDtTemp = helper.FillTable("USP_AP0500Y_S2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)    //공장코드
                                                        , helper.CreateParameter("AS_WORKCENTERCODE", ls_wccode, DbType.String, ParameterDirection.Input)    //작업장
                                                        , helper.CreateParameter("AS_RECDATE", ls_recdate, DbType.String, ParameterDirection.Input));  //실적일자

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();

                    _DtChange2 = (DataTable)this.grid2.DataSource;

                    grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                    rtnDtTemp = GET_TBM1100_CODE(ls_plantcode, string.Empty, string.Empty);
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
                #endregion

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            if (Convert.ToString(this.cboPlantCode_H.Value) == string.Empty)
            {
                this.ShowDialog(Common.getLangText("사업장은 반드시 선택 되어야 합니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }


            if (rbtnRunProd.Checked == true)
            {
                this.grid1.InsertRow();

                this.grid1.ActiveRow.Cells["RNUM"].Value = "입력";
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(this.cboPlantCode_H.Value);
                this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value = string.Empty;
                this.grid1.ActiveRow.Cells["RECDATE"].Value = string.Format("{0:yyyyMMdd}", cboRecdata_H.Value);    //실적일자
                this.grid1.ActiveRow.Cells["ORDERNO"].Value = string.Empty;
                this.grid1.ActiveRow.Cells["PRODQTY"].Value = string.Empty;
                this.grid1.ActiveRow.Cells["STARTDATE"].Value = string.Format("{0:yyyy-MM-dd}", cboRecdata_H.Value);    //실적일자
                this.grid1.ActiveRow.Cells["ENDDATE"].Value = string.Format("{0:yyyy-MM-dd}", cboRecdata_H.Value);    //실적일자
            }
            else
            {
                this.grid3.InsertRow();

                this.grid3.ActiveRow.Cells["RNUM"].Value = "입력";
                this.grid3.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(this.cboPlantCode_H.Value);
                this.grid3.ActiveRow.Cells["RECDATE"].Value = string.Format("{0:yyyyMMdd}", cboRecdata_H.Value);    //실적일자
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            if (rbtnRunProd.Checked == true)
            {
                if (Convert.ToString(this.grid1.ActiveRow.Cells["RNUM"].Value) == "입력")
                {
                    //if (MessageBox.Show("입력 중인 선택 정보를 삭제 하시겠습니까?", "입력 정보 삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    this.grid1.DeleteRow();
                    //}
                    if (this.ShowDialog(Common.getLangText("입력 중인 선택 정보를 삭제 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.grid1.DeleteRow();
                    }
                }
            }
            else
            {
                if (Convert.ToString(this.grid3.ActiveRow.Cells["RNUM"].Value) == "입력")
                {
                    //if (MessageBox.Show("입력 중인 선택 정보를 삭제 하시겠습니까?", "입력 정보 삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    this.grid3.DeleteRow();
                    //}
                    if (this.ShowDialog(Common.getLangText("입력 중인 선택 정보를 삭제 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.grid3.DeleteRow();
                    }
                }
            }

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            int iChk = 0;
            if (rbtnRunProd.Checked == true)
            {
                this.grid1.UpdateData();

                for (int i = 0; i < _DtChange1.Rows.Count; i++)
                {
                    if (Convert.ToString(_DtChange1.Rows[i]["RNUM"]) == "입력")
                        iChk = iChk + 1;
                }
            }
            else
            {
                this.grid3.UpdateData();

                for (int i = 0; i < _DtChange3.Rows.Count; i++)
                {
                    if (Convert.ToString(_DtChange3.Rows[i]["RNUM"]) == "입력")
                        iChk = iChk + 1;
                }
            }

            if (iChk == 0)
            {
                //MessageBox.Show("수작업 등록 할 내용이 없습니다.", "가동 및 생산/불량 실적 정보 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ShowDialog(Common.getLangText("수작업 등록 할 내용이 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            //if (MessageBox.Show("가동 및 생산/불량 실적 정보를 등록하시겠습니까?", "가동 및 생산/불량 실적 정보 등록", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            //    == System.Windows.Forms.DialogResult.Cancel)
            //    return;

            if (this.ShowDialog(Common.getLangText("가동 및 생산/불량 실적 정보를 등록하시겠습니까?", "MSG"), DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.Cancel)
                return;

            base.DoSave();

            DBHelper helper = new DBHelper("", true);
            int iRow = 0;

            try
            {
                if (rbtnRunProd.Checked == true)
                {
                    #region ▷ 가동/실적
                    for (int i = 0; i < _DtChange1.Rows.Count; i++)
                    {
                        DataRow drRow = _DtChange1.Rows[i];

                        if (Convert.ToString(drRow["RNUM"]) != "입력")
                            continue;

                        if (drRow.RowState == DataRowState.Added)
                        {
                            helper.ExecuteNoneQuery("USP_AP0500Y_I1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", grid1.Rows[i].Cells["PLANTCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", grid1.Rows[i].Cells["WORKCENTERCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_RECDATE", grid1.Rows[i].Cells["RECDATE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", grid1.Rows[i].Cells["ORDERNO"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PRODQTY", grid1.Rows[i].Cells["PRODQTY"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STARTDATE", grid1.Rows[i].Cells["STARTDATE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ENDDATE", grid1.Rows[i].Cells["ENDDATE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STATUS", Convert.ToString(grid1.Rows[i].Cells["LINESTATUS"].Value), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STOPCODE", Convert.ToString(grid1.Rows[i].Cells["STOPCODE"].Value), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ERRORITEMCODE", grid1.Rows[i].Cells["ERRORITEMCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ERRORCODE", grid1.Rows[i].Cells["ERRORCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ERRORQTY", grid1.Rows[i].Cells["ERRORQTY"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID1", grid1.Rows[i].Cells["WORKERID1"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID2", grid1.Rows[i].Cells["WORKERID2"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID3", grid1.Rows[i].Cells["WORKERID3"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID4", grid1.Rows[i].Cells["WORKERID4"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID5", grid1.Rows[i].Cells["WORKERID5"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID6", grid1.Rows[i].Cells["WORKERID6"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID7", grid1.Rows[i].Cells["WORKERID7"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID8", grid1.Rows[i].Cells["WORKERID8"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID9", grid1.Rows[i].Cells["WORKERID9"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKERID10", grid1.Rows[i].Cells["WORKERID10"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                iRow = i + 1;
                                throw new Exception();
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region ▷ 실적 ◁
                    for (int i = 0; i < _DtChange3.Rows.Count; i++)
                    {
                        DataRow drRow = _DtChange3.Rows[i];

                        if (Convert.ToString(drRow["RNUM"]) != "입력")
                            continue;

                        if (drRow.RowState == DataRowState.Added)
                        {
                            helper.ExecuteNoneQuery("USP_AP0500Y_I2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", grid3.Rows[i].Cells["PLANTCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_WORKCENTERCODE", grid3.Rows[i].Cells["WORKCENTERCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_RECDATE", grid3.Rows[i].Cells["RECDATE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ORDERNO", grid3.Rows[i].Cells["ORDERNO"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PRODQTY", grid3.Rows[i].Cells["PRODQTY"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PRODDATE", grid3.Rows[i].Cells["PRODDATE"].Text, DbType.String, ParameterDirection.Input)  //HH24:MI:SS
                                    , helper.CreateParameter("AS_ERRORITEMCODE", grid3.Rows[i].Cells["ERRORITEMCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ERRORCODE", grid3.Rows[i].Cells["ERRORCODE"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ERRORQTY", grid3.Rows[i].Cells["ERRORQTY"].Text, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "E")
                            {
                                iRow = i + 1;
                                throw new Exception();
                            }
                        }
                    }
                    #endregion
                }

                helper.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(iRow.ToString() + "번째 줄 등록 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + (helper.RSMSG == string.Empty ? ex.Message : helper.RSMSG));
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();

            ExcelManager excel = new ExcelManager();

            if (this.grid1.IsActivate == true)
                excel.DownloadExcel(this.grid1, this.Name, false);
            else if (this.grid2.IsActivate == true)
                excel.DownloadExcel(this.grid2, this.Name, false);
            else
                this.ShowDialog(Common.getLangText("다운로드 할 그리드를 선택한 뒤 진행하십시오.", "MSG"), DialogForm.DialogType.OK);
        }

        #endregion

        #region ▶ USER EVENTS 

        #region ▶ GRID 
        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "WORKCENTERCODE")
            {
                if (e.Cell.Text != string.Empty)
                {
                    DBHelper helper = new DBHelper(false);

                    try
                    {
                        string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                        string sRecDate = Convert.ToString(this.grid1.ActiveRow.Cells["RECDATE"].Value);         //실적일자
                        string sWorkCenterCode = Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);  //라인코드

                        rtnDtTemp = helper.FillTable("USP_AP0500Y_S2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    //공장코드
                                                        , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_RECDATE", sRecDate, DbType.String, ParameterDirection.Input));  //실적일자

                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds();

                            _DtChange2 = (DataTable)this.grid2.DataSource;

                            grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                            grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;


                            rtnDtTemp = GET_TBM1100_CODE(sPlantCode, string.Empty, string.Empty);
                            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
            }
        }

        private void grid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (Convert.ToString(this.grid1.ActiveRow.Cells["RNUM"].Value) != "입력")
                e.Cancel = true;
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0) return;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                string sRecDate = Convert.ToString(this.grid1.ActiveRow.Cells["RECDATE"].Value);         //실적일자
                string sWorkCenterCode = Convert.ToString(this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);  //라인코드

                if (sPlantCode == string.Empty || sRecDate == string.Empty || sWorkCenterCode == string.Empty)
                    return;

                rtnDtTemp = helper.FillTable("USP_AP0500Y_S2", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    //공장코드
                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_RECDATE", sRecDate, DbType.String, ParameterDirection.Input));  //실적일자

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();

                    _DtChange2 = (DataTable)this.grid2.DataSource;

                    grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                    rtnDtTemp = GET_TBM1100_CODE(sPlantCode, string.Empty, string.Empty);
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        private void grid2_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (Convert.ToString(this.grid2.ActiveRow.Cells["STATUS"].Value) == "R" ||
                 (Convert.ToString(this.grid2.ActiveRow.Cells["STATUS"].Value) == "S"
                  && Convert.ToString(this.grid2.ActiveRow.Cells["STOPCODE"].Value) == "A06"))
                e.Cancel = true;

            if (this.grid2.ActiveCell.Column.Key == "ERRORITEMCODE")
            {
                if (Convert.ToString(this.grid2.ActiveRow.Cells["STOPCODE"].Value) != "B02" ||
                    Convert.ToString(this.grid2.ActiveRow.Cells["STOPCODE"].Value) != "B04")
                {
                    e.Cancel = true;
                }
            }
            else if (this.grid2.ActiveCell.Column.Key == "MACHCODE")
            {
                if (Convert.ToString(this.grid2.ActiveRow.Cells["STOPCODE"].Value) != "C10")
                {
                    e.Cancel = true;
                }
            }
        }

        private void grid3_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "WORKCENTERCODE")
            {
                if (e.Cell.Text != string.Empty)
                {
                    DBHelper helper = new DBHelper(false);

                    try
                    {
                        string sPlantCode = Convert.ToString(this.grid3.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                        string sRecDate = Convert.ToString(this.grid3.ActiveRow.Cells["RECDATE"].Value);         //실적일자
                        string sWorkCenterCode = Convert.ToString(this.grid3.ActiveRow.Cells["WORKCENTERCODE"].Value);  //라인코드

                        rtnDtTemp = helper.FillTable("USP_AP0500Y_S2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    //공장코드
                                                        , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_RECDATE", sRecDate, DbType.String, ParameterDirection.Input));  //실적일자

                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds();

                            _DtChange2 = (DataTable)this.grid2.DataSource;

                            grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                            grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;


                            rtnDtTemp = GET_TBM1100_CODE(sPlantCode, string.Empty, string.Empty);
                            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
            }
        }

        private void grid3_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (Convert.ToString(this.grid3.ActiveRow.Cells["RNUM"].Value) != "입력")
                e.Cancel = true;
        }

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0) return;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(this.grid3.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                string sRecDate = Convert.ToString(this.grid3.ActiveRow.Cells["RECDATE"].Value);         //실적일자
                string sWorkCenterCode = Convert.ToString(this.grid3.ActiveRow.Cells["WORKCENTERCODE"].Value);  //라인코드

                if (sPlantCode == string.Empty || sRecDate == string.Empty || sWorkCenterCode == string.Empty)
                    return;

                rtnDtTemp = helper.FillTable("USP_AP0500Y_S2", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)    //공장코드
                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_RECDATE", sRecDate, DbType.String, ParameterDirection.Input));    //실적일자

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();

                    _DtChange2 = (DataTable)this.grid2.DataSource;

                    grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                    rtnDtTemp = GET_TBM1100_CODE(sPlantCode, string.Empty, string.Empty);
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region ▶ BUTTON
        private void btnSaveLineStatus_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("비가동 정보 변경사항을 저장하시겠습니까?", "비가동 정보 저장", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) 
            //                == System.Windows.Forms.DialogResult.Cancel)
            if (this.ShowDialog(Common.getLangText("비가동 정보 변경사항을 저장하시겠습니까?", "MSG"), DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.Cancel)
                return;

            if (_DtChange2.GetChanges() == null)
            {
                //MessageBox.Show("변경된 사항이 없습니다.", "비가동 정보 변경 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
                this.ShowDialog(Common.getLangText("변경된 사항이 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            this.grid2.UpdateData();

            DBHelper helper = new DBHelper("", true);
            int iRow = 0;

            try
            {
                for (int i = 0; i < _DtChange2.Rows.Count; i++)
                {
                    DataRow drRow = _DtChange2.Rows[i];

                    if (drRow.RowState == DataRowState.Modified)
                    {
                        helper.ExecuteNoneQuery("USP_AP0500Y_U2", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", grid2.Rows[i].Cells["PLANTCODE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", grid2.Rows[i].Cells["WORKCENTERCODE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STARTDATE", grid2.Rows[i].Cells["STARTDATE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STATUS", grid2.Rows[i].Cells["STATUS"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ENDDATE", grid2.Rows[i].Cells["ENDDATE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RECDATE", grid2.Rows[i].Cells["RECDATE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STOPCODE", grid2.Rows[i].Cells["STOPCODE"].Value, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ERRORITEMCODE", grid2.Rows[i].Cells["ERRORITEMCODE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ERRORMACHCODE", grid2.Rows[i].Cells["ERRORMACHCODE"].Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            iRow = i + 1;
                            throw new Exception();
                        }
                    }
                }

                helper.Commit();
            }
            catch
            {
                MessageBox.Show(iRow.ToString() + "번째 줄 수정 중 오류가 발생하였습니다." + Environment.NewLine + "오류내용: " + helper.RSMSG);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    DataTable dtExcelImport = GetExcel(openfiledialog.FileName);

                    if (rbtnRunProd.Checked == true)
                    {
                        //대상 GRID DataTable 복사(구조o, 데이터x)
                        DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

                        //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                        for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                        {
                            DataRow drTarget = dtTarget.NewRow();

                            drTarget["RNUM"] = "입력";    //추가
                            drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                            drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                            drTarget["RECDATE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                            drTarget["ORDERNO"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                            drTarget["PRODQTY"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                            drTarget["STARTDATE"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                            drTarget["ENDDATE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                            drTarget["LINESTATUS"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                            drTarget["STOPCODE"] = Convert.ToString(dtExcelImport.Rows[i][9]);
                            drTarget["ERRORITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][10]);
                            drTarget["ERRORCODE"] = Convert.ToString(dtExcelImport.Rows[i][11]);
                            drTarget["ERRORQTY"] = Convert.ToString(dtExcelImport.Rows[i][12]);
                            drTarget["WORKERID1"] = Convert.ToString(dtExcelImport.Rows[i][13]);
                            drTarget["WORKERID2"] = Convert.ToString(dtExcelImport.Rows[i][14]);
                            drTarget["WORKERID3"] = Convert.ToString(dtExcelImport.Rows[i][15]);
                            drTarget["WORKERID4"] = Convert.ToString(dtExcelImport.Rows[i][16]);
                            drTarget["WORKERID5"] = Convert.ToString(dtExcelImport.Rows[i][17]);
                            drTarget["WORKERID6"] = Convert.ToString(dtExcelImport.Rows[i][18]);
                            drTarget["WORKERID7"] = Convert.ToString(dtExcelImport.Rows[i][19]);
                            drTarget["WORKERID8"] = Convert.ToString(dtExcelImport.Rows[i][20]);
                            drTarget["WORKERID9"] = Convert.ToString(dtExcelImport.Rows[i][21]);
                            drTarget["WORKERID10"] = Convert.ToString(dtExcelImport.Rows[i][22]);

                            dtTarget.Rows.Add(drTarget);
                        }

                        this.grid1.DataSource = dtTarget;
                        this.grid1.DataBind();

                        _DtChange1 = (DataTable)this.grid1.DataSource;
                    }
                    else
                    {
                        //대상 GRID DataTable 복사(구조o, 데이터x)
                        DataTable dtTarget = ((DataTable)this.grid3.DataSource).Clone();

                        //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                        for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                        {
                            DataRow drTarget = dtTarget.NewRow();

                            drTarget["RNUM"] = "입력";    //추가
                            drTarget["PLANTCODE"] = Convert.ToString(dtExcelImport.Rows[i][1]);
                            drTarget["WORKCENTERCODE"] = Convert.ToString(dtExcelImport.Rows[i][2]);
                            drTarget["RECDATE"] = Convert.ToString(dtExcelImport.Rows[i][3]);
                            drTarget["ORDERNO"] = Convert.ToString(dtExcelImport.Rows[i][4]);
                            drTarget["PRODQTY"] = Convert.ToString(dtExcelImport.Rows[i][5]);
                            drTarget["PRODDATE"] = Convert.ToDateTime(dtExcelImport.Rows[i][6]).ToString("HHmmss");
                            drTarget["ERRORITEMCODE"] = Convert.ToString(dtExcelImport.Rows[i][7]);
                            drTarget["ERRORCODE"] = Convert.ToString(dtExcelImport.Rows[i][8]);
                            drTarget["ERRORQTY"] = Convert.ToString(dtExcelImport.Rows[i][9]);

                            dtTarget.Rows.Add(drTarget);
                        }

                        this.grid3.DataSource = dtTarget;
                        this.grid3.DataBind();

                        _DtChange3 = (DataTable)this.grid3.DataSource;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("엑셀 수작업 등록 양식이 잘못되었습니다.\r\n양식다운을 하신 뒤에 작업을 진행하십시오.\r\n오류내용: ", "MSG") + ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }

        }

        private void btnFileDown_Click(object sender, EventArgs e)
        {
            if (rbtnRunProd.Checked == true)
                _GridUtil.ExportExcel(this.grid1);
            else
                _GridUtil.ExportExcel(this.grid3);
        }
        #endregion

        private void radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRunProd.Checked == true)
            {
                this.grid1.Visible = true;
                this.grid3.Visible = false;

                rbtnRunProd.Font = new Font(rbtnRunProd.Font.FontFamily, rbtnRunProd.Font.Size, FontStyle.Bold);
                rbtnProd.Font = new Font(rbtnProd.Font.FontFamily, rbtnProd.Font.Size, FontStyle.Regular);

                _GridUtil.Grid_Clear(this.grid1);
                _GridUtil.Grid_Clear(this.grid3);
            }
            else
            {
                this.grid1.Visible = false;
                this.grid3.Visible = true;

                rbtnRunProd.Font = new Font(rbtnRunProd.Font.FontFamily, rbtnRunProd.Font.Size, FontStyle.Regular);
                rbtnProd.Font = new Font(rbtnProd.Font.FontFamily, rbtnProd.Font.Size, FontStyle.Bold);

                _GridUtil.Grid_Clear(this.grid1);
                _GridUtil.Grid_Clear(this.grid3);
            }
        }

        private void txtTabMove_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!cboClassCode_H.Focused)
            //        SendKeys.Send("{TAB}");

            //    if (cboClassCode_H.Focused)
            //    {
            //        DoInquire();
            //        cboPlantCode_H.Select();
            //    }
            //}
        }

        #endregion

        #region ▶ USER FUNCTIONS 
        /// <summary>
        /// 코드마스터 조회 (추가 Query)
        /// </summary>
        /// <param name="MajorCode">MAJORCODE</param>
        /// <param name="sSql">추가 Query</param>
        /// <returns></returns>
        private DataTable GET_BM0000_CODE_N(string MajorCode, string sSql)
        {
            DataTable Dt = new DataTable();

            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine(" SELECT MINORCODE                             AS CODE_ID,     ");
                query.AppendLine("        '['  || MINORCODE || '] '||  CODENAME AS CODE_NAME,   ");
                query.AppendLine("        RELCODE1, RELCODE2, RELCODE3,                         ");
                query.AppendLine("        RELCODE4, RELCODE5, DISPLAYNO                         ");
                query.AppendLine("   FROM TBM0000 WITH (NOLOCK)                                 ");
                query.AppendLine("  WHERE MAJORCODE = '" + MajorCode.ToUpper() + "'             ");
                query.AppendLine("    AND MINORCODE <> '$'                                      ");
                query.AppendLine("    " + sSql + "                                              ");
                query.AppendLine("    AND USEFLAG ='Y'                                          ");
                query.AppendLine("  ORDER BY DISPLAYNO                                          ");
                Dt = helper.FillTable(Convert.ToString(query), CommandType.Text);

                return Dt;
            }
            catch
            {
                return Dt;
            }
            finally
            {
                helper.Close();
            }
        }

        private DataTable GET_TBM1100_CODE(string PLANTCODE, string STOPTYPE, string STOPCODE)
        {
            DBHelper helper = new DBHelper(false);
            DataTable DtTemp = new DataTable();

            try
            {
                StringBuilder lsSQL = new StringBuilder();

                lsSQL.AppendLine(" SELECT DISTINCT                                          ");
                lsSQL.AppendLine("        STOPCODE                            AS CODE_ID    ");
                lsSQL.AppendLine("      , '[' || STOPCODE || '] ' || STOPDESC AS CODE_NAME  ");
                lsSQL.AppendLine("   FROM TBM1100                                           ");
                lsSQL.AppendLine("  WHERE STOPCODE LIKE '" + STOPCODE + "%'                 ");
                lsSQL.AppendLine("    AND STOPTYPE LIKE '" + STOPTYPE + "%'                 ");
                lsSQL.AppendLine("    AND PLANTCODE LIKE '" + PLANTCODE + "%'               ");
                lsSQL.AppendLine("  ORDER BY STOPCODE ASC                                   ");

                DtTemp = helper.FillTable(lsSQL.ToString());

                return DtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DtTemp;
            }
            finally
            {
                helper.Close();
            }

        }

        private DataTable GetExcel(string sFilePath)
        {
            string oledbConnStr = string.Empty;

            if (sFilePath.IndexOf(".xlsx") > -1)
            {
                // 엑셀 2007 이상
                oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 12.0\"";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";
                oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No'";
            }

            DataTable dtExcel = null;
            OleDbDataAdapter adt = null;

            using (OleDbConnection con = new OleDbConnection(oledbConnStr))
            {
                con.Open();

                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();             //엑셀 첫 번째 시트명
                string sQuery = string.Format(" SELECT * FROM [{0}] ", sheetName);  //조회 쿼리

                dtExcel = new DataTable();
                adt = new OleDbDataAdapter(sQuery, con);
                adt.Fill(dtExcel);
            }

            return dtExcel;
        }
        #endregion
    }
}