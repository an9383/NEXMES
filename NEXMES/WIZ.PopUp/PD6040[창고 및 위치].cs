#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PD6040
//   Form Name    : 창고 및 위치
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 창고 및 위치 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class PD6040 : Form
    {
        #region < MEMBER AREA >

        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;
        private string _sWhType = string.Empty;

        //public string pWhCode = string.Empty;
        //public string pWhName = string.Empty;
        public string pStorageLocCode = string.Empty;
        //public string pStorageLocName = string.Empty;
        private string sStorage = string.Empty;


        DataTable rtnDtTemp = new DataTable();
        DataSet rtnDsTemp = new DataSet();
        #endregion

        #region < CONSTRUCTOR >
        public PD6040()
        {
            InitializeComponent();

            txtStorageBARCODE.Focus();
        }

        public PD6040(string sWhType)
        {
            InitializeComponent();

            _sWhType = sWhType;
        }
        #endregion

        #region < FORM LOAD >
        private void PD6040_Load(object sender, EventArgs e)
        {
            //타이틀 설정
            lblFormName.Text = lblFormName.Text + " (" + LoginInfo.PlantCode + "-" + LoginInfo.UserID + ")";
            //GridInit1();
            //GridInit2();

            GetStorage();
        }

        #endregion

        #region < USER METHOD AREA >
        //private void GridInit1()
        //{
        //    grid1.View = View.Details;
        //    grid1.Columns.Add(new Grid.ColHeader("",        0,   HorizontalAlignment.Center, true));
        //    grid1.Columns.Add(new Grid.ColHeader("창고코드", 80,  HorizontalAlignment.Center, true));  //창고코드
        //    grid1.Columns.Add(new Grid.ColHeader("창고명",   140, HorizontalAlignment.Center, true));  //창고명  
        //}

        //private void GridInit2()
        //{
        //    grid2.View = View.Details;
        //    grid2.Columns.Add(new Grid.ColHeader("",        0,   HorizontalAlignment.Center, true));
        //    grid2.Columns.Add(new Grid.ColHeader("위치코드", 80,  HorizontalAlignment.Center, true));  //위치코드
        //    grid2.Columns.Add(new Grid.ColHeader("위치명",   140, HorizontalAlignment.Center, true));  //위치코드명

        //}

        ///// <summary>
        ///// 창고코드 조회
        ///// </summary>
        //private void GetWhCode()
        //{
        //    try
        //    {
        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETWHCODE(_sWhType, ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            for (int i = 0; i < _dt.Rows.Count; i++)
        //            {
        //                ListViewItem lvl = new ListViewItem();
        //                lvl.SubItems.Add(_dt.Rows[i]["WHCODE"].ToString());
        //                lvl.SubItems.Add(_dt.Rows[i]["WHNAME"].ToString());

        //                grid1.Items.Add(lvl);
        //                grid1.EndUpdate();
        //            }
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            MessageBox.Show("[창고 조회] " + RS_MSG);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("[창고 조회] " + ex.Message);
        //    }
        //}


        ///// <summary>
        ///// 위치코드 조회
        ///// </summary>
        //private void GetStorageLocCode(string sWhCode)
        //{
        //    try
        //    {
        //        grid2.Items.Clear();

        //        DataTable _dt = new DataTable();
        //        _dt = USP_PDA_GETSTORAGECODE(sWhCode, ref RS_CODE, ref RS_MSG);

        //        if (RS_CODE == "S")
        //        {
        //            for (int i = 0; i < _dt.Rows.Count; i++)
        //            {
        //                ListViewItem lvl = new ListViewItem();
        //                lvl.SubItems.Add(_dt.Rows[i]["STORAGELOCCODE"].ToString());
        //                lvl.SubItems.Add(_dt.Rows[i]["STORAGELOCNAME"].ToString());

        //                grid2.Items.Add(lvl);
        //                grid2.EndUpdate();
        //            }
        //        }
        //        else if (RS_CODE == "E")
        //        {
        //            MessageBox.Show("[창고 위치 조회] " + RS_MSG);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("[위치 조회] " + ex.Message);
        //    }
        //}

        //private DataTable USP_PDA_GETWHCODE(string sWhType, ref string RS_CODE, ref string RS_MSG)
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        rtnDtTemp = helper.FillTable("USP_PDA_GETWHCODE", CommandType.StoredProcedure,
        //                                            helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                                          , helper.CreateParameter("AS_WHTYPE",  sWhType,             DbType.String, ParameterDirection.Input));

        //        RS_CODE = Convert.ToString(helper.RSCODE);
        //        RS_MSG = Convert.ToString(helper.RSMSG);

        //        return rtnDtTemp;
        //    }
        //    catch (Exception ex)
        //    {
        //        RS_CODE = "E";
        //        RS_MSG = ex.Message.ToString();
        //        return new DataTable();
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        //public DataTable USP_PDA_GETSTORAGECODE(string sWhCode, ref string RS_CODE, ref string RS_MSG)
        //{
        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        rtnDtTemp = helper.FillTable("USP_PDA_GETSTORAGECODE", CommandType.StoredProcedure,
        //                                              helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                                            , helper.CreateParameter("AS_WHCODE",    sWhCode,             DbType.String, ParameterDirection.Input));

        //        RS_CODE = Convert.ToString(helper.RSCODE);
        //        RS_MSG = Convert.ToString(helper.RSMSG);

        //        return rtnDtTemp;
        //    }
        //    catch (Exception ex)
        //    {
        //        RS_CODE = "E";
        //        RS_MSG = ex.Message.ToString();
        //        return new DataTable();
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        private void GetStorage()
        {
            try
            {
                sStorage = txtStorageBARCODE.Text;

                if (sStorage == string.Empty) return;

                string sStorageName = string.Empty;

                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETSTORAGECODE2(sStorage, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        sStorageName = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCNAME"]);
                        sStorage = DBHelper.nvlString(_dt.Rows[0]["STORAGELOCCODE"]);
                        txtStorageName.Text = sStorageName;
                        txtStorageCode.Text = sStorage;
                        txtStorageBARCODE.Text = string.Empty;
                        txtStorageBARCODE.Focus();
                    }
                    else
                    {
                        MessageBox.Show(DBHelper.nvlString(RS_MSG), Common.getLangText("저장 위치 조회")); //창고 및 위치 오류
                        txtStorageBARCODE.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show(DBHelper.nvlString(RS_MSG), Common.getLangText("저장 위치 조회")); //창고 및 위치 오류
                    txtStorageBARCODE.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ControlClear();
                MessageBox.Show(DBHelper.nvlString(RS_MSG), Common.getLangText("저장 위치 조회")); //창고 및 위치 오류
            }
        }


        //수입검사 대기등록 대상 바코드 스캔
        private DataTable USP_PDA_GETSTORAGECODE2(string sStorage, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_STORAGELOCCODE2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STORAGELOCCODE", sStorage, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }

        private void ControlClear()
        {
            txtStorageBARCODE.Text = string.Empty;
            txtStorageCode.Text = string.Empty;
            txtStorageName.Text = string.Empty;

            txtStorageBARCODE.Focus();

        }

        #endregion

        #region < EVENT AREA >
        //private void grid1_ItemActivate(object sender, EventArgs e)
        //{
        //    if (grid1.Items.Count == 0) return;
        //    if (grid1.SelectedIndices.Count == 0) return;

        //    string sWhCode = grid1.FocusedItem.SubItems[1].Text;

        //    GetStorageLocCode(sWhCode);
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //if (grid1.SelectedIndices.Count == 0) return;

            //pWhCode = grid1.FocusedItem.SubItems[1].Text;
            //pWhName = grid1.FocusedItem.SubItems[2].Text;

            //if (grid2.SelectedIndices.Count > 0)
            //{
            //    pStorageLocCode = grid2.FocusedItem.SubItems[1].Text;
            //    pStorageLocName = grid2.FocusedItem.SubItems[2].Text;
            //}
            pStorageLocCode = DBHelper.nvlString(txtStorageCode.Text);
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStorageBARCODE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetStorage();
            }
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }
    }
}
