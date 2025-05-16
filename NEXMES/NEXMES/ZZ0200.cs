#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID        : ZZ0200
//   Form Name      : DATABASE 정보 저장
//   Name Space     : NEXMES
//   Created Date   : 2017.01.01
//   Made By        : WIZ
//   Description    : 
//   DB Table       : 
//   StoreProcedure : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using WIZ;
using WIZ.Control;
using WIZ.Forms;
#endregion

namespace NEXMES
{
    public partial class ZZ0200 : Form
    {
        #region [ MEMBER AREA ]
        private string _sSite = string.Empty;
        private string sProdVer = string.Empty;

        private bool bLoad = false;
        private bool bChange = false;

        private Configuration appConfig;

        private RegistryKey regKey;
        #endregion

        #region [ CONSTRUCTOR ]
        public ZZ0200()
        {
            InitializeComponent();

            btnTest.Text = Common.getLangText(btnTest.Text.Trim());
            btnLicense.Text = Common.getLangText(btnLicense.Text.Trim());
            btnSave.Text = Common.getLangText(btnSave.Text.Trim());
            btnClose.Text = Common.getLangText(btnClose.Text.Trim());

            RegistryKey regSet = Registry.LocalMachine.OpenSubKey("Software\\WizLic");

            if (regSet == null)
            {
                regSet = Registry.LocalMachine.CreateSubKey("Software\\WizLic");
                regSet.Close();
            }

            regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02");

            if (regKey == null)
            {
                regKey = Registry.LocalMachine.CreateSubKey("Software\\WizLic").CreateSubKey("02");

                regKey.SetValue("ProdVer", Common.EncryptString("Trial"));
                regKey.SetValue("ProdKey", Common.EncryptString("Wizcore"));
                regKey.SetValue("DateKey", Common.EncryptString(string.Format("{0:yyyy-MM-dd}", DateTime.Now)));
                regKey.Close();
            }

            regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", true);

            sProdVer = Common.DecryptString(Convert.ToString(regKey.GetValue("ProdVer", string.Empty)));
            regKey.Close();
        }

        public ZZ0200(string sSite)
        {
            InitializeComponent();

            _sSite = sSite;

            btnTest.Text = Common.getLangText(btnTest.Text.Trim());
            btnLicense.Text = Common.getLangText(btnLicense.Text.Trim());
            btnSave.Text = Common.getLangText(btnSave.Text.Trim());
            btnClose.Text = Common.getLangText(btnClose.Text.Trim());

            RegistryKey regSet = Registry.LocalMachine.OpenSubKey("Software\\WizLic");

            if (regSet == null)
            {
                regSet = Registry.LocalMachine.CreateSubKey("Software\\WizLic");
                regSet.Close();
            }

            regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02");

            if (regKey == null)
            {
                regKey = Registry.LocalMachine.CreateSubKey("Software\\WizLic").CreateSubKey("02");

                regKey.SetValue("ProdVer", Common.EncryptString("Trial"));
                regKey.SetValue("ProdKey", Common.EncryptString("Wizcore"));
                regKey.SetValue("DateKey", Common.EncryptString(string.Format("{0:yyyy-MM-dd}", DateTime.Now)));
                regKey.Close();
            }

            regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", true);

            sProdVer = Common.DecryptString(Convert.ToString(regKey.GetValue("ProdVer", string.Empty)));
            regKey.Close();
        }
        #endregion

        #region [ ZZ0200_Load ]
        private void ZZ0200_Load(object sender, EventArgs e)
        {
            bLoad = true;

            InitLoad();

            bLoad = false;
        }

