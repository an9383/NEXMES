#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0480
//   Form Name    : 작업장별 설비점검항목관리
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-24
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 설비점검 내역 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0480 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0480()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0480_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목별 검사항목 (GRID1은 우측에 위치한 MAIN GRID!)
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKCODE", "점검항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKNAME", "점검항목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKCYCLE", "점검주기", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "IMG", "이미지", true, GridColDataType_emu.Image, 0, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKCYCLE"].Header.Appearance.ForeColor = Color.SkyBlue;

                //GRID2 작업장 (GRID2는 좌측 상단 첫번쨰 GRID) (MAIN GRID를 제외한 GRID는 사업장 / 코드 / 코드명 만 출력) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 175, 130, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                //GRID3 점검항목 (GRID3는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid3, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MACHKCODE", "검사항목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MACHKNAME", "검사항목명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("MACHKCYCLE"); //점검주기
                WIZ.Common.FillComboboxMaster(this.cbo_MACHKCYCLE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHKCYCLE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });

                //검사항목
                btbManager.PopUpAdd(txt_MACHKCODE_H, txt_MACHKNAME_H, "BM0460", new object[] { cbo_PLANTCODE_H, cbo_USEFLAG_H });

                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화
            pic_IMAGE_B.Image = null;

            base.DoInquire();

            //조회항목에서 선택된 값 GET
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sMachkCode = DBHelper.nvlString(txt_MACHKCODE_H.Text.Trim());
            string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
            string sMachkCycle = DBHelper.nvlString(cbo_MACHKCYCLE_H.Value);
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            DBHelper helper = new DBHelper(false);

            //GRID2 작업장 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0480_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

            //GRID3 점검항목 조회
            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0480_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            // 좌측 매칭할 정보들이 선택되어 있는지 확인
            if (grid2.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("작업장을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else if (grid3.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("점검항목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //해당 TABLE의 기본키및 명칭은 좌측 GRID에서 선택된 정보들을 GRID1의 해당 컬럼에 BINDING
                //GRID2의 정보
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERCODE"].Value);
                this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERNAME"].Value);
                //GRID3의 정보
                this.grid1.ActiveRow.Cells["MACHKCODE"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["MACHKCODE"].Value);
                this.grid1.ActiveRow.Cells["MACHKNAME"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["MACHKNAME"].Value);

                //사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //행 추가시 기본이미지를 세팅
                this.grid1.ActiveRow.Cells["IMG"].Value = ConvertImageToByteArray(Properties.Resources.Default_Image);

                grid1.UpdateData();

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치 (좌측에서 받아온 값도 수정이 안되도록 해야함)
                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKCENTERCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKCENTERNAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MACHKCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MACHKNAME"].Activation = Activation.NoEdit;

                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow(); //신규로 추가된 행을 제거하는 용도로 사용
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

            DateTime dtNow = DateTime.Now;

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (DBHelper.nvlString(drRow["MACHKCYCLE"]) == "")
                        {
                            this.ShowDialog(Common.getLangText("점검주기는 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0480_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHKCODE", DBHelper.nvlString(drRow["MACHKCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHKCYCLE", DBHelper.nvlString(drRow["MACHKCYCLE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AB_IMG", drRow["IMG"], DbType.Binary, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0480_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHKCODE", DBHelper.nvlString(drRow["MACHKCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHKCYCLE", DBHelper.nvlString(drRow["MACHKCYCLE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();

            BM0480_EXCEL bm0480_excel = new BM0480_EXCEL();
            bm0480_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        //GRID1 조회 (GRID1은 항상 GRID2의 ROW를 더블클릭할때 바인딩함)
        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화     
            pic_IMAGE_B.Image = null;    // 이미지 초기화

            DBHelper helper = new DBHelper(false);

            //GRID1 품목별 검사항목 조회
            try
            {
                //GRID2에서 정보 GET
                string sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


                //조회조건에서 정보 GET
                string sMachkcode = DBHelper.nvlString(txt_MACHKCODE_H.Text.Trim());
                string sMachkCycle = DBHelper.nvlString(cbo_MACHKCYCLE_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0480_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCODE", sMachkcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        //GRID1 신규행 추가
        private void btn_ROWINSERT_B_Click(object sender, EventArgs e)
        {
            DoNew();
        }

        //GRID1 추가된 행 삭제(이미 DB에 저장된 정보는 삭제해도 DB상에서 삭제안됨. 재조회시 조회됨)
        private void btn_ROWDELETE_B_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        //GRID 선택행 이미지 조회
        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachkCode = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCODE"].Value);
            string sMachkCycle = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCYCLE"].Value);

            byte[] bImage = GetImage(sPlantCode, sWorkcenterCode, sMachkCode, sMachkCycle);

            if (bImage != null)
            {
                pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage);
            }
            else
            {
                pic_IMAGE_B.Image = null;
            }
        }

        //GRID1 항목별 이미지 UPLOAD
        private void btn_UPLOAD_B_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            {
                return;
            }

            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);


                DateTime dtNow = DateTime.Now;


                pic_IMAGE_B.Image = new Bitmap(openFileDlg.FileName);


                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sMachkCode = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCODE"].Value);
                string sMachkCycle = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCYCLE"].Value);


                DBHelper helper = new DBHelper(false);

                try
                {
                    //신규 행인지 기존에 등록된 행인지에 따라 이미지 저장 프로세스 분기
                    rtnDtTemp = helper.FillTable("USP_BM0480_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));

                    //신규행일 경우 현재 선택된 행의 IMG컬럼에 값을 넣어주고 상단에 저장을 누를시 반영
                    if (rtnDtTemp.Rows.Count == 0)
                    {

                        grid1.ActiveRow.Cells["IMG"].Value = ConvertImageToByteArray(pic_IMAGE_B.Image);


                        this.ShowDialog(Common.getLangText("상단의 저장버튼을 누를시 반영됩니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }
                    else
                    {
                        DBHelper helper2 = new DBHelper("", true);
                        // 이미지 저장 프로시저
                        try
                        {
                            helper2.ExecuteNoneQuery("USP_BM0480_U2", CommandType.StoredProcedure
                          , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AB_IMG", ConvertImageToByteArray(pic_IMAGE_B.Image), DbType.Binary, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));

                            if (helper2.RSCODE == "S")
                            {
                                this.ClosePrgFormNew();
                                helper2.Commit();
                                this.ShowDialog(Common.getLangText("이미지가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            }
                            else if (helper2.RSCODE == "E")
                            {
                                this.ClosePrgFormNew();
                                CancelProcess = true;
                                helper2.Rollback();
                                this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                        }
                        finally
                        {
                            helper2.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            else
            {
                return;
            }
        }

        //GRID1 항목별 이미지 삭제
        private void btn_DELETE_B_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;

            if (grid1.ActiveRow == null)
            {
                return;
            }

            pic_IMAGE_B.Image = Properties.Resources.Default_Image;



            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachkCode = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCODE"].Value);
            string sMachkCycle = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCYCLE"].Value);

            DBHelper helper = new DBHelper(false);

            try
            {
                //신규 행인지 기존에 등록된 행인지에 따라 이미지 저장 프로세스 분기
                rtnDtTemp = helper.FillTable("USP_BM0480_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));

                //신규행일 경우 현재 선택된 행의 IMG컬럼에 값을 넣어주고 상단에 저장을 누를시 반영
                if (rtnDtTemp.Rows.Count == 0)
                {

                    grid1.ActiveRow.Cells["IMG"].Value = ConvertImageToByteArray(pic_IMAGE_B.Image);


                    this.ShowDialog(Common.getLangText("상단의 저장버튼을 누를시 반영됩니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    DBHelper helper2 = new DBHelper("", true);

                    // 이미지 저장 프로시저
                    try
                    {
                        helper2.ExecuteNoneQuery("USP_BM0480_U2", CommandType.StoredProcedure
                                                               , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AB_IMG", ConvertImageToByteArray(pic_IMAGE_B.Image), DbType.Binary, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                               , helper2.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));

                        if (helper2.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper2.Commit();
                            this.ShowDialog(Common.getLangText("이미지가 삭제 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper2.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper2.Rollback();
                            this.ShowDialog(helper2.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper2.Rollback();
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        //GRID1 항목별 이미지 VIEW
        private void btn_VIEW_B_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            {
                return;
            }

            string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sWorkcenterCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sMachkCode = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCODE"].Value);
            string sMachkCycle = DBHelper.nvlString(grid1.ActiveRow.Cells["MACHKCYCLE"].Value);

            byte[] bImage = GetImage(sPlantCode, sWorkcenterCode, sMachkCode, sMachkCycle);

            if (bImage != null)
            {
                IMAGEVIEW_POP pop_ImageView = new IMAGEVIEW_POP(bImage);
                pop_ImageView.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
        }
        #endregion

        #region < METHOD AREA >
        private byte[] GetImage(string sPlantCode, string sWorkcenterCode, string sMachkCode, string sMachkCycle)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0480_S4", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MACHKCYCLE", sMachkCycle, DbType.String, ParameterDirection.Input));

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

            }

            if (rtnDtTemp.Rows.Count > 0 && rtnDtTemp.Rows[0]["IMG"] != DBNull.Value)
            {
                bImage = (byte[])rtnDtTemp.Rows[0]["IMG"];
            }
            else if (grid1.ActiveRow.Cells["IMG"].Value != DBNull.Value)
            {
                bImage = (byte[])grid1.ActiveRow.Cells["IMG"].Value;
            }
            else
            {
                bImage = ConvertImageToByteArray(Properties.Resources.Default_Image);
            }

            return bImage;
        }

        #region ConvertImageToByteArray
        public byte[] ConvertImageToByteArray(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pByte;

            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(pByte, 0, (int)ms.Length);
            ms.Close();
            return pByte;
        }
        #endregion

        #region BYTE[]를 이미지로 변환
        public Image ConvertByteArrayToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();

            Image theImage = null;

            try
            {
                ms.Position = 0;

                ms.Write(pByte, 0, (int)pByte.Length);

                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return theImage;
        }
        #endregion

        #endregion


    }
}