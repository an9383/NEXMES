#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM7600
//   Form Name      : 품목별 측정 SPEC 관리
//   Name Space     : MHSPC.BM
//   Created Date   : 2012.10.08
//   Made By        : WIZCORE
//   Description    : 품목별 측정 SPEC 관리
//   DB Table       : BM7600
//   StoreProcedure : USP_BM7600_S1(S2, I1, D1, U1)
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM7600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private System.Windows.Forms.Control focusItem;
        private DataTable DtTemp = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private bool StatusCheck = false;   //DoSearch 시점에 상태값 변경 하기 위해 사용
        #endregion

        #region < CONSTRUCTOR >
        public BM7600()
        {
            InitializeComponent();

            string PlantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.DefaultValue = PlantCode;
        }
        #endregion

        #region<BM7600_Load>
        private void BM7600_Load(object sender, EventArgs e)
        {
            focusItem = new System.Windows.Forms.Control();


            System.Windows.Forms.Control IICycle = new System.Windows.Forms.Control();
            System.Windows.Forms.Control IIsampleQty = new System.Windows.Forms.Control();



            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "Item", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "Item Description", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
            _GridUtil.SetColumnMerge(this, grid1, "LINECODE");
            _GridUtil.SetColumnMerge(this, grid1, "LINENAME");

            _GridUtil.SetInitUltraGridBind(grid1);

            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid2, "FLAG", "등록여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEMNAME", "측정항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEM", "측정코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREEQUID", "측정기ID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREEQUNAME", "측정기", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INTERALID", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LINECODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LINENAME", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPERCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPERNAME", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "IIOPERCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "IIOPCODENAME", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DWINTERNALID", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DWNO", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STATSAPPLYFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CRITICALAPPLYFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USRMEASUREEQUID", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "IFDATAID", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DAPOINTID", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "COMPORT", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SEQNO", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPEC", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LSL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LTOLVAL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UTOLVAL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CALIBRATIONFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CALIBRATIONTYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CALIBRATION", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "GRAPHTYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SAMPLEQTY", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UCL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LCL", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPVALTYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCNT", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPTIME", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCYCLE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MGTFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "HIVISFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "HIPISFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DISPLAYFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "IIFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PIFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPCFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEMRENAME", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONCODE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REVISIONFORMULA", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARKS", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "XMLJUDGETYPE", "표기순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            //--2013.03.21 추가 항목
            _GridUtil.InitColumnUltraGrid(grid2, "VALTYPE", "공차/측정값", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CARRIERFLAG", "CARRIERFLAG", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TOLTYPE", "공차기준구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "R_UCL", "R_UCL", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "R_LCL", "R_LCL", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            DtGrid2 = (DataTable)this.grid2.DataSource;

            //공장
            Common _Common = new Common();
            DtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", DtTemp, "CODE_ID", "CODE_NAME");
            //사용여부
            DtTemp = _Common.GET_BM0000_CODE("USEYN");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", DtTemp, "CODE_ID", "CODE_NAME");
            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (StatusCheck == false)
            {
                base.DoInquire();
                string plantcode = Convert.ToString(this.cboPlantCode_H.Value);
                if (plantcode == null)
                    plantcode = "";
                string linecode = Convert.ToString(this.txtLineCode_H.Value);
                if (linecode == null)
                    linecode = "";
                string itemcode = Convert.ToString(this.txtItemCode_H.Value);
                if (itemcode == null)
                    itemcode = "";

                _GridUtil.Grid_Clear(grid1);

                DtTemp = USP_BM7600_S1(plantcode, linecode, itemcode);

                grid1.DataSource = DtTemp;
                grid1.DataBind();

                DtGrid1 = DtTemp;

                if (DtTemp.Rows.Count == 0)
                {
                    _GridUtil.Grid_Clear(this.grid1);
                    _GridUtil.Grid_Clear(this.grid2);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                    return;
                }

                StatusCheck = true;
                this.grid1.GetRow();
            }
            else
            {
                #region 그리드 상테에서 삭제 신규나, 수정의 상태 변경을 찾아 메세지 경고를 보여줌
                if (UltraGridUtil.CheckSearchDataGrid(this, this.grid1, this.DtGrid1, false) == true)
                {
                    DialogResult result = MessageBox.Show("자료를 저장하지 않았습니다. \n\r\n\r저장하지 않고 검색하겠습니까?", "변경데이터 있음", MessageBoxButtons.OKCancel);
                    if (result != DialogResult.OK)
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
                #endregion
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            return;
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            int frow = 0;
            int erow = 0;
            for (int k = 0; k < this.grid2.Rows.Count; k++)
            {
                if (grid2.Rows[k].Selected)
                {
                    if (grid2.Rows[k].Cells["Flag"].Value.ToString() == "O")
                    {
                        grid2.Rows[k].Cells["Flag"].Value = "X";
                        grid2.Rows[k].Hidden = true;
                        if (erow == 0) frow = grid2.Rows[k].Index;
                        erow = grid2.Rows[k].Index;
                    }
                    else grid2.Rows[k].Selected = false;
                }
            }
            if (this.grid2.Rows[erow] != null) this.grid2.Rows[erow].Activate();
            else
            {
                if (this.grid2.Rows[frow - 1] != null)
                {
                    this.grid2.Rows[frow - 1].Activate();
                }
                else this.grid2.Rows[0].Activate();
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            try
            {
                base.DoSave();
                this.grid1.SetRow();
                this.grid2.GetRow();

                this.grid1.PerformAction(UltraGridAction.DeactivateCell);

                if (UltraGridUtil.CheckSaveDataGrid(this, this.grid2, DtGrid2, true) == true)
                {
                    USP_BM7600_CRUD(DtGrid2, this.WorkerID);
                    StatusCheck = false;
                }
                else
                {
                    StatusCheck = true;
                }
            }
            catch (SException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }

        public override void DoDownloadExcel()
        {
            if (this.grid2.Rows.Count == 0)
            {

                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            this.grid2.ExportExcel();
            base.DoDownloadExcel();
        }
        #endregion

        #region < EVENT AREA >

        // grid1의 행을 선택할 때마다 grid1의 코드를 기준으로 grid2의 행이 변함.
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            string plantcode = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
            if (plantcode == null)
                plantcode = "";
            string linecode = Convert.ToString(grid1.ActiveRow.Cells["LineCode"].Value);
            if (linecode == null)
                linecode = "";
            string itemcode = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);
            if (itemcode == null)
                itemcode = "";


            DtTemp = USP_BM7600_S2(plantcode, linecode, "", itemcode);

            if (DtTemp.Rows.Count > 0)
            {
                grid2.DataSource = DtTemp;
                grid2.DataBind();

                DtGrid2 = DtTemp;
                StatusCheck = true;

                tcrInspDetail.Enabled = true;
            }
            else
            {
                _GridUtil.Grid_Clear(this.grid2);
                tcrInspDetail.Enabled = false;
            }

            this.grid2.GetRow();
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            string enter = e.KeyCode.ToString();
            if (enter == "Return")
            {
                Infragistics.Win.UltraWinGrid.GridKeyActionMapping KeyMapping1 = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Tab, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0);
                this.grid1.KeyActionMappings.Add(KeyMapping1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            }
        }

        /// <summary>
        /// 라인코드 팝업창
        /// </summary>
        private void txtLineCode_H_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = Convert.ToString(this.cboPlantCode_H.Value);
            if (plantcode == null)
                plantcode = "";


        }
        //라인코드 변경시 라인명 클리어
        private void txtLineCode_H_ValueChanged(object sender, EventArgs e)
        {
            this.txtLineName_H.Text = string.Empty;
        }

        //공정코드 변경시 공정명 클리어
        private void txtOPCode_H_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 품목 팝업창
        /// </summary>
        private void txtItemCode_H_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = Convert.ToString(this.cboPlantCode_H.Value);
            if (plantcode == null)
                plantcode = "";

        }
        //품목 변경시 품목명 클리어
        private void txtItemCode_H_ValueChanged(object sender, EventArgs e)
        {
            this.txtItemName_H.Text = string.Empty;
        }

        /// <summary>
        /// 입력창의 품목 팝업창
        /// </summary>
        private void txtItemCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            if (txtLineCode.Text == "")
            {

                this.ShowDialog(Common.getLangText("라인코드를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

        }

        /// <summary>
        /// 입력창의 공정코드 팝업창
        /// </summary>
        private void txtOPCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            string linecode = (string)this.txtLineCode.Value;
            if (linecode == null)
                linecode = "";


        }
        //공정코드 변경시 공정명 클리어
        private void txtOPCode_ValueChanged(object sender, EventArgs e)
        {
            if (!((txtLineCode.Focused) || (txtOPCode.Focused))) return;
            this.txtOPName.Text = string.Empty;
        }

        /// <summary>
        /// 입력창의 측정기 팝업창
        /// </summary>
        private void txtUsrMeasureEquID_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            string linecode = (string)this.txtLineCode.Value;
            if (linecode == null)
                linecode = "";
            string opcode = (string)this.txtOPCode.Value;
            if (opcode == null)
                opcode = "";
            string beforeMACHID = this.txtMeasureEquID.Text;

            if (beforeMACHID != this.txtMeasureEquID.Text)
            {
                this.txtIFDataID.Text = string.Empty;
                this.txtComPort.Text = string.Empty;
                this.txtSEQ.Text = string.Empty;
            }
        }
        //측정기 코드 변경시 측정기명 클리어
        private void txtUsrMeasureEquID_ValueChanged(object sender, EventArgs e)
        {
            if (!txtUsrMeasureEquID.Focused) return;
            this.txtMeasureEquName.Text = string.Empty;
            this.txtIFDataID.Text = string.Empty;
            this.txtComPort.Text = string.Empty;
            this.txtSEQ.Text = string.Empty;
            this.txtMeasureEquID.Text = string.Empty;
            this.txtDapointID.Text = string.Empty;
        }

        /// <summary>
        /// 입력창의 IFDataID 팝업창
        /// </summary>
        private void txtIFDataID_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null || plantcode == "")
            {

                this.ShowDialog(Common.getLangText("사업장을 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                cboPlantCode.Focus();
                return;
            }
            string measureEquID = (string)this.txtMeasureEquID.Value;
            if (measureEquID == null || measureEquID == "")
            {

                this.ShowDialog(Common.getLangText("측정기 ID를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                txtUsrMeasureEquID.Focus();
                return;
            }

        }


        //공정코드 팝업
        private void txtIIOPCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            string linecode = (string)this.txtLineCode.Value;
            if (linecode == null)
                linecode = "";
            System.Windows.Forms.Control txtlinecode = new System.Windows.Forms.Control();
            System.Windows.Forms.Control txtlinename = new System.Windows.Forms.Control();

        }
        private void txtIIOPCode_ValueChanged(object sender, EventArgs e)
        {
            if (!txtIIOPCode.Focused) return;
            txtIIOPName.Text = "";
        }

        /// <summary>
        /// IFDataID 텍스트 입력 제한
        /// </summary>
        private void txtIFDataID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// 텍스트로 숫자만 입력 가능(소숫점 하나 허용)
        /// </summary>
        private void txtSPEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).Text.Length > 0 && !((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).Text.Contains("."))
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar('.')))
                {
                    if (e.KeyChar == Convert.ToChar('-'))
                    {
                        if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).SelectionStart != 0 && !((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).Text.Contains("-"))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    e.Handled = true;
                }
            }
            else
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
                {
                    if (e.KeyChar == Convert.ToChar('-'))
                    {
                        if (((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).SelectionStart == 0 && !((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).Text.Contains("-"))
                        {
                            return;
                        }
                    }
                    e.Handled = true;
                }
            }
        }

        //시료수 값으로 숫자만 입력 허용
        private void txtSampleQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                e.Handled = true;
            }
        }


        //도면 팝업창
        private void txtDWNO_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;

            string linecode = (string)this.txtLineCode.Value;

            string opcode = (string)this.txtOPCode.Value;
            if (opcode == null)
                opcode = "";

            string itemcode = grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            if (itemcode == null)
                itemcode = "";

            System.Windows.Forms.Control DWName = new System.Windows.Forms.Control();

        }

        //측정 방법 변경에 따른 측정값구분 변경
        private void cboMeasureType_ValueChanged(object sender, EventArgs e)
        {
            if (!cboMeasureType.Focused) return;
            string type = this.cboMeasureType.Value == null ? "" : this.cboMeasureType.Value.ToString();
            switch (type)
            {
                case "A":
                    this.cboInspValType.Value = "V";
                    break;
                case "M":
                    this.cboInspValType.Value = "J";
                    break;
                default:
                    this.cboInspValType.Value = null;
                    break;
            }
        }

        private void txtSPEC_AfterEnterEditMode(object sender, EventArgs e)
        {
            ((Infragistics.Win.UltraWinEditors.UltraTextEditor)(sender)).SelectAll();
        }

        private void txtUsrMeasureEquID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                this.txtUsrMeasureEquID.Text = string.Empty;
                this.txtMeasureEquName.Text = string.Empty;
                this.txtIFDataID.Text = string.Empty;
                this.txtComPort.Text = string.Empty;
                this.txtSEQ.Text = string.Empty;
                this.txtMeasureEquID.Text = string.Empty;
                this.txtDapointID.Text = string.Empty;
            }
        }

        #region < SPEC INFO COPY >
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            {

                this.ShowDialog(Common.getLangText("선택된 행이 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            string linecode = grid1.ActiveRow.Cells["LineCode"].Value.ToString();
            string linename = grid1.ActiveRow.Cells["LineName"].Value.ToString();
            string itemcode = grid1.ActiveRow.Cells["ItemCode"].Value.ToString();
            string itemname = grid1.ActiveRow.Cells["ItemName"].Value.ToString();


        }
        #endregion

        #endregion

        #region <METHOD AREA>
        /// <summary>
        /// 행의 신규 등록시 오류 CHECK
        /// </summary>
        private void DoNewValidate(DataRow row)
        {
            string missItem = string.Empty;
            bool iiUseFlag = false;
            // 입력항목에 대한 VALIDATION CHECK
            if (row["InspCode"].ToString() == "")
            {
                missItem = grid1.DisplayLayout.Bands[0].Columns["InspCode"].Header.Caption;
                focusItem = txtInspCode;
            }
            else if (row["LineCode"].ToString() == "")
            {
                missItem = grid1.DisplayLayout.Bands[0].Columns["LineCode"].Header.Caption;
                focusItem = txtLineCode;
            }
            else if (row["InspItem"].ToString() == "")
            {
                missItem = grid1.DisplayLayout.Bands[0].Columns["InspItem"].Header.Caption;
                focusItem = txtInspItem;
            }
            else if (row["IIFlag"].ToString() == "Y")
            {
                iiUseFlag = true;
                if (row["IIOPCode"].ToString() == "")
                {
                    missItem = lblIIOPCode.Text;
                    focusItem = txtIIOPCode;
                }
                if (row["MGTFlag"].ToString() == "")
                {
                    missItem = lblMGTFlag.Text;
                    focusItem = cboMGTGlag;
                }
                if (row["DWInternalID"].ToString() == "")
                {
                    missItem = lblDWNO.Text;
                    focusItem = txtDWNO;
                }
                if (row["InspCnt"].ToString() == "")
                {
                    missItem = lblInspCycle2.Text;
                    focusItem = txtInspCnt2;
                }
                if (row["InspTime"].ToString() == "")
                {
                    missItem = lblInspCycle2.Text;
                    focusItem = txtInspTime;
                }
            }

            if (missItem != "")
            {
                if (iiUseFlag)
                {
                    tcrInspDetail.SelectedTab = tcrInspDetail.Tabs[2];
                }

                focusItem.Focus();
                row.RowError = this.FormInformation.GetMessage(missItem);


                //this.ShowDialog("C:R00000", WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < GRID2 ROW ACTIVATE >
        private void grid2_ClickCell_1(object sender, EventArgs e)
        {
            if (grid2.ActiveRow.Cells["RevisionCode"].Text == string.Empty) cboRevisionFlag.Enabled = false;
            else cboRevisionFlag.Enabled = true;

            #region 측정방법
            //공장
            cboPlantCode.DataBindings.Clear();
            cboPlantCode.DataBindings.Add("Value", DtGrid2, "PLANTCODE");
            //라인
            txtLineCode.DataBindings.Clear();
            txtLineName.DataBindings.Clear();
            txtLineCode.DataBindings.Add("Value", DtGrid2, "LINECODE");
            txtLineName.DataBindings.Add("Value", DtGrid2, "LINENAME");
            //검사항목
            txtInspCode.DataBindings.Clear();
            txtInspName.DataBindings.Clear();
            txtInspCode.DataBindings.Add("Value", DtGrid2, "INSPCODE");
            txtInspName.DataBindings.Add("Value", DtGrid2, "INSPNAME");

            //측정항목
            txtInspItem.DataBindings.Clear();
            txtInspItemName.DataBindings.Clear();
            txtInspItem.DataBindings.Add("Value", DtGrid2, "INSPITEM");
            txtInspItemName.DataBindings.Add("Value", DtGrid2, "INSPITEMNAME");

            //통계 적용여부
            cboUseFlag.DataBindings.Clear();
            cboUseFlag.DataBindings.Add("Value", DtGrid2, "STATSAPPLYFLAG");
            //이상발생 관리여부
            cboCriticalApplyFlag.DataBindings.Clear();
            cboCriticalApplyFlag.DataBindings.Add("Value", DtGrid2, "CRITICALAPPLYFLAG");
            //시료수
            txtSampleQTY.DataBindings.Clear();
            txtSampleQTY.DataBindings.Add("Value", DtGrid2, "SAMPLEQTY");
            //측정방법
            cboMeasureType.DataBindings.Clear();
            cboMeasureType.DataBindings.Add("Value", DtGrid2, "MEASURETYPE");
            //측정값구분
            cboInspValType.DataBindings.Clear();
            cboInspValType.DataBindings.Add("Value", DtGrid2, "INSPVALTYPE");
            //측정기
            txtUsrMeasureEquID.DataBindings.Clear();
            txtUsrMeasureEquID.DataBindings.Add("Value", DtGrid2, "USRMEASUREEQUID");
            //IFDataID
            txtIFDataID.DataBindings.Clear();
            txtIFDataID.DataBindings.Add("Value", DtGrid2, "IFDATAID");
            //SEQ
            txtSEQ.DataBindings.Clear();
            txtSEQ.DataBindings.Add("Value", DtGrid2, "SEQNO");
            //측정포트
            txtComPort.DataBindings.Clear();
            txtComPort.DataBindings.Add("Value", DtGrid2, "COMPORT");
            #endregion

            #region 검사정보
            //규격
            txtSPEC.DataBindings.Clear();
            txtSPEC.DataBindings.Add("Value", DtGrid2, "SPEC");
            //하한공차
            txtLTolVal.DataBindings.Clear();
            txtLTolVal.DataBindings.Add("Value", DtGrid2, "LTOLVAL");
            //상환공차
            txtUTolVal.DataBindings.Clear();
            txtUTolVal.DataBindings.Add("Value", DtGrid2, "UTOLVAL");
            //SPEC적용기준
            cboSpecType.DataBindings.Clear();
            cboSpecType.DataBindings.Add("Value", DtGrid2, "SPECTYPE");
            //검사주기
            cboInspCycle.DataBindings.Clear();
            cboInspCycle.DataBindings.Add("Value", DtGrid2, "INSPCYCLE");
            //검사횟수
            txtInspCnt.DataBindings.Clear();
            txtInspCnt.DataBindings.Add("Value", DtGrid2, "INSPCNT");
            //Hivis
            cboHivis.DataBindings.Clear();//HIVISFLAG
            cboHivis.DataBindings.Add("Value", DtGrid2, "HIVISFLAG");
            //Hipis
            cboHipis.DataBindings.Clear();
            cboHipis.DataBindings.Add("Value", DtGrid2, "HIPISFLAG");
            //자주검사
            cboIIFlag.DataBindings.Clear();
            cboIIFlag.DataBindings.Add("Value", DtGrid2, "IIFLAG");
            //공정검사
            cboPIFlag.DataBindings.Clear();
            cboPIFlag.DataBindings.Add("Value", DtGrid2, "PIFLAG");
            //XML전송기준
            cboXMLJudgeType.DataBindings.Clear();
            cboXMLJudgeType.DataBindings.Add("Value", DtGrid2, "XMLJUDGETYPE");
            //작업표준서 표기여부
            cboDisplayFlag.DataBindings.Clear();
            cboDisplayFlag.DataBindings.Add("Value", DtGrid2, "DISPLAYFLAG");
            //LSL
            txtLSL.DataBindings.Clear();
            txtLSL.DataBindings.Add("Value", DtGrid2, "LSL");
            //USL
            txtUSL.DataBindings.Clear();
            txtUSL.DataBindings.Add("Value", DtGrid2, "USL");
            //CL
            txtCL.DataBindings.Clear();
            txtCL.DataBindings.Add("Value", DtGrid2, "CL");
            //UCL
            txtUCL.DataBindings.Clear();
            txtUCL.DataBindings.Add("Value", DtGrid2, "UCL");
            //LCL
            txtLCL.DataBindings.Clear();
            txtLCL.DataBindings.Add("Value", DtGrid2, "LCL");
            //CARRIERFLAG
            cboCarrierFlag.DataBindings.Clear();
            cboCarrierFlag.DataBindings.Add("Value", DtGrid2, "CARRIERFLAG");
            //VALTYPE
            cboValType.DataBindings.Clear();
            cboValType.DataBindings.Add("Value", DtGrid2, "VALTYPE");
            //TOLTYPE
            txtTolType.DataBindings.Clear();
            txtTolType.DataBindings.Add("Value", DtGrid2, "TOLTYPE");
            //RUCL
            txtRUCL.DataBindings.Clear();
            txtRUCL.DataBindings.Add("Value", DtGrid2, "R_UCL");
            //RLCL
            txtRLCL.DataBindings.Clear();
            txtRLCL.DataBindings.Add("Value", DtGrid2, "R_LCL");
            #endregion

            #region 자주검사
            //자주검사 공정코드
            txtIIOPCode.DataBindings.Clear();
            txtIIOPCode.DataBindings.Add("Value", DtGrid2, "IIOPERCODE");
            //자주검사ㅏ공정명
            txtIIOPName.DataBindings.Clear();
            txtIIOPName.DataBindings.Add("Value", DtGrid2, "IIOPCODENAME");
            //도면
            txtDWNO.DataBindings.Clear();
            txtDWNO.DataBindings.Add("Value", DtGrid2, "DWNO");
            //담당
            cboMGTGlag.DataBindings.Clear();
            cboMGTGlag.DataBindings.Add("Value", DtGrid2, "MGTFLAG");
            //보정식
            cboRevisionFlag.DataBindings.Clear();
            cboRevisionFlag.DataBindings.Add("Value", DtGrid2, "REVISIONFLAG");
            //보정여부
            txtRevisionFormula.DataBindings.Clear();
            txtRevisionFormula.DataBindings.Add("Value", DtGrid2, "REVISIONFORMULA");
            //검사주기 몇회
            txtInspCnt2.DataBindings.Clear();
            txtInspCnt2.DataBindings.Add("Value", DtGrid2, "INSPCNT");
            //검사주기 시간
            txtInspTime.DataBindings.Clear();
            txtInspTime.DataBindings.Add("Value", DtGrid2, "INSPTIME");
            //비고
            txtRemarks.DataBindings.Clear();
            txtRemarks.DataBindings.Add("Value", DtGrid2, "REMARKS");
            #endregion
        }
        #endregion

        #region < GRID2 CLICK >
        private void grid2_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.Key == "Icheck")
            {
                if (this.grid2.ActiveRow.Cells["Icheck"].Value.ToString() == "True")
                {
                    if (this.grid2.ActiveRow.Cells["InspItemName"].Value != null)
                        this.grid2.ActiveRow.Cells["InspItemReName"].Value = null;


                    this.grid2.ActiveRow.Cells["Icheck"].Value = "false";
                }
                else
                {
                    if (this.grid2.ActiveRow.Cells["InspItemReName"].Value.ToString() == "")
                        if (this.grid2.ActiveRow.Cells["InspItemName"].Value.ToString() != "")
                            this.grid2.ActiveRow.Cells["InspItemReName"].Value = this.grid2.ActiveRow.Cells["InspItemName"].Value.ToString();

                    this.grid2.ActiveRow.Cells["Icheck"].Value = "true";
                }
            }
        }
        #endregion

        #region 품목별 검사기준관리 조회

        private DataTable USP_BM7600_S1(string AS_PLANTCODE, string AS_LINECODE, string AS_ITEMCODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_BM7600_S1N", CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE", AS_ITEMCODE, DbType.String, ParameterDirection.Input));


                return rtnDtTemp;
            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region 품목별 검사기준관리 조회  (상세)

        private DataTable USP_BM7600_S2(string AS_PLANTCODE, string AS_LINECODE, string AS_OPERCODE, string AS_ITEMCODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_BM7600_S2N", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("OPERCODE", AS_OPERCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("ITEMCODE", AS_ITEMCODE, DbType.String, ParameterDirection.Input));


                return rtnDtTemp;
            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region 저장/수정/삭제
        public void USP_BM7600_CRUD(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            #region [수정]

                            helper.ExecuteNoneQuery("USP_BM7600_I2N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INTERALID", Convert.ToString(drRow["INTERALID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPERCODE", Convert.ToString(drRow["OPERCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IIOPERCODE", Convert.ToString(drRow["IIOPERCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DWINTERNALID", Convert.ToString(drRow["DWINTERNALID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DWNO", Convert.ToString(drRow["DWNO"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STATSAPPLYFLAG", Convert.ToString(drRow["STATSAPPLYFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALAPPLYFLAG", Convert.ToString(drRow["CRITICALAPPLYFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPITEM", Convert.ToString(drRow["INSPITEM"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATAID", Convert.ToString(drRow["IFDATAID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SEQNO", Convert.ToString(drRow["SEQNO"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SPEC", Convert.ToDecimal(drRow["SPEC"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USL", Convert.ToDecimal(drRow["USL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LSL", Convert.ToDecimal(drRow["LSL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CL", Convert.ToDecimal(drRow["CL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LTOLVAL", Convert.ToDecimal(drRow["LTOLVAL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UTOLVAL", Convert.ToDecimal(drRow["UTOLVAL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SPECTYPE", Convert.ToString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CALIBRATIONFLAG", Convert.ToString(drRow["CALIBRATIONFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CALIBRATIONTYPE", Convert.ToString(drRow["CALIBRATIONTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CALIBRATION", Convert.ToString(drRow["CALIBRATION"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("GRAPHTYPE", Convert.ToString(drRow["GRAPHTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SAMPLEQTY", Convert.ToDecimal(drRow["SAMPLEQTY"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("UCL", Convert.ToDecimal(drRow["UCL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LCL", Convert.ToDecimal(drRow["LCL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASURETYPE", Convert.ToString(drRow["MEASURETYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPVALTYPE", Convert.ToString(drRow["INSPVALTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REVISIONFLAG", Convert.ToString(drRow["REVISIONFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCNT", Convert.ToDecimal(drRow["INSPCNT"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPTIME", Convert.ToDecimal(drRow["INSPTIME"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCYCLE", Convert.ToDecimal(drRow["INSPCYCLE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MGTFLAG", Convert.ToString(drRow["MGTFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HIVISFLAG", Convert.ToString(drRow["HIVISFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HIPISFLAG", Convert.ToString(drRow["HIPISFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DISPLAYFLAG", Convert.ToString(drRow["DISPLAYFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IIFLAG", Convert.ToString(drRow["IIFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PIFLAG", Convert.ToString(drRow["PIFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SPCFLAG", Convert.ToString(drRow["SPCFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAPOINTID", Convert.ToString(drRow["DAPOINTID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("XMLJUDGETYPE", Convert.ToString(drRow["XMLJUDGETYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("VALTYPE", Convert.ToString(drRow["VALTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CARRIERFLAG", Convert.ToString(drRow["CARRIERFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TOLTYPE", Convert.ToString(drRow["TOLTYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("R_UCL", Convert.ToString(drRow["R_UCL"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("R_LCL", Convert.ToString(drRow["R_LCL"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();

                helper.Commit();
            }
            catch (Exception ex)
            {

                helper.Rollback();


                WIZ.Forms.CheckForm checkform = new Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region<btnInfoModi_Click>
        private void btnInfoModi_Click(object sender, EventArgs e)
        {
            if (grid2.Rows.Count == 0 || grid2.ActiveRow == null) return;

            string plantcode = grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            string linecode = grid2.ActiveRow.Cells["LINECODE"].Value.ToString();
            string itemcode = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            string inspcode = grid2.ActiveRow.Cells["INSPCODE"].Value.ToString();
            string inspname = grid2.ActiveRow.Cells["INSPNAME"].Value.ToString();
            string inspitem = grid2.ActiveRow.Cells["INSPITEM"].Value.ToString();
            string inspitemname = grid2.ActiveRow.Cells["INSPITEMNAME"].Value.ToString();
            string spec = this.txtSPEC.Text;
            string utolval = this.txtUTolVal.Text;
            string ltolval = this.txtLTolVal.Text;
            string ucl = this.txtUCL.Text;
            string lcl = this.txtLCL.Text;
            string rucl = this.txtRUCL.Text;
            string rlcl = this.txtRLCL.Text;


        }
        #endregion

    }
}