        private void InitLoad()
        {

            Dictionary<string, string> dicType = new Dictionary<string, string>();
            dicType.Add("N", "None : 0 Days");
            dicType.Add("T", "Trial : 15 Days");
            dicType.Add("D", "Demo : 180 Days");
            dicType.Add("R", "Release : Unlimited");

            cboType.DisplayMember = "Value";
            cboType.ValueMember = "Key";
            cboType.DataSource = new BindingSource(dicType, null);

            switch (sProdVer)
            {
                case "Trial":
                    cboType.SelectedValue = "T";
                    break;
                case "Demo":
                    cboType.SelectedValue = "D";
                    break;
                case "Release":
                    cboType.SelectedValue = "R";
                    break;
                default:
                    cboType.SelectedValue = "N";
                    break;
            }

            Dictionary<string, string> dicCompany = new Dictionary<string, string>();
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgMPYOu0snDjK8M+jWi67uAz1dqrcYNvWo3iC0m8Vnftft74TlaE8m8w9aBE74iE8TROVwqHU1VdfzCdeeyLhIdPN2xbmxD4r19/xBVDkaYTZ4T2PkVAmQ+VTzx5A66DwkHc9JV/O/7/wh3N/HWiYeGXISxBCA3ogq6uQ02HlGeH8O+JmJxotcsreLwHsrs6H13d3HX2EdcaX9rrBFjUNk+GebyUVKER9IxpZ/x/uYg/A", "대화산업");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW8TkEmZiJhanlMYaEk80w8K5mdWTtE+yaUitcoK4v697M6OxLuaYpfapU+rVZOq5d0zaHf37/SQXvAJw0Uwd4h552IXmIMvXniZPZGqSFXx+gQYkoQIoPtEk95IVD+Yzon6eXb0G4K0A05Ro8tRxFSJZZFcaDpODef0gPWudaYp9Gmv87I/TRhF/SWWDHgzX+Y=", "영보공업");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/DzGv9DVoKY8PODTd9jHXfU4uuI7s6UIAMlDp+Xknx9edNKBd8XGd/nxB0lLa2BLSvHd4ISogktkEoVlyqC1capMfhifEmzeZdX11Z/a4G6yuBE7gLu5knJYJCWnfeel0GpWSROAL9XW9lc3xlHvHhFUvhaAkTUrmdiEKaeVaGCnCAe5rlbxuVreKu6uZgb+8=", "유진하이텍");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgFxt+LMiH8Lts3l4nIsy6iYCLz7cu/1uZWu5I38fMJ07SpNSFkq2pcNffSTEc6FLplI/MeTogRwfC35I17EILtp0oqIM8mjgoBbo3aDOAX/trA5oetOAtcc4cj3dqlJTwCfP4R6fy/HOjH4fQWJOEcNd4tc7k6xvl7BqQMPrD/TGyyXwnnMW74DrHykgA5YCRUxBNMfRlfgp5gBLonbitX0OcNQe0tpISgYT4tizh/bL", "우성");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW+yQPC2qI4Vv5LECTId6xqzMxTgAMItvWtFxbXTvvWYEFkfEUqsCpzoD4pBSWDk8NwWrsvkladNHmRUMWh0Xr0FihqYv0ux9+61z5OYvGhzMr9S3peshCWlo2M7MJAOXogI0Yw1a0aeUCYqqsvCwacPGSimQsz57XPaMbx+yYyIDA==", "일렉트로엠");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgMTcpwfp3CZEVwbO10BwdLpxZ2A4S7qwJWWzLTNCkfTiBw1MStnVZuRxld9tyJ3tfdJB6dd/GXBvTedWYZlH6n+UWV244PZhLF/PHQ+R64coeLXhJEeOM065gB3OYw0W/9Rcp8qH4GuqQXSQ99HNFI426Jq2vUb1mcbsmG7P1BLZg1ZzyHTxYhURWkW8cQDiabZqemierhhfZvxZOEKSryg=", "안성우진캠");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW+mQKfhBP2M2BhBcUpdJ90SG6cGCosyCSVNbjE8wquNR7X2c7mO1YHHLZw4L75Rs1KYL8QZTd+VMLkNoq8ipDqNq6r5Vvj1MIBqthcaLXrdgPaodsaxZG81I8FOft7imO+b4L9aXUm+9OSLOsKRx+MhpeZwDFsAyl7bRPYF9M2g7ezlgpdvJYQDc7aXI10UjI8=", "안성우진캠(1.60)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/LIlDQlrGUPMpOHXKJbNE6fuwMfgSSPZV0KeKt2GtlN7PjHDqJIGwCPcAQunIsAN8MXh7Soapo/yFk3dN8+TFlAWbIuKZ2/Q/gHNkb//yrtmogR4NHkjx+Iqs2dYfarkb0xocyIFQeI3yohs/D36F4E1Sh7JlTMwYTq//UZKcsnXjzAIAvPwveZXbJuaJhWo0=", "비봉우진캠(2.60)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/u0zJyqgJ497M+u4hPkH5o5CYErSHBNKGOCRQ5dAHVFf4VD8NxQNnXhhF6pBYqzoTxvv04i6fwvNrq+gS5lvGN96NRd3DMmI9g8B6d9uK+HchY3ocmZclwppa+C1ADbKA5mJ6f+YW92K6LepWYScBuKtssn1GWSysyVMulO4JNkMUqqV5Sf/u8+KX26B2bmi+H6eKCqJ8U737l7dKr1n5m", "씨와이씨");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgHcuZ9Ei2PW6qoE7KTDrXnnLEchLJmbEpxoiYZjpiNGN9YAAUdIhIoFP8pFURUS/hCnbWnFkZBcNStWKhgzSqfVVkmODRdLm5HMtwmEN9K9WQ/ulXzHC9DqV/Fbd6Otcyr47y7OvYaEEtQLaA9+QAZmqBAqu6O1p6xp7SjO9TKKCHEK6+e2QRdZ4dJmfuhpdmarVA65ffeP1FQagM9iW4F4pJk39RMnIK4pdSxUOmICR", "동양피스톤");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/h2vXbUp92gQgbgFdNyi1ogovuyq5dQ6Iq+DaDaqEWW1ERPQIm+ol4+1yXFi+EnfCkchJR6pri/4w/wJKVnidQTUox5CMmwEeLnwvx3n7ivCHZl9TtTVT7MQlDLpZ/kYwi1eTuS3Wyt5HNVXA89axg1qfz5rRAAqwZngeb5yq2fpEFxOht+ZPRqlHiU1TXsAk=", "다나와컴퓨터");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgEZwjZji7WnqW47W73pis7DJ4RBaTl28XRxE8NQhCewPJSihmkZ1xLdXwbtuEZ4XY/VOKNmav2tEJXREWBGnEwbyQETpUAHK6jttxhGnCa0g58xMUpxGqC7fWCvRLSawaVwrTvAfxly+v6O7f5DfSeQnyBezQ2gAWiMJs7mB8YSbfAC9ptLa7x4s2+IrJNRnokmpeVzeNFXs8pQ4NUhZMUY=", "다나와컴퓨터(도메인)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/FOyvI6+7sxd9juGahgwbO45EPbZketTdBv/LxJZqYToqE1BtSIrgcpcItOVb3xpIOnVWoORN1Lo7oMQEF0PghHlztOZcdRVbTsMlJoNr0etbNSZ5Sg3T1kUEgxGAsGYYLqL3nz7tiboaNXp4cGf19lZ9MzT9lNm4ZirpyTI2Y8i5bKYeJUUnoN4XZl2kbWs8=", "엘림");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgJr0gKkaKpE8W0wdmgcMv/UjkGedpuHmRM7RvgJOP4qXD74mMwodwNUZXg/ipmjcq79dQQPngm6Eqq7FR0vvdBQUfIa9wrWdwz9me43Ngq/pqlE5yjkLXVS0d6z3CVtYjvZcXhr4cukqG64fVAd2B8dq333CT7kaFJakhbxsRuRUsbpy6lq2CuzjNi7+w4REOsSOrJq7nmJ63CQl1KeMlZQ=", "카페리즈");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/Skj58kqZB1uAnaSeQOUSUnZVWvDu7q2oGA2IY3LFooLL3LJYz59ajauMzI8OxLYeaSzghX7rU757RaEItdAK6sIpgdixFk53xo889bgt7JPGzuyvZihGfG0zo/zvuYQur37o4BXhIbHpobG+F/vTvP3GpxRIc+HFN7GplzbbNOZ7lbkTxaHSqusjpPRwF1Qc=", "화승테크");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW88Y1f0g+2QrSKuJKIu9u81pbxyfjke7zF3vZ+j3M3CkbF5+/qH4rQB2thMpqwI7KjTFOyy+QYuzJlVy1KTDKqDK9qSDrY7/1o98FOJ+Pl+2zw0E+yg8PbxPLtQtQ6Jg5pW9xFgMxpjgA8sWLgVlaHG3Xg/UVsCUgvGWX6yzaiLnk04R4E4PXL3X1U56S2qMfo=", "에스에너지");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZqScF/ck6FN6eCUgwSgklARpVu7ZMGKZcwJGli1x24bvpDsCM9PaHjoM09SaPs6aRkAGgnPAyODtUCXXKhrx03eXshCium+7lNaLOvH2OI/8gIuaRcs7q2tAwcl57t9We", "동양피스톤_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZH/K5/HvbLAywQKOpO8kLO+VAfFMIgKfE8c4sFowG6rXAx8P/vK9MsKq7iumVmDWb5KD7ts3HiCDtNtWCqeNlXg3h0VlhHWk9NLFC1jJGRPQ=", "영보_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZR6BuX2fbEUIb1WglNpFDvuGDhTzFm4KSPXP7wB3eoNi7BvH3ruRr9E5uU1SrhVrZKhBqsDWySzEQbXzXdOB22y/nZ7JjwafFxi3jlmqZdkI=", "안성우진캠_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZMy32Jcv83Vl0CMr27UeSNAOhMODLSGM8YsApfcFsYbjh+t9ESoLFV+nEKgZiBpi6CVoBjkAO0xfiTr4dyHagp4F0SFHLQJUC9F5GKUyFs0A=", "대화_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZZW04sKv88A6/A1vh8BvlGaALJwtes5+OwuW6XXYZ0Rb+EX11k/WMxOTBDNqU1IwbihZrToK9sNzpuq9ncVRvpKye0Wz/ZYkZm/HyStKC6tU=", "유진_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Z5XCNf2Gql48pMTPHN/dSekiXw+ZNKxgh5aZqkfa6IaFv0bfZkWPsA51/4yDeccANjIPiC/eDJnanyWKB0I8KlRV/8luDjHz6PDO2yYaV+R0=", "씨와이씨_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZGjYRuZiaQjpq000G0VWNFzTaBdcFm59Fs1n7OMrpPLiftu9gLNgauYpKy01r8h4VA095iegdsBwf3DseZpVAiibfRdp9swvUnii9t0W7fGM=", "일렉트로엠_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Zg+MtjUKN8OHU3M6U4N+77S/wEiL9F9M6XTXOVvo9/RW8r9OcAIz0oZngCh4+qKLMsFs1BbsNfGAuLgiDCQ1iyqRD2u6M6rpVq2g94KaB9pc=", "대선주조_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Zg9P10MaSePgTCFNlH5xEgseqV104HSp8RlIKRmVNFIiCFYW3EG7LCUsNbWusAZdM/TEg3KGQzQT3HQpw0QDi1mFO87lPc/qIxCcwSCnbawM=", "이온폴리스_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZBY5aSxnh5lvfA2oByfSeR2H4Zhe9e8c76+WaU3dcHsStiX9dXJluQ4f3M63xUbD6hZFjLdjvdUCFJu6/jaGWY5xBvOd8/ODlQ8ApJIAWGiU=", "카페니즈_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZXFrVkK7UUF6GXBXqA6MOVKSMjj8Y+mj0p6QvmzSjv1/gowsGeAUWNE0PHj3A2YpSkpw/yjSaLXHTxhMZ8ceHkLjSDD02qM2UQ2uQWNI6JRk=", "엘림_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Z4fIWkbGlxT1XbjRYxIWQWo1RbTF+fXY05XgtLy0B1WcsI+Di1OD4Sytc6NTm8fzl7kjRjDBDBpi5dXzoCquRKHkfp8SoX0dU267blxmeuCE=", "단단_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZL9u+MOxWrlu7eHB4nLnTJrE1/tT4JxwNduSZ2dqO7KZhFN6jOHDcHrb7lTsTz9GUtwlmll0Bau2+cG5hPBhtu72Jljx9KCyNxf0RNV8AIGhLZE/6uRcfhWKS2yblCTGz", "화승테크_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZhuElT2zhMF1vgPTwqtWvgMQ2QK/T2yA/LgC0ytU5TkPWRrLS7PIE981jGbVNiVGU+1WCf+2WSTsxGsd2ivFCZiIKpA0o+Vu1ub4FTEuE6T4=", "다나와컴퓨터_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZE4brSbZd7yyNwpbV2h2wPi1OPMNzsXZAcmAp7FQQC7SZnjjvUhFrlXDCt1ak8vh61+QhOR9dVPpC9XvYjkm+Wq1M523F1s0WLTrnYeKMC68PU4qwZzj90WMoL1p5MAsi", "DEMO_VERSION");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZE4brSbZd7yyNwpbV2h2wPg3CNkbCKnHPr/LAlcZsoxQ5FmwHTgdqfmgDftevxGXjJWBWSh3yAOOKI7W8JVekIIK3U1fZH7cD9tE1gJ5Gg6E=", "TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC5LUghTiCA31a52+eLSw83CCluxXdNE6FgW/sKOtHAkH/UWto0vcpWlY7XRLrVhU57kpHR7mfSoCCvpk9w3C3N3rMoovpFNH6W3rBmGT61NonAVIIfX6ytv/wkhsRbmXxY4fr2Hx15ADBsaQKY7wFAxnmU32lvdBXBv8QyHoqAkFPRcg+sC2UY1cOS8ZUJUXxqr727jfLo/exeoLtdYW64=", "TEST_KAKAO");

            cboCompany.DisplayMember = "Value";
            cboCompany.ValueMember = "Key";
            cboCompany.DataSource = new BindingSource(dicCompany, null);

            string sConStr = CModule.GetAppSetting(CModule.sConnectionString, CModule.sDefualtConnectString);

            txtConn.Text = sConStr.Trim();  //현재 문자열에서 선행 공백과 후행 공백을 모두 제거합니다.
            txtMAC.Text = Convert.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());

            cboCompany.SelectedValue = sConStr;

            if (cboCompany.SelectedValue == null)
            {
                dicCompany.Add(sConStr, CModule.GetAppSetting("DBConnectionName"));
                cboCompany.DataSource = new BindingSource(dicCompany, null);

                txtConn.Text = sConStr.Trim();
                cboCompany.SelectedValue = sConStr;
            }
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnLicense_Click(object sender, EventArgs e)
        {
            if (grbLicense.Visible)
            {
                if (bChange)
                {
                    DialogForm _dForm = new DialogForm(Common.getLangText("저장대상이 있습니다. 화면전환 하시겠습니까?", "MSG"), DialogForm.DialogType.YESNO);

                    _dForm.ShowDialog();

                    if (_dForm.DialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                grbDB.Visible = true;
                grbLicense.Visible = false;
            }
            else
            {
                switch (sProdVer)
                {
                    case "Trial":
                        cboType.SelectedValue = "T";
                        break;
                    case "Demo":
                        cboType.SelectedValue = "D";
                        break;
                    case "Release":
                        cboType.SelectedValue = "R";
                        break;
                    default:
                        cboType.SelectedValue = "N";
                        break;
                }

                grbDB.Visible = false;
                grbLicense.Visible = true;
            }

            bChange = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sConnString = Common.DecryptString(txtConn.Text.Trim());

                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                conn.Close();

                ShowDialog(Common.getLangText("정상 연결 되었습니다.", "MSG"));
            }
            catch
            {
                ShowDialog(Common.getLangText("연결 오류 입니다.", "MSG"));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grbDB.Visible)
                {
                    string sConnString = txtConn.Text.Trim();

                    CModule.SetAppSetting(CModule.sConnectionString, sConnString);
                    CModule.SetAppSetting("DBConnectionName", cboCompany.Text);

                    ShowDialog(Common.getLangText("저장 되었습니다.", "MSG"));
                }
                else if (grbLicense.Visible)
                {
                    if (!bChange)
                    {
                        ShowDialog(Common.getLangText("저장대상이 없습니다.", "MSG"));

                        return;
                    }

                    string sType = Convert.ToString(cboType.SelectedValue);

                    switch (sProdVer)
                    {
                        case "Trial":
                        case "Demo":
                            switch (sType)
                            {
                                case "R":
                                    if (txtKey.Text.Trim() == string.Empty)
                                    {
                                        ShowDialog(Common.getLangText("라이센스키를 입력 하세요.", "MSG"));

                                        return;
                                    }

                                    regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", true);

                                    regKey.SetValue("ProdVer", Common.EncryptString("Release"));
                                    regKey.SetValue("ProdKey", txtKey.Text.Trim());
                                    regKey.Close();

                                    ShowDialog(Common.getLangText("저장 되었습니다.", "MSG"));

                                    Application.Restart();
                                    break;
                                default:
                                    ShowDialog(Common.getLangText("라이센스 종류를 변환 할 수 없습니다.", "MSG"));
                                    break;
                            }
                            break;
                        case "Release":
                            switch (sType)
                            {
                                default:
                                    ShowDialog(Common.getLangText("라이센스 종류를 변환 할 수 없습니다.", "MSG"));
                                    break;
                            }
                            break;
                        default:
                            switch (sType)
                            {
                                case "T":
                                    regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", true);

                                    regKey.SetValue("ProdVer", Common.EncryptString("Trial"));
                                    regKey.SetValue("ProdKey", string.Empty);
                                    regKey.Close();

                                    ShowDialog(Common.getLangText("저장 되었습니다.", "MSG"));

                                    Application.Restart();
                                    break;
                                case "R":
                                    if (txtKey.Text.Trim() == string.Empty)
                                    {
                                        ShowDialog(Common.getLangText("라이센스키를 입력 하세요.", "MSG"));

                                        return;
                                    }

                                    regKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("01", true);

                                    regKey.SetValue("ProdVer", Common.EncryptString("Release"));
                                    regKey.SetValue("ProdKey", txtKey.Text.Trim());
                                    regKey.Close();

                                    ShowDialog(Common.getLangText("저장 되었습니다.", "MSG"));

                                    Application.Restart();
                                    break;
                                default:
                                    ShowDialog(Common.getLangText("라이센스 종류를 변환 할 수 없습니다.", "MSG"));
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog("[" + Common.getLangText("저장 실패", "MSG") + "] " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [ METHOD AREA ]
        private void ShowDialog(string sMessageID, DialogForm.DialogType sType = DialogForm.DialogType.OK)
        {
            DialogForm _Diag = new DialogForm(sMessageID, sType);

            _Diag.ShowDialog();
        }

        #region Ctrl + A, Ctrl + C, Ctrl + V
        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case Keys.A | Keys.Control:
                        if (this.ActiveControl is Infragistics.Win.EmbeddableTextBoxWithUIPermissions)
                        {
                            Infragistics.Win.EmbeddableTextBoxWithUIPermissions txt = (Infragistics.Win.EmbeddableTextBoxWithUIPermissions)this.ActiveControl;
                            txt.SelectionStart = 0;
                            txt.SelectionLength = txt.Text.Length;
                            return true;
                        }
                        break;
                    case Keys.C | Keys.Control:
                        if (this.ActiveControl is Infragistics.Win.EmbeddableTextBoxWithUIPermissions)
                        {
                            Infragistics.Win.EmbeddableTextBoxWithUIPermissions txt = (Infragistics.Win.EmbeddableTextBoxWithUIPermissions)this.ActiveControl;
                            Clipboard.SetText(txt.Text);
                            return true;
                        }
                        break;
                    case Keys.V | Keys.Control:
                        if (this.ActiveControl is Infragistics.Win.EmbeddableTextBoxWithUIPermissions)
                        {
                            Infragistics.Win.EmbeddableTextBoxWithUIPermissions txt = (Infragistics.Win.EmbeddableTextBoxWithUIPermissions)this.ActiveControl;
                            txt.Text = Clipboard.GetText();
                            return true;
                        }
                        break;
                }
                return base.ProcessDialogKey(keyData);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion

        private void cboCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            txtConn.Text = Convert.ToString(cboCompany.SelectedValue);
        }

        private void sLabel1_Click(object sender, EventArgs e)
        {
            DBForm dbform = new DBForm(CModule.ToString(cboCompany.SelectedValue), CModule.ToString(cboCompany.Text));
            if (DialogResult.OK == dbform.ShowDialog())
            {
                InitLoad();
            }
        }
    }
}
