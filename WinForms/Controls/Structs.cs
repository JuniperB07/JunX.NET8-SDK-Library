using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms.Controls
{
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
