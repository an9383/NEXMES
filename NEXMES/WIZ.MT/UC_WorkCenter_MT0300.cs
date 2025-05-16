using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.MT
{
    public partial class UC_WorkCenter_MT0300 : UserControl
    {
        public DBHelper helper = new DBHelper(false);
        public DataTable rtnDtTemp = new DataTable();

        private DataRow DrWorkCenter;
        private Hashtable hashX = new Hashtable();
        private Hashtable hashY = new Hashtable();
        private Hashtable hashD = new Hashtable();

        private bool dragging = false;
        private int offsetX, offsetY;

        string tmpWorkCenterCode = string.Empty;

        ColorBlend cb = new ColorBlend();
        Color color01 = ColorTranslator.FromHtml("#125EA0"); // 계획정지  foreColor
        Color color02 = ColorTranslator.FromHtml("#8F4606"); // 장비/설비 foreColor
        Color color03 = ColorTranslator.FromHtml("#3D0F9B"); // 품질정지  foreColor
        Color color04 = ColorTranslator.FromHtml("#978A02"); // 제품/부품 foreColor
        Color color05 = ColorTranslator.FromHtml("#099288"); // 인적요인  foreColor
        Color color06 = ColorTranslator.FromHtml("#578201"); // 가동      foreColor
        Color color07 = ColorTranslator.FromHtml("#ffffff"); // for Gradient
        Color color08 = ColorTranslator.FromHtml("#d2d4d5"); // for Gradient
        Color color09 = ColorTranslator.FromHtml("#d8d8d8"); // BorderColor
        Color color10 = ColorTranslator.FromHtml("#F8FCFF"); // 계획정지  label backGroundColor
        Color color11 = ColorTranslator.FromHtml("#FEFCFA"); // 장비/설비 label backGroundColor
        Color color12 = ColorTranslator.FromHtml("#FAF8FF"); // 품질정지  label backGroundColor
        Color color13 = ColorTranslator.FromHtml("#FFFEF6"); // 제품/부품 label backGroundColor
        Color color14 = ColorTranslator.FromHtml("#FDFFF8"); // 인적요인  label backGroundColor
        Color color15 = ColorTranslator.FromHtml("#FDFFF8"); // 가동      label backGroundColor



        public UC_WorkCenter_MT0300(Hashtable hashXAXIS, Hashtable hashYAXIS, Hashtable hashWCData)
        {
            InitializeComponent();

            hashX = hashXAXIS;
            hashY = hashYAXIS;
            hashD = hashWCData;

            //lblWorkCenterCode.Parent = colorPanel;


        }

        public DataRow WCData
        {
            get { return DrWorkCenter; }
            set
            {
                DrWorkCenter = value;

                lblItemCode.Text = Convert.ToString(DrWorkCenter["ITEMCODE"]);
                lblItemName.Text = Convert.ToString(DrWorkCenter["ITEMNAME"]);
                //lblWorkCenterCode.Text = "[" + Convert.ToString(DrWorkCenter["WORKCENTERCODE"]) + "] " + Convert.ToString(DrWorkCenter["WORKCENTERNAME"]);
                lblWorkCenterCode.Text = Convert.ToString(DrWorkCenter["WORKCENTERNAME"]);
                lblProdQty.Text = Convert.ToString(DrWorkCenter["PRODQTY"]);
                lblLastLineTime.Text = Convert.ToString(DrWorkCenter["LASTLINESTATUS"]);
                lblLastLineTime.Text = Convert.ToString(DrWorkCenter["LASTLINETIME"]);

                tmpWorkCenterCode = Convert.ToString(DrWorkCenter["WORKCENTERCODE"]);

                switch (Convert.ToString(DrWorkCenter["LINESTATUS"]))
                {
                    case "R":
                        this.SetColor(color15, color06, Properties.Resources.icon_01);
                        break;
                    case "S":
                        switch (Convert.ToString(DrWorkCenter["STOPTYPE"]))
                        {
                            case "A": // 계획정지
                                this.SetColor(color10, color01, Properties.Resources.icon_02);
                                break;
                            case "B": // 장비/설비
                                this.SetColor(color11, color02, Properties.Resources.icon_03);
                                break;
                            case "C": // 품질정지
                                this.SetColor(color12, color03, Properties.Resources.icon_04);
                                break;
                            case "D": // 제품/부품
                                this.SetColor(color13, color04, Properties.Resources.icon_05);
                                break;
                            case "E": // 인적요인
                                this.SetColor(color14, color05, Properties.Resources.icon_06);
                                break;
                            default:
                                this.SetColor(Color.White, Color.Black, null);
                                break;
                        }
                        break;
                    default:
                        this.SetColor(Color.White, Color.Black, Properties.Resources.icon_01);
                        break;
                }
            }
        }

        private void SetColor(Color bClr, Color fClr, Bitmap Img)
        {
            lblWorkCenterCode.ForeColor = fClr;

            this.tLblItemCode.BackColor = bClr;
            this.tLblItemName.BackColor = bClr;
            this.tLblLineStatus.BackColor = bClr;
            this.tLblProdQty.BackColor = bClr;
            this.tLblLastLineTime.BackColor = bClr;

            pictureBox1.Image = Img;
        }

        private void lblWorkCenterCode_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragging = true;
            this.offsetX = e.X;
            this.offsetY = e.Y;
        }

        private void lblWorkCenterCode_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragging)
            {
                this.Left = e.X + this.Left - offsetX;
                this.Top = e.Y + this.Top - offsetY;
            }
        }

        private void lblWorkCenterCode_MouseUp(object sender, MouseEventArgs e)
        {
            this.dragging = false;

            helper.FillTable("USP_MT0150_U3", CommandType.StoredProcedure // UserControl 드래그시 변경된 위치값 UPDATE
          , helper.CreateParameter("XAXIS", DbType.Int32, this.Left)
          , helper.CreateParameter("YAXIS", DbType.Int32, this.Top)
          , helper.CreateParameter("WORKCENTERCODE", DbType.String, tmpWorkCenterCode));
        }

        private void UC_WorkCenterC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                ContextMenu menu = new ContextMenu();
                MenuItem item1 = new MenuItem("작업장 정보 등록");
                MenuItem item2 = new MenuItem("삭제");

                item1.Click += new EventHandler(item1_Click);
                item2.Click += new EventHandler(item2_Click);
                menu.MenuItems.Add(item1);
                menu.MenuItems.Add(item2);

                menu.Show(lblWorkCenterCode, new Point(e.X, e.Y));
            }
        }

        private void item1_Click(object sender, EventArgs e) //작업장 정보 등록
        {
            try
            {
                PopUpManager wcpop = new PopUpManager();

                string befWCCode = tmpWorkCenterCode; // 작업장 코드

                rtnDtTemp = wcpop.OpenPopUp("TBM0600Y", new string[] { "", "", "", "", "" }); //작업장 POP-UP


                string popWcCode = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);

                helper.ExecuteNoneQuery("USP_MT0150_U2", CommandType.StoredProcedure  //등록된 작업장의 위치값과 MONITORINGFLAG = 'Y' 로 UPDATE
                , helper.CreateParameter("XAXIS", this.Left, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("YAXIS", this.Top, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("WORKCENTERCODE", popWcCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.ExecuteNoneQuery("USP_MT0150_U1", CommandType.StoredProcedure //화면 상에 존재하는 작업장을 다른 작업장으로 변경하기 위해 삭제
                    , helper.CreateParameter("WORKCENTERCODE", befWCCode, DbType.String, ParameterDirection.Input));

                    rtnDtTemp = helper.FillTable("USP_MT0150_S2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", "", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKCENTERCODE", popWcCode, DbType.String, ParameterDirection.Input));

                    this.WCData = rtnDtTemp.Rows[0];
                    this.Name = "UC" + rtnDtTemp.Rows[0]["WORKCENTERCODE"];
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }

            }
            catch
            {
                return;
            }
        }

        private void colorPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, this.colorPanel.Width, this.colorPanel.Height), color07, color08, LinearGradientMode.Vertical);
            cb.Colors = new Color[] { color07, color08 };
            cb.Positions = new Single[] { 0.0F, 1.0F };
            lgb.InterpolationColors = cb;

            g.FillRectangle(lgb, new Rectangle(0, 0, this.colorPanel.Width, this.colorPanel.Height));
            lgb.Dispose();
            g.Dispose();
        }

        private void item2_Click(object sender, EventArgs e) //삭제 
        {
            try
            {
                this.Dispose();

                string wcTxt = Convert.ToString(DrWorkCenter["WORKCENTERCODE"]);

                helper.ExecuteNoneQuery("USP_MT0150_U1", CommandType.StoredProcedure // XAXIS, YAXIS = 0, MONITORINGFLAG = 'N' 
               , helper.CreateParameter("WORKCENTERCODE", wcTxt, DbType.String, ParameterDirection.Input));

                hashX.Remove("UC" + wcTxt); // Hashtable에서 삭제
                hashY.Remove("UC" + wcTxt);
                hashD.Remove("UC" + wcTxt);
            }
            catch
            {
                return;
            }
        }

        private void border_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, color09, ButtonBorderStyle.Solid);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.Red, 1.0f))
            {
                pen.Alignment = PenAlignment.Center;

                pen.DashStyle = DashStyle.Solid;

                if (e.Row == (tableLayoutPanel1.RowCount - 1))
                {
                    r.Height -= 1;
                }

                if (e.Column == (tableLayoutPanel1.ColumnCount - 1))
                {
                    r.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, r);
            }
        }
    }
}
