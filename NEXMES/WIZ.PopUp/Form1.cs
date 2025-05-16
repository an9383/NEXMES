using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //string yourkey = textBox1.Text;
            string sDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string yourkey = "kXhRLwed59ex0EC6scLiQfCgd1SDczuj";
            string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate = " + sDate + "&data=AP01";

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
    }
}
