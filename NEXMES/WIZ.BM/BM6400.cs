#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6400
//   Form Name    : 품목코드 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-06-08
//   Made By      : WIZCORE
//   Description  : 기준정보 ( 품목 마스터 ) 정보 관리 폼 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        private bool GridSaveFlagCheck = false;
        #endregion

        #region < CONSTRUCTOR >
        public BM6400()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager bizGrid = new BizGridManager(grid2);
            bizGrid.PopUpAdd("INSPCODE", "INSPNAME", "TBM6000", new string[] { "", "" }); //검사항목
            bizGrid.PopUpAdd("INSPITEM", "INSPITEMNAME", "TBM6010", new string[] { "INSPCODE", "" }); //검사항목별 측정항목
        }
        #endregion

        #region 폼 초기화

        private void BM6400_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATAID", "레코드ID", true, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATANAME", "레코드명", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFRECORDTYPE", "레코드 유형", false, GridColDataType_emu.VarChar, 123, 5, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECORDLEN", "레코드 길이", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEHEADERLINE", "헤더라인수", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DELIMITER", "구분자", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAGID", "TagID", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid2, "IFDATAID", "레코드ID", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SEQNO", "일련번호", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DAITEM", "수집항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DAITEMNAME", "수집항목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEM", "측정항목", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEMNAME", "측정항목명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INTERVALS", "시작점", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INTERVALLEN", "데이터길이", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILETYPE", "파일유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DATATYPE", "데이터유형", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RCVDATATYPE", "자주검사데이터유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PROCGB", "관리구분", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PROCTYPE", "계산유형", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DATALEN", "데이터길이", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FORMAT", "형식", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "POSITION", "위치", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PRECISION", "정밀도", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLCADDR", "PLC ADDR", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TAGID", "TAGID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARKS", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "", false, GridColDataType_emu.DateTime24, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "", false, GridColDataType_emu.DateTime24, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            this.grid2.DisplayLayout.Bands[0].Columns["INSPCODE"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            this.grid2.DisplayLayout.Bands[0].Columns["INSPITEM"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            this.grid2.DisplayLayout.Bands[0].Columns["SEQNO"].Format = "#,###";
            this.grid2.DisplayLayout.Bands[0].Columns["PRECISION"].Format = "#,###";

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            //grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.SetInitUltraGridBind(grid2);
            #region 콤보박스
            Common _Common = new Common();

            rtnDtTemp = _Common.GET_BM0000_CODE("SPCDATATYPE");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "DATATYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PROCGB");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PROCGB", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("SPCPROCTYPE");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PROCTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);
            this._GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                string sIfDataId = txtIfDataId.Text;
                string sRecordName = txtIfDataName.Text;
                grid1.DataSource = helper.FillTable("USP_BM6400_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("IFDATAID", sIfDataId, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("IFDATANAME", sRecordName, DbType.String, ParameterDirection.Input)
                                                                    );

                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            DBHelper helper = new DBHelper(false);
            try
            {
                string sIfDataId = this.grid1.ActiveRow.Cells["IFDATAID"].Value.ToString();

                grid2.DataSource = helper.FillTable("USP_BM6400_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("IFDATAID", sIfDataId, DbType.String, ParameterDirection.Input)
                                                                    );

                grid2.DataBinds();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                // grid1 의 row 는 한줄만 추가 가능 
                base.DoNew();
                if (this.grid2.IsActivate)
                {
                    if (this.grid1.Rows.Count == 0) return;
                    _GridUtil.AddRow(this.grid2);

                    this.grid2.ActiveRow.Cells["DAItem"].Value = "*";
                    this.grid2.ActiveRow.Cells["DAItemName"].Value = "*";
                    this.grid2.ActiveRow.Cells["IntervalS"].Value = 0;
                    this.grid2.ActiveRow.Cells["IntervalLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["ProcGB"].Value = 1;
                    this.grid2.ActiveRow.Cells["ProcType"].Value = "VAL";
                    this.grid2.ActiveRow.Cells["DataLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["Position"].Value = 0;
                    this.grid2.ActiveRow.Cells["Precision"].Value = 0;
                }
                else
                {
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["IFDATAID"].Value.ToString() == "")
                        {
                            return;
                        }
                    }
                    _GridUtil.AddRow(this.grid1);
                    _GridUtil.AddRow(this.grid2);

                    this.grid2.ActiveRow.Cells["DAItem"].Value = "*";
                    this.grid2.ActiveRow.Cells["DAItemName"].Value = "*";
                    this.grid2.ActiveRow.Cells["IntervalS"].Value = 0;
                    this.grid2.ActiveRow.Cells["IntervalLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["ProcGB"].Value = 1;
                    this.grid2.ActiveRow.Cells["ProcType"].Value = "VAL";
                    this.grid2.ActiveRow.Cells["DataLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["Position"].Value = 0;
                    this.grid2.ActiveRow.Cells["Precision"].Value = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            if (this.grid1.IsActivate)
            {
                this.grid1.DeleteRow();
                if (this.grid1.Rows.Count == 0) return;
                else this.grid1.Rows[0].Activated = true;
            }
            else
            {
                this.grid2.DeleteRow();
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (dt != null)
                {
                    if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        CancelProcess = true;
                        return;
                    }

                    base.DoSave();

                    foreach (DataRow drRow in dt.Rows)
                    {

                        switch (drRow.RowState)
                        {
                            case DataRowState.Deleted:
                                #region 삭제
                                drRow.RejectChanges();
                                helper.ExecuteNoneQuery("USP_BM6400_D1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_SEQNO", "", DbType.String, ParameterDirection.Input)
                                                        );
                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가

                                #endregion
                                break;
                            case DataRowState.Modified:
                                #region 수정
                                helper.ExecuteNoneQuery("USP_BM6400_U1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_IFDATANAME", drRow["IFDATANAME"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_IFRECORDTYPE", drRow["IFRECORDTYPE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                        }
                        if (helper.RSCODE != "S")
                            grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    }
                }



                // GRID2 등록
                dt = grid2.chkChange();
                string sIfDataId = this.grid1.ActiveRow.Cells["IFDATAID"].Value.ToString();
                if (dt != null)
                {
                    foreach (DataRow drRow2 in dt.Rows)
                    {
                        switch (drRow2.RowState)
                        {
                            case DataRowState.Deleted:
                                #region 삭제
                                drRow2.RejectChanges();
                                string sSeqNo = drRow2["SEQNO"].ToString();
                                helper.ExecuteNoneQuery("USP_BM6400_D1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_IFDATAID", sIfDataId, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_SEQNO", sSeqNo, DbType.String, ParameterDirection.Input)
                                                        );

                                drRow2.Delete();
                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가
                                // IFRECODR 공통 등록
                                if (sIfDataId == "")
                                {
                                    helper.ExecuteNoneQuery("USP_BM6400_I1N", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_IFDATANAME", this.grid1.ActiveRow.Cells["IFDATANAME"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_IFRECORDTYPE", this.grid1.ActiveRow.Cells["IFRECORDTYPE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                           );
                                    if (helper.RSCODE == "S")
                                    {
                                        sIfDataId = helper.RSMSG;
                                    }
                                    else
                                    {
                                        this.ClosePrgFormNew();
                                        helper.Rollback();
                                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                        return;
                                    }
                                }
                                // IFRECORD 상세 등록
                                if (sIfDataId != "")
                                {
                                    helper.ExecuteNoneQuery("USP_BM6400_I2N", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_IFDATAID", sIfDataId, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DAITEM", drRow2["DAITEM"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", drRow2["INSPCODE"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPITEM", drRow2["INSPITEM"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DAITEMNAME", drRow2["DAITEMNAME"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INTERVALS", drRow2["INTERVALS"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INTERVALLEN", drRow2["INTERVALLEN"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FILETYPE", drRow2["FILETYPE"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DATATYPE", drRow2["DATATYPE"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_RCVDATATYPE", drRow2["RCVDATATYPE"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PROCGB", drRow2["PROCGB"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PROCTYPE", drRow2["PROCTYPE"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DATALEN", drRow2["DATALEN"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FORMAT", drRow2["FORMAT"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_POSITION", drRow2["POSITION"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PRECISION", drRow2["PRECISION"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLCADDR", drRow2["PLCADDR"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAGID", drRow2["TAGID"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_REMARKS", drRow2["REMARKS"], DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                            );

                                }
                                if (helper.RSCODE != "S")
                                {
                                    this.ClosePrgFormNew();
                                    helper.Rollback();
                                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                    return;
                                }

                                #endregion
                                break;
                            case DataRowState.Modified:
                                #region 수정
                                helper.ExecuteNoneQuery("USP_BM6400_U2N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_IFDATAID", sIfDataId, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_IFSEQNO", drRow2["SEQNO"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_DAITEM", drRow2["DAITEM"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_INSPCODE", drRow2["INSPCODE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_INSPITEM", drRow2["INSPITEM"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_DAITEMNAME", drRow2["DAITEMNAME"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_INTERVALS", drRow2["INTERVALS"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_INTERVALLEN", drRow2["INTERVALLEN"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_FILETYPE", drRow2["FILETYPE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_DATATYPE", drRow2["DATATYPE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_RCVDATATYPE", drRow2["RCVDATATYPE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_PROCGB", drRow2["PROCGB"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_PROCTYPE", drRow2["PROCTYPE"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_DATALEN", drRow2["DATALEN"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_FORMAT", drRow2["FORMAT"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_POSITION", drRow2["POSITION"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_PRECISION", drRow2["PRECISION"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_PLCADDR", drRow2["PLCADDR"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_TAGID", drRow2["TAGID"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_REMARKS", drRow2["REMARKS"], DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                        }
                        if (helper.RSCODE != "S")
                            grid2.SetRowError(drRow2, helper.RSMSG, helper.RSCODE);
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), DialogForm.DialogType.OK);  // 데이터가 저장되었습니다.
                    DoInquire();
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["IFDATAID"].Value.ToString() == sIfDataId)
                        {
                            this.grid1.Rows[i].Cells["IFDATAID"].Activated = true;
                            return;
                        }
                    }
                }
                else
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
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

        #region<Grid1ToolAct>
        private void Grid1ToolAct(string sIfDataId)
        {

        }
        #endregion

        #region<Grid2ToolAct>
        private void Grid2ToolAct(string sIfDataId)
        {

        }

        #endregion

    }
}