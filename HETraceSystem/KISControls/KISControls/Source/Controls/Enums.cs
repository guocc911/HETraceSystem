using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace KIS.Controls
{
    /// <summary>
    /// Specifies the border style of a control.
    /// </summary>
	public enum BorderStyles
	{
		None,	
		Single,
		Shadow,
        Inset,
        Outset,
        Groove,
        Ridge
	};

    /// <summary>
    /// Specifies the position of caption bar.
    /// </summary>
    public enum CaptionPositions
    {
        Top,
        Bottom,
        Left,
        Right
    };
}