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
        private CornerRadius _cornerRadius = new CornerRadius(20, 20, 20, 20);
        private Color _borderColor = Color.Gray;
        private float _borderThickness = 1f;

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
        /// Gets or sets the per-corner radius configuration for the control.
        /// </summary>
        /// <value>
        /// A <see cref="CornerRadius"/> struct specifying individual radius values for each corner.
        /// </value>
        /// <remarks>
        /// Allows asymmetric rounding by assigning distinct curvature values to top-left, top-right, bottom-left, and bottom-right corners.
        /// Changing this value triggers a redraw of the control to reflect the updated corner styling.
        /// Useful for advanced UI theming, card layouts, or custom visual grouping.
        /// </remarks>
        public CornerRadius Radius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
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
        /// Overrides the default paint behavior to render a panel with individually rounded corners and styled borders.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> containing the graphics context and clip rectangle.</param>
        /// <remarks>
        /// Constructs a <see cref="GraphicsPath"/> using the <see cref="CornerRadius"/> values for each corner, enabling asymmetric rounding.
        /// Sets the control's <c>Region</c> to match the path and draws the border using the specified <c>BorderColor</c> and <c>BorderThickness</c>.
        /// Enables <c><see cref="SmoothingMode.AntiAlias"/></c> for high-quality rendering.
        /// Ideal for modern UI components requiring per-corner styling, card layouts, or theme-driven visual grouping.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, _cornerRadius.TopLeft * 2, _cornerRadius.TopLeft * 2, 180, 90); //Top-Left Corner
            path.AddArc(this.Width - _cornerRadius.TopRight * 2, 0, _cornerRadius.TopRight * 2, _cornerRadius.TopRight * 2, 270, 90); //Top-Right Corner
            path.AddArc(this.Width - _cornerRadius.BottomRight * 2, this.Height - _cornerRadius.BottomRight * 2, _cornerRadius.BottomRight * 2, _cornerRadius.BottomRight * 2, 0, 90); //Bottom-Right Corner
            path.AddArc(0, this.Height - _cornerRadius.BottomLeft * 2, _cornerRadius.BottomLeft * 2, _cornerRadius.BottomLeft * 2, 90, 90); //Bottom-Left Corner
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(_borderColor, _borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

    /// <summary>
    /// Represents individual corner radius values for a rectangular UI element.
    /// </summary>
    /// <remarks>
    /// Allows fine-grained control over the curvature of each corner—top-left, top-right, bottom-left, and bottom-right.
    /// Useful for rendering asymmetric rounded panels, custom borders, or theme-driven UI components with non-uniform corner styling.
    /// </remarks>
    public struct CornerRadius
    {
        /// <summary>
        /// Gets or sets the radius of the top-left corner.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the top-left corner.
        /// </value>
        /// <remarks>
        /// Used to define asymmetric rounding for UI elements that require distinct styling per corner.
        /// </remarks>
        public int TopLeft { get; set; }
        /// <summary>
        /// Gets or sets the radius of the top-right corner.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the top-right corner.
        /// </value>
        /// <remarks>
        /// Used to define asymmetric rounding for UI elements that require distinct styling per corner.
        /// </remarks>
        public int TopRight { get; set; }
        /// <summary>
        /// Gets or sets the radius of the bottom-left corner.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the bottom-left corner.
        /// </value>
        /// <remarks>
        /// Used to define asymmetric rounding for UI elements that require distinct styling per corner.
        /// </remarks>
        public int BottomLeft { get; set; }
        /// <summary>
        /// Gets or sets the radius of the bottom-right corner.
        /// </summary>
        /// <value>
        /// An <see langword="int"/> representing the curvature in pixels for the bottom-right corner.
        /// </value>
        /// <remarks>
        /// Used to define asymmetric rounding for UI elements that require distinct styling per corner.
        /// </remarks>
        public int BottomRight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CornerRadius"/> struct with individual radius values for each corner.
        /// </summary>
        /// <param name="SetTopLeft">The radius for the top-left corner.</param>
        /// <param name="SetTopRight">The radius for the top-right corner.</param>
        /// <param name="SetBottomLeft">The radius for the bottom-left corner.</param>
        /// <param name="SetBottomRight">The radius for the bottom-right corner.</param>
        /// <remarks>
        /// Enables asymmetric corner styling by allowing distinct radius values for each corner.
        /// Useful for rendering custom UI elements with non-uniform curvature.
        /// </remarks>
        public CornerRadius(int SetTopLeft, int SetTopRight, int SetBottomLeft, int SetBottomRight)
        {
            TopLeft = SetTopLeft;
            TopRight = SetTopRight;
            BottomLeft = SetBottomLeft;
            BottomRight = SetBottomRight;
        }
    }
}
