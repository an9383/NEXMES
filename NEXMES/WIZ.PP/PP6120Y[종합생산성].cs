#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 종합생산성
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP6120Y : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        DataSet rtnDsTemp = new DataSet();                      //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();                  //return DataTable 공통
        DataTable _DtTemp = new DataTable();                    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();          //그리드 객체
        Common _Common = new Common();                          //Common 객체

        BizTextBoxManager btbManager = new BizTextBoxManager(); //팝업 매니저
        PopUp_Biz _biz = new PopUp_Biz();                       //팝업 비지니스 로직 객체 생성
        #endregion

        public PP6120Y()
        {
            InitializeComponent();
        }

        private void PP6120Y_Load(object sender, EventArgs e)
        {
            #region ▶ Grid Setting ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);
            _GridUtil.InitColumnUltraGrid(grid1, "NUM", "NO", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OKQTY", "양품수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY", "불량수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STANDTIME", "정규시간", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BUHATIME", "부하시간", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GADONGTIME", "가동시간", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "JUNGGADTIME", "정미가동시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GACHGATIME", "가치가동시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HGADONG", "시간가동룔", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SGADONG", "성능가동률", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OKPER", "양품률", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTOPER", "설비종합효율", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SANGSANPER", "생산종합효율", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGB", "비가동(B)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGC", "비가동(C)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGD", "비가동(D)", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGT", "비가동전체(B+C+D)", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGTCD", "비가동전체(C+D)", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGPB", "비가동률(B)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGPC", "비가동률(C)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BEGADONGPD", "비가동률(D)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BUHAILSU", "부하일수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BUHAPER", "부하율", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ ComboBox Setting ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = "1100";

            CboStartDate_H.Value = DateTime.Now;
            CboEnddate_H.Value = DateTime.Now;
            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;
            #endregion

            #region ▶ POP-Up Setting ◀
            #endregion
        }


        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);             //공장코드                                
                string ls_wccode = Convert.ToString(txtWcCode.Tag);     //라인코드
                string ls_sdate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);//조회일자(시작)
                string ls_edate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);    //조회일자(종료)
                string ls_itemcode = Convert.ToString(txtItemCode.Tag);                 //생산품목

                string sSP = string.Empty;

                if (Common.DateCheck.CheckDate(ls_sdate, ls_edate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //시작일자를 종료일자보다 이전으로 선택해주십시오.
                    return;
                }

                base.DoInquire();

                #region ▶ 종합 생산성 ◀
                rtnDtTemp = helper.FillTable("USP_PP6120Y_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WCCODE", ls_wccode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SDATE", ls_sdate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_EDATE", ls_edate, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    DataTable DtGrid = rtnDtTemp.Clone();

                    #region ▶▶ SUB-TOTAL LOGIC ◀◀
                    /*
                    int pRNum = Convert.ToInt32(rtnDtTemp.Rows[0]["NUM"]);
                    string pPlantCode      = Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]);
                    string pBanCode        = Convert.ToString(rtnDtTemp.Rows[0]["BANCODE"]);
                    string pBanName        = Convert.ToString(rtnDtTemp.Rows[0]["BANNAME"]);
                    string pWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);
                    string pWorkCenterName = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]);

                    double pNoOkQty       = Convert.ToDouble(rtnDtTemp.Rows[0]["OKQTY"]);
                    double pNoBadQty      = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTY"]);
                    double pNoStandTime   = Convert.ToDouble(rtnDtTemp.Rows[0]["STANDTIME"]);
                    double pNoBuhaTime    = Convert.ToDouble(rtnDtTemp.Rows[0]["BUHATIME"]);
                    double pNoGadongTime  = Convert.ToDouble(rtnDtTemp.Rows[0]["GADONGTIME"]);
                    double pNoJungGadTime = Convert.ToDouble(rtnDtTemp.Rows[0]["JUNGGADTIME"]);
                    double pNoGachGaTime  = Convert.ToDouble(rtnDtTemp.Rows[0]["GACHGATIME"]);
                    double pNoHGadong     = Convert.ToDouble(rtnDtTemp.Rows[0]["HGADONG"]);
                    double pNoSGadong     = Convert.ToDouble(rtnDtTemp.Rows[0]["SGADONG"]);
                    double pNoOkPer       = Convert.ToDouble(rtnDtTemp.Rows[0]["OKPER"]);
                    double pNoMachToper   = Convert.ToDouble(rtnDtTemp.Rows[0]["MACHTOPER"]);
                    double pNoSangSanPer  = Convert.ToDouble(rtnDtTemp.Rows[0]["SANGSANPER"]);
                    double pNoBeGadongB   = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGB"]);
                    double pNoBeGadongC   = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGC"]);
                    double pNoBeGadongD   = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGD"]);
                    double pNoBeGadongT   = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGT"]);
                    double pNoBeGadongTCD = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGTCD"]);
                    double pNoBeGadongPB  = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGPB"]);
                    double pNoBeGadongPC  = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGPC"]);
                    double pNoBeGadongPD  = Convert.ToDouble(rtnDtTemp.Rows[0]["BEGADONGPD"]);
                    double pNoBuaIlsu     = Convert.ToDouble(rtnDtTemp.Rows[0]["BUHAILSU"]);
                    double pNoBuhaPer     = Convert.ToDouble(rtnDtTemp.Rows[0]["BUHAPER"]);

                    double NoOkQty       = pNoOkQty      ;
                    double NoBadQty      = pNoBadQty     ;
                    double NoStandTime   = pNoStandTime  ;
                    double NoBuhaTime    = pNoBuhaTime   ;
                    double NoGadongTime  = pNoGadongTime ;
                    double NoJungGadTime = pNoJungGadTime;
                    double NoGachGaTime  = pNoGachGaTime ;
                    double NoHGadong     = pNoHGadong    ;
                    double NoSGadong     = pNoSGadong    ;
                    double NoOkPer       = pNoOkPer      ;
                    double NoMachToper   = pNoMachToper  ;
                    double NoSangSanPer  = pNoSangSanPer ;
                    double NoBeGadongB   = pNoBeGadongB  ;
                    double NoBeGadongC   = pNoBeGadongC  ;
                    double NoBeGadongD   = pNoBeGadongD  ;
                    double NoBeGadongT   = pNoBeGadongT  ;
                    double NoBeGadongTCD = pNoBeGadongTCD;
                    double NoBeGadongPB  = pNoBeGadongPB ;
                    double NoBeGadongPC  = pNoBeGadongPC ;
                    double NoBeGadongPD  = pNoBeGadongPD ;
                    double NoBuaIlsu     = pNoBuaIlsu    ;
                    double NoBuhaPer     = pNoBuhaPer;


                    DtGrid.Rows.Add(new object[] { pRNum,         pPlantCode,    pBanCode,     pBanName,     pWorkCenterCode, pWorkCenterName,
                                                    pNoOkQty,      pNoBadQty,     pNoStandTime, pNoBuhaTime,  pNoGadongTime,   pNoJungGadTime, 
                                                    pNoGachGaTime, pNoHGadong,    pNoSGadong,   pNoOkPer,     pNoMachToper,    pNoSangSanPer,  
                                                    pNoBeGadongB,  pNoBeGadongC,  pNoBeGadongD, pNoBeGadongT, NoBeGadongTCD,   pNoBeGadongPB,
                                                    pNoBeGadongPC, pNoBeGadongPD, pNoBuaIlsu,   pNoBuhaPer });

                    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                    {
                        int tRNum              = Convert.ToInt32(rtnDtTemp.Rows[i]["NUM"]);
                        string tPlantCode      = Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]);
                        string tBanCode        = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);
                        string tBanName        = Convert.ToString(rtnDtTemp.Rows[i]["BANNAME"]);
                        string tWorkCenterCode = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);
                        string tWorkCenterName = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]);

                        double tNoOkQty       = Convert.ToDouble(rtnDtTemp.Rows[i]["OKQTY"]);
                        double tNoBadQty      = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                        double tNoStandTime   = Convert.ToDouble(rtnDtTemp.Rows[i]["STANDTIME"]);
                        double tNoBuhaTime    = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHATIME"]);
                        double tNoGadongTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["GADONGTIME"]);
                        double tNoJungGadTime = Convert.ToDouble(rtnDtTemp.Rows[i]["JUNGGADTIME"]);
                        double tNoGachGaTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["GACHGATIME"]);
                        double tNoHGadong     = Convert.ToDouble(rtnDtTemp.Rows[i]["HGADONG"]);
                        double tNoSGadong     = Convert.ToDouble(rtnDtTemp.Rows[i]["SGADONG"]);
                        double tNoOkPer       = Convert.ToDouble(rtnDtTemp.Rows[i]["OKPER"]);
                        double tNoMachToper   = Convert.ToDouble(rtnDtTemp.Rows[i]["MACHTOPER"]);
                        double tNoSangSanPer  = Convert.ToDouble(rtnDtTemp.Rows[i]["SANGSANPER"]);
                        double tNoBeGadongB   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGB"]);
                        double tNoBeGadongC   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGC"]);
                        double tNoBeGadongD   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGD"]);
                        double tNoBeGadongT   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGT"]);
                        double tNoBeGadongTCD = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGTCD"]);
                        double tNoBeGadongPB  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPB"]);
                        double tNoBeGadongPC  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPC"]);
                        double tNoBeGadongPD  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPD"]);
                        double tNoBuaIlsu     = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHAILSU"]);
                        double tNoBuhaPer     = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHAPER"]);

                        NoOkQty       = NoOkQty       + tNoOkQty;
                        NoBadQty      = NoBadQty      + tNoBadQty;
                        NoStandTime   = NoStandTime   + tNoStandTime;
                        NoBuhaTime    = NoBuhaTime    + tNoBuhaTime;
                        NoGadongTime  = NoGadongTime  + tNoGadongTime;
                        NoJungGadTime = NoJungGadTime + tNoJungGadTime;
                        NoGachGaTime  = NoGachGaTime  + tNoGachGaTime;
                        NoHGadong     = NoHGadong     + tNoHGadong;
                        NoSGadong     = NoSGadong     + tNoSGadong;
                        NoOkPer       = NoOkPer       + tNoOkPer;
                        NoMachToper   = NoMachToper   + tNoMachToper;
                        NoSangSanPer  = NoSangSanPer  + tNoSangSanPer;
                        NoBeGadongB   = NoBeGadongB   + tNoBeGadongB;
                        NoBeGadongC   = NoBeGadongC   + tNoBeGadongC;
                        NoBeGadongD   = NoBeGadongD   + tNoBeGadongD;
                        NoBeGadongT   = NoBeGadongT   + tNoBeGadongT;
                        NoBeGadongTCD = NoBeGadongTCD + tNoBeGadongTCD;
                        NoBeGadongPB  = NoBeGadongPB  + tNoBeGadongPB;
                        NoBeGadongPC  = NoBeGadongPC  + tNoBeGadongPC;
                        NoBeGadongPD  = NoBeGadongPD  + tNoBeGadongPD;
                        NoBuaIlsu     = NoBuaIlsu     + tNoBuaIlsu;
                        NoBuhaPer     = NoBuhaPer     + tNoBuhaPer;

                        if (pBanCode != tBanCode)
                        {
                            // 시간 가동률(pNoHGadong)        pNoGadongTime      /  pNoBuhaTime * 100
                            if (pNoGadongTime * pNoBuhaTime == 0) pNoHGadong = 0;
                            else pNoHGadong = Math.Round(pNoGadongTime / pNoBuhaTime * 100, 2);

                            // 성능 가동률(pNoSGadong)        pNoJungGadTime     /  pNoGadongTime * 100
                            if (pNoJungGadTime * pNoGadongTime == 0) pNoSGadong = 0;
                            else pNoSGadong = Math.Round(pNoJungGadTime / pNoGadongTime * 100, 2);

                            // 양품률(pNoOkPer)              pNoGachGaTime      /  pNoJungGadTime * 100
                            if (pNoGachGaTime * pNoJungGadTime == 0) pNoOkPer = 0;
                            else pNoOkPer = Math.Round(pNoGachGaTime / pNoJungGadTime * 100, 2);

                            // 설비 종합효율(pNoMachToper)    pNoGachGaTime      /  pNoBuhaTime * 100
                            if (pNoGachGaTime * pNoBuhaTime == 0) pNoMachToper = 0;
                            else pNoMachToper = Math.Round(pNoGachGaTime / pNoBuhaTime * 100, 2);

                            // 생산 종합효율(pNoSangSanPer)   pNoGachGaTime      /  pNoStandTime * 100
                            if (pNoGachGaTime * pNoBuhaTime == 0) pNoSangSanPer = 0;
                            else pNoSangSanPer = Math.Round(pNoGachGaTime / pNoBuhaTime * 100, 2);

                            // 비가동 전체(pNoBeGadongT)     (pNoBeGadongB + pNoBeGadongC + pNoBeGadongD ) / pNoStandTime
                            if ((pNoBeGadongB + pNoBeGadongC + pNoBeGadongD) * pNoBuhaTime == 0) pNoBeGadongT = 0;
                            else pNoBeGadongT = Math.Round((pNoBeGadongB + pNoBeGadongC + pNoBeGadongD) / pNoBuhaTime * 100, 2);

                            // 비가동 전체(C+D) (pNoBeGadongB + pNoBeGadongC + pNoBeGadongD ) / pNoStandTime
                            if ((pNoBeGadongC + pNoBeGadongD) * pNoBuhaTime == 0) pNoBeGadongTCD = 0;
                            else pNoBeGadongTCD = Math.Round((pNoBeGadongC + pNoBeGadongD) / pNoBuhaTime * 100, 2);

                            // 비가동률(B)(pNoBeGadongPB)    pNoBeGadongB / pNoStandTime * 100 
                            if (pNoBeGadongB * pNoBuhaTime == 0) pNoBeGadongPB = 0;
                            else pNoBeGadongPB = Math.Round(pNoBeGadongB / pNoBuhaTime * 100, 2);

                            // 비가동률(C)(pNoBeGadongPC)    pNoBeGadongC / pNoStandTime * 100 
                            if (pNoBeGadongC * pNoBuhaTime == 0) pNoBeGadongPC = 0;
                            else pNoBeGadongPC = Math.Round(pNoBeGadongC / pNoBuhaTime * 100, 2);

                            // 비가동률(D)(pNoBeGadongPD)    pNoBeGadongD / pNoStandTime * 100 
                            if (pNoBeGadongD * pNoBuhaTime == 0) pNoBeGadongPD = 0;
                            else pNoBeGadongPD = Math.Round(pNoBeGadongD / pNoBuhaTime * 100, 2);

                            // 부하율(pNoBuhaPer)     pNoBuhaTime / pNoStandTime * 100
                            if (pNoBuhaTime * pNoStandTime == 0) pNoBuhaPer = 0;
                            else pNoBuhaPer = Math.Round(pNoBuhaTime / pNoStandTime * 100, 2);

                            DtGrid.Rows.Add(new object[] { null, null, null, null, null, pBanName + " 합계 :",pNoOkQty,      pNoBadQty,     pNoStandTime, pNoBuhaTime,  pNoGadongTime, pNoJungGadTime, 
                                                                                                                pNoGachGaTime, pNoHGadong,    pNoSGadong,   pNoOkPer,     pNoMachToper,  pNoSangSanPer,  
                                                                                                                pNoBeGadongB,  pNoBeGadongC,  pNoBeGadongD, pNoBeGadongT, pNoBeGadongTCD, pNoBeGadongPB, 
                                                                                                                pNoBeGadongPC, pNoBeGadongPD, pNoBuaIlsu,   pNoBuhaPer });
                            pBanCode = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);
                            pBanName = Convert.ToString(rtnDtTemp.Rows[i]["BANNAME"]);

                            pNoOkQty       = Convert.ToDouble(rtnDtTemp.Rows[i]["OKQTY"]);
                            pNoBadQty      = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                            pNoStandTime   = Convert.ToDouble(rtnDtTemp.Rows[i]["STANDTIME"]);
                            pNoBuhaTime    = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHATIME"]);
                            pNoGadongTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["GADONGTIME"]);
                            pNoJungGadTime = Convert.ToDouble(rtnDtTemp.Rows[i]["JUNGGADTIME"]);
                            pNoGachGaTime  = Convert.ToDouble(rtnDtTemp.Rows[i]["GACHGATIME"]);
                            pNoHGadong     = Convert.ToDouble(rtnDtTemp.Rows[i]["HGADONG"]);
                            pNoSGadong     = Convert.ToDouble(rtnDtTemp.Rows[i]["SGADONG"]);
                            pNoOkPer       = Convert.ToDouble(rtnDtTemp.Rows[i]["OKPER"]);
                            pNoMachToper   = Convert.ToDouble(rtnDtTemp.Rows[i]["MACHTOPER"]);
                            pNoSangSanPer  = Convert.ToDouble(rtnDtTemp.Rows[i]["SANGSANPER"]);
                            pNoBeGadongB   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGB"]);
                            pNoBeGadongC   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGC"]);
                            pNoBeGadongD   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGD"]);
                            pNoBeGadongT   = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGT"]);
                            pNoBeGadongTCD = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGTCD"]);
                            pNoBeGadongPB  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPB"]);
                            pNoBeGadongPC  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPC"]);
                            pNoBeGadongPD  = Convert.ToDouble(rtnDtTemp.Rows[i]["BEGADONGPD"]);
                            pNoBuaIlsu     = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHAILSU"]);
                            pNoBuhaPer     = Convert.ToDouble(rtnDtTemp.Rows[i]["BUHAPER"]);

                            DtGrid.Rows.Add(new object[] {tRNum,         tPlantCode,    tBanCode,     tBanName,     tWorkCenterCode, tWorkCenterName,
                                                            tNoOkQty,      tNoBadQty,     tNoStandTime, tNoBuhaTime,  tNoGadongTime,   tNoJungGadTime, 
                                                            tNoGachGaTime, tNoHGadong,    tNoSGadong,   tNoOkPer,     tNoMachToper,    tNoSangSanPer,  
                                                            tNoBeGadongB,  tNoBeGadongC,  tNoBeGadongD, tNoBeGadongT, tNoBeGadongTCD,  tNoBeGadongPB,   
                                                            tNoBeGadongPC, tNoBeGadongPD, tNoBuaIlsu,   tNoBuhaPer });
                        }
                        else
                        {
                            pBanCode = Convert.ToString(rtnDtTemp.Rows[i]["BANCODE"]);

                            DtGrid.Rows.Add(new object[] {tRNum,         tPlantCode,    tBanCode,     tBanName,     tWorkCenterCode, tWorkCenterName,
                                                            tNoOkQty,      tNoBadQty,     tNoStandTime, tNoBuhaTime,  tNoGadongTime,   tNoJungGadTime, 
                                                            tNoGachGaTime, tNoHGadong,    tNoSGadong,   tNoOkPer,     tNoMachToper,    tNoSangSanPer,  
                                                            tNoBeGadongB,  tNoBeGadongC,  tNoBeGadongD, tNoBeGadongT, tNoBeGadongTCD,  tNoBeGadongPB,   
                                                            tNoBeGadongPC, tNoBeGadongPD, tNoBuaIlsu,   tNoBuhaPer });

                            pNoOkQty      = pNoOkQty        + tNoOkQty;
                            pNoBadQty      = pNoBadQty       + tNoBadQty;
                            pNoStandTime   = pNoStandTime    + tNoStandTime;
                            pNoBuhaTime    = pNoBuhaTime     + tNoBuhaTime;
                            pNoGadongTime  = pNoGadongTime   + tNoGadongTime;
                            pNoJungGadTime = pNoJungGadTime  + tNoJungGadTime;
                            pNoGachGaTime  = pNoGachGaTime   + tNoGachGaTime;
                            pNoHGadong     = pNoHGadong      + tNoHGadong;
                            pNoSGadong     = pNoSGadong      + tNoSGadong;
                            pNoOkPer       = pNoOkPer        + tNoOkPer;
                            pNoMachToper   = pNoMachToper    + tNoMachToper;
                            pNoSangSanPer  = pNoSangSanPer   + tNoSangSanPer;
                            pNoBeGadongB   = pNoBeGadongB    + tNoBeGadongB;
                            pNoBeGadongC   = pNoBeGadongC    + tNoBeGadongC;
                            pNoBeGadongD   = pNoBeGadongD    + tNoBeGadongD;
                            pNoBeGadongT   = pNoBeGadongT    + tNoBeGadongT;
                            pNoBeGadongTCD = pNoBeGadongTCD  + tNoBeGadongTCD;
                            pNoBeGadongPB  = pNoBeGadongPB   + tNoBeGadongPB;
                            pNoBeGadongPC  = pNoBeGadongPC   + tNoBeGadongPC;
                            pNoBeGadongPD  = pNoBeGadongPD   + tNoBeGadongPD;
                            pNoBuaIlsu     = pNoBuaIlsu      + tNoBuaIlsu;
                            pNoBuhaPer     = pNoBuhaPer      + tNoBuhaPer;
                        }
                    }

                    // 시간 가동률(pNoHGadong)        pNoGadongTime      /  pNoBuhaTime * 100
                    if (pNoGadongTime * pNoBuhaTime == 0) pNoHGadong = 0;
                    else pNoHGadong = Math.Round(pNoGadongTime / pNoBuhaTime * 100, 2);

                    // 성능 가동률(pNoSGadong)        pNoJungGadTime     /  pNoGadongTime * 100
                    if (pNoJungGadTime * pNoGadongTime == 0) pNoSGadong = 0;
                    else pNoSGadong = Math.Round(pNoJungGadTime / pNoGadongTime * 100, 2);

                    // 양품률(pNoOkPer)              pNoGachGaTime      /  pNoJungGadTime * 100
                    if (pNoGachGaTime * pNoJungGadTime == 0) pNoOkPer = 0;
                    else pNoOkPer = Math.Round(pNoGachGaTime / pNoJungGadTime * 100, 2);

                    // 설비 종합효율(pNoMachToper)    pNoGachGaTime      /  pNoBuhaTime * 100
                    if (pNoGachGaTime * pNoBuhaTime == 0) pNoMachToper = 0;
                    else pNoMachToper = Math.Round(pNoGachGaTime / pNoBuhaTime * 100, 2);

                    // 생산 종합효율(pNoSangSanPer)   pNoGachGaTime      /  pNoStandTime * 100
                    if (pNoGachGaTime * pNoStandTime == 0) pNoSangSanPer = 0;
                    else pNoSangSanPer = Math.Round(pNoGachGaTime / pNoStandTime * 100, 2);

                    // 비가동 전체(pNoBeGadongT)     (pNoBeGadongB + pNoBeGadongC + pNoBeGadongD ) / pNoStandTime
                    if ((pNoBeGadongB + pNoBeGadongC + pNoBeGadongD) * pNoBuhaTime == 0) pNoBeGadongT = 0;
                    else pNoBeGadongT = Math.Round((pNoBeGadongB + pNoBeGadongC + pNoBeGadongD) / pNoBuhaTime * 100, 2);

                    // 비가동 전체(C+D) (pNoBeGadongTCD)     (pNoBeGadongC + pNoBeGadongD ) / pNoStandTime
                    if ((pNoBeGadongC + pNoBeGadongD) * pNoBuhaTime == 0) pNoBeGadongTCD = 0;
                    else pNoBeGadongTCD = Math.Round((pNoBeGadongC + pNoBeGadongD) / pNoBuhaTime * 100, 2);

                    // 비가동률(B)(pNoBeGadongPB)    pNoBeGadongB / pNoStandTime * 100 
                    if (pNoBeGadongB * pNoBuhaTime == 0) pNoBeGadongPB = 0;
                    else pNoBeGadongPB = Math.Round(pNoBeGadongB / pNoBuhaTime * 100, 2);

                    // 비가동률(C)(pNoBeGadongPC)    pNoBeGadongC / pNoStandTime * 100 
                    if (pNoBeGadongC * pNoBuhaTime == 0) pNoBeGadongPC = 0;
                    else pNoBeGadongPC = Math.Round(pNoBeGadongC / pNoBuhaTime * 100, 2);

                    // 비가동률(D)(pNoBeGadongPD)    pNoBeGadongD / pNoStandTime * 100 
                    if (pNoBeGadongD * pNoBuhaTime == 0) pNoBeGadongPD = 0;
                    else pNoBeGadongPD = Math.Round(pNoBeGadongD / pNoBuhaTime * 100, 2);

                    // 부하율(pNoBuhaPer)     pNoBuhaTime / pNoStandTime * 100
                    if (pNoBuhaTime * pNoStandTime == 0) pNoBuhaPer = 0;
                    else pNoBuhaPer = Math.Round(pNoBuhaTime / pNoStandTime * 100, 2);


                    DtGrid.Rows.Add(new object[] { null, null, null, null, null, pBanName + " 합계 :",pNoOkQty,      pNoBadQty,     pNoStandTime, pNoBuhaTime,  pNoGadongTime,  pNoJungGadTime, 
                                                                                                        pNoGachGaTime, pNoHGadong,    pNoSGadong,   pNoOkPer,     pNoMachToper,   pNoSangSanPer,  
                                                                                                        pNoBeGadongB,  pNoBeGadongC,  pNoBeGadongD, pNoBeGadongT, pNoBeGadongTCD, pNoBeGadongPB, 
                                                                                                        pNoBeGadongPC, pNoBeGadongPD, pNoBuaIlsu,   pNoBuhaPer });


                    // 시간 가동률(NoHGadong)        NoGadongTime      /  NoBuhaTime * 100
                    if (NoGadongTime * NoBuhaTime == 0) NoHGadong = 0;
                    else NoHGadong = Math.Round(NoGadongTime / NoBuhaTime * 100, 2);

                    // 성능 가동률(NoSGadong)        NoJungGadTime     /  NoGadongTime * 100
                    if (NoJungGadTime * NoGadongTime == 0) NoSGadong = 0;
                    else NoSGadong = Math.Round(NoJungGadTime / NoGadongTime * 100, 2);

                    // 양품률(NoOkPer)              NoGachGaTime      /  NoJungGadTime * 100
                    if (NoGachGaTime * NoJungGadTime == 0) NoOkPer = 0;
                    else NoOkPer = Math.Round(NoGachGaTime / NoJungGadTime * 100, 2);

                    // 설비 종합효율(NoMachToper)    NoGachGaTime      /  NoBuhaTime * 100
                    if (NoGachGaTime * NoBuhaTime == 0) NoMachToper = 0;
                    else NoMachToper = Math.Round(NoGachGaTime / NoBuhaTime * 100, 2);

                    // 생산 종합효율(NoSangSanPer)   NoGachGaTime      /  NoStandTime * 100
                    if (NoGachGaTime * pNoStandTime == 0) NoSangSanPer = 0;
                    else NoSangSanPer = Math.Round(NoGachGaTime / NoStandTime * 100, 2);

                    // 비가동 전체(NoBeGadongT)     (NoBeGadongB + NoBeGadongC + NoBeGadongD ) / NoStandTime
                    if ((NoBeGadongB + NoBeGadongC + NoBeGadongD) * NoBuhaTime == 0) NoBeGadongT = 0;
                    else NoBeGadongT = Math.Round((NoBeGadongB + NoBeGadongC + NoBeGadongD) / NoBuhaTime * 100, 2);

                    // 비가동 전체(C+D) (NoBeGadongTCD)     (NoBeGadongC + NoBeGadongD ) / NoStandTime
                    if ((NoBeGadongC + NoBeGadongD) * NoBuhaTime == 0) NoBeGadongTCD = 0;
                    else NoBeGadongTCD = Math.Round((NoBeGadongC + NoBeGadongD) / NoBuhaTime * 100, 2);

                    // 비가동률(B)(NoBeGadongPB)    NoBeGadongB / NoStandTime * 100 
                    if (NoBeGadongB * NoBuhaTime == 0) NoBeGadongPB = 0;
                    else NoBeGadongPB = Math.Round(NoBeGadongB / NoBuhaTime * 100, 2);

                    // 비가동률(C)(NoBeGadongPC)    NoBeGadongC / NoStandTime * 100 
                    if (NoBeGadongC * NoBuhaTime == 0) NoBeGadongPC = 0;
                    else NoBeGadongPC = Math.Round(NoBeGadongC / NoBuhaTime * 100, 2);

                    // 비가동률(D)(NoBeGadongPD)    NoBeGadongD / NoStandTime * 100 
                    if (NoBeGadongD * NoBuhaTime == 0) NoBeGadongPD = 0;
                    else NoBeGadongPD = Math.Round(NoBeGadongD / NoBuhaTime * 100, 2);

                    // 부하율(pNoBuhaPer)     pNoBuhaTime / pNoStandTime * 100
                    if (NoBuhaTime * NoStandTime == 0) NoBuhaPer = 0;
                    else NoBuhaPer = Math.Round(NoBuhaTime / NoStandTime * 100, 2);

                    DtGrid.Rows.Add(new object[] { null, null, null, null, null, "전 체 합 계 :", NoOkQty,      NoBadQty,     NoStandTime, NoBuhaTime,  NoGadongTime,  NoJungGadTime, 
                                                                                                    NoGachGaTime, NoHGadong,    NoSGadong,   NoOkPer,     NoMachToper,   NoSangSanPer,  
                                                                                                    NoBeGadongB,  NoBeGadongC,  NoBeGadongD, NoBeGadongT, NoBeGadongTCD, NoBeGadongPB,
                                                                                                    NoBeGadongPC, NoBeGadongPD, NoBuaIlsu,   NoBuhaPer });
                    */
                    grid1.DataSource = DtGrid;
                    grid1.DataBinds();

                    #endregion
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
                    return;
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
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

            WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();
            excel.DownloadExcel(this.grid1, this.Name, false);
        }
        #endregion


        #region < EVENT AREA >
        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;

            if (Convert.ToString(e.Row.Cells["NUM"].Value) == string.Empty)
            {
                if (Convert.ToString(e.Row.Cells["WORKCENTERNAME"].Value) == "전 체 합 계 :")
                {
                    e.Row.Appearance.BackColor = Color.FromArgb(176, 219, 189);
                }
                else
                {
                    e.Row.Appearance.BackColor = Color.FromArgb(227, 243, 251);
                }
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Cells["WORKCENTERNAME"].Appearance.TextHAlign = HAlign.Right;
            }
            else
            {
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.False;
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtItemCode.Tag = null;
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
        }

        private void txtItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "" };
            //    POP_TBM0100 _frmA = new POP_TBM0100( values );
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtItemCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "", "", "" ,"" ,"" };
            //    POP_TBM0600 _frmA = new POP_TBM0600( values );
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtWcCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtWcName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtWcCode.Tag = null;
                txtWcCode.Text = string.Empty;
                txtWcName.Text = string.Empty;
            }
        }
        #endregion
    }
}
