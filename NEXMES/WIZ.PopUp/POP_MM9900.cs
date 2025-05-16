using Infragistics.Win.UltraWinEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class POP_MM9900 : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        DataTable rtnDtTemp = new DataTable();
        Common _Common = new Common();

        private string sPlant = string.Empty;
        private string sDeptCode = string.Empty;
        #endregion

        #region [ 생성자 ]
        public POP_MM9900()
        {
            InitializeComponent();
        }

        public POP_MM9900(string PlantCode, string DeptCode)
        {
            InitializeComponent();

            sPlant = PlantCode;
            sDeptCode = DeptCode;

        }
        #endregion

        #region [ Form Load ]
        private void POP_MM9900_Load(object sender, EventArgs e)
        {
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE");
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            ComboBoxCloseYear();

            cboDeptCode.Value = sDeptCode;
            cboDeptCode.Enabled = false;

            cboPlantCode_H.Value = sPlant;

            cboPlantCode_H.Focus();

            lblMsg.Appearance.ForeColor = Color.Red;

        }

        #endregion

        #region [ User Method Area ]
        private void ComboBoxCloseYear()
        {
            int sNowYear = Convert.ToInt32(DateTime.Now.Year);

            DataTable dtCloseYear = new DataTable();
            dtCloseYear.Columns.Add("YEAR", typeof(string));

            DataRow drRow = null;

            for (int i = 0; i < 5; i++)
            {
                drRow = dtCloseYear.NewRow();

                drRow["YEAR"] = sNowYear;
                sNowYear++;

                dtCloseYear.Rows.Add(drRow);
            }

            FillUltraCombobox(cboCloseYear, dtCloseYear, dtCloseYear.Columns["YEAR"].ColumnName, dtCloseYear.Columns["YEAR"].ColumnName);
        }

        /// <summary>
        /// UltraComboBox Setting
        /// </summary>
        private void FillUltraCombobox(UltraComboEditor comboBox, object DataSource, string ValueField, string DisplayField, int SelectIndex = 0)
        {
            comboBox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            comboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;

            List<KeyValuePair<string, string>> comboBoxData = new List<KeyValuePair<string, string>>();

            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow drRow1 in (DataSource as DataSet).Tables[0].Rows)
                    comboBoxData.Add(new KeyValuePair<string, string>(drRow1[ValueField].ToString(), drRow1[DisplayField].ToString()));
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow drRow2 in (DataSource as DataTable).Rows)
                    comboBoxData.Add(new KeyValuePair<string, string>(drRow2[ValueField].ToString(), drRow2[DisplayField].ToString()));
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> dValue in (DataSource as Dictionary<string, string>))
                    comboBoxData.Add(dValue);
            }

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = comboBoxData;

            comboBox.MouseWheel += new MouseEventHandler(Common.comboBox_MouseWheel);

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = SelectIndex;
        }
        #endregion

        #region [ Event Area ]
        private void btnEndDate_Click(object sender, EventArgs e)
        {
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            string sDeptCode = Convert.ToString(cboDeptCode.Value);
            string sCloseYear = Convert.ToString(cboCloseYear.Value);

            if (sPlantCode == string.Empty /*|| sPlantCode.Length != 4*/)
            {
                MessageBox.Show("공장을 확인하세요.");
                return;
            }

            if (sDeptCode == string.Empty)
            {
                MessageBox.Show("업무구분을 확인하세요.");
                return;
            }

            if (sCloseYear == string.Empty)
            {
                MessageBox.Show("마감 년도를 확인하세요.");
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                helper.ExecuteNoneQuery("USP_POP_MM9900_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@CLOSEYEAR", sCloseYear, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    MessageBox.Show(sCloseYear + "년도의 마감일자가 총 " + helper.RSMSG + "건 정상 등록 되었습니다.");
                }
                else if (helper.RSMSG == "E")
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion
    }
}
