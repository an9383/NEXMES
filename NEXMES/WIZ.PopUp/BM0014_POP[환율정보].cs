#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0014
//   Form Name    : 품목마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WIZ.Forms;
#endregion


namespace WIZ.PopUp
{
    public partial class BM0014_POP : BasePopupForm
    {

        public BM0014_POP()
        {
            InitializeComponent();
        }

        private void BM0014_POP_Load(object sender, EventArgs e)
        {

            //string yourkey = textBox1.Text;
            string sDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string yourkey = "kXhRLwed59ex0EC6scLiQfCgd1SDczuj";
            //string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate = " + sDate + "&data=AP01";
            string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&data=AP01";

            //request를 openapi 서버로 전송해보자!
            WebRequest wr = WebRequest.Create(query);
            wr.Method = "GET";

            WebResponse wrs = wr.GetResponse();
            Stream s = wrs.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            string response = sr.ReadToEnd();

            //richTextBox1.Text = response;
            List<exchange> exchange_data = JsonConvert.DeserializeObject<List<exchange>>(response);


            for (int i = 0; i < exchange_data.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = exchange_data[i].cur_nm;
                if (lvi.Text == "미국 달러")
                {
                    lvi.SubItems.Add(exchange_data[i].cur_unit);
                    lvi.SubItems.Add(exchange_data[i].tts);
                    lvi.SubItems.Add(exchange_data[i].ttb);
                    //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
                    listView1.Items.Add(lvi);
                }
                else if (lvi.Text == "유로")
                {
                    lvi.SubItems.Add(exchange_data[i].cur_unit);
                    lvi.SubItems.Add(exchange_data[i].tts);
                    lvi.SubItems.Add(exchange_data[i].ttb);
                    //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
                    listView1.Items.Add(lvi);
                }
                else if (lvi.Text == "일본 옌")
                {
                    lvi.SubItems.Add(exchange_data[i].cur_unit);
                    lvi.SubItems.Add(exchange_data[i].tts);
                    lvi.SubItems.Add(exchange_data[i].ttb);
                    //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
                    listView1.Items.Add(lvi);
                }
                else if (lvi.Text == "위안화")
                {
                    lvi.SubItems.Add(exchange_data[i].cur_unit);
                    lvi.SubItems.Add(exchange_data[i].tts);
                    lvi.SubItems.Add(exchange_data[i].ttb);
                    //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
                    listView1.Items.Add(lvi);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string yourkey = textBox1.Text;
            string yourkey = "kXhRLwed59ex0EC6scLiQfCgd1SDczuj";
            string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&data=AP01";

            //request를 openapi 서버로 전송해보자!
            WebRequest wr = WebRequest.Create(query);
            wr.Method = "GET";

            WebResponse wrs = wr.GetResponse();
            Stream s = wrs.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            string response = sr.ReadToEnd();

            //richTextBox1.Text = response;
            List<exchange> exchange_data = JsonConvert.DeserializeObject<List<exchange>>(response);

            for (int i = 0; i < exchange_data.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = exchange_data[i].cur_nm;
                lvi.SubItems.Add(exchange_data[i].cur_unit);
                lvi.SubItems.Add(exchange_data[i].tts);
                lvi.SubItems.Add(exchange_data[i].ttb);
                //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
                listView1.Items.Add(lvi);
            }

        }



        //"result":1,
        //"cur_unit":"AED", 통화코드
        //"ttb":"298.55", 전신환(송금)받으실때
        //"tts":"304.58", 전신환(송금)보내실때
        //"deal_bas_r":"301.57",
        //"bkpr":"301",
        //"yy_efee_r":"0",
        //"ten_dd_efee_r":"0",
        //"kftc_bkpr":"301",
        //"kftc_deal_bas_r":"301.57",
        //"cur_nm":"아랍에미리트 디르함"} 국가/통화명
        class exchange
        {
            public string cur_unit { get; set; }
            public string ttb { get; set; }
            public string tts { get; set; }
            public string cur_nm { get; set; }
        }


        //private void Search()
        //{
        //    string RS_CODE    = string.Empty;
        //    string RS_MSG     = string.Empty;
        //    string sPlantCode = string.Empty;
        //    string sItemType  = string.Empty;
        //    string sItemCode  = string.Empty;
        //    string sItemName  = string.Empty;
        //    string sUseFlag   = string.Empty;
        //    string sSpec= string.Empty;

        //    sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
        //    sItemType  = Convert.ToString(cbo_ITEMTYPE_H.Value);
        //    sItemCode  = txt_ITEMCODE_H.Text.Trim();
        //    sItemName  = txt_ITEMNAME_H.Text.Trim();
        //    sUseFlag   = Convert.ToString(cbo_USEFLAG_H.Value);
        //    sSpec = txt_ITEMSPEC_H.Text.Trim();

        //    _DtTemp = _biz.SEL_BM0013(sPlantCode, sItemCode, sItemName, sItemType, sUseFlag, sSpec);

        //    //grid1.DataSource = _DtTemp;
        //    //grid1.DataBind();
        //}



        #region < EVENT AREA >
        //private void btn_SEARCH_H_Click(object sender, EventArgs e)
        //{
        //    Search();
        //}

        //private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        //{
        //    DataTable TmpDt = new DataTable();
        //    TmpDt.Columns.Add("ITEMCODE", typeof(string));
        //    TmpDt.Columns.Add("ITEMNAME", typeof(string));

        //    TmpDt.Rows.Add(new object[] { e.Row.Cells["ITEMCODE"].Value, e.Row.Cells["ITEMNAME"].Value });

        //    this.Tag = TmpDt;
        //    this.Close();
        //}

        //private void txt_ITEMCODE_H_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search();
        //    }
        //}

        //private void txt_ITEMNAME_H_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        Search();
        //    }
        //}

        #endregion

    }
}
