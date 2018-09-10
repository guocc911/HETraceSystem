using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace PileBurner.Contorl
{


    /// <summary>
    /// 客户端采集的状态
    /// </summary>
    public enum ClientStatus
    {
        None = 0,//未连接
        Link = 1,//已连接
        Error = 2,//有异常
    }

    /// <summary>
    ///LED按钮
    /// </summary>
    public partial class LedBulb : Control
    {

        #region Public and Private Members

        private Color _color;


        private ClientStatus _status = ClientStatus.None;


        private string _info;



        /// <summary>
        /// Dark shade of the LED color used for gradient
        /// </summary>
        public Color DarkColor { get; protected set; }

        /// <summary>
        /// Very dark shade of the LED color used for gradient
        /// </summary>
        public Color DarkDarkColor { get; protected set; }


        /// <summary>
        /// </summary>
        public string Info
        {
            get { return _info; }

            set { _info = value; }
        }


        public ClientStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;

                this.DarkColor = ControlPaint.Dark(_color);
                this.DarkDarkColor = ControlPaint.DarkDark(_color);

                switch (this._status)
                {
                    case ClientStatus.Link://成功连接

                        this._color = Color.Green;

                        break;
                    case ClientStatus.Error:

                        this._color = Color.Red;

                        break;
                    case ClientStatus.None:
                    default:
                        this._color = Color.DimGray;

                        break;
                }

                this.Invalidate();	// Redraw the control

            }
        }


        #endregion

        #region Constructor

        public LedBulb()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion

        #region Transpanency Method

        protected override void OnMove(EventArgs e)
        {
            // RecreateHandle();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        #endregion

        #region Drawing Methods

        /// <summary>
        /// Handles the Paint event for this UserControl
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Create an offscreen graphics object for double buffering
            Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                // Draw the control
                drawControl(g);
                // Draw the image to the screen
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
            }
        }

        /// <summary>
        /// Renders the control to an image
        /// </summary>
        /// <param name="g"></param>
        private void drawControl(Graphics g)
        {
            Color lightColor = this._color;
            /* (this.On) ? this.Color : */
            //this.DarkColor;
            Color darkColor = /*(this.On) ? this.DarkColor : */this.DarkDarkColor;

            Rectangle paddedRectangle = new Rectangle(this.Padding.Left, this.Padding.Top, this.Width - (this.Padding.Left + this.Padding.Right), this.Height - (this.Padding.Top + this.Padding.Bottom));
            int width = (paddedRectangle.Width < paddedRectangle.Height) ? paddedRectangle.Width : paddedRectangle.Height;
            Rectangle drawRectangle = new Rectangle(paddedRectangle.X, paddedRectangle.Y, width - 1, width - 1);

            // Draw the background ellipse
            if (drawRectangle.Width < 1) drawRectangle.Width = 1;
            if (drawRectangle.Height < 1) drawRectangle.Height = 1;
            g.FillEllipse(new SolidBrush(darkColor), drawRectangle);

            // Draw the glow gradient
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(drawRectangle);
            PathGradientBrush pathBrush = new PathGradientBrush(path);
            pathBrush.CenterColor = lightColor;
            pathBrush.SurroundColors = new Color[] { Color.FromArgb(0, lightColor) };
            g.FillEllipse(pathBrush, drawRectangle);

            // Set the clip boundary  to the edge of the ellipse
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(drawRectangle);
            g.SetClip(gp);

            // Draw the white reflection gradient
            GraphicsPath path1 = new GraphicsPath();
            Rectangle whiteRect = new Rectangle(drawRectangle.X - Convert.ToInt32(drawRectangle.Width * .15F), drawRectangle.Y - Convert.ToInt32(drawRectangle.Width * .15F), Convert.ToInt32(drawRectangle.Width * .8F), Convert.ToInt32(drawRectangle.Height * .8F));
            path1.AddEllipse(whiteRect);
            PathGradientBrush pathBrush1 = new PathGradientBrush(path);
            pathBrush1.CenterColor = Color.FromArgb(180, 255, 255, 255);
            pathBrush1.SurroundColors = new Color[] { Color.FromArgb(0, 255, 255, 255) };
            g.FillEllipse(pathBrush1, whiteRect);

            // Draw the border
            float w = drawRectangle.Width;
            g.SetClip(this.ClientRectangle);
            //if (this.On)

            g.DrawEllipse(new Pen(Color.FromArgb(95, Color.Black), 1F), drawRectangle);


            // Create font and brush.

            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Font font = new Font("",10,Font);

           // SizeF sizef = g.MeasureString(this._info, this.Font);

           // RectangleF drawRect = new RectangleF(drawRectangle.Right + drawRectangle.Width / 2, drawRectangle.Top + (drawRectangle.Height - sizef.Height), sizef.Width, sizef.Height);

            // Draw string to screen.
          //  g.DrawString(this._info, this.Font, drawBrush, drawRect);


        }

        #endregion
    }
}
