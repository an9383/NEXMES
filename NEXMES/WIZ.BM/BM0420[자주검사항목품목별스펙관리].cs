#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0420
//   Form Name    : 자주검사항목 품목별 스펙관리
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 자주 검사항목 품목별 스펙을 관리 
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
    public partial class BM0420 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0420()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0420_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목별 검사항목 (GRID1은 우측에 위치한 MAIN GRID!)
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "검사값구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "검사단위", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "IMG", "이미지", true, GridColDataType_emu.Image, 0, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["INSPNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["VALUETYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["UNITCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECNOL"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECUSL"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECLSL"].Header.Appearance.ForeColor = Color.SkyBlue;

                //GRID2 품목 (GRID2는 좌측 상단 첫번쨰 GRID) (MAIN GRID를 제외한 GRID는 사업장 / 코드 / 코드명 만 출력) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                //GRID3 검사항목 (GRID3는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid3, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //검사값구분              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");  //관리구분             
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //검사단위              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                //검사항목
                btbManager.PopUpAdd(txt_INSPCODE_H, txt_INSPNAME_H, "BM0180", new object[] { cbo_PLANTCODE_H, cbo_USEFLAG_H });

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
            pic_IMAGE_B.Image = null;    // 이미지 초기화

            base.DoInquire();

            //조회항목에서 선택된 값 GET
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            string sInspCode = DBHelper.nvlString(txt_INSPCODE_H.Text.Trim());
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            DBHelper helper = new DBHelper(false);

            //GRID2 품목 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0420_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
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

            //GRID3 검사항목 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0420_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
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
                this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else if (grid3.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("검사항목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //해당 TABLE의 기본키및 명칭은 좌측 GRID에서 선택된 정보들을 GRID1의 해당 컬럼에 BINDING
                //GRID2의 정보
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                this.grid1.ActiveRow.Cells["ITEMCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                this.grid1.ActiveRow.Cells["ITEMNAME"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMNAME"].Value);
                //GRID3의 정보
                this.grid1.ActiveRow.Cells["INSPCODE"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["INSPCODE"].Value);
                this.grid1.ActiveRow.Cells["INSPNAME"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["INSPNAME"].Value);

                //사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                this.grid1.ActiveRow.Cells["VALUETYPE"].Value = "V";
                this.grid1.ActiveRow.Cells["SPECTYPE"].Value = "B";
                this.grid1.ActiveRow.Cells["UNITCODE"].Value = "EA";

                //행 추가시 기본이미지를 세팅
                this.grid1.ActiveRow.Cells["IMG"].Value = ConvertImageToByteArray(Properties.Resources.Default_Image);

                grid1.UpdateData();

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치 (좌측에서 받아온 값도 수정이 안되도록 해야함)
                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["INSPCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["INSPNAME"].Activation = Activation.NoEdit;

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
                        if (DBHelper.nvlString(drRow["VALUETYPE"]) == "")
                        {
                            this.ShowDialog(Common.getLangText("검사값구분은 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        //검사값구분이 값일경우
                        if (DBHelper.nvlString(drRow["VALUETYPE"]) != "J")
                        {
                            if (DBHelper.nvlString(drRow["SPECTYPE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("관리구분은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["UNITCODE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("단위는 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECNOL"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("기준값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            //하한관리가 아니면 상한값은 필수입력
                            if (DBHelper.nvlString(drRow["SPECUSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "L")
                            {
                                this.ShowDialog(Common.getLangText("상한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            //상한관리가 아니면 하한값은 필수입력
                            if (DBHelper.nvlString(drRow["SPECLSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "U")
                            {
                                this.ShowDialog(Common.getLangText("하한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECTYPE"]) != "L" && Convert.ToDouble(drRow["SPECUSL"]) < Convert.ToDouble(drRow["SPECNOL"]))
                            {
                                this.ShowDialog(Common.getLangText("상한값은 기준값보다 작을수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECTYPE"]) != "U" && Convert.ToDouble(drRow["SPECLSL"]) > Convert.ToDouble(drRow["SPECNOL"]))
                            {
                                this.ShowDialog(Common.getLangText("하한값은 기준값보다 클수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        else
                        {
                            drRow["SPECTYPE"] = "";
                            drRow["UNITCODE"] = "";
                            drRow["SPECNOL"] = DBNull.Value;
                            drRow["SPECUSL"] = DBNull.Value;
                            drRow["SPECLSL"] = DBNull.Value;
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
                            helper.ExecuteNoneQuery("USP_BM0420_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPCODE", DBHelper.nvlString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VALUETYPE", DBHelper.nvlString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SPECTYPE", DBHelper.nvlString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCODE", DBHelper.nvlString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECNOL", DBHelper.nvlDouble(drRow["SPECNOL"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECUSL", DBHelper.nvlDouble(drRow["SPECUSL"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_SPECLSL", DBHelper.nvlDouble(drRow["SPECLSL"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AB_IMG", drRow["IMG"], DbType.Binary, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0420_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_INSPCODE", DBHelper.nvlString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_VALUETYPE", DBHelper.nvlString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_SPECTYPE", DBHelper.nvlString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_UNITCODE", DBHelper.nvlString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_SPECNOL", DBHelper.nvlDouble(drRow["SPECNOL"]), DbType.Double, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_SPECUSL", DBHelper.nvlDouble(drRow["SPECUSL"]), DbType.Double, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_SPECLSL", DBHelper.nvlDouble(drRow["SPECLSL"]), DbType.Double, ParameterDirection.Input)
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

            BM0420_EXCEL bm0420_excel = new BM0420_EXCEL();
            bm0420_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        //GRID1 조회 (GRID1은 항상 GRID2의 ROW를 더블클릭할때 바인딩함)
        private void grid2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화        
            pic_IMAGE_B.Image = null;    // 이미지 초기화

            DBHelper helper = new DBHelper(false);

            //GRID1 품목별 검사항목 조회
            try
            {
                //GRID2에서 정보 GET
                string sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


                //조회조건에서 정보 GET
                string sInspCode = DBHelper.nvlString(txt_INSPCODE_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_BM0420_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
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
            string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPCODE"].Value);

            byte[] bImage = GetImage(sPlantCode, sItemCode, sInspCode);

            if (bImage != null)
            {
                MemoryStream MS = new MemoryStream(bImage);
                pic_IMAGE_B.Image = new Bitmap(MS);

                bImage = null;
                MS.Close();
                MS.Dispose();

                //pic_IMAGE_B.Image = ConvertByteArrayToImage(bImage); 
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

                pic_IMAGE_B.Image = new Bitmap(openFileDlg.FileName);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPCODE"].Value);
                DateTime dtNow = DateTime.Now;

                DBHelper helper = new DBHelper(false);

                try
                {
                    //신규 행인지 기존에 등록된 행인지에 따라 이미지 저장 프로세스 분기
                    rtnDtTemp = helper.FillTable("USP_BM0420_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
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
                            helper2.ExecuteNoneQuery("USP_BM0420_U2", CommandType.StoredProcedure
                          , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper2.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
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
            string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPCODE"].Value);

            DBHelper helper = new DBHelper(false);

            try
            {
                //신규 행인지 기존에 등록된 행인지에 따라 이미지 저장 프로세스 분기
                rtnDtTemp = helper.FillTable("USP_BM0420_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
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
                        helper2.ExecuteNoneQuery("USP_BM0420_U2", CommandType.StoredProcedure
                      , helper2.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                      , helper2.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                      , helper2.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
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
            string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sInspCode = DBHelper.nvlString(grid1.ActiveRow.Cells["INSPCODE"].Value);

            byte[] bImage = GetImage(sPlantCode, sItemCode, sInspCode);

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

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "VALUETYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() != "J")
                {
                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
                }
                else
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                    grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

                }
            }

            else if (e.Cell.Column.ToString() == "SPECTYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() == "U")
                {
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "L")
                {
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "B")
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
            }
        }

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            pic_IMAGE_B.Image = null;

            if (grid1.ActiveRow.Cells["VALUETYPE"].Value.ToString() != "J")
            {
                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
            }
            else
            {
                grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

            }

            if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "U")
            {
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "L")
            {
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "B")
            {
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
        }

        #endregion

        #region < METHOD AREA >
        private byte[] GetImage(string sPlantCode, string sItemCode, string sInspCode)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0420_S4", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input));

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


        #endregion      

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
                string sItemCode = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


                //조회조건에서 정보 GET
                string sInspCode = DBHelper.nvlString(txt_INSPCODE_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_BM0420_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
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
    }
}