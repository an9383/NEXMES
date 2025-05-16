
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0130
//   Form Name    : 제품포장실적등록
//   Name Space   : WIZ.WM
//   Created Date : 2020-01-28
//   Made By      : YSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*


using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.WM
{
    public partial class WM0130 : WIZ.Forms.BaseMDIChildForm
    {
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();

        private string sPlantCode;
        private string sStartDate;
        private string sEndDate;
        private string sLotNo;
        private string sBoxBarcode;
        private string sItemCode;
        private string sItemName;

        private int iBoxCount = 1;

        #region 클래스 선언부
        private class clsBox
        {
            public string sBoxNum;
            public string sPackDT;
            public int iIndex;
            public double dChangeQty;

            public clsBox(string BoxNum)
            {
                sBoxNum = BoxNum;
                dChangeQty = 0;
            }

            public clsBox(int iIndex)
            {
                this.iIndex = iIndex;
                dChangeQty = 0;
            }
        }

        private class clsLot
        {
            public string sLotNo;
            public string sItemCode;
            public string sItemName;
            public string sUnitCode;
            public double dPreData;

            public clsBoxCollection listBox;

            public clsLot(string LotNo)
            {
                sLotNo = LotNo;
                listBox = new clsBoxCollection();
            }

            public clsBox GetBox(int iIndex)
            {
                foreach (clsBox b in this.listBox)
                {
                    if (b.iIndex == iIndex)
                    {
                        return b;
                    }
                }
                clsBox cl = new clsBox(iIndex);
                this.listBox.Add(cl);

                return cl;
            }

            public clsBox GetBox(string sBoxNo)
            {
                foreach (clsBox b in this.listBox)
                {
                    if (b.sBoxNum == sBoxNo)
                    {
                        return b;
                    }
                }
                clsBox cl = new clsBox(sBoxNo);
                this.listBox.Add(cl);

                return cl;
            }
        }

        private class clsLotCollection : Collection<clsLot>
        {
            public clsLot this[string sLotNo]  //인덱서를 선언한다.
            {
                get
                {
                    foreach (clsLot c in this)
                    {
                        if (c.sLotNo == sLotNo)
                        {
                            return c;
                        }
                    }
                    clsLot cl = new clsLot(sLotNo);
                    this.Add(cl);

                    return cl;
                }
            }

            public bool Contain(string sLotNo, string sBoxNo)
            {
                foreach (clsLot c in this)
                {
                    if (c.sLotNo == sLotNo)
                    {
                        foreach (clsBox cb in c.listBox)
                        {
                            if (cb.sBoxNum == sBoxNo)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }

            public bool Contain(string sLotNo)
            {
                foreach (clsLot c in this)
                {
                    if (c.sLotNo == sLotNo)
                    {
                        return true;
                    }
                }

                return false;
            }

            public void Remove(string sLotNo)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].sLotNo == sLotNo)
                    {
                        this.Remove(this[i]);
                        i--;
                        break;
                    }
                }
            }
        }

        private class clsBoxCollection : Collection<clsBox>
        {
            public clsBox this[string sBoxNum]
            {
                get
                {
                    foreach (clsBox c in this)
                    {
                        if (c.sBoxNum == sBoxNum)
                        {
                            return c;
                        }
                    }
                    clsBox cl = new clsBox(sBoxNum);
                    this.Add(cl);

                    return cl;
                }
            }

            public void Remove(string sBoxNum)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].sBoxNum == sBoxNum)
                    {
                        Remove(this[i]);
                        i--;
                        break;
                    }
                }
            }
        }
        private clsLotCollection listLot;
        private clsLotCollection preListLot;
        #endregion

        public WM0130()
        {
            InitializeComponent();
        }

        private void WM0050_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "재고 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "포장 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNPACKQTY", "미포장 수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            grid1.Columns["NOWQTY"].Format = "#,##0";
            grid1.Columns["PACKQTY"].Format = "#,##0";
            grid1.Columns["UNPACKQTY"].Format = "#,##0";
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "CHK",             "선택",     false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PACKDT", "포장일자", false, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "포장수량", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHANGEQTY", "변화수량", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "DEF", "박스", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "RESULT", "포장상태", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);

            grid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            grid2.Columns["PACKQTY"].Format = "#,##0";
            grid2.Columns["CHANGEQTY"].Format = "#,##0";
            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "PACKQTY", "재고수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "STATUS", "상태", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            grid3.Columns["PACKQTY"].Format = "#,##0";
            _GridUtil.SetInitUltraGridBind(grid3);

            grid3.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            grid3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

            _GridUtil.InitializeGrid(this.grid4, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "LOTNO", "LOT NO", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "PACKQTY", "재고수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "STATUS", "상태", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            grid4.Columns["PACKQTY"].Format = "#,##0";
            _GridUtil.SetInitUltraGridBind(grid4);

            grid4.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            grid4.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            #endregion

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            #region COMBOBOX

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            this.cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            #endregion

            cbo_PACKDT_S.Value = DateTime.Now.AddDays(-3);
            cbo_PACKDT_E.Value = DateTime.Now.AddDays(1);
            listLot = new clsLotCollection();
            preListLot = new clsLotCollection();
        }

        #region < TOOL BAR AREA >
        public override void DoNew()
        {
            base.DoNew();
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid4);
            if (grid2.Rows.Count > 0)
            {
                this.grid2.ActiveRow = this.grid2.Rows[this.grid2.Rows.Count - 1];
            }

            int iRow = this.grid2.InsertRow();

            this.grid2.ActiveRow.Cells["PACKNO"].Value = "[NEW BOX] " + iBoxCount.ToString();
            this.grid2.ActiveRow.Cells["PACKDT"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.grid2.ActiveRow.Cells["DEF"].Value = "[NEW BOX] " + iBoxCount.ToString();
            this.grid2.ActiveRow.Cells["CHANGEQTY"].Value = 0.0;

            iBoxCount++;

            grid2.Rows[iRow].Activation = Activation.NoEdit;
            UltraGridUtil.ActivationAllowEdit(this.grid2, "PACKNO");
            UltraGridUtil.ActivationAllowEdit(this.grid2, "PACKDT");

            grid2.ActiveRowScrollRegion.ScrollPosition = this.grid2.ActiveRow.Index;

            return;
        }
        public override void DoSave()
        {
            int iLotCnt = 0;

            foreach (clsLot c in listLot)
            {
                if (c.listBox.Count > 0)
                {
                    iLotCnt++;
                }
            }

            if (iLotCnt == 0)
            {
                this.ShowDialog(Common.getLangText("저장할 LOT 가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText(iLotCnt.ToString() + "건의 LOT 가 포장이 변경됩니다.\n저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            base.DoSave();
            DBHelper helper = new DBHelper("", true);

            try
            {
                foreach (clsLot c in listLot)
                {
                    foreach (clsBox cb in c.listBox)
                    {
                        helper.ExecuteNoneQuery("USP_WM0130_11", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKNO", cb.sBoxNum, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKDT", cb.sPackDT, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_LOTNO", c.sLotNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PACKQTY", cb.dChangeQty, DbType.Decimal, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG);
                            return;
                        }
                    }
                }

                helper.ExecuteNoneQuery("USP_WM0130_11", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PCODE", "I2", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKDT", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKQTY", 0, DbType.Decimal, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                listLot = new clsLotCollection();
                preListLot = new clsLotCollection();

                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message);
                return;
            }

            base.DoInquire();

            SetStatusBarMessage("정상적으로 저장되었습니다.");
        }

        public override void DoInquire()
        {
            foreach (clsLot c in listLot)
            {
                if (c.listBox.Count > 0)
                {
                    if (this.ShowDialog(Common.getLangText("수정한 사항이 있습니다. 저장하지 않고 조회하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    break;
                }
            }

            base.DoInquire();

            iBoxCount = 1;

            DBHelper helper = new DBHelper("", false);

            sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            sStartDate = cbo_PACKDT_S.Text;
            sEndDate = cbo_PACKDT_E.Text;
            sLotNo = txtLotNo.Text.Trim();
            sBoxBarcode = txtBoxBarcode.Text.Trim();
            sItemCode = txt_ITEMCODE_H.Text.Trim();
            sItemName = txt_ITEMNAME_H.Text.Trim();

            grid1.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_START", sStartDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_END", sEndDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_BOXBARCODE", sBoxBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));

            grid1.DataBinds();

            grid2.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_START", sStartDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_END", sEndDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_BOXBARCODE", sBoxBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));

            foreach (UltraGridRow row in grid2.Rows)
            {
                row.Activation = Activation.NoEdit;
            }
            grid2.DataBinds();

            grid3.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PCODE", "S3", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_START", sStartDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_END", sEndDate, DbType.String, ParameterDirection.Input)
                //, helper.CreateParameter("AS_PACKDT_START", "2001-01-01", DbType.String, ParameterDirection.Input)
                //, helper.CreateParameter("AS_PACKDT_END", "2080-01-01", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_BOXBARCODE", sBoxBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));

            grid3.DataBinds();

            grid4.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PCODE", "S4", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_START", sStartDate, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_PACKDT_END", sEndDate, DbType.String, ParameterDirection.Input)
                //, helper.CreateParameter("AS_PACKDT_START", "2001-01-01", DbType.String, ParameterDirection.Input)
                //, helper.CreateParameter("AS_PACKDT_END", "2080-01-01", DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_BOXBARCODE", sBoxBarcode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));

            grid4.DataBinds();

            listLot = new clsLotCollection();
            preListLot = new clsLotCollection();
        }
        #endregion

        #region < EVENT AREA >
        //private void txtInputBarCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar.Equals('\r'))
        //    {
        //        ScanLogic();
        //    }
        //}
        //private void ScanLogic()
        //{
        //    try
        //    {
        //        DBHelper helper = new DBHelper(false);

        //        string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

        //        if (BarcodeInfo.Columns.Count == 0)
        //        {
        //            BarcodeInfo.Columns.Add(new DataColumn("CHK", typeof(int)));
        //            BarcodeInfo.Columns.Add(new DataColumn("ITEMCODE", typeof(string)));
        //            BarcodeInfo.Columns.Add(new DataColumn("ITEMNAME", typeof(string)));
        //            BarcodeInfo.Columns.Add(new DataColumn("LOTNO", typeof(string)));
        //            BarcodeInfo.Columns.Add(new DataColumn("WHCODE", typeof(string)));
        //            BarcodeInfo.Columns.Add(new DataColumn("STORAGELOCCODE", typeof(string)));
        //            BarcodeInfo.Columns.Add(new DataColumn("NOWQTY", typeof(double)));
        //        }

        //        gBarCode = txtInputBarCode.Text.Trim();

        //        if (gBarCode == string.Empty) return;

        //        //바코드 유효성 검사
        //        string query = "";

        //        //SP생성 대기 쿼리
        //        query = "SELECT ";
        //        query += " 1 AS CHK,";
        //        query += " A.PLANTCODE,";
        //        query += " A.LOTNO,";
        //        query += " A.ITEMCODE,";
        //        query += " A.WHCODE,";
        //        query += " A.STORAGELOCCODE,";
        //        query += " CONVERT(FLOAT ,A.NOWQTY) AS NOWQTY,";
        //        query += " B.ITEMNAME,";
        //        query += " B.UNITPACK";
        //        query += " FROM WM0030 A WITH (NOLOCK)";
        //        query += " JOIN BM0010 B ON (A.ITEMCODE = B.ITEMCODE)";
        //        query += " WHERE A.LOTNO =  '" + gBarCode + "'";

        //        rtnDtTemp = helper.FillTable(query);



        //        //중복 등록 확인
        //        checkLOT();

        //        //비정상 라벨
        //        if (rtnDtTemp.Rows.Count == 0)
        //        {
        //            this.ShowDialog(Common.getLangText("재고 처리가 되지 않은 바코드번호 입니다", "MSG"), Forms.DialogForm.DialogType.OK);
        //        }
        //        else if (Convert.ToInt32(rtnDtTemp.Rows[0]["NOWQTY"]) == 0)
        //        {
        //            this.ShowDialog(Common.getLangText("재고가 남아있지 않은 바코드번호 입니다", "MSG"), Forms.DialogForm.DialogType.OK);
        //        }
        //        else if(overlap)
        //        {
        //            this.ShowDialog(Common.getLangText("이미 리스트에 추가된 바코드번호 입니다", "MSG"), Forms.DialogForm.DialogType.OK);
        //        }
        //        else
        //        {
        //            //바코드 리딩 리스트
        //            DataRow LOTinfo = BarcodeInfo.NewRow();
        //            LOTinfo["CHK"] = 1;
        //            LOTinfo["ITEMCODE"] = rtnDtTemp.Rows[0]["ITEMCODE"];
        //            LOTinfo["ITEMNAME"] = rtnDtTemp.Rows[0]["ITEMNAME"];
        //            LOTinfo["LOTNO"] = rtnDtTemp.Rows[0]["LOTNO"];
        //            LOTinfo["WHCODE"] = rtnDtTemp.Rows[0]["WHCODE"];
        //            LOTinfo["STORAGELOCCODE"] = rtnDtTemp.Rows[0]["STORAGELOCCODE"];
        //            LOTinfo["NOWQTY"] = rtnDtTemp.Rows[0]["NOWQTY"];
        //            BarcodeInfo.Rows.Add(LOTinfo);

        //            grid2.DataSource = BarcodeInfo;
        //            grid2.DataBinds();
        //            rtnDtTemp.Clear();

        //            //바코드 리딩 리스트 기반으로 포장 바코드 리스트 생성
        //            Grid2_DataBinds();

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        //ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        txtInputBarCode.Text = string.Empty;
        //    }
        //}


        //private bool checkLOT()
        //{
        //    try
        //    {
        //        for (int i = 0; i < BarcodeInfo.Rows.Count; i++)
        //        {
        //            if (txtInputBarCode.Text == Convert.ToString(BarcodeInfo.Rows[i]["LOTNO"]))
        //            {
        //                overlap = true;
        //                break;
        //            }
        //            else
        //                overlap = false;
        //        }
        //    }
        //    catch { }
        //    finally { overlap = false; }

        //    return overlap;
        //}

        #endregion

        #region < METHOD AREA >
        private void grid1_Click(object sender, EventArgs e)
        {
            Grid3_Search();
        }

        private void Grid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                Grid3_Search();
            }
        }

        private void grid2_Click(object sender, EventArgs e)
        {
            Grid4_Search();
        }

        private void Grid2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                Grid4_Search();
            }
        }

        private void Grid3_Search()
        {
            if (grid1.Rows.Count > 0 && grid1.ActiveRow != null)
            {
                DBHelper helper = new DBHelper("", false);

                string ssItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                grid3.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(sPlantCode), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PCODE", "S3", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKDT_START", "2001-01-01", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKDT_END", "2080-01-01", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_BOXBARCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", ssItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input));

                grid3.DataBinds();

                foreach (clsLot c in listLot)
                {
                    if (c.sItemCode == ssItemCode)
                    {
                        SetGridLotNo(grid3, c, "");
                    }
                }
            }
        }

        private void Grid4_Search()
        {
            if (grid2.Rows.Count > 0 && grid2.ActiveRow != null)
            {
                DBHelper helper = new DBHelper("", false);

                string ssBoxNo = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKNO"].Value);

                grid4.DataSource = helper.FillTable("USP_WM0130_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(sPlantCode), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PCODE", "S5", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKDT_START", "2001-01-01", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PACKDT_END", "2080-01-01", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_BOXBARCODE", ssBoxNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input));

                grid4.DataBinds();

                foreach (clsLot c in listLot)
                {
                    SetGridLotNo(grid4, c, ssBoxNo);
                }
            }
        }

        #endregion

        #region 포장 등록 취소 기능 구현
        private void btn_ROWINSERT_B_Click(object sender, EventArgs e)
        {
            Infragistics.Win.Misc.UltraButton btn = sender as Infragistics.Win.Misc.UltraButton;

            if (btn != null)
            {
                if (grid2.Rows.Count > 0 && grid2.ActiveRow != null)
                {
                    switch (btn.Name)
                    {
                        case "btn_ROWINSERT_B":
                            // 포장처리
                            {
                                string sPackNo = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKNO"].Value);

                                if (grid3.Selected.Rows.Count == 1)
                                {
                                    string sLotNo = DBHelper.nvlString(grid3.Selected.Rows[0].Cells["LOTNO"].Value);

                                    if (CModule.isNumeric(txtNOWQTY.Text.Trim()))
                                    {
                                        UltraGridRow row = grid3.Rows[grid3.Selected.Rows[0].Index];

                                        double dValue = DBHelper.nvlDouble(txtNOWQTY.Text.Trim());
                                        double dPackQty = DBHelper.nvlDouble(row.Cells["PACKQTY"].Value);

                                        if (dPackQty < dValue)
                                        {
                                            dValue = dPackQty;
                                        }

                                        if (!preListLot.Contain(sLotNo))
                                        {
                                            preListLot[sLotNo].dPreData = dPackQty;
                                        }

                                        grid2.ActiveRow.Cells["CHANGEQTY"].Value = DBHelper.nvlDouble(grid2.ActiveRow.Cells["CHANGEQTY"].Value) + dValue;

                                        listLot[sLotNo].sItemCode = DBHelper.nvlString(row.Cells["ITEMCODE"].Value);
                                        listLot[sLotNo].sItemName = DBHelper.nvlString(row.Cells["ITEMNAME"].Value);
                                        listLot[sLotNo].sUnitCode = DBHelper.nvlString(row.Cells["UNITCODE"].Value);

                                        row.Cells["STATUS"].Value = "수정";
                                        row.Cells["PACKQTY"].Value = DBHelper.nvlDouble(row.Cells["PACKQTY"].Value) - dValue;
                                        listLot[sLotNo].listBox[sPackNo].dChangeQty = dValue;
                                        listLot[sLotNo].listBox[sPackNo].sPackDT = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKDT"].Value);

                                        if (DBHelper.nvlDouble(row.Cells["PACKQTY"].Value) == 0)
                                        {
                                            row.Delete(false);
                                        }
                                        SetGridLotNo(grid4, listLot[sLotNo], sPackNo);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < grid3.Selected.Rows.Count; i++)
                                    {
                                        string sLotNo = DBHelper.nvlString(grid3.Selected.Rows[i].Cells["LOTNO"].Value);
                                        double dPackQty = DBHelper.nvlDouble(grid3.Selected.Rows[i].Cells["PACKQTY"].Value);

                                        UltraGridRow row = grid3.Rows[grid3.Selected.Rows[0].Index];

                                        if (!preListLot.Contain(sLotNo))
                                        {
                                            preListLot[sLotNo].dPreData = dPackQty;
                                        }

                                        listLot[sLotNo].sItemCode = DBHelper.nvlString(row.Cells["ITEMCODE"].Value);
                                        listLot[sLotNo].sItemName = DBHelper.nvlString(row.Cells["ITEMNAME"].Value);
                                        listLot[sLotNo].sUnitCode = DBHelper.nvlString(row.Cells["UNITCODE"].Value);
                                        listLot[sLotNo].listBox[sPackNo].dChangeQty = dPackQty;

                                        grid2.ActiveRow.Cells["CHANGEQTY"].Value = DBHelper.nvlDouble(grid2.ActiveRow.Cells["CHANGEQTY"].Value) + dPackQty;
                                        listLot[sLotNo].listBox[sPackNo].sPackDT = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKDT"].Value);

                                        row.Delete(false);
                                        i--;
                                        SetGridLotNo(grid4, listLot[sLotNo], sPackNo);
                                    }
                                }
                            }
                            break;
                        case "btn_ROWDELETE_B":
                            // 포장취소
                            if (grid4.Selected.Rows.Count == 1)
                            {
                                string sPackNo = DBHelper.nvlString(grid4.Selected.Rows[0].Cells["PACKNO"].Value);
                                string sLotNo = DBHelper.nvlString(grid4.Selected.Rows[0].Cells["LOTNO"].Value);

                                clsLot c = listLot[sLotNo];
                                clsBox cb = c.listBox[sPackNo];

                                UltraGridRow dBoxRow = null;

                                for (int ix = 0; ix < grid2.Rows.Count; ix++)
                                {
                                    if (cb.sBoxNum == DBHelper.nvlString(grid2.Rows[ix].Cells["PACKNO"].Value))
                                    {
                                        dBoxRow = grid2.Rows[ix];
                                        break;
                                    }
                                }

                                if (CModule.isNumeric(txtPACKQTY.Text.Trim()))
                                {
                                    UltraGridRow row = grid4.Rows[grid4.Selected.Rows[0].Index];
                                    double dValue = DBHelper.nvlDouble(txtPACKQTY.Text.Trim());
                                    double dPackQty = DBHelper.nvlDouble(row.Cells["PACKQTY"].Value);

                                    if (dPackQty < dValue)
                                    {
                                        dValue = dPackQty;
                                    }

                                    if (!preListLot.Contain(sLotNo, sPackNo))
                                    {
                                        preListLot[sLotNo].listBox[sPackNo].dChangeQty = dPackQty;
                                    }

                                    c.sItemCode = DBHelper.nvlString(row.Cells["ITEMCODE"].Value);
                                    c.sItemName = DBHelper.nvlString(row.Cells["ITEMNAME"].Value);
                                    c.sUnitCode = DBHelper.nvlString(row.Cells["UNITCODE"].Value);
                                    listLot[sLotNo].listBox[sPackNo].dChangeQty = (-1) * dValue;

                                    row.Cells["STATUS"].Value = "수정";

                                    row.Cells["PACKQTY"].Value = DBHelper.nvlDouble(row.Cells["PACKQTY"].Value) - dValue;
                                    if (DBHelper.nvlDouble(row.Cells["PACKQTY"].Value) == 0)
                                    {
                                        row.Delete(false);
                                    }

                                    if (dBoxRow != null)
                                    {
                                        dBoxRow.Cells["CHANGEQTY"].Value = DBHelper.nvlDouble(dBoxRow.Cells["CHANGEQTY"].Value) - dValue;
                                        listLot[sLotNo].listBox[sPackNo].sPackDT = DBHelper.nvlString(dBoxRow.Cells["PACKDT"].Value);
                                    }

                                    SetGridLotNo(grid3, c, sPackNo);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < grid4.Selected.Rows.Count; i++)
                                {
                                    string sPackNo = DBHelper.nvlString(grid4.Selected.Rows[i].Cells["PACKNO"].Value);
                                    string sLotNo = DBHelper.nvlString(grid4.Selected.Rows[i].Cells["LOTNO"].Value);
                                    double dPackQty = DBHelper.nvlDouble(grid4.Selected.Rows[i].Cells["PACKQTY"].Value);

                                    clsLot c = listLot[sLotNo];
                                    clsBox cb = c.listBox[sPackNo];

                                    UltraGridRow dBoxRow = null;

                                    for (int ix = 0; ix < grid2.Rows.Count; ix++)
                                    {
                                        if (cb.sBoxNum == DBHelper.nvlString(grid2.Rows[ix].Cells["PACKNO"].Value))
                                        {
                                            dBoxRow = grid2.Rows[ix];
                                            break;
                                        }
                                    }

                                    UltraGridRow row = grid4.Rows[grid4.Selected.Rows[i].Index];

                                    if (!preListLot.Contain(sLotNo, sPackNo))
                                    {
                                        preListLot[sLotNo].listBox[sPackNo].dChangeQty = dPackQty;
                                    }

                                    listLot[sLotNo].listBox[sPackNo].dChangeQty = (-1) * dPackQty;
                                    c.sItemCode = DBHelper.nvlString(row.Cells["ITEMCODE"].Value);
                                    c.sItemName = DBHelper.nvlString(row.Cells["ITEMNAME"].Value);
                                    c.sUnitCode = DBHelper.nvlString(row.Cells["UNITCODE"].Value);

                                    row.Delete(false);
                                    i--;

                                    if (dBoxRow != null)
                                    {
                                        dBoxRow.Cells["CHANGEQTY"].Value = DBHelper.nvlDouble(dBoxRow.Cells["CHANGEQTY"].Value) - dPackQty;
                                        listLot[sLotNo].listBox[sPackNo].sPackDT = DBHelper.nvlString(dBoxRow.Cells["PACKDT"].Value);
                                    }

                                    SetGridLotNo(grid3, c, sPackNo);
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void SetGridLotNo(Control.Grid grid, clsLot c, string sBoxNo)
        {
            for (int x = 0; x < c.listBox.Count; x++)
            {
                clsBox cb = c.listBox[x];
                if (cb.sBoxNum == sBoxNo || sBoxNo == "")
                {
                    bool bChange = false;

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        if (c.sLotNo == DBHelper.nvlString(grid.Rows[i].Cells["LOTNO"].Value))
                        {
                            // dPackQty 가 마이너스면 포장 취소
                            // 플러스면 포장처리이다.
                            if (grid.Name == "grid3")
                            {
                                // 미포장 처리 쪽
                                // 미포장일 경우 마이너스면, 재고가 늘어야 한다.
                                grid.Rows[i].Cells["PACKQTY"].Value = DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value); // - cb.dChangeQty;
                                bChange = true;
                            }
                            else if (grid.Name == "grid4")
                            {
                                // 포장 처리 쪽
                                // 포장일 경우 플러스면, 재고가 늘어야 한다.
                                if (cb.sBoxNum == DBHelper.nvlString(grid.Rows[i].Cells["PACKNO"].Value))
                                {
                                    grid.Rows[i].Cells["PACKQTY"].Value = DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value) + cb.dChangeQty;

                                    if (preListLot[c.sLotNo].listBox[cb.sBoxNum].dChangeQty == DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value))
                                    {
                                        grid.Rows[i].Cells["STATUS"].Value = "";
                                        preListLot[sLotNo].listBox.Remove(cb.sBoxNum);
                                        c.listBox.Remove(cb.sBoxNum);
                                    }
                                    else
                                    {
                                        grid.Rows[i].Cells["STATUS"].Value = "수정";
                                    }

                                    bChange = true;
                                }
                            }

                            if (DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value) <= 0)
                            {
                                grid.Rows[i].Delete(false);
                                break;
                            }
                        }
                    }

                    if (bChange)
                        continue;

                    if (grid.Name == "grid3" && cb.dChangeQty > 0)
                    {
                        return;
                    }

                    if (grid.Name == "grid4" && cb.dChangeQty < 0)
                    {
                        return;
                    }

                    int iRow = grid.InsertRow();

                    grid.Rows[iRow].Cells["LOTNO"].Value = c.sLotNo;
                    grid.Rows[iRow].Cells["ITEMCODE"].Value = c.sItemCode;
                    grid.Rows[iRow].Cells["ITEMNAME"].Value = c.sItemName;
                    grid.Rows[iRow].Cells["UNITCODE"].Value = c.sUnitCode;
                    grid.Rows[iRow].Cells["STATUS"].Value = "수정";

                    if (grid.Name == "grid3")
                    {
                        grid.Rows[iRow].Cells["PACKQTY"].Value = (-1) * cb.dChangeQty;

                        if (!preListLot.Contain(c.sLotNo))
                        {
                            preListLot[c.sLotNo].dPreData = 0;
                        }
                    }
                    else if (grid.Name == "grid4")
                    {
                        grid.Rows[iRow].Cells["PACKNO"].Value = cb.sBoxNum;
                        grid.Rows[iRow].Cells["PACKQTY"].Value = cb.dChangeQty;

                        if (!preListLot.Contain(c.sLotNo, cb.sBoxNum))
                        {
                            preListLot[c.sLotNo].listBox[cb.sBoxNum].dChangeQty = 0;
                        }
                    }
                }
            }

            if (grid.Name == "grid3")
            {
                bool bCHG = false;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (c.sLotNo == DBHelper.nvlString(grid.Rows[i].Cells["LOTNO"].Value))
                    {
                        bCHG = true;

                        if (preListLot[c.sLotNo].dPreData == DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value))
                        {
                            grid.Rows[i].Cells["STATUS"].Value = "";
                            listLot.Remove(c.sLotNo);
                        }

                        break;
                    }
                }

                // 값이 없으면
                if (!bCHG)
                {
                    if (preListLot[c.sLotNo].dPreData == 0)
                    {
                        listLot.Remove(c.sLotNo);
                    }
                }
            }

            if (grid.Name == "grid4")
            {
                foreach (clsLot cl in preListLot)
                {
                    foreach (clsBox cb in cl.listBox)
                    {
                        cb.sPackDT = "";
                    }
                }

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (c.sLotNo == DBHelper.nvlString(grid.Rows[i].Cells["LOTNO"].Value))
                    {
                        for (int x = 0; x < preListLot[c.sLotNo].listBox.Count; x++)
                        {
                            if (preListLot[c.sLotNo].listBox[x].sBoxNum == DBHelper.nvlString(grid.Rows[i].Cells["PACKNO"].Value))
                            {
                                preListLot[c.sLotNo].listBox[x].sPackDT = "FIND";

                                if (preListLot[c.sLotNo].listBox[x].dChangeQty == DBHelper.nvlDouble(grid.Rows[i].Cells["PACKQTY"].Value))
                                {
                                    listLot.Remove(c.sLotNo);
                                    grid.Rows[i].Cells["STATUS"].Value = "";
                                }
                            }
                        }
                    }
                }

                foreach (clsBox cb in preListLot[c.sLotNo].listBox)
                {
                    if (sBoxNo == cb.sBoxNum)
                    {
                        if (cb.sPackDT == "")
                        {
                            if (cb.dChangeQty == 0)
                            {
                                c.listBox.Remove(sBoxNo);
                            }
                        }
                    }
                }
            }
        }

        private void grid3_Click(object sender, EventArgs e)
        {
            if (grid3.Selected.Rows.Count == 1)
            {
                txtNOWQTY.Text = DBHelper.nvlString(grid3.Selected.Rows[0].Cells["PACKQTY"].Value);
            }
            else
            {
                txtNOWQTY.Text = "";
            }
        }

        private void grid3_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (grid3.Selected.Rows.Count == 1)
            {
                txtNOWQTY.Text = DBHelper.nvlString(grid3.Selected.Rows[0].Cells["PACKQTY"].Value);
            }
            else
            {
                txtNOWQTY.Text = "";
            }
        }

        private void grid4_Click(object sender, EventArgs e)
        {
            if (grid4.Selected.Rows.Count == 1)
            {
                txtPACKQTY.Text = DBHelper.nvlString(grid4.Selected.Rows[0].Cells["PACKQTY"].Value);
            }
            else
            {
                txtPACKQTY.Text = "";
            }
        }

        private void grid4_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (grid4.Selected.Rows.Count == 1)
            {
                txtPACKQTY.Text = DBHelper.nvlString(grid4.Selected.Rows[0].Cells["PACKQTY"].Value);
            }
            else
            {
                txtPACKQTY.Text = "";
            }
        }

        private void grid2_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (grid2.Rows.Count > 0 && grid2.ActiveRow != null)
            {
                string sBoxNum = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKNO"].Value);
                string sDef = DBHelper.nvlString(grid2.ActiveRow.Cells["DEF"].Value);

                grid2.ActiveRow.Cells["DEF"].Value = sDef;

                foreach (clsLot c in listLot)
                {
                    foreach (clsBox cb in c.listBox)
                    {
                        if (cb.sBoxNum == sDef)
                        {
                            cb.sBoxNum = sBoxNum;
                            cb.sPackDT = DBHelper.nvlString(grid2.ActiveRow.Cells["PACKDT"].Value);
                        }
                    }
                }

                foreach (UltraGridRow row in grid4.Rows)
                {
                    if (DBHelper.nvlString(row.Cells["PACKNO"].Value) == sDef)
                    {
                        row.Cells["PACKNO"].Value = sBoxNum;
                    }
                }
            }
        }
        #endregion
    }
}


