using System.Runtime.InteropServices;

namespace WIZ
{
    public abstract class GridBase
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct RowHeaderFlag
        {
            public static string MARK_INSERT;

            public static string MARK_UPDATE;

            public static string MARK_DELETE;

            public static string MARK_NULL;
        }

        public enum InsertRowPosition
        {
            First,
            Forward,
            Next,
            Last
        }
    }
}
