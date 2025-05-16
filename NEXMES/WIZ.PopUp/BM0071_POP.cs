#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0071
//   Form Name    : 설비 이미지 등록 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 설비 이미지 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0071_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        string _sPlantCode = string.Empty;
        string _sMachCode = string.Empty;
        long _lFileSize = 0;

        int iWRate = 0;
        int iHRate = 0;
        #endregion

        #region < CONSTRUCTOR >

        public BM0071_POP(string sPlantCode, string sMachCode)
        {
            InitializeComponent();

            _sPlantCode = sPlantCode;
            _sMachCode = sMachCode;

            ControlSetting("Y");

            LoadImage(1);

        }
        #endregion

        #region < EVENT AREA >
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "모든 그림파일|*.png;*.img;*.jpg;*.bmp|PNG(*.png)|*.png|IMG(*.img)|*.img|JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
            fDialog.Title = "이미지 선택";
            fDialog.ShowDialog();

            if (fDialog.FileName != string.Empty)
            {
                Bitmap originImg = new Bitmap(fDialog.FileName);
                FileInfo fileInfo = new FileInfo(fDialog.FileName);
                _lFileSize = fileInfo.Length;

                string sRateFlag = CheckRate(originImg.Width, originImg.Height);

                int iBaseWidth = 1920;
                int iBaseHeight = 1080;

                if (sRateFlag == "Y") // 16:9 비율인 경우, 이미지 사이즈 1920 X 1080으로 변경.
                {
                    Bitmap resizeImg = new Bitmap(originImg, iBaseWidth, iBaseHeight);
                    picMachImage.Image = resizeImg;

                    ControlSetting("N");
                }
                else
                {
                    Bitmap resizeImg = ResizeImg(originImg, iBaseWidth, iBaseHeight, iWRate, iHRate);

                    SolidBrush brush = new SolidBrush(Color.White);
                    Rectangle R = new Rectangle(0, 0, iBaseWidth, iBaseHeight);

                    Bitmap bitmap = new Bitmap(iBaseWidth, iBaseHeight);
                    Graphics G = Graphics.FromImage(bitmap);
                    G.FillRectangle(brush, R);
                    G.DrawImage(resizeImg, 0, 0);
                    picMachImage.Image = bitmap;

                    ControlSetting("N");

                    brush.Dispose();
                    G.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picMachImage.Image == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                byte[] bImage = ImageToByte((Image)picMachImage.Image);


                helper.ExecuteNoneQuery("USP_BM0071_POP_I1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", _sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MACHCODE", _sMachCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AL_FILESIZE", _lFileSize, DbType.Int64, ParameterDirection.Input)
                                                           , helper.CreateParameter("AB_MACHIMAGE", bImage, DbType.Binary, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.Binary, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    MessageBox.Show(Common.getLangText("이미지가 저장되었습니다.", "MSG"));
                    LoadImage(1);
                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Common.getLangText("현재 이미지를 삭제하시겠습니까?", "MSG"), Common.getLangText("이미지 삭제", "MSG"), MessageBoxButtons.OKCancel);

            if (result.ToString() != "OK")
                return;

            if (btnSave.Enabled == true)
            {
                LoadImage(1);
                return;
            }
            else
            {
                DBHelper helper = new DBHelper("", true);

                int iCurPage = Convert.ToInt32(lblCurPage.Text);

                try
                {
                    helper.ExecuteNoneQuery("USP_BM0071_POP_D1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("AS_PLANTCODE", _sPlantCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_MACHCODE", _sMachCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AI_MACHSEQ", iCurPage, DbType.Int32, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        MessageBox.Show(Common.getLangText("이미지가 삭제되었습니다.", "MSG"));
                    }
                    else
                    {
                        helper.Rollback();
                        MessageBox.Show(helper.RSMSG);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    helper.Close();
                    UpdateSeq();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            int iCurPage = Convert.ToInt32(lblCurPage.Text);

            if (iCurPage == 1)
                return;

            iCurPage--;

            lblCurPage.Text = Convert.ToString(iCurPage);

            LoadImage(iCurPage);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int iCurPage = Convert.ToInt32(lblCurPage.Text);
            int iTotPage = Convert.ToInt32(lblTotPage.Text);

            if (iCurPage == iTotPage)
                return;

            iCurPage++;

            lblCurPage.Text = Convert.ToString(iCurPage);

            LoadImage(iCurPage);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (picMachImage.Image == picMachImage.InitialImage)
                return;

            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.Title = "이미지 저장";
            fDialog.Filter = "PNG(*.png)|*.png|JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
            fDialog.ShowDialog();

            if (fDialog.FileName != string.Empty)
            {
                Bitmap img = new Bitmap(picMachImage.Image);
                img.Save(fDialog.FileName, ImageFormat.Jpeg);
                MessageBox.Show("이미지를 정상적으로 다운로드했습니다.", "이미지 다운로드");
            }

        }

        #endregion

        #region < METHOD AREA >
        private string CheckRate(int iBaseWidth, int iBaseHeight) // 이미지의 비율이 16:9인지 아닌지 확인
        {
            int iWidth = iBaseWidth;
            int iHeight = iBaseHeight;
            string sRate = string.Empty;

            while (iWidth != 0 && iHeight != 0)
            {
                if (iWidth > iHeight)
                    iWidth %= iHeight;
                else
                    iHeight %= iWidth;
            }

            if (iWidth == 0)
            {
                iWRate = iBaseWidth / iHeight;
                iHRate = iBaseHeight / iHeight;
            }
            else
            {
                iWRate = iBaseWidth / iWidth;
                iHRate = iBaseHeight / iWidth;
            }

            if (iWRate == 16 && iHRate == 9)
                return "Y";
            else
                return "N";
        }

        private Bitmap ResizeImg(Bitmap img, int iWidth, int iHeight, int iWRate, int iHRate) // 이미지가 16:9 비율이 아닐 때, 가로 혹은 세로가 1920 X 1080보다 큰 경우 이미지 RESIZE
        {
            int iResizeNum = 0;
            int iWDiff = img.Width - iWidth;
            int iHDiff = img.Height - iHeight;

            if (img.Width > iWidth) // 원본 이미지와 바탕이 되는 16:9비율 그래픽과 크기 비교. 가로, 세로 중 더 큰 쪽을 기준으로 Resizing
            {
                if (img.Height > iHeight)
                {
                    if (iHDiff > iWDiff)
                        iResizeNum = CalDownRate(img.Height, iHeight, iHRate);
                    else
                        iResizeNum = CalDownRate(img.Width, iWidth, iWRate);
                }
                else
                    iResizeNum = CalDownRate(img.Width, iWidth, iWRate);
            }
            else if (img.Height > iHeight)
                iResizeNum = CalDownRate(img.Height, iHeight, iHRate);

            Bitmap resizeImg = new Bitmap(img, img.Width - (iResizeNum * iWRate), img.Height - (iResizeNum * iHRate));

            return resizeImg;
        }

        private int CalDownRate(int length, int stlength, int iRate)
        {
            int i = 1;

            while (length - (i * iRate) >= stlength)
            {
                i++;
            }

            return i;
        }

        private void LoadImage(int iMachSeq)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0071_POP_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", _sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MACHCODE", _sMachCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AI_MACHSEQ", iMachSeq, DbType.Int32, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    picMachImage.Image = ByteToImage((byte[])rtnDtTemp.Rows[0]["MACHIMG"]);

                    lblTotPage.Text = Convert.ToString(rtnDtTemp.Rows[0]["IMGCNT"]);
                    lblCurPage.Text = Convert.ToString(iMachSeq);
                }
                else
                {
                    picMachImage.Image = picMachImage.InitialImage;
                    lblTotPage.Text = "0";
                    lblCurPage.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ControlSetting("Y");
                helper.Close();
            }
        }

        private void ControlSetting(string sSaveFlag)
        {
            if (sSaveFlag == "Y")
            {
                btnPre.Enabled = true;
                btnNext.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                btnPre.Enabled = false;
                btnNext.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        public byte[] ImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                long lKb = (_lFileSize / 1024);
                long lMb = (lKb / 1024);
                if (lMb > 1) //원본 이미지의 용량이 약 1mb보다 클 경우 이미지 용량 축소.
                {
                    // 이미지 용량 축소
                    ImageCodecInfo imageCodecInfo;
                    imageCodecInfo = GetEncoderInfo("image/jpeg");
                    System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    EncoderParameter encoderParam = new EncoderParameter(encoder, 45L);
                    encoderParams.Param[0] = encoderParam;

                    img.Save(ms, imageCodecInfo, encoderParams);
                    img.Dispose();
                    encoderParams.Dispose();
                    encoderParam.Dispose();

                    return ms.ToArray();
                }
                else
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                ms.Close();
                img.Dispose();
            }
        }

        public Image ByteToImage(byte[] bImage)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                ms.Write(bImage, 0, (int)bImage.Length);
                Image img = Image.FromStream(ms);
                return img;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            {
                ms.Close();
            }
        }

        private void UpdateSeq()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_BM0071_POP_U1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", _sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MACHCODE", _sMachCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_EDITOR", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    LoadImage(1);
                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }
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

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion
    }
}
