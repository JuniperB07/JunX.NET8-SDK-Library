using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunX.NET8.WinForms
{
    /// <summary>
    /// Provides methods for aiding in validating or checking control properties.
    /// </summary>
    public static class FormHelper
    {
        /// <summary>
        /// Determines whether any control in the specified collection has an empty or whitespace-only <c>Text</c> property.
        /// </summary>
        /// <param name="Controls">
        /// A collection of <see cref="Control"/> objects to evaluate for empty or whitespace-only text values.
        /// </param>
        /// <returns>
        /// <c>true</c> if at least one control has an empty or whitespace-only <c>Text</c> value; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is typically used for validating input fields in WinForms applications. It performs a shallow check
        /// on the <c>Text</c> property of each control in the provided collection. Controls without a <c>Text</c> property
        /// (e.g., <see cref="Panel"/>, <see cref="PictureBox"/>) will return <c>false</c> unless explicitly included with non-empty text.
        /// </remarks>
        public static bool HasEmptyField(IEnumerable<Control> Controls)
        {
            foreach(Control ctrl in Controls)
            {
                if (string.IsNullOrWhiteSpace(ctrl.Text))
                    return true;
            }
            return false;
        }
    }
}
