#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_MM0000Y_UNIT
//   Form Name    : 자재 입고 단위 수량 변환
//   Name Space   : WIZ.POPUP
//   Created Date : 2020-06-30
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace WIZ.PopUp
{
    public partial class MM0000_POP_UNIT : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        private string sPlantCode = string.Empty;                   //공장
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sMaterialgrade = string.Empty;                   //재질
        private string sItemSpec = string.Empty;                   //규격
        private string sItemType = string.Empty;                   //품목분류
        private string sUnitCode = string.Empty;                   //단위
        private string sPoOrderQty = string.Empty;                   //발주량(A)
        private string sTotInQty = string.Empty;                   //입고 중량
        private string MINUNIT = string.Empty;                   //하위 단위

        private int iBOXQty = 0;
        private int iPALLETQty = 0;
        private int iROLLQty = 0;
        private int iTANKQty = 0;

        Common _Common = new Common();

        //Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        //Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        public string m_strQty { get; set; }

        #endregion

        #region < CONSTRUCTOR >
        public MM0000_POP_UNIT()
        {
            InitializeComponent();
        }

        public MM0000_POP_UNIT(DataRow drRow)
        {
            InitializeComponent();

            sItemType = Convert.ToString(drRow["ITEMTYPE"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            sItemName = Convert.ToString(drRow["ITEMNAME"]);
            string sUnitCode = DBHelper.nvlString(this.cboUnitCode_H.Value);

            txtItemType.Text = sItemType;      //품목분류
            txtItemCode.Text = sItemCode;      //품목코드
            txtItemName.Text = sItemName;      //품목명
            txtPoOrderQty.Text = sPoOrderQty;    //발주수량(A)
            txtStockQty.Text = sTotInQty;      //입고수량
        }
        #endregion

        #region < FORM EVENT >
        private void MM0000_POP_UNIT_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            try
            {
                // 콤보박스 셋팅
                DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
                rtnDtTemp = _Common.GET_BM0000_CODE("INPACKUNIT");  //입고단위
                WIZ.Common.FillComboboxMaster(this.cboUnitCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                //데이터 가져오기
                DBHelper helper = new DBHelper(false);
                string command = string.Empty;

                command = " SELECT ISNULL(PALLETQTY,0) AS PALLETQTY , " +
                    "ISNULL(BOXQTY,0) AS BOXQTY ," +
                    " ISNULL(TANKQTY,0) AS TANKQTY , " +
                    "DBO.FN_UNITNAME(UNITCODE) AS UNIT " +
                    "FROM BM0010  WHERE ITEMCODE = " + "'" + sItemCode + "'";

                DataTable dttemp = helper.FillTable(command, CommandType.Text);

                iPALLETQty = Convert.ToInt32(dttemp.Rows[0]["PALLETQTY"]);
                iBOXQty = Convert.ToInt32(dttemp.Rows[0]["BOXQTY"]);
                iTANKQty = Convert.ToInt32(dttemp.Rows[0]["TANKQTY"]);
                //iROLLQty = Convert.ToInt32(dttemp.Rows[0]["ROLLQty"]);

                MINUNIT = dttemp.Rows[0]["UNIT"].ToString();

                if (iPALLETQty == 0 && iBOXQty == 0 && iTANKQty == 0)
                {
                    MessageBox.Show("단위 수량이 등록 되지않았습니다");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }

        #endregion

        #region < USER METHOD AREA >
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

        #region < EVENT AREA >

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (txtStockQty.Text == string.Empty)
                {
                    MessageBox.Show("총 발주량을 계산하세요.");
                    return;
                }

                int iPoOrderQty = Convert.ToInt32(txtPoOrderQty.Text);                //발주량

                this.m_strQty = Convert.ToString(txtStockQty.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                this.Close();
            }
        }

        /// <summary>
        /// 단위량 계산
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            int iStockQty = 0;
            int iPoOrderQty = Convert.ToInt32(txtPoOrderQty.Text);
            string strInUnit = Convert.ToString(cboUnitCode_H.Value);


            try
            {
                switch (strInUnit)
                {
                    case "PALLET":
                        iStockQty = iPoOrderQty * iPALLETQty * iBOXQty;
                        break;
                    case "BOX":
                        iStockQty = iPoOrderQty * iBOXQty;
                        break;
                    case "TANK":
                        iStockQty = iPoOrderQty * iTANKQty;
                        break;
                    case "ROLL":
                        iStockQty = iROLLQty;
                        break;

                }
                txtUnitCode.Text = MINUNIT;

                txtStockQty.Text = iStockQty.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }//CLASS
}//namespace
