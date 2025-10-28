using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JunX.NET8.WinForms.Controls
{
    /// <summary>
    /// Represents a custom <see cref="Panel"/> control with rounded corners and configurable border styling.
    /// </summary>
    /// <remarks>
    /// The <see cref="RoundedPanel"/> enhances the standard <see cref="Panel"/> by rendering a rounded rectangular region with anti-aliased borders.
    /// It exposes properties for corner radius, border color, and border thickness, allowing for flexible UI theming and visual refinement.
    /// Ideal for modern interfaces, card-style layouts, or grouped sections requiring soft edges and consistent styling.
    /// </remarks>
    public class RoundedPanel : Panel
    {
        private int _topLeft = 20, _topRight = 20, _bottomLeft = 20, _bottomRight = 20, _allCorners = 20;
        private Color _borderColor = Color.Gray;
        private float _borderThickness = 1f;
        private bool _setAllCorners = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundedPanel"/> class with double buffering enabled for smoother rendering.
        /// </summary>
        /// <remarks>
        /// Enables <c>DoubleBuffered</c> to reduce flickering during redraws, especially when rendering custom graphics such as rounded borders.
        /// This constructor prepares the control for high-quality, anti-aliased painting in UI scenarios requiring visual polish.
        /// </remarks>
        public RoundedPanel()
        {
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Gets or sets the radius of the top-left corner of the control.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the top-left corner.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// Useful for customizing asymmetric rounded panels or theme-driven UI components.
        /// </remarks>
        public int TopLeftCorner
        {
            get { return _topLeft; }
            set
            {
                _topLeft = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the radius of the top-right corner of the control.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the top-right corner.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// Useful for customizing asymmetric rounded panels or theme-driven UI components.
        /// </remarks>
        public int TopRightCorner
        {
            get { return _topRight; }
            set
            {
                _topRight = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the radius of the bottom-left corner of the control.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the bottom-left corner.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// Useful for customizing asymmetric rounded panels or theme-driven UI components.
        /// </remarks>
        public int BottomLeftCorner
        {
            get { return _bottomLeft; }
            set
            {
                _bottomLeft = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the radius of the bottom-right corner of the control.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the bottom-right corner.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// Useful for customizing asymmetric rounded panels or theme-driven UI components.
        /// </remarks>
        public int BottomRightCorner
        {
            get { return _bottomRight; }
            set
            {
                _bottomRight = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a uniform radius value to apply to all four corners of the control.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for all corners.
        /// </value>
        /// <remarks>
        /// This property simplifies styling when symmetric rounding is desired. Setting this value does not automatically update individual corner properties unless explicitly synchronized.
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// </remarks>
        public int AllCorners
        {
            get { return _allCorners; }
            set
            {
                _allCorners = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="AllCorners"/> radius should be applied uniformly to all corners.
        /// </summary>
        /// <value>
        /// <see langword="true"/> to apply the <c>AllCorners</c> value to all corners; otherwise, <see langword="false"/>.
        /// </value>
        /// <remarks>
        /// When enabled, the control uses the <c>AllCorners</c> value to override individual corner settings for consistent rounding.
        /// Changing this value triggers a redraw of the control to reflect the updated corner logic.
        /// Useful for toggling between symmetric and asymmetric corner styling in design-time or runtime scenarios.
        /// </remarks>
        public bool SetAllCorners
        {
            get { return _setAllCorners; }
            set
            {
                _setAllCorners = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color used to draw the border of the rounded panel.
        /// </summary>
        /// <value>
        /// A <see cref="Color"/> representing the border color.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated border styling.
        /// Useful for theme customization, visual grouping, or branding-driven UI design.
        /// </remarks>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the thickness of the border drawn around the rounded panel.
        /// </summary>
        /// <value>
        /// A <see langword="float"/> representing the border thickness in pixels.
        /// </value>
        /// <remarks>
        /// Changing this value triggers a redraw of the control to reflect the updated border width.
        /// Useful for emphasizing panel boundaries, applying theme-based styling, or enhancing visual hierarchy in custom UIs.
        /// </remarks>
        public float BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Overrides the default paint behavior to render a custom-shaped control with either uniform or individually rounded corners and styled borders.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> containing the graphics context and clip rectangle.</param>
        /// <remarks>
        /// Validates all corner radius values to ensure a minimum of 1 pixel, preventing rendering artifacts.
        /// If <c>_setAllCorners</c> is <c>true</c>, applies the <c>_allCorners</c> value uniformly to all corners; otherwise, uses individual corner values.
        /// Constructs a <see cref="GraphicsPath"/> to define the rounded shape and sets the control's <see cref="Region"/> for non-rectangular hit testing.
        /// Applies anti-aliasing for smooth rendering and draws the border using the specified <c>_borderColor</c> and <c>_borderThickness</c>.
        /// Supports flexible styling for modern UI components, including symmetric cards and asymmetric panels.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            #region Validate Corner Radii
            if (_topLeft < 1)
                TopLeftCorner = 1;
            if (_topRight < 1)
                TopRightCorner = 1;
            if (_bottomLeft < 1)
                BottomLeftCorner = 1;
            if (_bottomRight < 1)
                BottomRightCorner = 1;
            if (_allCorners < 1)
                AllCorners = 1;
            #endregion

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();

            if (_setAllCorners)
            {
                path.AddArc(0, 0, _allCorners * 2, _allCorners * 2, 180, 90); //Top-Left Corner
                path.AddArc(this.Width - _allCorners * 2, 0, _allCorners * 2, _allCorners * 2, 270, 90); //Top-Right Corner
                path.AddArc(this.Width - _allCorners * 2, this.Height - _allCorners * 2, _allCorners * 2, _allCorners * 2, 0, 90); //Bottom-Right Corner
                path.AddArc(0, this.Height - _allCorners * 2, _allCorners * 2, _allCorners * 2, 90, 90); //Bottom-Left Corner
            }
            else
            {
                path.AddArc(0, 0, _topLeft * 2, _topLeft * 2, 180, 90); //Top-Left Corner
                path.AddArc(this.Width - _topRight * 2, 0, _topRight * 2, _topRight * 2, 270, 90); //Top-Right Corner
                path.AddArc(this.Width - _bottomRight * 2, this.Height - _bottomRight * 2, _bottomRight * 2, _bottomRight * 2, 0, 90); //Bottom-Right Corner
                path.AddArc(0, this.Height - _bottomLeft * 2, _bottomLeft * 2, _bottomLeft * 2, 90, 90); //Bottom-Left Corner
            }

            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(_borderColor, _borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
