#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0028
//   Form Name    : 생산실적조회
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 생산실적조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0028 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //-- return DataTable
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();

        //-- 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        #endregion

        #region < CONSTRUCTOR >
        public PP0028()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0028_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "사업장",      false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left,   true, false);            
            //_GridUtil.InitColumnUltraGrid(grid1, "RECDATE",     "작업일자",      false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true, false);    
            //_GridUtil.InitColumnUltraGrid(grid1, "OPCODE",      "공정",        false, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "MATERIAL",    "재질",        false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",    "품명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTNO",       "LOTNO",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",     "생산수량",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",    "단위",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center,  true, false);          
            //_GridUtil.InitColumnUltraGrid(grid1, "PROD_WEIGHT", "중량(KG)",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right,  true, false);         
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //rtnDtTemp = _Common.GET_BM0060_CODE("");         //작업장           
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            DataTable dt = new DataTable();
            dt.Columns.Add("MINORCODE", typeof(string));
            dt.Columns.Add("MINORNAME", typeof(string));

            dt.Rows.Add("LOT", "LOT별");
            dt.Rows.Add("ITEM", "품번별");

            cbo_GROUP_H.DataSource = dt;
            cbo_GROUP_H.ValueMember = "MINORCODE";
            cbo_GROUP_H.DisplayMember = "MINORNAME";

            cbo_GROUP_H.SelectedIndex = 0;
            #endregion

            #region POPUP SETTING
            DBHelper helper = new DBHelper(false);
            try
            {

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                rtnDtTemp = helper.FillTable("USP_BM5055_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", "MC0038", DbType.String, ParameterDirection.Input));


                WIZ.Common.FillComboboxMaster(this.cbo_ConditionCode_H, rtnDtTemp, rtnDtTemp.Columns["SUBCODE"].ColumnName, rtnDtTemp.Columns["SUBNAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MethodCode", rtnDtTemp, "METHODCODE", "METHODNAME");
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


            //작업장명
            //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "", "" });
            //품목
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);             //공장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);//조회일자(시작)
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);  //조회일자(종료)                
                string sItemCode = txt_ITEMCODE_H.Text.Trim();                            //품목
                string sItemName = txt_ITEMNAME_H.Text.Trim();                            //품목
                string sLOTNO = txtLotNo.Text.Trim();                              //LOTNO
                string sMaterial = DBHelper.nvlString(cbo_ConditionCode_H.Value);             //공장
                string sType = DBHelper.nvlString(cbo_GROUP_H.Value);

                if (Common.DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                DataSet ds = helper.FillDataSet("USP_PP0028_S1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MATERIAL", sMaterial, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_TYPE", sType, DbType.String, ParameterDirection.Input));

                if (ds.Tables.Count == 2)
                {
                    grid1.DataSource = ds.Tables[0];
                    grid1.DataBinds();

                    for (int i = 0; i < grid1.Columns.Count; i++)
                    {
                        string sName = "";
                        if (grid1.Columns[i].Key == "RECDATE")
                        {
                            sName = "성형일자";
                        }

                        if (grid1.Columns[i].Key == "ITEMCODE")
                        {
                            sName = "품목";
                        }

                        if (grid1.Columns[i].Key == "ITEMNAME")
                        {
                            sName = "품명";
                        }

                        if (grid1.Columns[i].Key == "LOTNO")
                        {
                            sName = "LOTNO";
                        }

                        if (grid1.Columns[i].Key.StartsWith("OP"))
                        {
                            DataRow[] drArr = ds.Tables[1].Select("OP_SEQ = '" + grid1.Columns[i].Key + "' ");
                            if (drArr.Length > 0)
                            {
                                sName = CModule.ToString(drArr[0]["OPNAME"]);
                            }

                            grid1.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = HAlign.Right;
                            grid1.DisplayLayout.Bands[0].Columns[i].Format = "#,###,###";
                        }

                        grid1.Columns[i].Header.Caption = sName;
                    }
                }

                this.ClosePrgFormNew();
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
        #endregion


        #region < EVENT AREA >
        #endregion
    }
}