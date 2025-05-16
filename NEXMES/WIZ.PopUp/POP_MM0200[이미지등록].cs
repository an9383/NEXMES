using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace WIZ.PopUp
{
    public partial class POP_MM0200 : WIZ.Forms.BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();

        private string imgPath1 = string.Empty;
        private string imgPath2 = string.Empty;
        private string imgPath3 = string.Empty;
        private string imgPath4 = string.Empty;
        byte[] imgBuffer1 = null;
        byte[] imgBuffer2 = null;
        byte[] imgBuffer3 = null;
        byte[] imgBuffer4 = null;

        private string del_lot = string.Empty;

        #endregion

        public POP_MM0200()
        {
            InitializeComponent();

        }

        public POP_MM0200(DataRow drRow)
        {
            InitializeComponent();

            string PLANTCODE = Convert.ToString(drRow["PLANTCODE"]);
            string INSPLOTNO = Convert.ToString(drRow["INSPMATLOTNO"]);
            string INSPCODE = Convert.ToString(drRow["INSPCODE"]);
            string INSPNAME = Convert.ToString(drRow["INSPNAME"]);

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            this.cboPlantCode_H.Value = PLANTCODE;
            this.txtInspLotNo_H.Text = INSPLOTNO;
            this.txtInspCode.Text = INSPCODE;
            txtInspName.Text = INSPNAME;
        }

        private void POP_MM0200_Load(object sender, EventArgs e)
        {

            search();
        }

        private void search()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                DataTable _TmpDt = helper.FillTable("USP_MM0910Y_S1", CommandType.StoredProcedure
                                                                 , helper.CreateParameter("PLANTCODE", Convert.ToString(this.cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                                                 , helper.CreateParameter("INSPLOTNO", this.txtInspLotNo_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                                 , helper.CreateParameter("INSPCODE", this.txtInspCode.Text.Trim(), DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    if (_TmpDt.Rows.Count > 0)
                    {


                        if (_TmpDt.Rows[0]["INSPIMG1"].ToString() != "")
                        {
                            imgBuffer1 = (byte[])_TmpDt.Rows[0]["INSPIMG1"];
                            MemoryStream ms = new MemoryStream(imgBuffer1);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            imgBuffer1 = null;
                        }


                        if (_TmpDt.Rows[0]["INSPIMG2"].ToString() != "")
                        {
                            imgBuffer2 = (byte[])_TmpDt.Rows[0]["INSPIMG2"];
                            MemoryStream ms2 = new MemoryStream(imgBuffer2);
                            pictureBox2.Image = Image.FromStream(ms2);
                        }
                        else
                        {
                            imgBuffer2 = null;
                        }


                        if (_TmpDt.Rows[0]["INSPIMG3"].ToString() != "")
                        {
                            imgBuffer3 = (byte[])_TmpDt.Rows[0]["INSPIMG3"];
                            MemoryStream ms3 = new MemoryStream(imgBuffer3);
                            pictureBox3.Image = Image.FromStream(ms3);
                        }
                        else
                        {
                            imgBuffer3 = null;
                        }


                        if (_TmpDt.Rows[0]["INSPIMG4"].ToString() != "")
                        {
                            imgBuffer4 = (byte[])_TmpDt.Rows[0]["INSPIMG4"];
                            MemoryStream ms4 = new MemoryStream(imgBuffer4);
                            pictureBox4.Image = Image.FromStream(ms4);
                        }
                        else
                        {
                            imgBuffer4 = null;
                        }

                        this.txtRemark_H.Text = Convert.ToString(_TmpDt.Rows[0]["REMARK"]);

                        del_lot = Convert.ToString(_TmpDt.Rows[0]["INSPMATLOTNO"]);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //저장 버튼 누를시
        private void button5_Click(object sender, EventArgs e)
        {
            INSERT_SAVE();
        }
        private void INSERT_SAVE()
        {
            DBHelper helper = new DBHelper("", true);

            DialogResult result = MessageBox.Show("저장하시겠습니까?", "수입 검사 이미지 저장", MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO")
                return;

            try
            {
                if (imgPath1.Length != 0)
                {
                    imgBuffer1 = File.ReadAllBytes(imgPath1);
                }
                if (imgPath2.Length != 0)
                {
                    imgBuffer2 = File.ReadAllBytes(imgPath2);
                }
                if (imgPath3.Length != 0)
                {
                    imgBuffer3 = File.ReadAllBytes(imgPath3);
                }
                if (imgPath4.Length != 0)
                {
                    imgBuffer4 = File.ReadAllBytes(imgPath4);
                }




                helper.ExecuteNoneQuery("USP_MM0910Y_I1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(this.cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("INSPLOTNO", DBHelper.nvlString(this.txtInspLotNo_H.Text), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("INSPCODE", DBHelper.nvlString(this.txtInspCode.Text), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("REMARK", DBHelper.nvlString(this.txtRemark_H.Text), DbType.String, ParameterDirection.Input)

                                                        , helper.CreateParameter("INSPIMG1", (imgBuffer1 == null) ? SqlBinary.Null : imgBuffer1, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("INSPIMG2", (imgBuffer2 == null) ? SqlBinary.Null : imgBuffer2, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("INSPIMG3", (imgBuffer3 == null) ? SqlBinary.Null : imgBuffer3, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("INSPIMG4", (imgBuffer4 == null) ? SqlBinary.Null : imgBuffer4, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    imgPath1 = string.Empty;
                    imgPath2 = string.Empty;
                    imgPath3 = string.Empty;
                    imgPath4 = string.Empty;
                    helper.Commit();
                    MessageBox.Show("저장완료 되었습니다.");
                }
                else
                {
                    helper.Rollback();
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                helper.Close();
            }
        }

        //삭제시
        private void button1_Click(object sender, EventArgs e)
        {

            string btnname = ((System.Windows.Forms.Button)sender).Name;

            DELETEIMG(btnname);
        }
        private void DELETEIMG(string name)
        {
            string GUBUN = string.Empty;

            if (name == "button1")
            {
                GUBUN = "1";
            }
            if (name == "button2")
            {
                GUBUN = "2";
            }
            if (name == "button3")
            {
                GUBUN = "3";
            }
            if (name == "button4")
            {
                GUBUN = "4";
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (GUBUN == "1")
                {
                    if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("삭제할 이미지가 없습니다.");
                        return;
                    }
                }
                if (GUBUN == "2")
                {
                    if (pictureBox2.Image == null)
                    {
                        MessageBox.Show("삭제할 이미지가 없습니다.");
                        return;
                    }
                }
                if (GUBUN == "3")
                {
                    if (pictureBox3.Image == null)
                    {
                        MessageBox.Show("삭제할 이미지가 없습니다.");
                        return;
                    }
                }
                if (GUBUN == "4")
                {
                    if (pictureBox4.Image == null)
                    {
                        MessageBox.Show("삭제할 이미지가 없습니다.");
                        return;
                    }
                }
                DialogResult result = MessageBox.Show("등록된 이미지를 삭제하시겠습니까?", "수입 검사 이미지 삭제", MessageBoxButtons.YesNo);

                if (result.ToString().ToUpper() == "YES")
                {

                    helper.ExecuteNoneQuery("USP_MM0910Y_D1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", Convert.ToString(this.cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPLOTNO", this.txtInspLotNo_H.Text, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("INSPCODE", this.txtInspCode.Text, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("IMGGUBUN", GUBUN, DbType.String, ParameterDirection.Input));
                    if (helper.RSCODE == "S")
                    {
                        if (GUBUN == "1")
                        {
                            pictureBox1.Image = null;
                        }
                        else if (GUBUN == "2")
                        {
                            pictureBox2.Image = null;
                        }
                        else if (GUBUN == "3")
                        {
                            pictureBox3.Image = null;
                        }
                        else if (GUBUN == "4")
                        {
                            pictureBox4.Image = null;
                        }

                        helper.Commit();

                        MessageBox.Show("삭제 완료되었습니다.");

                        search();

                    }
                    else if (helper.RSCODE == "E")
                    {
                        MessageBox.Show("수입 검사 이미지 삭제 중 오류가 발생하였습니다." + Environment.NewLine + helper.RSMSG);
                        helper.Rollback();
                    }


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


        /// 검사 이미지 추가
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            GETPICTURE(pictureBox1, 1);
        }
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            GETPICTURE(pictureBox2, 2);
        }
        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            GETPICTURE(pictureBox3, 3);
        }
        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            GETPICTURE(pictureBox4, 4);
        }

        public void GETPICTURE(System.Windows.Forms.PictureBox a, int imgPath)
        {
            try
            {
                if (this.txtInspLotNo_H.Text == string.Empty || this.txtInspCode.Text == string.Empty) return;

                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "PNG|*.png|IMG|*.img|JPG|*.jpg";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (imgPath == 1)
                        imgPath1 = openfiledialog.FileName;
                    else if (imgPath == 2)
                        imgPath2 = openfiledialog.FileName;
                    else if (imgPath == 3)
                        imgPath3 = openfiledialog.FileName;
                    else if (imgPath == 4)
                        imgPath4 = openfiledialog.FileName;

                    a.Image = Image.FromFile(openfiledialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
