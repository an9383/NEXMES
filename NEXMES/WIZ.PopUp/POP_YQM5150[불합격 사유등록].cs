
#region <USING AREA>
using System;
using System.Data;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_YQM5150 : WIZ.Forms.BasePopupForm
    {
        DataTable rtnDtTemp = new DataTable();    // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        public POP_YQM5150()
        {
            InitializeComponent();
        }

        private void POP_YQM5150_Load(object sender, EventArgs e)
        {

        }
        private void Set_Grid1()
        {
            #region --- Grid1 Setting ---
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명,    1. 칼럼명,     2. caption    3. colNotNullable,  4.colDataType,     5.columnWidth,
            // 6. maxLength,  7. HAlign,    8. visible,   9. editable,       10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "ERRORRESION", "불합격 사유", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);    // 공장(사업장)

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            #endregion
        }
    }
}
