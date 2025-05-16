using System;
using System.Data;
using System.Drawing;
using System.IO;



namespace WIZ.PopUp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProductTab_R2 : Telerik.Reporting.Report
    {
        DBHelper helper = new DBHelper(false);

        Image returnImage;
        string AS_PLANTCODE = LoginInfo.PlantCode.ToString();

        public ProductTab_R2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //this.pictureBox1.Value = "=Fields.ITEMIMG1";


            //
            // TODO: Add any constructor code after InitializeComponent call
            //



        }

        public ProductTab_R2(string PoNo, int cnt, string PreInGroupNo)
        {
            InitializeComponent();

            pictureBox1.Value = null;
            pictureBox2.Value = null;
            pictureBox3.Value = null;
            pictureBox4.Value = null;
            pictureBox5.Value = null;
            pictureBox6.Value = null;
            pictureBox7.Value = null;
            pictureBox8.Value = null;

            DataTable rtnDtTemp = helper.FillTable("USP_POP_MM0000Y_S2", CommandType.StoredProcedure
                                                                       , helper.CreateParameter("@AS_PLANTCODE", WIZ.LoginInfo.PlantCode.ToString(), DbType.String, ParameterDirection.Input)
                                                                       , helper.CreateParameter("@AS_PONO", PoNo, DbType.String, ParameterDirection.Input)
                                                                       , helper.CreateParameter("@AS_PREINGROUPNO", PreInGroupNo, DbType.String, ParameterDirection.Input)
                                                                       , helper.CreateParameter("@AS_FLAG", 2, DbType.Int32, ParameterDirection.Input));
            if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMIMG"]) != "")
            {
                byte[] ImageByte = (byte[])rtnDtTemp.Rows[0]["ITEMIMG"];
                MemoryStream ms = new MemoryStream(ImageByte);
                returnImage = Image.FromStream(ms);


                switch (cnt)
                {
                    case 0:
                        pictureBox1.Value = returnImage;
                        break;
                    case 1:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        break;
                    case 2:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        break;
                    case 3:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        break;
                    case 4:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        break;
                    case 5:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        break;
                    case 6:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        pictureBox7.Value = returnImage;
                        break;
                    case 7:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        pictureBox7.Value = returnImage;
                        pictureBox8.Value = returnImage;
                        break;
                }

                ms.Dispose();
            }
        }

        public ProductTab_R2(string PoNo, string lotno, int cnt)
        {
            InitializeComponent();

            pictureBox1.Value = null;
            pictureBox2.Value = null;
            pictureBox3.Value = null;
            pictureBox4.Value = null;
            pictureBox5.Value = null;
            pictureBox6.Value = null;
            pictureBox7.Value = null;
            pictureBox8.Value = null;

            DataTable rtnDtTemp = helper.FillTable("USP_MM0110Y_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode.ToString(), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PONO", PoNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LOTNO", lotno, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FLAG", "1", DbType.String, ParameterDirection.Input));
            if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMIMG"]) != "")
            {
                byte[] ImageByte = (byte[])rtnDtTemp.Rows[0]["ITEMIMG"];
                MemoryStream ms = new MemoryStream(ImageByte);
                returnImage = Image.FromStream(ms);


                switch (cnt)
                {
                    case 0:
                        pictureBox1.Value = returnImage;
                        break;
                    case 1:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        break;
                    case 2:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        break;
                    case 3:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        break;
                    case 4:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        break;
                    case 5:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        break;
                    case 6:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        pictureBox7.Value = returnImage;
                        break;
                    case 7:
                        pictureBox1.Value = returnImage;
                        pictureBox2.Value = returnImage;
                        pictureBox3.Value = returnImage;
                        pictureBox4.Value = returnImage;
                        pictureBox5.Value = returnImage;
                        pictureBox6.Value = returnImage;
                        pictureBox7.Value = returnImage;
                        pictureBox8.Value = returnImage;
                        break;
                }

                ms.Dispose();
            }
        }
    }
}
