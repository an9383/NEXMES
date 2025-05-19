using System.Windows.Forms;

namespace WIZ.Forms
{
    public interface IForm
    {
        void SetToolBarButton(string key, bool isBtnEnabled);

        void SetStatusBarMessage(string message);

        void SetTextForID(string message, string sID);

        void SetFormID(string formid);

        void SetLoginID(string loginid);

        void SetLoginName(string loginName);

        void DoToolBarClick(string key);

        void SetLink(Form childForm, bool bLink);

        void SetTextRowCount(string value);

        void ExportExcel(string sFileName = "");

        void ImportExcel();

        void Tree_Refresh();
    }
}
