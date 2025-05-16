namespace WIZ
{
    public enum GridColDataType_emu
    {
        DateTime24,
        DateTime,
        YearMonthDay,
        YearMonth,
        Year,
        VarChar,
        Currency,
        CurrencyNonNegative,
        CurrencyPositive,
        Double,
        DoubleNonNegative,
        DoublePositive,
        Integer,
        IntegerNonNegative,
        IntegerPositive,
        CheckBox,
        Image,
        Button,
        Color,
        Font,
        TimeWithSpin,
        Time24WithSpin,
        URL,
        TrackBar,
        Phone,
        HandPhone,
        IPv4Address,
        ProgressBar,
        FormattedText,
        Explain,
        Float
    }

    public class GridColDataType
    {
        private static string[] GridColDataType_String =
        {
            "DateTime24",
            "DateTime",
            "YearMonthDay",
            "YearMonth",
            "Year",
            "VarChar",
            "Currency",
            "CurrencyNonNegative",
            "CurrencyPositive",
            "Double",
            "DoubleNonNegative",
            "DoublePositive",
            "Integer",
            "IntegerNonNegative",
            "IntegerPositive",
            "CheckBox",
            "Image",
            "Button",
            "Color",
            "Font",
            "TimeWithSpin",
            "Time24WithSpin",
            "URL",
            "TrackBar",
            "Phone",
            "HandPhone",
            "IPv4Address",
            "ProgressBar",
            "FormattedText",
            "Explain",
            "Float"
        };

        public static GridColDataType_emu getGridColDataType(string sText)
        {
            for (int i = 0; i < GridColDataType_String.Length; i++)
            {
                if (sText == GridColDataType_String[i])
                {
                    return (GridColDataType_emu)i;
                }
            }

            return GridColDataType_emu.VarChar;
        }
    }
}
