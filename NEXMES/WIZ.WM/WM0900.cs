#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0900
//   Form Name    : 수입검사 실적  정보 조회
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.WM
{
    public partial class WM0900 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >

        public WM0900()
        {
            InitializeComponent();
        }

        #endregion

        #region   MM0900_Load
        private void MM0900_Load(object sender, EventArgs e)
        {

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            btnPlanInput_Click(null, null);

        }
        #endregion   MM0900_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //  base.DoInquire();
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


        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //  base.DoInquire();
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

        private void btnPlanInput_Click(object sender, EventArgs e)
        {
            cboPlantCode_H.Value = "1100";
            cboCloseMonth.Value = DateTime.Now;
            txtCloseDay.Text = DateTime.Now.ToString("yyyy-MM") + "-30";
            txtPrcFlag.Text = "[WM] 제품업무";
        }

    }
}


