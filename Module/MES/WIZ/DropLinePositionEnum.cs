using System;

namespace WIZ
{
    [Flags]
    public enum DropLinePositionEnum
    {
        None = 0x0,
        OnNode = 0x1,
        AboveNode = 0x2,
        BelowNode = 0x4,
        All = 0x7
    }
}
