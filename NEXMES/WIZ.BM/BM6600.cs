#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6600
//   Form Name    : 품목별 사용 작업표준서 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-02-21
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private int ImageNumber = 0;       // 가져올 작업표준서의 순번
        private int Imageseq = 0;       // 가져온 작업표준서의 순번
        private int ImageCount = 0;       // 금형의 총 작업표준서 수
        byte[] bImage = null;    // 작업표준서

        #endregion

        #region < CONSTRUCTOR >
        public BM6600()
        {
            InitializeComponent();

            //팝업 관리
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(ItemCode_H, ItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });  // 품목 팝업
            btbManager.PopUpAdd(txtManagerId, txtManagerName, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "Y", "", "", "" }); // 관리자 팝업
        }
        #endregion

        #region 폼 초기화

        private void BM6600_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAJORITEMTYPE", "품목대분류", false, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 130, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT", "단위", false, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMSPEC", "규격", false, GridColDataType_emu.VarChar, 100, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATERIALGRADE", "재질", false, GridColDataType_emu.VarChar, 100, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, false, true, true, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 220, 30, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CYCLETIME", "주기", false, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UPH", "UPH", false, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CAVITY", "CAVITY", false, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  // 사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("OPHEADER"); //품목대분류
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MAJORITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ItemType"); //품목구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  // 사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);     // 공장
                string sItemCode = DBHelper.nvlString(this.ItemCode_H.Value);         // 품목코드
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);       // 사용여부

                grid1.DataSource = helper.FillTable("USP_BM6600_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   );
                grid1.DataBinds();
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


        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            if (this.grid1.Rows.Count == 0) return;
            if (MessageBox.Show(Common.getLangText("해당 작업표준서로 상세 내역을 삭제 하시겠습니까 ?", "MSG"), "작업 표준서 상세 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // 작업표준서 삭제
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_BM6600_D1", CommandType.StoredProcedure
                   , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AI_ITEMSEQ", this.Imageseq, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                   );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    // 데이터가 저장 되었습니다.
                    MessageBox.Show(Common.getLangText("작업표준서 상세내역이 삭제 되었습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindImage(this.Imageseq + 1);
                }
                else if (helper.RSCODE == "X")
                {
                    MessageBox.Show(Common.getLangText("해당 품목에 등록되어있는 작업표준서가 존재하지 않습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.Rollback();
                    this.ClosePrgFormNew();
                }
                else
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (this.grid1.Rows.Count == 0) return;
            Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            DBHelper helper = new DBHelper("", true);
            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();

                string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sManagerId = Convert.ToString(this.txtManagerId.Text);
                string sRemark = Convert.ToString(this.txtRemark.Text);
                helper.ExecuteNoneQuery("USP_BM6600_I1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AI_ITEMSEQ", Imageseq, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MANAGERID", sManagerId, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                        );
                // RSCODE 가 S 일경우 helper.RSMSG 로 MoldCode를 리턴함.
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (helper.RSCODE == "X")
                {
                    MessageBox.Show(Common.getLangText("해당 품목에 등록되어있는 작업표준서가 존재하지 않습니다. 작업 표준서 등록 후 저장하세요.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.Rollback();
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            // 작업장 리스트 조회
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);  // 공장
                string sItemCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);   // 품목코드
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);                        // 사용여부

                grid2.DataSource = helper.FillTable("USP_BM6600_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   );
                grid2.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }



            // 작업표준서 호출
            this.ImageNumber = 0;      // 작업 표준서 호출 수 초기화
            ultraGroupBox1.Text = "작업 표준서";
            // 작업표준서 표현 가장 첫 작업표준서 0
            FindImage(0);
        }

        private void btnImageIn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Image image = Image.FromFile(openfiledialog.FileName);
                    string ImgPath = openfiledialog.FileName;
                    string ImgNM = openfiledialog.SafeFileName;

                    FileStream stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);
                    bImage = reader.ReadBytes((int)stream.Length);
                    reader.Close();
                    stream.Close();

                    // 작업표준서 표현
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (MessageBox.Show(Common.getLangText("해당 작업표준서로 등록하시겠습니까 ?", "MSG"), "작업 표준서 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        bImage = null;
                        pictureBox1.Image = null;
                        return;
                    }
                    // 작업표준서 저장
                    DBHelper helper = new DBHelper("", true);
                    try
                    {
                        helper.ExecuteNoneQuery("USP_BM6600_I2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("@AS_ITEMINSPIMAGE", (bImage == null) ? SqlBinary.Null : bImage, DbType.Binary, ParameterDirection.Input)
                           , helper.CreateParameter("@AS_ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_MANAGERID", this.txtManagerId.Text, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_REMARK", this.txtRemark.Text, DbType.String, ParameterDirection.Input)
                           );
                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
                            // 데이터가 저장 되었습니다.
                            MessageBox.Show(Common.getLangText("작업표준서가 등록 되었습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // 선택한 품목 에서 호출한 작업표준서의 가장 마지막 seq 작업표준서를 호출함
                        FindImage(this.ImageCount);
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        this.ShowDialog(ex.ToString());
                    }
                    finally
                    {
                        helper.Close();
                    }

                }
            }
            catch (SException ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        // 작업표준서 호출
        private void FindImage(int ImageSeq)
        {
            DBHelper helper = new DBHelper("", false);
            try
            {
                // 작업표준서 호출
                DataTable DtPlant = helper.FillTable("USP_BM6600_S3", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_NUMBER", ImageSeq, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                     );
                if (DtPlant.Rows.Count > 0 && DtPlant.Rows[0]["ITEMINSPIMG"].ToString() != string.Empty)
                {
                    byte[] bImage = null;
                    bImage = (byte[])DtPlant.Rows[0]["ITEMINSPIMG"];
                    if (bImage != null)
                        pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox1.BringToFront();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Imageseq = Convert.ToInt32(DtPlant.Rows[0]["ITEMSEQ"]);
                    this.ImageCount = Convert.ToInt32(DtPlant.Rows[0]["LICOUNT"]);
                    this.txtManagerId.Text = Convert.ToString(DtPlant.Rows[0]["MANAGERID"]);
                    this.txtManagerName.Text = Convert.ToString(DtPlant.Rows[0]["MANAGERNAME"]);
                    this.txtRemark.Text = Convert.ToString(DtPlant.Rows[0]["REMARK"]);

                }
                else
                {
                    this.Imageseq = 0;
                    this.ImageCount = 0;
                    this.txtManagerId.Text = "";
                    this.txtManagerName.Text = "";
                    this.txtRemark.Text = "";
                    this.pictureBox1.Image = null;
                }
                ultraGroupBox1.Text = "작업 표준서     " + Imageseq + " / " + ImageCount;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        // 다음 작업표준서 표현
        private void btnImageNext_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber - 1;
            FindImage(ImageNumber);
        }

        // 이전 작업표준서 표현
        private void btnImageBefor_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.Imageseq == 0)
            {
                return;
            }
            ImageNumber = ImageNumber + 1;
            FindImage(ImageNumber);
        }
        // 작업표준서 삭제
        private void btnImageDel_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0 || this.Imageseq == 0)
            {
                MessageBox.Show(Common.getLangText("작업표준서를 삭제할 대상이 없습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(Common.getLangText("선택한 작업표준서를 삭제 하시겠습니까?", "MSG"), "작업 표준서 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // 작업표준서 삭제
            DBHelper helper = new DBHelper("", true);
            try
            {
                helper.ExecuteNoneQuery("USP_BM6600_I3", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_NUMBER", Imageseq - 1, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                   );
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    MessageBox.Show(Common.getLangText("선택된 작업표준서가 삭제 되었습니다.", "MSG"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 처음 작업표준서 호출
                    FindImage(0);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        // 작업표준서 사이즈 변경
        private int PicClickCount = 0;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (PicClickCount % 2 == 0)
            {
                this.ultraGroupBox2.Size = new System.Drawing.Size(0, 395);
                this.ultraGroupBox3.Size = new System.Drawing.Size(1124, 0);
            }
            else
            {
                this.ultraGroupBox2.Size = new System.Drawing.Size(582, 395);
                this.ultraGroupBox3.Size = new System.Drawing.Size(1124, 326);
            }

            PicClickCount = PicClickCount + 1;
        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

    }
}




